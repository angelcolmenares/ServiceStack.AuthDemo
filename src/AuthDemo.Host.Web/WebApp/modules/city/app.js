Ext.Loader.setConfig({enabled: true});
Ext.Loader.setPath('AD', '../app');
Ext.require([	'Ext.tip.*']);
   
    Ext.QuickTips.init();
    
    Ext.application({
    name: 'AD',
    appFolder: '../app',
 
    launch: function() {
        Ext.create('Ext.form.Panel', {
    	width:950,
        id:'panelModule',
        baseCls:'x-plain',
        frame: false,
        renderTo: 'module',
        layout: {
            type: 'table',
            columns: 2
        },
        items:[
        	{xtype:'citylist'},
        	{
				xtype:'panel',
				height:352,
				width:340,
				baseCls:'x-plain',
				layout: {
       				type: 'vbox'       
    			},
				items:[
					{ xtype:'cityform'}
				]	
			},
			{xtype:'personlist'},
        	{
				xtype:'panel',
				height:352,
				width:340,
				baseCls:'x-plain',
				layout: {
       				type: 'vbox'       
    			},
				items:[
					{ xtype:'personform'},
					{ xtype:'photoform'}
				]	
			}
        ]
    });
    },
    controllers: ['City' ]
    
});
	    
