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
	[RequiredPermission("Country.read")]
	[RequiredPermission(ApplyTo.Post, "Country.create")]	
	[RequiredPermission(ApplyTo.Put , "Country.update")]	
	[RequiredPermission(ApplyTo.Delete, "Country.destroy")]
	public class CountryService:AppRestService<Country>
	{
		
	}
}

