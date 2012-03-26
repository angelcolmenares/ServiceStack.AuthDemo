using System;
using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;

namespace AuthDemo.ServiceModel.Types
{
	[RestService("/Person/create","post")]
	[RestService("/Person/read","get")]
	[RestService("/Person/read/{Id}","get")]
	[RestService("/Person/update/{Id}","put")]
	[RestService("/Person/destroy/{Id}","delete")]
	public partial class Person
	{
	}
}
