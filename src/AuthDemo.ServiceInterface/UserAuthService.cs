using System;
﻿using ServiceStack.CacheAccess;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

using AuthDemo.ServiceModel.Types;
using AuthDemo.ServiceModel.Operations;

using AuthDemo.ServiceDbAcces;

namespace AuthDemo.ServiceInterface
{
	[Authenticate]
	public class UserAuthService:AppRestService<UserAuth>
	{
	
		public override object OnGet (UserAuth request)
		{
						
			IAuthSession session = this.GetSession();
			
			if (!session.HasRole(RoleNames.Admin))
			
				return GetById( session.UserAuthId );
			
			else{ 
				
				if(request.Id!=default(int))
					return GetById( request.Id );
				
				if(!request.UserName.IsNullOrEmpty())
					return request.GetByUserName(Factory.DbFactory);
				
				return base.OnGet (request);
			}
			
		}
	}
}

/*
 var httpReq = base.RequestContext.Get<IHttpRequest>();
			httpReq.QueryString["format"];
			*/ 