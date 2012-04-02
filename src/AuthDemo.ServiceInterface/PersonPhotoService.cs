using System;
using System.IO;
using System.Linq;
using System.Net;
﻿using ServiceStack.CacheAccess;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.OrmLite;

using AuthDemo.ServiceDbAcces;
using AuthDemo.ServiceModel.Operations;
using AuthDemo.ServiceModel.Types;

namespace AuthDemo.ServiceInterface
{
	[Authenticate]
	[RequiredPermission("Person.read")]
	[RequiredPermission(ApplyTo.Post, "Person.create")]	
	[RequiredPermission(ApplyTo.Put , "Person.update")]	
	
	public class PersonPhotoService:RestServiceBase<PersonPhoto>
	{
		public Factory Factory{ get; set;}
		public AppConfig Config { get; set;}
		
		public override object OnPost (PersonPhoto request)
		{
			
			if(RequestContext.Files.Count()==0){
				return ErrorResult("No file to save", string.Empty, "NoFile");
			}
			
			if(request.Id==default(int)){
				return ErrorResult("No Id to save", string.Empty, "NoId");
			}
						
			var person = Factory.GetById<Person>(request.Id).First();			
			
			if(person==default(Person)){
				return ErrorResult("No found Person with id:"+ request.Id.ToString(),string.Empty, "IdNotFound");
			}
						
			
			try{
				var uploadedFile =RequestContext.Files[0];
				request.PhotoFileName = person.GetNextPhotoFileName(uploadedFile.FileName); 
				var newFilePath = Path.Combine(Config.PhotoDirectory, 
			                               request.PhotoFileName);
				uploadedFile.SaveTo(newFilePath);
				person.PhotoFileName= request.PhotoFileName;
				person.UpdatePhotoFileName(Factory.DbFactory);
				
										
				return  new  HttpResult(new PersonPhotoResponse(request)){
					Headers = {
						{ HttpHeaders.ContentType, ContentType.Html  }
					}
				};				
			}
			catch(Exception e ){
				return ErrorResult(e.Message, e.StackTrace, "FileUploadError");
			}												
		}
		
		
		public override object OnPut (PersonPhoto request)
		{
			return OnPost(request);
		}
						
				
		private HttpResult ErrorResult(string message, string stackTrace, string errorCode)
		{		
			var result  = HttpResponse.ErrorResult<PersonPhotoResponse>(message, stackTrace, errorCode);
			result.Headers.Add(HttpHeaders.ContentType, ContentType.Html);
			return result;
		}
		
	}
}

/*
 * http://docs.sencha.com/ext-js/4-0/#!/api/Ext.form.Basic-method-submit
 * hasUpload( )
Returns true if the form contains a file upload field. This is used to determine the method for 
submitting the form: File uploads are not performed using normal 'Ajax' techniques, 
that is they are not performed using XMLHttpRequests. 
Instead a hidden <form> element containing all the fields is created temporarily
and submitted with its target set to refer to a dynamically generated, 
hidden <iframe> which is inserted into the document but removed after the return data has been gathered.

The server response is parsed by the browser to create the document for the IFRAME. 
If the server is using JSON to send the return object, 
then the Content-Type header must be set to "text/html" in order to tell the browser to insert the text unchanged into the document body.

Characters which are significant to an HTML parser must be sent as HTML entities, 
so encode "<" as "&lt;", "&" as "&amp;" etc.

The response text is retrieved from the document, and a fake XMLHttpRequest object is created 
containing a responseText property in order to conform to the requirements of event handlers and callbacks.

Be aware that file upload packets are sent with the content type multipart/form and s
ome server technologies (notably JEE) may require some custom processing in order to retrieve 
parameter names and parameter values from the packet content.



http://docs.sencha.com/ext-js/4-0/#!/api/Ext.form.Basic-method-submit

submit( Object options ) : Ext.form.Basic
Shortcut to do a submit action. This will use the AJAX submit action by default. If the standardSubmit config is enabled it will use a standard form element to submit, or if the api config is present it will use the Ext.direct.Direct submit action.

Parameters
options : Object
The options to pass to the action (see doAction for details).

The following code:

myFormPanel.getForm().submit({
    clientValidation: true,
    url: 'updateConsignment.php',
    params: {
        newStatus: 'delivered'
    },
    success: function(form, action) {
       Ext.Msg.alert('Success', action.result.msg);
    },
    failure: function(form, action) {
        switch (action.failureType) {
            case Ext.form.action.Action.CLIENT_INVALID:
                Ext.Msg.alert('Failure', 'Form fields may not be submitted with invalid values');
                break;
            case Ext.form.action.Action.CONNECT_FAILURE:
                Ext.Msg.alert('Failure', 'Ajax communication failed');
                break;
            case Ext.form.action.Action.SERVER_INVALID:
               Ext.Msg.alert('Failure', action.result.msg);
       }
    }
});
would process the following server response for a successful submission:

{
    "success":true, // note this is Boolean, not string
    "msg":"Consignment updated"
}
and the following server response for a failed submission:

{
    "success":false, // note this is Boolean, not string
    "msg":"You do not have permission to perform this operation"
}
Returns
Ext.form.Basic
this



 * 
 */