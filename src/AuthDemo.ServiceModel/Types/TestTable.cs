using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.Common;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace AuthDemo.ServiceModel.Types
{
	[Alias("TEST_TABLE")]
	public partial class TestTable:IHasId<System.Int16>{

		public TestTable(){}

		[Alias("ID")]
		[PrimaryKey]
		public System.Int16 Id { get; set;} 

		[Alias("ID_1")]
		[PrimaryKey]
		public System.Int16 Id1 { get; set;} 

		[Alias("DESCRIPTION")]
		[StringLength(12)]
		public System.String Description { get; set;} 

	}
}
