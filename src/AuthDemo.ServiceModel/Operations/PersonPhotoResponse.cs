using System;
//using System.Runtime.Serialization;
using System.Collections.Generic;
using ServiceStack.ServiceInterface.ServiceModel;
using AuthDemo.ServiceModel.Types;

namespace AuthDemo.ServiceModel.Operations
{
		
	public class PersonPhotoResponse :Response<PersonPhoto>, IHasResponseStatus 
	{
		public PersonPhotoResponse ():base()
		{
		}
			
		public PersonPhotoResponse (PersonPhoto response):base()
		{
			Data.Add(response);
		}
		
		//[DataMember(Name = "success")]
		public bool success{
			get{
				return string.IsNullOrEmpty( ResponseStatus.ErrorCode);
			}
			set{
				
			}
		}
		
		//[DataMember(Name = "msg")]
		public string msg{
			get{
				return ResponseStatus.Message;
			}
			set{
				
			}
		}
		
	}
}