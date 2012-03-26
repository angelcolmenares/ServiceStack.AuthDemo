Ext.define('AD.view.country.Form', {
    extend: 'Ext.form.Panel',
    alias : 'widget.countryform',
    
    constructor: function(config){
    	config=config|| {};
    	//config.id= config.id||'countryForm';
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
            fieldLabel: 'Country Name',
            name: 'Name',
            allowBlank:false
        },{
        	fieldLabel: 'Continent',
            name: 'Continent',
            allowBlank:false
        }];
 
        this.buttons = [{ 
            text:'Add',
            formBind: false,
            disabled:false,
            action:'save'
                          
	    }];
 
        this.callParent(arguments);
    }
});