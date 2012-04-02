using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("EMPLOYEE")]
	public partial class Employee:IHasId<System.Int16>{

		public Employee(){}

		[Alias("EMP_NO")]
		[Sequence("EMP_NO_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		public System.Int16 Id { get; set;} 

		[Alias("FIRST_NAME")]
		[Required]
		[StringLength(15)]
		public System.String FirstName { get; set;} 

		[Alias("LAST_NAME")]
		[Required]
		[StringLength(20)]
		public System.String LastName { get; set;} 

		[Alias("PHONE_EXT")]
		[StringLength(4)]
		public System.String PhoneExt { get; set;} 

		[Alias("HIRE_DATE")]
		public System.DateTime HireDate { get; set;} 

		[Alias("DEPT_NO")]
		[Required]
		[StringLength(3)]
		public System.String DeptNo { get; set;} 

		[Alias("JOB_CODE")]
		[Required]
		[StringLength(5)]
		public System.String JobCode { get; set;} 

		[Alias("JOB_GRADE")]
		public System.Int16 JobGrade { get; set;} 

		[Alias("JOB_COUNTRY")]
		[Required]
		[StringLength(15)]
		public System.String JobCountry { get; set;} 

		[Alias("SALARY")]
		[DecimalLength(10,2)]
		public System.Decimal Salary { get; set;} 

		[Alias("FULL_NAME")]
		[StringLength(37)]
		[Compute]
		public System.String FullName { get; set;} 


		
	}
}
