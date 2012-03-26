using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("SALES")]
	public partial class Sales{

		public Sales(){}

		[Alias("PO_NUMBER")]
		[PrimaryKey]
		[Required]
		[StringLength(8)]
		public System.String PoNumber { get; set;} 

		[Alias("CUST_NO")]
		public System.Int32 CustNo { get; set;} 

		[Alias("SALES_REP")]
		public System.Int16? SalesRep { get; set;} 

		[Alias("ORDER_STATUS")]
		[Required]
		[StringLength(7)]
		public System.String OrderStatus { get; set;} 

		[Alias("ORDER_DATE")]
		public System.DateTime OrderDate { get; set;} 

		[Alias("SHIP_DATE")]
		public System.DateTime? ShipDate { get; set;} 

		[Alias("DATE_NEEDED")]
		public System.DateTime? DateNeeded { get; set;} 

		[Alias("PAID")]
		[StringLength(1)]
		public System.String Paid { get; set;} 

		[Alias("QTY_ORDERED")]
		public System.Int32 QtyOrdered { get; set;} 

		[Alias("TOTAL_VALUE")]
		[DecimalLength(9,2)]
		public System.Decimal TotalValue { get; set;} 

		[Alias("DISCOUNT")]
		public System.Single Discount { get; set;} 

		[Alias("ITEM_TYPE")]
		[StringLength(12)]
		public System.String ItemType { get; set;} 

		[Alias("AGED")]
		[DecimalLength(0,9)]
		[Compute]
		public System.Decimal? Aged { get; set;} 


	}
}
