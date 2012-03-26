using System;
using System.Net;
﻿using ServiceStack.CacheAccess;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.OrmLite;

using AuthDemo.ServiceDbAcces;
using AuthDemo.ServiceModel.Operations;

namespace AuthDemo.ServiceInterface
{
	public class AppRestService<T>:RestServiceBase<T> where T:new()
	{
		//public Session Session{get; protected set; }
		
		//public ICacheClient CacheClient { get; set; }
		
				
		public Factory Factory{ get; set;}
		
		public override object OnGet (T request)
		{		
			try{
				return  new Response<T>(){
					Data=Factory.Get<T>(request)
				};
			}
			catch(Exception e ){
				return HttpResponse.ErrorResult<Response<T>>(e, "GetError");
			}
		}
		
		public override object OnPost (T request)
		{
			try{		
				return new Response<T>(){
					Data=Factory.Post<T>(request)
				};			
			}
			catch(Exception e ){
				return HttpResponse.ErrorResult<Response<T>>(e, "PostError");
			}
		}
		
		public override object OnPut (T request)
		{
			
			try{
				return new Response<T>(){
					Data=Factory.Put<T>(request)
				};
			}
			catch(Exception e ){
				return HttpResponse.ErrorResult<Response<T>>(e, "PutError");
			}
		}
		
		public override object OnDelete (T request)
		{
		
			try{
				return  new Response<T>(){
					Data=Factory.Delete<T>(request)
				};
			}
			catch(Exception e ){
				return HttpResponse.ErrorResult<Response<T>>(e, "DeleteError");
			}
		}
		
		
		public object GetById(object id) 
		{
			try{
				return new Response<T>(){
					Data=Factory.GetById<T>(id) 	
				};
			}
			catch(Exception e ){
				return HttpResponse.ErrorResult<Response<T>>(e, "GetByIdError");
			}
		}
		
		
		
	}
}

