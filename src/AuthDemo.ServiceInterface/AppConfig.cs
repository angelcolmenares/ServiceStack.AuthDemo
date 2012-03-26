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
			PhotoDirectory = resources.Get<string>("PhotoDirectory","~/WebApp/photos/")
				.MapHostAbsolutePath()
				.Replace('\\', Path.DirectorySeparatorChar);		
		}

		public string PhotoDirectory { get; set; }
		
	}
}



