using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("Countries")]
	public partial class Country:IHasId<System.Int32>
	{
		public Country ()
		{
		}
		
		[Alias("CountryId")]
		[AutoIncrement]
		public int Id { get; set;}
		[StringLength(40)]
		public string Name { get; set;}
		[StringLength(30)]
		public string Continent{get; set;}
		
	}
	
}
