(function(){
	Ext.ns('Aicl.Util');
	
	Aicl.Util = {}; 
	
	var Util = Aicl.Util, 
		_msgCt, 
		_createBox= function (title, content){
       		return '<div class="msg"><h3>' + title + '</h3><p>' + content + '</p></div>';
    	};
        
    Ext.apply(Util,{
    	
    	convertToDate: function (v){
			if (!v) return null;
			return (typeof v == 'string')
			?new Date(parseFloat(/Date\(([^)]+)\)/.exec(v)[1])) // thanks demis bellot!
			:v ;   
		},

		convertToUTC: function (date){
			return Ext.Date.format(date,'MS');
		},

		formatNumber: function (value, format){
			format= format|| ',0.00'; 
			return ( typeof(value) =='number')?
				Ext.util.Format.number(value,format):
				Ext.util.Format.currency( this.unFormatValue(value),format );
		},

		formatCurrency: function (value){
			return typeof(value=='number')?
				Ext.util.Format.currency(value):
				Ext.util.Format.currency( this.unFormatValue(value) );
			  
		},

		unFormatValue: function (value){
			return  value.replace(/[^0-9\.]/g, '');
		},

		isToday: function(date){
			var d ;
			if( typeof date=='object') d= Ext.Date.format(date,'d.m.Y');
			else d= Ext.util.Format.substr(date,0,10);
	
			var today = Ext.Date.format(new Date() ,'d.m.Y');
			return today==d;
		},
		
		// ajax request
		
		executeAjaxRequest: function (config){
			Ext.MessageBox.show({
				msg: config.msg || 'Please wait...',
				progressText: config.progessText || 'Executing...',
		        width: config.width || 300,
				wait:true,
		        waitConfig: {interval:200}
		   		//icon:'ext-mb-download' //custom class in msg-box.html
			});
		
			Ext.Ajax.request({
				url: config.url + ( Ext.util.Format.uppercase(config.method)=='DELETE'
									? Aicl.Util.paramsToUrl(config.params) 
									:config.format==undefined?'': Ext.String.format('?format={0}', config.format)),
				method: config.method, 
			    success: function(response, options) {
		            var result = Ext.decode(response.responseText);
					if(result.ResponseStatus.ErrorCode){
						Aicl.Util.msg('Ajax request error in ResponseStatus', result.ResponseStatus.Message + ' -( '); 
						return ;
					}
					if(config.showReady) Aicl.Util.msg('Ready', result.ResponseStatus.Message);
					if( config.success ) config.success(result);
					
			    },
			    failure: function(response, options) {
			    	var result={};
			    	if(response.responseText){
			    		 result= Ext.decode(response.responseText);
			    	}
			    	else{
			    		result=response;
			    	}
		            
					Aicl.Util.msg('Ajax request failure', 'Status: ' + response.status +'<br/>Message: '+
					 ((result.ResponseStatus)? result.ResponseStatus.Message: response.statusText) +' -( ');
					if( config.failure ) config.failure(result);
				},
				callback: function(options, success, response) {
					Ext.MessageBox.hide();	
					var result={};
					if(response.responseText){
						result = Ext.decode(response.responseText);
					}
					else{
						result=response;
					}
					if( config.callback ) config.callback(result, success);
				},
				params:config.params
			});	
		},

		executeRestRequest: function (config){
			config.format=  config.format|| 'json';
			this.executeAjaxRequest(config)
		},

		paramsToUrl:function(params){
			var s='';
			for( p in params){
				s= Ext.String.urlAppend(s, Ext.String.format('{0}={1}', p, params[p]));
			};
			return s;
			
		},
		
		// proxies
			
		createRestProxy:function (config){
			
			config.format=config.format|| 'json';
			config.type= config.type || 'rest';
			
			config.api=config.api||{};
			config.api.create=config.api.create|| config.url+'/create';
			config.api.read=config.api.read|| config.url+'/read';
			config.api.update=config.api.update|| config.url+'/update';
			config.api.destroy=config.api.destroy|| config.url+'/destroy';
			config.url= config.url || Aicl.Util.getUrlApi()+'/' + config.storeId;
			
			return this.createProxy(config);
			
		},
		
		createAjaxProxy:function (config){
			config.type=config.type||'ajax';
			config.url= config.url || Aicl.Util.getHttpUrlApi()+'/' + config.storeId;
			var proxy= this.createProxy(config);
			proxy.actionMethods= {create: "POST", read: "GET", update: "PUT", destroy: "DELETE"};
			return proxy;
		},
		
		createProxy:function (config){
				
			if(config.format){
				config.extraParams=config.extraParams||{};
				config.extraParams['format']=config.format
			}
			
			config.api=config.api||{};
			config.api.create=config.api.create;
			config.api.read=config.api.read;
			config.api.update=config.api.update;
			config.api.destroy=config.api.destroy;
			
			config.reader= config.reader||{
				type: 'json',
		        root: 'Data', 
				totalProperty : undefined,
		    	successProperty	: undefined,
				messageProperty :  undefined
			};
			
			config.writer= config.writer || {
				type: 'json',
				getRecordData: function(record) { 
					console.log('Proxy writer getRecordData', record);
					return record.data; 
				}
			};
			
			var proxy={
				type: config.type,
				url : config.url,
				api : config.api,
		    	reader: config.reader,
				writer: config.writer,
				pageParam: config.pageParam? config.pageParam: undefined,
				limitParam: config.limitParam? config.limitParam:undefined,
				startParam: config.startParam? config.startParam:undefined,
				extraParams: config.extraParams?config.extraParams:undefined,
				storeId: config.storeId,
				listeners:config.listeners ||
				{
		        	exception:function(proxy, response,  operation,  options) {
		        		console.log('Proxy exception store: '+ this.storeId, arguments)
		            	var result={};
			    		if(response.responseText){
			    	 		result= Ext.decode(response.responseText);
			    		}
			    		else{
			    			result=response;
			    		}
						Aicl.Util.msg('Proxy exception store:' + this.storeId ,
						'Status: ' + response.status +'<br/>Message: '+
							((result.ResponseStatus)? result.ResponseStatus.Message: response.statusText) +' -( ');
					 	
					 	if(this.storeId){
					 		var store= Ext.getStore(this.storeId);
					 		if(store) store.rejectChanges();
					 	}
		        	}
		        	
		    	}
		    };
		    
		    return proxy;
		},
		
		// auth 
		setAuth:function (trueOrFalse){
			 sessionStorage["authenticated"]= trueOrFalse;
			 
		},
		
		isAuth: function (){
			var v = sessionStorage["authenticated"]
			return v==undefined? false: Ext.decode(v);
		},
		
		setUrlApi: function (urlApi){
			sessionStorage["urlApi"]=urlApi;
		},
		
		getUrlApi:function (){
			return sessionStorage["urlApi"];
		},
		
		getHttpUrlApi:function (){
			return sessionStorage["httpUrlApi"];
		},
		
		setHttpUrlApi:function(httpUrlApi){
			sessionStorage["httpUrlApi"]=httpUrlApi;
		},
		
		setPhotoDir: function(photoDir){
			sessionStorage["photoDir"]=photoDir;
		},
		
		getPhotoDir: function(){
			return sessionStorage["photoDir"];
		},
		
		setEmptyImgUrl: function( url){
			sessionStorage["emptyImgUrl"]= url; 
		},
		
		getEmpytImgUrl: function(){
			return sessionStorage["emptyImgUrl"];
		},
		
		checkRole:function (role){
			var a= sessionStorage.roles? Ext.decode(sessionStorage.roles): [];
			return a.indexOf(role)>0;
		},
		
		
		//helpers
		isValidEmail:function (email) {
			var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
			return filter.test(email)
		},
		
		msg: function(title, format){
            if(!_msgCt){
                _msgCt = Ext.core.DomHelper.insertFirst(document.body, {id:'msg-div'}, true);
            }
            var s = Ext.String.format.apply(String, Array.prototype.slice.call(arguments, 1));
            var m = Ext.core.DomHelper.append(_msgCt, _createBox(title, s), true);
            m.hide();
            m.slideIn('t').ghost("t", { delay: 1000, remove: true});
		}   	
    	
    });	
    
})();
    	

Ext.define('Aicl.data.Store',{
	extend: 'Ext.data.Store',
    constructor: function(config){    	    	
    	
    	config.proxy= config.proxy || Aicl.Util.createRestProxy( {
    		storeId: config.storeId,
			url: config.proxy && config.proxy.url?
				config.proxy.url:
				Aicl.Util.getUrlApi()+'/' + config.storeId
    	});
    	
    	config.autoLoad= config.autoLoad==undefined? false: config.autoLoad;
    	config.autoSync= config.autoSync==undefined? true: config.autoSync;
    	config.listeners= config.listeners ||
    	{
            write: (config.listeners && config.listeners.write)?
            config.listeners.write(store, operation, options):
            function(store, operation, options){
            	console.log('store'+ this.storeId+ '  write arguments: ', arguments); 
                var record =  operation.getRecords()[0],
                    name = Ext.String.capitalize(operation.action),
                    verb;                                
                if (name == 'Destroy') {
                	record =operation.records[0];
                    verb = 'Destroyed';
                } else {
                    verb = name + 'd';
                }
                console.log('store'+ this.storeId +' write record: ', record);
                Aicl.Util.msg(name, Ext.String.format("{0} {1}: {2}", verb, this.storeId , record.getId()));
            }
        };
        
        this.callParent(arguments);

    }
});  



Ext.data.Store.implement({
    rejectChanges: function(){
    	Ext.each(this.removed, function(record){
   			this.insert(record.lastIndex || 0, record);
  		}, this);
 
  		Ext.each(this.getUpdatedRecords(), function(record) {
   			record.reject();
  		}, this);
 
  		this.remove(this.getNewRecords());
   		//this.each(function(record) {   		//	record.reject();  		//}, this);
   		this.removed = [];
    }
});

Ext.form.Panel.implement({
    setFocus:function(item){
    	var ff = item==undefined?this.items.items[1].name:Ext.isNumber(item)?this.items.items[item].name:item;
    	this.getForm().findField(ff).focus(false,10);
    }
});



/*Ext.data.Store.implement({
	convertToDate:function(v){ 
		console.log('converToDate', arguments);
		return  Aicl.Util.convertToDate(v)
	}
});*/


//Ext.define('Aicl.data.Model',{
//	extend: 'Ext.data.Model',
//convertToDate:function(v){ 
//		console.log('converToDate', arguments);
//		return  Aicl.Util.convertToDate(v)
//	}
//});

/*
responseText: ""
responseXML: null
status: 401
statusText: "Invalid Role"
*/
