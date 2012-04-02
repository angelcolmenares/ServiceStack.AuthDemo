Ext.define('AD.store.Person', {
    extend: 'Aicl.data.Store',
    model:  'AD.model.Person',
    
    constructor: function(config){
    	config= config|| {};
    	config.storeId= config.storeId||'Person';   	
    	if (arguments.length==0 )
    		this.callParent([config]);
    	else
    		this.callParent(arguments); 
    }
});
