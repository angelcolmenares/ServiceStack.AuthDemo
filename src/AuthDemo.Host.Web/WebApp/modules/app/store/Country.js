Ext.define('AD.store.Country', {
    extend: 'Aicl.data.Store',
    model:  'AD.model.Country',
    
    constructor: function(config){
    	config= config|| {};
    	config.storeId= config.storeId||'Country';   	
    	if (arguments.length==0 )
    		this.callParent([config]);
    	else
    		this.callParent(arguments); 
    }
});
