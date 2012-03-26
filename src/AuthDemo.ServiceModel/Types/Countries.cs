using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("COUNTRY")]
	public partial class Countries{

		public Countries(){}

		[Alias("COUNTRY")]
		[PrimaryKey]
		[Required]
		[StringLength(15)]
		public System.String Name { get; set;} 

		[Alias("CURRENCY")]
		[Required]
		[StringLength(10)]
		public System.String Currency { get; set;} 


		
	}
}