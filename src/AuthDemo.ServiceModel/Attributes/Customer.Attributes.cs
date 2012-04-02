using System;
using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;

namespace AuthDemo.ServiceModel.Types
{
	
	[RestService("/Customer/create","post")]
	[RestService("/Customer/read","get")]
	[RestService("/Customer/read/{Id}","get")]
	[RestService("/Customer/update/{Id}","put")]
	[RestService("/Customer/destroy/{Id}","delete")]
	public partial class Customer
	{
	}
}

