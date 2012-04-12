using System;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Funq;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common.Web;
using ServiceStack.Common.Utils;
using ServiceStack.Configuration;
using ServiceStack.DataAccess;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface;
using ServiceStack.FluentValidation;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;

using AuthDemo.ServiceInterface;
using AuthDemo.ServiceDbAcces;
using AuthDemo.ServiceModel.Types;

namespace AuthDemo.Host.Web
{
	public class AppHost:AppHostBase
	{
		private static ILog log;
		
		public AppHost (): base("AuthDemo ServiceStack", typeof(AuthorService).Assembly)
		{
			LogManager.LogFactory = new ConsoleLogFactory();
			log = LogManager.GetLogger(typeof (AppHost));
		}
		
		public override void Configure(Container container)
		{
			//Permit modern browsers (e.g. Firefox) to allow sending of any REST HTTP Method
			base.SetConfig(new EndpointHostConfig
			{
				GlobalResponseHeaders =
					{
						{ "Access-Control-Allow-Origin", "*" },
						{ "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
					},
				  DefaultContentType = ContentType.Json 
			});
			
			
			var config = new AppConfig(new ConfigurationResourceManager());
			container.Register(config);

			if (!Directory.Exists(config.PhotoDirectory))
			{
				Directory.CreateDirectory(config.PhotoDirectory);
			}
							
			
			OrmLiteConfig.DialectProvider= GetDialectProvider(config);
			
			IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(
				ConfigUtils.GetConnectionString("ApplicationDb"));
			
			container.Register<Factory>(
				new Factory(){
					DbFactory=dbFactory
				}
			);
			
			CreateAppTables(dbFactory);
			
			ConfigureAuth(container);
			
			ConfigureServiceRoutes();
			
			log.InfoFormat("AppHost Configured: " + DateTime.Now);
		}
		
		
		private void ConfigureServiceRoutes()
		{
			Routes
				.Add<UserAuth>("/UserAuth",ApplyTo.Get)
				.Add<UserAuth>("/UserAuth/Id/{Id}",ApplyTo.Get)
				.Add<UserAuth>("/UserAuth/UserName/{UserName*}",ApplyTo.Get)
				.Add<UserAuth>("/UserAuth",ApplyTo.Post)
				.Add<UserAuth>("/UserAuth/Id/{Id}",ApplyTo.Put)
				.Add<UserAuth>("/UserAuth/Id/{Id}",ApplyTo.Delete);
		}
		
		private void ConfigureAuth(Container container){
			
			container.Register<ICacheClient>(new MemoryCacheClient());
			
			Plugins.Add(new AuthFeature(
				 () => new AuthUserSession(), // or Use your own typed Custom AuthUserSession type
				new IAuthProvider[]
        	{
				new CredentialsAuthProvider()
        	}));
		    
			var appSettings = new ConfigurationResourceManager();
				
			var dbFactory = new OrmLiteConnectionFactory(ConfigUtils.GetConnectionString("UserAuth")) ;
			
			OrmLiteAuthRepository authRepo = new OrmLiteAuthRepository(
				dbFactory
			);
			
			container.Register<IUserAuthRepository>(
				c => authRepo
			); //Use OrmLite DB Connection to persist the UserAuth and AuthProvider info

			
			if (appSettings.Get("RecreateAuthTables", false))
				authRepo.DropAndReCreateTables(); //Drop and re-create all Auth and registration tables
			else{
				authRepo.CreateMissingTables();   //Create only the missing tables				
			}
						
			Plugins.Add( new  RegistrationFeature());
			
		    //Add admin user  
			string userName = "admin";
			string password = "admin";
		
			List<string> userPermissions= new List<string>(
			new string[]{	
			"Customer.create", "Company.create", "Country.create", "City.create", "Author.create", "Person.create",	
			"Customer.read",   "Company.read",   "Country.read",   "City.read",   "Author.read",   "Person.read",
			"Customer.update", "Company.update", "Country.update", "City.update", "Author.update", "Person.update"
			});
			
			List<string> adminPermissions= new List<string>(userPermissions);
			adminPermissions.AddRange(new string[]{	
			"Customer.destroy","Company.destroy","Country.destroy","City.destroy","Author.destroy","Person.destroy"
			});
			
			if ( authRepo.GetUserAuthByUserName(userName)== default(UserAuth) ){
				List<string> roles= new List<string>();
				roles.Add(RoleNames.Admin);
			    string hash;
			    string salt;
			    new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
			    authRepo.CreateUserAuth(new UserAuth {
				    DisplayName = userName,
			        Email = userName+"@mail.com",
			        UserName = userName,
			        FirstName = "",
			        LastName = "",
			        PasswordHash = hash,
			        Salt = salt,
					Roles =roles,
					Permissions=adminPermissions
			    }, password);
			}
			// user
			userName="user1";
			password="user1";
			if ( authRepo.GetUserAuthByUserName(userName)== default(UserAuth) ){
				string hash;
			    string salt;
			    new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
			    authRepo.CreateUserAuth(new UserAuth {
				    DisplayName = userName,
			        Email = userName+"@mail.com",
			        UserName = userName,
			        FirstName = "",
			        LastName = "",
			        PasswordHash = hash,
			        Salt = salt,
					Permissions=userPermissions
				}, password);
			}
			
		}
	
		
		private void CreateAppTables(IDbConnectionFactory dbFactory){
			List<Type> tables = new List<Type>( new Type[]{
				typeof(Author),
				typeof(Country),
				typeof(City),
				typeof(Company),
				typeof(Customer),
				typeof(Person)
			});
			
			foreach(Type t in tables){
				dbFactory.Exec( dbCmd=> dbCmd.CreateTable(false, t) );
			}
		}
		
		private  IOrmLiteDialectProvider GetDialectProvider(AppConfig config)
		{
			var ds = ConfigUtils.GetDictionaryFromAppSetting("DialectProvider");						
				
			var assembly = Assembly.LoadFrom(Path.Combine(config.LibDirectory, ds["AssemblyName"]));
			var type = assembly.GetType(ds["ClassName"]);
			if (type == null)
				throw new Exception(
					string.Format("Can not load type '{0}' from assembly '{1}'",
						ds["ClassName"], Path.Combine(config.LibDirectory , ds["AssemblyName"])));
			
			var fi = type.GetField(ds["InstanceFieldName"]);
			if (fi == null)
				throw new Exception(
					string.Format("Can not get Field '{0}' from class '{1}'",
						ds["InstanceFieldName"], ds["ClassName"]));

			var o = fi.GetValue(null);
			var dialect = o as IOrmLiteDialectProvider;

			if (dialect == null)
				throw new Exception(
					string.Format("Can not cast  from '{0}' to '{1}'",
						o, typeof(IOrmLiteDialectProvider))
				);

			return dialect;
		
		}
		
	}
}
// http://127.0.0.1:8080/api/json/syncreply/Auth?Username=user&Password=user
//http://127.0.0.1:8080/api/auth?UserName=user&Password=user&format=json
//http://127.0.0.1:8080/api/auth/credentials?UserName=user&Password=user&format=json
//http://127.0.0.1:8080/api/auth?provider=credentials&UserName=user&Password=user&format=json

// byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(data);
// csharp> string r = Convert.ToBase64String(encbuff)