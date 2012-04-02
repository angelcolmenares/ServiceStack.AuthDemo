Ext.define('AD.store.City', {
    extend: 'Aicl.data.Store',
    model:  'AD.model.City',
    
    constructor: function(config){
    	config= config|| {};
    	config.storeId= config.storeId||'City';   	
    	if (arguments.length==0 )
    		this.callParent([config]);
    	else
    		this.callParent(arguments); 
    }
});
