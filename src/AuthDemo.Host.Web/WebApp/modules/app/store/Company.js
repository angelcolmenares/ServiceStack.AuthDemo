Ext.define('AD.store.Company', {
    extend: 'Aicl.data.Store',
    model:  'AD.model.Company',
    
    constructor: function(config){
    	config= config|| {};
    	config.storeId= config.storeId||'Company';   	
    	if (arguments.length==0 )
    		this.callParent([config]);
    	else
    		this.callParent(arguments); 
    }
});
