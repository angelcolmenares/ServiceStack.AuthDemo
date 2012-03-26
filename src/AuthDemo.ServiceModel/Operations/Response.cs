using System;
using System.Collections.Generic;
using ServiceStack.ServiceInterface.ServiceModel;

namespace AuthDemo.ServiceModel.Operations
{
	public class Response<T>:IHasResponseStatus where T:new()
	{
		public Response ()
		{
			ResponseStatus= new ResponseStatus();
			Data= new List<T>();
		}
		
		public ResponseStatus ResponseStatus { get; set; }
		
		public List<T> Data {get; set;}
		/*
		public int Total { 
			get{return Data.Count;}
		}
		
		public bool Success{
			get {
				return string.IsNullOrEmpty( ResponseStatus.Message );
			}
		}
		*/
	}
}

