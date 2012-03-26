using System;
using ServiceStack.CacheAccess;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

using AuthDemo.ServiceModel.Types;
using AuthDemo.ServiceModel.Operations;

namespace AuthDemo.ServiceInterface
{
	[Authenticate]
	[RequiredPermission("Company.read")]
	[RequiredPermission(ApplyTo.Post, "Company.create")]	
	[RequiredPermission(ApplyTo.Put , "Company.update")]	
	[RequiredPermission(ApplyTo.Delete, "Company.destroy")]
	public class CompanyService:AppRestService<Company>
	{
		
	}
}

