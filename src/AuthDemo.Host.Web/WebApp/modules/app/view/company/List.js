Ext.define('AD.view.company.List' ,{ 
    extend: 'Ext.grid.Panel',
    alias : 'widget.companylist',
    
    constructor: function(config){
    	config= config|| {};
    	config.store= config.store ||  'Company',
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
            text     : 'Company Name',
            flex     : 1,
            sortable : true,
            dataIndex: 'Name'
        },{
            text     : 'Turnover',
            width    : 100,
            sortable : true,
            dataIndex: 'Turnover',
            renderer: Ext.util.Format.usMoney
        },{
            text     : 'Started',
            width    : 100,
            sortable : true,
            dataIndex: 'Started',
            renderer : Ext.util.Format.dateRenderer('d.m.Y')
        },{
            text     : 'No Employees',
            width    : 100,
           	sortable : true,
            dataIndex: 'Employees'
        },{
            text     : 'Created',
            width    : 100,
            sortable : true,
            dataIndex: 'CreatedDate',
            renderer : Ext.util.Format.dateRenderer('d.m.Y')
        }];
 
        this.dockedItems= [{
            xtype: 'toolbar',
            items: [{
                text:'New Company',
                tooltip:'add new Company',
                iconCls:'add',
                disabled:true,
                action: 'new'
            },'-',{
                text:'Delete',
                tooltip:'delete company',
                iconCls:'remove',
                disabled:true,
                action: 'delete'
            }]		
        }]
                
        this.callParent(arguments);
    }
});

