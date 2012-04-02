Ext.define('AD.view.city.List' ,{ 
    extend: 'Ext.grid.Panel',
    alias : 'widget.citylist',
    
    constructor: function(config){
    	config= config|| {};
    	config.store= config.store ||  'City',
        config.frame = config.frame==undefined? false:config.frame;
		config.selType = config.selType || 'rowmodel';
    	config.height = config.height||350;
    	config.width = config.width || 600;
    	config.viewConfig = config.viewConfig || {
        	stripeRows: true
	    };
        config.margin=config.margin|| '2 2 2 2';	
    	if (arguments.length==0 )
    		this.callParent([config]);
    	else
    		this.callParent(arguments); 
    },
    
    initComponent: function() {
        
        this.columns = [{
            text     : 'City',
            flex     : 1,
            sortable : true,
            dataIndex: 'Name'
        },{
            text     : 'People',
            width    : 200,
            sortable : true,
            dataIndex: 'Population',
            xtype: 'numbercolumn', format:'0,000'
        },{
            text     : 'Country',
            width    : 200,
            sortable : true,
            dataIndex: 'CountryId',
            renderer: function(value){
            	var store= Ext.getStore('Country');
            	if(store){
            		var record = store.getById(value);
            		return record? record.get('Name'): value;
            		
            	}        		
        		return value;
    		}
        }];
 
        this.dockedItems= [{
            xtype: 'toolbar',
            items: [{
                text:'New City',
                tooltip:'add new City',
                iconCls:'add',
                disabled:true,
                action: 'new'
            },'-',{
                text:'Delete',
                tooltip:'delete city',
                iconCls:'remove',
                disabled:true,
                action: 'delete'
            }]		
        }]
                
        this.callParent(arguments);
    }
});

