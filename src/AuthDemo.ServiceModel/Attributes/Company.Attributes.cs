using System;
using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;


namespace AuthDemo.ServiceModel.Types
{
	[RestService("/Company/create","post")]
	[RestService("/Company/read","get")]
	[RestService("/Company/read/{Id}","get")]
	[RestService("/Company/update/{Id}","put")]
	[RestService("/Company/destroy/{Id}","delete")]
	public partial class Company
	{
	}
}

