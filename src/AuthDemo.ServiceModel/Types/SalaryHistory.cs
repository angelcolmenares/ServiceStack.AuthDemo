using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("SALARY_HISTORY")]
	public partial class SalaryHistory{

		public SalaryHistory(){}

		[Alias("EMP_NO")]
		[PrimaryKey]
		public System.Int16 EmpNo { get; set;} 

		[Alias("CHANGE_DATE")]
		[PrimaryKey]
		public System.DateTime ChangeDate { get; set;} 

		[Alias("UPDATER_ID")]
		[PrimaryKey]
		[Required]
		[StringLength(20)]
		public System.String UpdaterId { get; set;} 

		[Alias("OLD_SALARY")]
		[DecimalLength(10,2)]
		public System.Decimal OldSalary { get; set;} 

		[Alias("PERCENT_CHANGE")]
		[Required]
		[StringLength(8)]
		public System.String PercentChange { get; set;} 

		[Alias("NEW_SALARY")]
		[StringLength(8)]
		[Compute]
		public System.String NewSalary { get; set;} 


	}
}
