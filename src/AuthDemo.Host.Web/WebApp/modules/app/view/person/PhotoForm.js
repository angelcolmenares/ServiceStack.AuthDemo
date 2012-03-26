Ext.define('AD.view.person.PhotoForm', {
    extend: 'Ext.form.Panel',
    alias : 'widget.photoform',
    
    constructor: function(config){
    	config=config|| {};
    	config.frame=config.frame==undefined?false: config.frame;
    	config.margin=config.margin|| '0 0 0 5';
    	config.bodyStyle = config.bodyStyle ||'padding:10px 10px 0';
    	config.width = config.width|| 320;
        config.height = config.height|| 200;
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
    	this.layout= {
    		type: 'vbox',    
        	align: 'center'
    	};
    	
        this.items = [{
            xtype:'hidden',
            name: 'Id'
        },{
        	xtype:'photoimg'
        },{
        	xtype: 'filefield',
        	name: 'fileupload',
        	msgTarget: 'side',
        	allowBlank: false,
        	disabled:true,
        	anchor: '100%',
        	buttonText: 'Select...',
    		buttonConfig: {
    			iconCls: 'select'
    		},
    		buttonOnly:true,
    		width:70
        }];
 
        this.buttons = [{ 
            text:'Upload',
            formBind: false,
            disabled:true,
            action:'upload',
            iconCls: 'upload'
	    }];
 
        this.callParent(arguments);
    }
});

Ext.define('photo.Img', {
	extend:'Ext.Img',
	alias:'widget.photoimg',
	src: Aicl.Util.getEmpytImgUrl(),
    width:75, height: 100
});

