using System;
using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace AuthDemo.ServiceModel.Types
{
	
	[RestService("/Author/create","post")]
	[RestService("/Author/read","get")]
	[RestService("/Author/read/{Id}","get")]
	[RestService("/Author/update/{Id}","put")]
	[RestService("/Author/destroy/{Id}","delete")]
	public partial class Author{}
	
			
	
}