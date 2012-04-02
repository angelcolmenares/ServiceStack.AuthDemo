using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("CUSTOMER")]
	public partial class Customer:IHasId<System.Int32>{

		public Customer(){}

		[Alias("CUST_NO")]
		[Sequence("CUST_NO_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		public System.Int32 Id { get; set;} 

		[Alias("CUSTOMER")]
		[Required]
		[StringLength(25)]
		public System.String CustomerName { get; set;} 

		[Alias("CONTACT_FIRST")]
		[StringLength(15)]
		public System.String ContactFirst { get; set;} 

		[Alias("CONTACT_LAST")]
		[StringLength(20)]
		public System.String ContactLast { get; set;} 

		[Alias("PHONE_NO")]
		[StringLength(20)]
		public System.String PhoneNo { get; set;} 

		[Alias("ADDRESS_LINE1")]
		[StringLength(30)]
		public System.String AddressLine1 { get; set;} 

		[Alias("ADDRESS_LINE2")]
		[StringLength(30)]
		public System.String AddressLine2 { get; set;} 

		[Alias("CITY")]
		[StringLength(25)]
		public System.String City { get; set;} 

		[Alias("STATE_PROVINCE")]
		[StringLength(15)]
		public System.String StateProvince { get; set;} 

		[Alias("COUNTRY")]
		[StringLength(15)]
		public System.String Country { get; set;} 

		[Alias("POSTAL_CODE")]
		[StringLength(12)]
		public System.String PostalCode { get; set;} 

		[Alias("ON_HOLD")]
		[StringLength(1)]
		public System.String OnHold { get; set;} 


		
	}
}
