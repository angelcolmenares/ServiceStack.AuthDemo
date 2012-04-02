Ext.define('AD.controller.Country', {
	extend: 'Ext.app.Controller',
    stores: [
        'Country','City' 
    ],  
    models: [
    	'Country','City'
    ],
    views: [
    	'country.List',
    	'country.Form',
    	'city.List',
    	'city.Form'
    ],
    refs:[
    	{ref: 'countryList',    	 selector: 'countrylist' },
    	{ref: 'countryDeleteButton', selector: 'countrylist button[action=delete]' 	},
    	{ref: 'countryNewButton',    selector: 'countrylist button[action=new]' 	},
    	{ref: 'countryForm',    	 selector: 'countryform' }, 
    	{ref: 'countrySaveButton', 	 selector: 'countryform button[action=save]' },
    	{ref: 'cityList',    	 selector: 'citylist' },
    	{ref: 'cityDeleteButton', selector: 'citylist button[action=delete]' 	},
    	{ref: 'cityNewButton',    selector: 'citylist button[action=new]' 	},
    	{ref: 'cityForm',    	 selector: 'cityform' }, 
    	{ref: 'citySaveButton', 	 selector: 'cityform button[action=save]' },
    	{ref: 'countryCombo', 	 selector: 'cityform countrycombo' }
    ],

    init: function(application) {
    	    	    	    	    	
        this.control({
            'countrylist': {  //widget.countrylist
                selectionchange: function( sm,  selections,  eOpts){
                	if (selections.length) {
                		var record= selections[0];
                		
                		this.getCountryForm().getForm().loadRecord(record);
                		this.getCountryDeleteButton().setDisabled(false);
                		this.getCountrySaveButton().setDisabled(false);
        				this.getCountrySaveButton().setText('Update');
        				        				        				
        				if(record.getId())
                			 this.getCityStore().load({ params: { CountryId: record.getId()  }});
                		this.getCityList().determineScrollbars()
                		this.getCityNewButton().setDisabled(false);
                		this.getCountryCombo().setValue( record.getId() );
                		this.getCitySaveButton().setDisabled(false);
        				
        				
        			}
        			else{
        				this.getCityStore().removeAll();
        				this.resetCountryForm();
        			}
                }
            },
            
            'countrylist button[action=delete]': {
                click: function(button, event, options){
                	var grid = this.getCountryList();
                	var record = grid.getSelectionModel().getSelection()[0];
        			grid.getStore().remove(record);
                }
            },
            
            'countrylist button[action=new]': {
            	click:function(button, event, options){
            		this.getCountryList().getSelectionModel().deselectAll();
            	}
            },
            
            'countryform button[action=save]':{
            	click:function(button, event, options){
            		var record = this.getCountryForm().getForm().getFieldValues(true);
            		var store =this.getCountryStore();
        			if (record.Id ){
           				var sr = store.getById(parseInt( record.Id) );
						sr.beginEdit();
						for( var r in record){
							sr.set(r, record[r])
						}
						sr.endEdit(); 
        			}
        			else{
          				var nr = Ext.ModelManager.create(record, this.getCountryModel().getName() );
						store.add(nr);
						this.getCountryList().getSelectionModel().doSingleSelect(nr,false);
        			}
            	}
            },
            
            'citylist': { 
                selectionchange: function( sm,  selections,  eOpts){
                	if (selections.length) {
                		this.getCityForm().getForm().loadRecord(selections[0]);
                		this.getCityDeleteButton().setDisabled(false);
        				this.getCitySaveButton().setText('Update');	        			
        			}
        			else{		
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
            }
            
        });
    },
    
    onLaunch: function(application){
    	this.getCountryStore().load();
    	this.getCountryNewButton().setDisabled(false);
    },
    
    resetCountryForm: function(){
        this.getCountryDeleteButton().setDisabled(true);
        this.getCountryForm().getForm().reset();            
        this.getCountrySaveButton().setText('Add');
	},
    
	resetCityForm: function(){
        this.getCityDeleteButton().setDisabled(true);
        this.getCityForm().getForm().reset();            
        this.getCitySaveButton().setText('Add');
        if ( this.getCountryList().getSelectionModel().getSelection().length )
        	this.getCountryCombo().setValue( this.getCountryList().getSelectionModel().getSelection()[0].getId() );
        else
        	this.getCountryCombo().setValue(0);
	}
	
});
