Ext.define('AD.controller.Company', {
	extend: 'Ext.app.Controller',
    stores: [
        'Company' 
    ],  
    models: [
    	'Company'
    ],
    views: [
    	'company.List',
    	'company.Form'
    ],
    refs:[
    	{ref: 'companyList',    	 selector: 'companylist' },
    	{ref: 'companyDeleteButton', selector: 'companylist button[action=delete]' 	},
    	{ref: 'companyNewButton',    selector: 'companylist button[action=new]' 	},
    	{ref: 'companyForm',    	 selector: 'companyform' }, 
    	{ref: 'companySaveButton', 	 selector: 'companyform button[action=save]' }
    ],

    init: function(application) {
    	    	
        this.control({
            'companylist': {  //widget.companylist
                selectionchange: function( sm,  selections,  eOpts){
                	if (selections.length) {
                		this.getCompanyForm().getForm().loadRecord(selections[0]);
                		this.getCompanyDeleteButton().setDisabled(false);
        				this.getCompanySaveButton().setText('Update');	          				
        			}
        			else{
        				this.resetCompanyForm();
        			}
                }
            },
            
            'companylist button[action=delete]': {
                click: function(button, event, options){
                	var grid = this.getCompanyList();
                	var record = grid.getSelectionModel().getSelection()[0];
        			grid.getStore().remove(record);
                }
            },
            
            'companylist button[action=new]': {
            	click:function(button, event, options){
            		this.resetCompanyForm();
            	}
            },
            
            'companyform button[action=save]':{
            	click:function(button, event, options){
            		var record = this.getCompanyForm().getForm().getFieldValues(true);
            		var store =this.getCompanyStore();
        			if (record.Id ){
           				var sr = store.getById(parseInt( record.Id) );
						sr.beginEdit();
						for( var r in record){
							sr.set(r, record[r])
						}
						sr.endEdit(); 
        			}
        			else{
          				var nr = Ext.ModelManager.create(record, this.getCompanyModel().getName() );
						store.add(nr);
						this.getCompanyList().getSelectionModel().doSingleSelect(nr,false);
        			}
            	}
            }
            
        });
    },
    
    onLaunch: function(application){
    	this.getCompanyStore().load();
    	this.getCompanyNewButton().setDisabled(false);
    },
    
    resetCompanyForm: function(){
        this.getCompanyDeleteButton().setDisabled(true);
        this.getCompanyForm().getForm().reset();            
        this.getCompanySaveButton().setText('Add');
	}
	
});
