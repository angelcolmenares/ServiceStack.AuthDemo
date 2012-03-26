Ext.define('AD.controller.City', {
	extend: 'Ext.app.Controller',
    stores: [
        'City','Country','Person' 
    ],  
    models: [
    	'City','Person'
    ],
    views: [
    	
    	'city.List',
    	'city.Form',
    	'person.List',
    	'person.Form',
    	'person.PhotoForm'
    ],
    refs:[
    	
    	{ref: 'cityList',    	 selector: 'citylist' },
    	{ref: 'cityDeleteButton', selector: 'citylist button[action=delete]' 	},
    	{ref: 'cityNewButton',    selector: 'citylist button[action=new]' 	},
    	{ref: 'cityForm',    	 selector: 'cityform' }, 
    	{ref: 'citySaveButton', 	 selector: 'cityform button[action=save]' },
    	{ref: 'countryCombo', 	 selector: 'cityform countrycombo' },
    	
    	{ref: 'personList',    	 selector: 'personlist' },
    	{ref: 'personDeleteButton', selector: 'personlist button[action=delete]' 	},
    	{ref: 'personNewButton',    selector: 'personlist button[action=new]' 	},
    	{ref: 'personForm',    	 selector: 'personform' }, 
    	{ref: 'personSaveButton', 	 selector: 'personform button[action=save]' },
    	{ref: 'jobCityCombo',    	 selector: 'personform jobcitycombo'  },
    	{ref: 'birthCityCombo',    	 selector: 'personform birthcitycombo' },
    	{ref: 'photoForm',    	 selector: 'photoform' },
    	{ref: 'photoImg',    	 selector: 'photoform photoimg' },
    	{ref: 'photoUploadButton',    	 selector: 'photoform button[action=upload]' },
    	{ref: 'selectField',    	 selector: 'photoform filefield' }
    	
    ],

    init: function(application) {
    	    	    	    	    	
        this.control({
            
            'citylist': { 
                selectionchange: function( sm,  selections,  eOpts){
                	if (selections.length) {
                		var record= selections[0];
                		                		
                		this.getCityForm().getForm().loadRecord(record);
                		this.getCityDeleteButton().setDisabled(false);
                		this.getCitySaveButton().setDisabled(false);
        				this.getCitySaveButton().setText('Update');	        			    				
        				
        				if(record.getId()){
        					this.getPersonStore().load({ params: { JobCityId: record.getId()  }});
        				}
        				this.getPersonList().determineScrollbars();
        				this.getPersonNewButton().setDisabled(false);
        				
        				this.getBirthCityCombo().setReadOnly(false);
        				this.getJobCityCombo().setValue( record.getId() );
        				this.getPersonSaveButton().setDisabled(false);
        				        				
        			}
        			else{	
        				this.getPersonStore().removeAll();
        				this.resetCityForm();
        			}
                }
            },
            
            'citylist button[action=delete]': {
                click: function(button, event, options){
                	var grid = this.getCityList();
                	var record = grid.getSelectionModel().getSelection()[0];
        			grid.getStore().remove(record);
                }
            },
            
            'citylist button[action=new]': {
            	click:function(button, event, options){
            		this.getCityList().getSelectionModel().deselectAll();
            	}
            },
            
            'cityform button[action=save]':{
            	click:function(button, event, options){
            		var record = this.getCityForm().getForm().getFieldValues(true);
            		var store =this.getCityStore();
        			if (record.Id ){
           				var sr = store.getById(parseInt( record.Id) );
						sr.beginEdit();
						for( var r in record){
							sr.set(r, record[r])
						}
						sr.endEdit(); 
        			}
        			else{
          				var nr = Ext.ModelManager.create(record, this.getCityModel().getName() );
						store.add(nr);
						this.getCityList().getSelectionModel().doSingleSelect(nr,false);
        			}
            	}
            },
            
            'personlist': { 
                selectionchange: function( sm,  selections,  eOpts){
                	if (selections.length) {
                		var record =selections[0];
                		this.getPersonForm().getForm().loadRecord(record);
                		this.getPersonDeleteButton().setDisabled(false);
        				this.getPersonSaveButton().setText('Update');	
        				var img = sessionStorage[record.getId()+'photo'] || record.get('PhotoFileName');
        				if(img)
        					this.getPhotoImg().setSrc(Aicl.Util.getPhotoDir()+'/'+ img);
        				else	
        					this.getPhotoImg().setSrc(Aicl.Util.getEmpytImgUrl());
        				this.getPhotoUploadButton().setDisabled(false);	
        				this.getPhotoForm().getForm().loadRecord(record);
        				this.getSelectField().setDisabled(false);
        			}
        			else{
        				//this.getPersonStore().removeAll();
        				this.resetPersonForm();
        			}
                }
            },
            
			'personlist button[action=delete]': {
		        click: function(button, event, options){
		        	var grid = this.getPersonList();
		        	var record = grid.getSelectionModel().getSelection()[0];
					grid.getStore().remove(record);
		        }
		    },
		    
		    'personlist button[action=new]': {
		    	click:function(button, event, options){
		    		this.getPersonList().getSelectionModel().deselectAll();
		    	}
		    },
		    
		    'personform button[action=save]':{
		    	click:function(button, event, options){
		    		var record = this.getPersonForm().getForm().getFieldValues(true);
		    		var store =this.getPersonStore();
					if (record.Id ){
		   				var sr = store.getById(parseInt( record.Id) );
						sr.beginEdit();
						for( var r in record){
							sr.set(r, record[r])
						}
						sr.endEdit(); 
					}
					else{
		  				var nr = Ext.ModelManager.create(record, this.getPersonModel().getName() );
						store.add(nr);
						this.getPersonList().getSelectionModel().doSingleSelect(nr,false);
					}
		    	}
		    },
		    'photoform button[action=upload]':{
		    	click:function(){
		    		var form = this.getPhotoForm().getForm();
		    		var photoImg = this.getPhotoImg();
            		if(!form.isValid()){
            			Ext.Msg.alert('Please select a file -( ');
						return ;
            		}
            	
	            	form.submit({
	                	url: Aicl.Util.getHttpUrlApi()+ '/PersonPhoto',
	                	waitMsg: 'Uploading file...',
	                	success: function(form, action) {
	                		console.log('submit photo success', arguments);
	                		sessionStorage[action.result.Data[0].Id+'photo']= action.result.Data[0].PhotoFileName;
	                		photoImg.setSrc(Aicl.Util.getPhotoDir()+'/'+ action.result.Data[0].PhotoFileName);
	                		Aicl.Util.msg('Ready', 'file uploaded.');
	                		form.findField('fileupload').inputEl.dom.value = '';
	                	},
	                	failure: function(form, action) {
	                		console.log('submit photo failure', arguments);
	                		Aicl.Util.msg('Error', Ext.String.format('Code:{0}<br/>Message:{1}',
	                			action.result.ResponseStatus.ErrorCode,
	                			action.result.ResponseStatus.Message) );
	                		form.findField('fileupload').inputEl.dom.value = ''
	                	}
	            	});   
		    		
		    		
		    	}
		    }
                        
        });
    },
    
    onLaunch: function(application){
    	this.getCountryStore().load();
    	this.getCityStore().load();
    	this.getCityNewButton().setDisabled(false);
    	this.getCountryCombo().setReadOnly(false);
    	
    	this.getCitySaveButton().setDisabled(false);
    },
    
    resetCityForm: function(){
        this.getCityDeleteButton().setDisabled(true);
        this.getCityForm().getForm().reset();            
        this.getCitySaveButton().setText('Add');
        
	},
    
	resetPersonForm: function(){
        this.getPersonDeleteButton().setDisabled(true);
        this.getPersonForm().getForm().reset();            
        this.getPersonSaveButton().setText('Add');

        this.getPhotoImg().setSrc(Aicl.Util.getEmpytImgUrl());
        this.getPhotoUploadButton().setDisabled(true);
        this.getPhotoForm().getForm().reset();
        this.getSelectField().setDisabled(true);
        
        if ( this.getCityList().getSelectionModel().getSelection().length )
        	this.getJobCityCombo().setValue( this.getCityList().getSelectionModel().getSelection()[0].getId() );
        else
        	this.getJobCityCombo().setValue(0);
        

	}
	
});
