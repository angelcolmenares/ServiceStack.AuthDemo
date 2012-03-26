Ext.define('AD.view.city.Form', {
    extend: 'Ext.form.Panel',
    alias : 'widget.cityform',
    
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
        	xtype:'countrycombo'
        },{
            fieldLabel: 'City Name',
            name: 'Name',
            allowBlank:false
        },{
        	fieldLabel: 'People',
            name: 'Population',
            xtype:'numberfield',
            allowBlank:false
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


Ext.define('country.ComboBox', {
	extend:'Ext.form.field.ComboBox',
	alias : 'widget.countrycombo',
    fieldLabel: 'Country',
    displayField: 'Name',
	valueField: 'Id',
	name:'CountryId',
    store: 'Country',
    queryMode: 'local',
    typeAhead: true,
    forceSelection:true,
    readOnly:true
});