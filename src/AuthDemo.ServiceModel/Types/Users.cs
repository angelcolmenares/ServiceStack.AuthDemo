using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("USERS")]
	public partial class Users:IHasId<System.Int16>{

		public Users(){}

		[Alias("ID")]
		[Sequence("USERS_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		public System.Int16 Id { get; set;} 

		[Alias("NAME")]
		[Required]
		[StringLength(60)]
		public System.String Name { get; set;} 

		[Alias("PASSWORD")]
		[Required]
		[StringLength(30)]
		public System.String Password { get; set;} 

		[Alias("FULL_NAME")]
		[StringLength(60)]
		public System.String FullName { get; set;} 

		[Alias("COL1")]
		[Required]
		[StringLength(2)]
		public System.String Col1 { get; set;} 

		[Alias("COL2")]
		[Required]
		[StringLength(2)]
		public System.String Col2 { get; set;} 

		[Alias("COL3")]
		[Required]
		[StringLength(2)]
		public System.String Col3 { get; set;} 

		[Alias("COL4")]
		[DecimalLength(5,2)]
		public System.Decimal? Col4 { get; set;} 

		[Alias("COL5")]
		public System.Single? Col5 { get; set;} 

		[Alias("COL6")]
		public System.Int32? Col6 { get; set;} 

		[Alias("COL7")]
		[StringLength(8)]
		public System.String Col7 { get; set;} 

		[Alias("COL8")]
		public System.Int64? Col8 { get; set;} 

		[Alias("COL9")]
		public System.DateTime? Col9 { get; set;} 

		[Alias("COL10")]
		public System.DateTime? Col10 { get; set;} 

		[Alias("COL11")]
		public System.Byte? Col11 { get; set;} 

		[Alias("COLNUM")]
		[DecimalLength(18,2)]
		public System.Decimal? Colnum { get; set;} 

		[Alias("COLDECIMAL")]
		[DecimalLength(10,4)]
		public System.Decimal? Coldecimal { get; set;} 

		[Alias("ACTIVEINTEGER")]
		public System.Int32 Activeinteger { get; set;} 

		[Alias("ACTIVECHAR")]
		[Required]
		[StringLength(1)]
		public System.String Activechar { get; set;} 


	}
}
