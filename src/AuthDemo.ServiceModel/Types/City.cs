using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("CITY")]
	public partial class City:IHasId<System.Int32>{

		public City(){}
		
		[Alias("CityId")]
		[AutoIncrement]
		public int Id { get; set;}
		public int CountryId { get; set;}
		[StringLength(40)]
		public string Name { get; set;}
		[Alias("People")]
		public int Population{ get;set;}
		
	}
}
