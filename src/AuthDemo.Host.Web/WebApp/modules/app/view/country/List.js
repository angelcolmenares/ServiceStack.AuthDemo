Ext.define('AD.view.country.List' ,{ 
    extend: 'Ext.grid.Panel',
    alias : 'widget.countrylist',
    
    constructor: function(config){
    	config= config|| {};
    	config.store= config.store ||  'Country',
        config.frame = config.frame==undefined? false:config.frame;
		config.selType = config.selType || 'rowmodel';
    	config.height = config.height|| 350;
    	config.width = config.width || 600;
    	config.margin=config.margin|| '2 2 2 2';
    	config.viewConfig = config.viewConfig || {
        	stripeRows: true
	    };
        	
    	if (arguments.length==0 )
    		this.callParent([config]);
    	else
    		this.callParent(arguments); 
    },
    
    initComponent: function() {
        
        this.columns = [{
            text     : 'Country Name',
            flex     : 1,
            sortable : true,
            dataIndex: 'Name'
        },{
            text     : 'Continent',
            width    : 200,
            sortable : true,
            dataIndex: 'Continent'
        }];
 
        this.dockedItems= [{
            xtype: 'toolbar',
            items: [{
            	//id: 'countryNewButton',
                text:'New Country',
                tooltip:'add new Country',
                iconCls:'add',
                disabled:true,
                action: 'new'
            },'-',{
            	//id: 'countryDeleteButton',
                text:'Delete',
                tooltip:'delete country',
                iconCls:'remove',
                disabled:true,
                action: 'delete'
            }]		
        }]
                
        this.callParent(arguments);
    }
});

