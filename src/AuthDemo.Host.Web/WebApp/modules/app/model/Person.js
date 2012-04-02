Ext.define('AD.model.Person',{
	extend: 'Ext.data.Model',
	idProperty: 'Id',
    fields:[
    	{name: 'Id', type:'int'},
    	{name: 'Name', type:'string'},
    	{name: 'BirthCityId', type:'int'},
    	{name: 'JobCityId', type:'int'},
    	{name: 'PhotoFileName', type:'string'}
    ]
});

