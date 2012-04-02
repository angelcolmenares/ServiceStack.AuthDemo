using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("PROJECT")]
	public partial class Project{

		public Project(){}

		[Alias("PROJ_ID")]
		[PrimaryKey]
		[Required]
		[StringLength(5)]
		public System.String ProjId { get; set;} 

		[Alias("PROJ_NAME")]
		[Required]
		[StringLength(20)]
		public System.String ProjName { get; set;} 

		[Alias("PROJ_DESC")]
		[StringLength(8)]
		public System.String ProjDesc { get; set;} 

		[Alias("TEAM_LEADER")]
		public System.Int16? TeamLeader { get; set;} 

		[Alias("PRODUCT")]
		[StringLength(12)]
		public System.String Product { get; set;} 


		
	}
}
