using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("PERSON")]
	public partial class Person:IHasId<System.Int32>{

		public Person(){}
		[Alias("PersonId")]
		[AutoIncrement]
		public int Id { get; set;}
		[Alias("PersonName")]
		[StringLength(60)]
		public string Name { get; set;}
		public int BirthCityId { get; set;}
		public int? JobCityId { get; set;}
		[StringLength(32)]
		public string PhotoFileName {get;set;}
	}
}
