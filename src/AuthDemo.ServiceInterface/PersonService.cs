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
	[RequiredPermission("Person.read")]
	[RequiredPermission(ApplyTo.Post, "Person.create")]	
	[RequiredPermission(ApplyTo.Put , "Person.update")]	
	[RequiredPermission(ApplyTo.Delete, "Person.destroy")]
	public class PersonService:AppRestService<Person>
	{
		public override object OnGet (Person request)
		{
			if(request.JobCityId.HasValue && request.JobCityId.Value!=default(int)){
				
				try{
					return  new Response<Person>(){
						Data=request.GetByJobCityId(Factory.DbFactory)
					};
				}
				catch(Exception e ){
					return HttpResponse.ErrorResult<Response<Person>>(e, "GetByJobCityError");
				}				
			}
			return base.OnGet (request);
		}
	}
}

