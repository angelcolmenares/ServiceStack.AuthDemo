using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("PROJ_DEPT_BUDGET")]
	public partial class ProjDeptBudget{

		public ProjDeptBudget(){}

		[Alias("FISCAL_YEAR")]
		[PrimaryKey]
		public System.Int32 FiscalYear { get; set;} 

		[Alias("PROJ_ID")]
		[PrimaryKey]
		[Required]
		[StringLength(5)]
		public System.String ProjId { get; set;} 

		[Alias("DEPT_NO")]
		[PrimaryKey]
		[Required]
		[StringLength(3)]
		public System.String DeptNo { get; set;} 

		[Alias("QUART_HEAD_CNT")]
		public System.Int32? QuartHeadCnt { get; set;} 

		[Alias("PROJECTED_BUDGET")]
		[DecimalLength(12,2)]
		public System.Decimal? ProjectedBudget { get; set;} 


		
	}
}
