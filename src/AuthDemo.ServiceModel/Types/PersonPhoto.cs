using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;


namespace AuthDemo.ServiceModel.Types
{
	
	public partial class PersonPhoto
	{
		public PersonPhoto(){}	
		public int Id { get; set;}
		public string PhotoFileName { get; set;}
	}
}
