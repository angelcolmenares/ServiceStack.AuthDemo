Ext.define('AD.model.Company',{
	extend: 'Ext.data.Model',
	idProperty: 'Id',
    fields:[
    	{name: 'Id', type:'int'},
    	{name: 'Name', type:'string'},
    	{name: 'Turnover', type:'number'},
    	{name: 'Started' ,  type :'date', 
    			convert: function(v){ return  Aicl.Util.convertToDate(v)}},  				
    	{name: 'Employees' ,  type:'int'},
    	{name: 'CreatedDate' ,  type :'date', 
    	   		convert: function(v){ return  Aicl.Util.convertToDate(v)}},
    	{name: 'Guid' ,  type:'string'}
    ]
    
});
