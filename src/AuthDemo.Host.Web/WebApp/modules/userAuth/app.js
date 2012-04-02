Ext.require(['*']);
Ext.onReady(function() {
		
	Ext.create('Ext.form.Panel', {
		frame: true,
        renderTo: 'module',
		layout : 'fit',
		height : 850,
		width:950,
		items : [{
			xtype : "component",
			id : 'response-win',
			autoEl : {
				tag : "iframe"
			}
		}]
	});
	
	Ext.getBody().mask('Loading...', 'x-mask-loading', false);

	Ext.Ajax.request({
                url: Aicl.Util.getUrlApi() + '/UserAuth?format=html',              
                success: function(response, opts) {
                	var ifr = Ext.getDom('response-win').contentWindow;
                	ifr.document.open();
					ifr.document.write(response.responseText);
					ifr.document.close();	
                },
                failure: function(response, options) {  
					Aicl.Util.msg('Error', 'Error!!!');
                },
                callback: function(options, success, response) {
                	Ext.getBody().unmask();
                }
            });

});

// {"ResponseStatus":{"ErrorCode":"Invalid UserName or
// Password","Message":"Invalid UserName or Password","Errors":[]}}
// {"SessionId":"1","UserName":"admin","ResponseStatus":{}}

