Ext.define('AD.view.company.Form', {
    extend: 'Ext.form.Panel',
    alias : 'widget.companyform',
    
    constructor: function(config){
    	config=config|| {};
    	config.frame=config.frame==undefined?false: config.frame;
    	config.margin=config.margin|| '0 0 0 5';
    	config.bodyStyle = config.bodyStyle ||'padding:10px 10px 0';
    	config.width = config.width|| 320;
        config.height = config.height|| 180;
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
            fieldLabel: 'Company Name',
            name: 'Name',
            allowBlank:false
        },{
        	xtype:'numberfield',
        	fieldLabel: 'Turnover',
            name: 'Turnover',
            allowBlank:false
        },{
            fieldLabel: 'Started Date',
            name: 'Started',
			format:	'd.m.Y',
			xtype     : 'datefield'
        },{
            xtype:'numberfield',
        	fieldLabel: 'No. Employees',
            name: 'Employees',
            allowBlank:false
        },{
            fieldLabel: 'Created Date',
            name: 'CreatedDate',
			format:	'd.m.Y',
			xtype     : 'datefield'
        }];
 
        this.buttons = [{ 
            text:'Add',
            formBind: true,
            disabled:true,
            action:'save'      
	    }];
 
        this.callParent(arguments);
    }
});
