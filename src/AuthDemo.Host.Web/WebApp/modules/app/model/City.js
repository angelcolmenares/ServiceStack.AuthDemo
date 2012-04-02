Ext.define('AD.model.City',{
	extend: 'Ext.data.Model',
	idProperty: 'Id',
    fields:[
    	{name: 'Id', type:'int'},
    	{name: 'Name', type:'string'},
    	{name: 'Population', type:'int'},
    	{name: 'CountryId', type:'int'}
    ]
});

