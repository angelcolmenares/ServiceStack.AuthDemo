using System;
using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;

namespace AuthDemo.ServiceModel.Types
{
	[RestService("/Country/create","post")]
	[RestService("/Country/read","get")]
	[RestService("/Country/read/{Id}","get")]
	[RestService("/Country/update/{Id}","put")]
	[RestService("/Country/destroy/{Id}","delete")]
	public partial class Country
	{
		
	}
}

