using System;
using System.IO;
using ServiceStack.Common.Utils;
using ServiceStack.Configuration;

namespace AuthDemo.ServiceInterface
{
	public class AppConfig
	{
		public AppConfig()
		{
			
		}

		public AppConfig(IResourceManager resources)
		{
			RootDirectory = resources.GetString("RootDirectory");	
			PhotoDirectory = resources.GetString("PhotoDirectory");
			LibDirectory = resources.GetString("LibDirectory");
		}

		public string PhotoDirectory { get; set; }
		public string RootDirectory { get; set; }
		public string LibDirectory { get; set; }
		
	}
}
/*
 .MapHostAbsolutePath()
.Replace('\\', Path.DirectorySeparatorChar);		
*/


