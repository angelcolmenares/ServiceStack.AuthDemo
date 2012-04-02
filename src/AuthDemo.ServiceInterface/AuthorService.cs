using System;
﻿using ServiceStack.CacheAccess;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

using AuthDemo.ServiceModel.Types;
using AuthDemo.ServiceModel.Operations;

namespace AuthDemo.ServiceInterface
{
	[Authenticate]
	[RequiredPermission("Author.read")]
	[RequiredPermission(ApplyTo.Post, "Author.create")]	
	[RequiredPermission(ApplyTo.Put , "Author.update")]	
	[RequiredPermission(ApplyTo.Delete, "Author.destroy")]
	public class AuthorService:AppRestService<Author>
	{
		
	}
}

