using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("JOB")]
	public partial class Job{

		public Job(){}

		[Alias("JOB_CODE")]
		[PrimaryKey]
		[Required]
		[StringLength(5)]
		public System.String JobCode { get; set;} 

		[Alias("JOB_GRADE")]
		[PrimaryKey]
		public System.Int16 JobGrade { get; set;} 

		[Alias("JOB_COUNTRY")]
		[PrimaryKey]
		[Required]
		[StringLength(15)]
		public System.String JobCountry { get; set;} 

		[Alias("JOB_TITLE")]
		[Required]
		[StringLength(25)]
		public System.String JobTitle { get; set;} 

		[Alias("MIN_SALARY")]
		[DecimalLength(10,2)]
		public System.Decimal MinSalary { get; set;} 

		[Alias("MAX_SALARY")]
		[DecimalLength(10,2)]
		public System.Decimal MaxSalary { get; set;} 

		[Alias("JOB_REQUIREMENT")]
		[StringLength(8)]
		public System.String JobRequirement { get; set;} 

		[Alias("LANGUAGE_REQ")]
		[StringLength(15)]
		public System.String LanguageReq { get; set;} 

	}
}
