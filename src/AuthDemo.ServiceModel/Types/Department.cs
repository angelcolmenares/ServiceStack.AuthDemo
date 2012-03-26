using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("DEPARTMENT")]
	public partial class Department{

		public Department(){}

		[Alias("DEPT_NO")]
		[PrimaryKey]
		[Required]
		[StringLength(3)]
		public System.String DeptNo { get; set;} 

		[Alias("DEPARTMENT")]
		[Required]
		[StringLength(25)]
		public System.String DepartmentName { get; set;} 

		[Alias("HEAD_DEPT")]
		[StringLength(3)]
		public System.String HeadDept { get; set;} 

		[Alias("MNGR_NO")]
		public System.Int16? MngrNo { get; set;} 

		[Alias("BUDGET")]
		[DecimalLength(12,2)]
		public System.Decimal? Budget { get; set;} 

		[Alias("LOCATION")]
		[StringLength(15)]
		public System.String Location { get; set;} 

		[Alias("PHONE_NO")]
		[StringLength(20)]
		public System.String PhoneNo { get; set;} 


	}
}
