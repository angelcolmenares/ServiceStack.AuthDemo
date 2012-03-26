using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("EMPLOYEE_PROJECT")]
	public partial class EmployeeProject{

		public EmployeeProject(){}

		[Alias("EMP_NO")]
		[PrimaryKey]
		public System.Int16 EmpNo { get; set;} 

		[Alias("PROJ_ID")]
		[PrimaryKey]
		[Required]
		[StringLength(5)]
		public System.String ProjId { get; set;} 


	}
}
