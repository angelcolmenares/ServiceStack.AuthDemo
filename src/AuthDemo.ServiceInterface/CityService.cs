using System;
using ServiceStack.CacheAccess;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

using AuthDemo.ServiceModel.Types;
using AuthDemo.ServiceModel.Operations;
using AuthDemo.ServiceDbAcces;

namespace AuthDemo.ServiceInterface
{
	[Authenticate]
	[RequiredPermission("City.read")]
	[RequiredPermission(ApplyTo.Post, "City.create")]	
	[RequiredPermission(ApplyTo.Put , "City.update")]	
	[RequiredPermission(ApplyTo.Delete, "City.destroy")]
	public class CityService:AppRestService<City>
	{
		public override object OnGet (City request)
		{
			if(request.CountryId!=default(int)){
				
				try{
					return  new Response<City>(){
						Data=request.GetByCountryId(Factory.DbFactory)
					};
				}
				catch(Exception e ){
					return HttpResponse.ErrorResult<Response<City>>(e, "GetByCountryError");
				}
								
			}
			
			return base.OnGet (request);
		}
	}
}

