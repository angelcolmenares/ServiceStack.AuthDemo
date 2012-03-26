Ext.define('AD.view.person.Form', {
    extend: 'Ext.form.Panel',
    alias : 'widget.personform',
    
    constructor: function(config){
    	config=config|| {};
    	config.frame=config.frame==undefined?false: config.frame;
    	config.margin=config.margin|| '0 0 0 5';
    	config.bodyStyle = config.bodyStyle ||'padding:10px 10px 0';
    	config.width = config.width|| 320;
        config.height = config.height|| 150;
		config.fieldDefaults = config.fieldDefaults || {
            msgTarget: 'side',
            labelWidth: 120,
			labelAlign: 'right'
        };
        config.defaultType = config.defaultType|| 'textfield';
        config.defaults = config.defaults || {
            anchor: '100%',
			labelStyle: 'padding-left:4px;'
        };
    	if (arguments.length==0 )
    		this.callParent([config]);
    	else
    		this.callParent(arguments);
        
    },
     
    initComponent: function() {
        this.items = [{
            xtype:'hidden',
            name: 'Id'
        },{
            fieldLabel: 'Name',
            name: 'Name',
            allowBlank:false
        },{
        	xtype:'birthcitycombo'
        	
        },{
            xtype:'jobcitycombo'
        }];
 
        this.buttons = [{ 
            text:'Add',
            formBind: false,
            disabled:true,
            action:'save'      
	    }];
 
        this.callParent(arguments);
    }
});


Ext.define('jobcity.ComboBox', {
	extend:'Ext.form.field.ComboBox',
	alias : 'widget.jobcitycombo',
    fieldLabel: 'Job City',
    displayField: 'Name',
	valueField: 'Id',
	name:'JobCityId',
    store: 'City',
    queryMode: 'local',
    typeAhead: true,
    forceSelection:true,
    readOnly:true
});


Ext.define('birthcity.ComboBox', {
	extend:'Ext.form.field.ComboBox',
	alias : 'widget.birthcitycombo',
    fieldLabel: 'Birth City',
    displayField: 'Name',
	valueField: 'Id',
	name:'BirthCityId',
    store: 'City',
    queryMode: 'local',
    typeAhead: true,
    forceSelection:true,
    readOnly:true,
    listeners:{
    	beforequery: function(  queryEvent,  eOpts ){
    		queryEvent.query='';
    	}
    }
});