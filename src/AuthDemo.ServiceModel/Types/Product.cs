using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("PRODUCT")]
	public partial class Product:IHasId<System.Int32>{

		public Product(){}

		[Alias("ID")]
		[PrimaryKey]
		public System.Int32 Id { get; set;} 

		[Alias("NAME")]
		[StringLength(8000)]
		public System.String Name { get; set;} 

		[Alias("UNITPRICE")]
		[DecimalLength(18,0)]
		public System.Decimal Unitprice { get; set;} 


		
	}
}
