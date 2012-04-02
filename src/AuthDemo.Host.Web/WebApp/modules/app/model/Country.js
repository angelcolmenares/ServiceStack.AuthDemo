Ext.define('AD.model.Country',{
	extend: 'Ext.data.Model',
	idProperty: 'Id',
    fields:[
    	{name: 'Id', type:'int'},
    	{name: 'Name', type:'string'},
    	{name: 'Continent', type:'string'}
    ]
});
