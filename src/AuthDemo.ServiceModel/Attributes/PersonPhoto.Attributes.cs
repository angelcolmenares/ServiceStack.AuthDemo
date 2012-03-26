using System;
using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;

namespace AuthDemo.ServiceModel.Types
{
	[RestService("/PersonPhoto/create","post")]
	[RestService("/PersonPhoto/update/{Id}","put")]
	public partial class PersonPhoto
	{
	}
}



