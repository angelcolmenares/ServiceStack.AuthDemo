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
	[RequiredPermission("Customer.read")]
	[RequiredPermission(ApplyTo.Post, "Customer.create")]	
	[RequiredPermission(ApplyTo.Put , "Customer.update")]	
	[RequiredPermission(ApplyTo.Delete, "Customer.destroy")]
	public class CustomerService:AppRestService<Customer>
	{
	}
}

