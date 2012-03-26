using System;
using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace AuthDemo.ServiceModel.Types
{
	[RestService("/City/create","post")]
	[RestService("/City/read","get")]
	[RestService("/City/read/{Id}","get")]
	[RestService("/City/update/{Id}","put")]
	[RestService("/City/destroy/{Id}","delete")]
	public partial class City
	{
	}
}

