using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using ServiceStack.Common.Utils;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceInterface.Auth;

using AuthDemo.ServiceModel.Operations;
using AuthDemo.ServiceModel.Types;


namespace AuthDemo.ServiceDbAcces
{
	public static class ModelExtensions
	{
		public static List<UserAuth> GetByUserName(this UserAuth request, 
		                                           IDbConnectionFactory DbFactory){
			var un= request.UserName;
			
			return DbFactory.Exec(dbCmd=> dbCmd.Select<UserAuth>
			                      (q=> q.UserName.Contains(un))).
			                      OrderBy( q=> q.UserName).ToList();
			
		}
		
		public static List<City> GetByCountryId(this City request, 
		                                           IDbConnectionFactory DbFactory){
			
			
			return DbFactory.Exec(dbCmd=> dbCmd.Select<City>
			                      (q=> q.CountryId ==request.CountryId )).
			                      OrderBy( q=> q.Name).ToList();
			
		}
		
		public static List<Person> GetByJobCityId(this Person request, 
		                                           IDbConnectionFactory DbFactory){
			
			
			return DbFactory.Exec(dbCmd=> dbCmd.Select<Person>
			                      (q=> q.JobCityId ==request.JobCityId)).
			                      OrderBy( q=> q.Name).ToList();
			
		}
		
		
		public static string GetNextPhotoFileName(this Person request, string fileName){
			
			if(string.IsNullOrEmpty( request.PhotoFileName))
				return BuildNextPhotoFileName(request.Id, 0, fileName);
			
			var name= Path.GetFileNameWithoutExtension(request.PhotoFileName);
			var sep= name.LastIndexOf("-")+1;
			
			if (sep<8)
				return BuildNextPhotoFileName(request.Id, 0,  fileName);
			int num;
			if( int.TryParse( name.Substring(sep), out num) ){
				return BuildNextPhotoFileName(request.Id, num, fileName);
			}
			else{
				return BuildNextPhotoFileName(request.Id, 0, fileName);
			}
		}
		
		public static void UpdatePhotoFileName(this Person request,IDbConnectionFactory DbFactory){
			SqlExpressionVisitor<Person> ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<Person>();
			ev.Where(q=>q.Id==request.Id).Update(f=> f.PhotoFileName);
			DbFactory.Exec(dbCmd=> dbCmd.Update<Person>(request, ev));
			                                
		}
		
		private static string BuildNextPhotoFileName(int id, int current, string  fileName){
			return id.ToString()+"-photo-"+ (current+1).ToString()+ Path.GetExtension(fileName);
		}
		
		
		
		
		
	}
}

