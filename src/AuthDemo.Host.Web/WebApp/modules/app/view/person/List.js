Ext.define('AD.view.person.List' ,{ 
    extend: 'Ext.grid.Panel',
    alias : 'widget.personlist',
    
    constructor: function(config){
    	config= config|| {};
    	config.store= config.store ||  'Person',
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
        
        this.columns =[{
            text     : 'Person Name',
            flex     : 1,
            sortable : true,
            dataIndex: 'Name'
        },{
            text     : 'Birth City',
            width    : 200,
            sortable : true,
            dataIndex: 'BirthCityId',
            renderer: function(value){
            	var store= Ext.getStore('City');
            	if(store){
            		var record = store.getById(value);
            		return record? record.get('Name'): value;   		
            	}        		
        		return value;
    		}
        },{
            text     : 'Job City',
            width    : 200,
            sortable : true,
            dataIndex: 'JobCityId',
            renderer: function(value){
            	if(value){
            		var store= Ext.getStore('City');
            		if(store){
            			var record = store.getById(value);
            			return record? record.get('Name'): value;
            		}
            	}        		
        		return '';
    		}
        }];
 
        this.dockedItems= [{
            xtype: 'toolbar',
            items: [{
                text:'New Person',
                tooltip:'add new person',
                iconCls:'add',
                disabled:true,
                action: 'new'
            },'-',{
                text:'Delete',
                tooltip:'delete person',
                iconCls:'remove',
                disabled:true,
                action: 'delete'
            }]		
        }]
                
        this.callParent(arguments);
    }
});

