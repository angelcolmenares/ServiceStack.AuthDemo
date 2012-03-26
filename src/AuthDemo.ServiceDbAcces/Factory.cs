using System;
using System.Reflection;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using ServiceStack.Common.Utils;
using ServiceStack.DesignPatterns.Model;

using AuthDemo.ServiceModel.Operations;

namespace AuthDemo.ServiceDbAcces
{
	public class Factory
	{
		public IDbConnectionFactory DbFactory {get;set;}
		
		public Factory ()
		{
		}
		
		public  List<T> Get<T> (T request) where T:new()
		{
			Type type = typeof(T);
			string id =string.Empty;
			PropertyInfo pi= ReflectionUtils.GetPropertyInfo(type, OrmLiteConfig.IdField);
			if( pi!=null ){
				id= pi.GetValue(request, new object[]{}).ToString();
			}
											
			return (string.IsNullOrEmpty(id) || id=="0")? 
				DbFactory.Exec(	dbCmd => dbCmd.Select<T>()):
				GetById<T>(id);
		}
		
		
		public  List<T> GetById<T> ( object id) where T:new()
		{
			List<T> l = new List<T>();
			
			try{
				T r = DbFactory.Exec(
					dbCmd => 
					dbCmd.GetById<T>(id)
					);
						
				l.Add(r);
			}
			catch(System.ArgumentNullException) {
			}
			
			return l;
		}
		
		public  List<T> Post<T> (T request) where T:new(){

			DbFactory.Exec(	(dbCmd) =>
			{ 
				dbCmd.Insert<T>(request);
				Type type = typeof(T);

				PropertyInfo pi= ReflectionUtils.GetPropertyInfo(type, OrmLiteConfig.IdField);
			
				if( pi!=null && pi.GetValue(request, new object[]{}).ToString() =="0"){
					var li = dbCmd.GetLastInsertId();
					if(pi.PropertyType == typeof(short))
						ReflectionUtils.SetProperty(request, pi, Convert.ToInt16(li));	
					else if(pi.PropertyType == typeof(int))
						ReflectionUtils.SetProperty(request, pi, Convert.ToInt32(li));	
					else
					ReflectionUtils.SetProperty(request, pi, Convert.ToInt64(li));
				}
			});
			
			List<T> l = new List<T>();
			
			
						
			l.Add(request);
			
			return l;
		}
		
		
		public  List<T> Put<T> (T request) where T:new(){

			DbFactory.Exec(
					dbCmd => 
					dbCmd.Update<T>(request)
			);
			List<T> l = new List<T>();
			l.Add(request);
			return l;
		}
		
		public  List<T> Delete<T> (T request) where T:new(){

			DbFactory.Exec(
					dbCmd => 
					dbCmd.Delete<T>(request)
			);
			return new List<T>();

		}
		
	}
}

