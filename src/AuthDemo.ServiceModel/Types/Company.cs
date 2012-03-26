using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("COMPANY")]
	public partial class Company:IHasId<System.Int32>{

		public Company(){}

		[Alias("ID")]
		[Sequence("COMPANY_ID_GEN")]
		[PrimaryKey]
		[AutoIncrement]
		public System.Int32 Id { get; set;} 

		[Alias("NAME")]
		[StringLength(100)]
		public System.String Name { get; set;} 

		[Alias("TURNOVER")]
		public System.Single? Turnover { get; set;} 

		[Alias("STARTED")]
		public System.DateTime? Started { get; set;} 

		[Alias("EMPLOYEES")]
		public System.Int32? Employees { get; set;} 

		[Alias("CREATED_DATE")]
		public System.DateTime? CreatedDate { get; set;} 

		[Alias("GUID")]
		public System.Guid? Guid { get; set;} 


		
	}
}
