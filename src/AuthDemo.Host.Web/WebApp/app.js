Ext.require(['*']);
Ext.onReady(function() {

	Aicl.Util.setUrlApi(location.protocol + "//" + location.host + '/api');
	Aicl.Util.setHttpUrlApi(location.protocol + "//" + location.host + '/api'+'/json/asynconeway')
	Aicl.Util.setPhotoDir(location.protocol + "//" + location.host +  '' + location.pathname+ 'photos');
	Aicl.Util.setEmptyImgUrl('../../resources/icons/fam/user.png');
	
	var loginPath = '/auth/credentials';
	var logoutPath = '/auth/logout';

	var buttons = [];
	var i = 0;
	var grupos = [{
				title : 'Companies',
				dir : 'company'
			}, {
				title : 'Countries',
				dir : 'country'
			}, {
				title : 'Cities',
				dir : 'city'
			}, {
				title : 'Persons',
				dir : 'person'
			}, {
				title : 'Authors',
				dir : 'author'
			}, {
				title : 'UserAuth',
				dir : 'userAuth'
			}];
	for (var grupo in grupos) {
		buttons[i] = Ext.create('Ext.Button', {
					text : grupos[grupo].title,
					directory : grupos[grupo].dir,
					scale : 'large',
					handler : function() {
						Ext.getDom('iframe-win').src = 'modules/'
								+ this.directory;
					}
				});
		i++;
	};

	var loginButton = Ext.create('Ext.Button', {
				text : 'Login',
				scale : 'large',
				disabled : Aicl.Util.isAuth(),
				handler : function() {
					login();

				}
			});

	buttons[i++] = loginButton;

	var logoutButton = Ext.create('Ext.Button', {
				text : 'Logout',
				scale : 'large',
				disabled : !Aicl.Util.isAuth(),
				handler : function() {
					logout();
				}
			});

	buttons[i] = logoutButton;

	Ext.create('Ext.Viewport', {
				layout : {
					type : 'border',
					padding : 5
				},
				defaults : {
					split : true
				},
				items : [{
							region : 'west',
							layout : 'fit',
							items : [{
										layout : {
											type : 'vbox',
											align : 'stretch'
										},
										defaults : {
											margins : '5 5 5 5'
										},
										items : buttons
									}],
							collapsible : true,
							split : true,
							width : '20%'
						}, {
							region : 'center',
							layout : 'fit',
							items : [{
										xtype : "component",
										id : 'iframe-win',
										autoEl : {
											tag : "iframe",
											src : "intro.html"
										}
									}]
						}]
			});

	var formLogin = Ext.create('Ext.form.Panel', {
		frame : true,
		bodyStyle : 'padding:5px 5px 0',
		fieldDefaults : {
			msgTarget : 'side',
			labelWidth : 75
		},
		defaultType : 'textfield',
		defaults : {
			anchor : '100%'
		},

		items : [{
					fieldLabel : 'User Name',
					name : 'UserName',
					allowBlank : false
				}, {
					fieldLabel : 'Password',
					name : 'Password',
					inputType : 'password',
					allowBlank : false
				}],

		buttons : [{
			text : 'Login',
			formBind : true,
			handler : function() {

				var form = this.up('form').getForm();
				var record = form.getFieldValues();
				Aicl.Util.executeRestRequest({
					url : Aicl.Util.getUrlApi() + loginPath,
					method : 'get',
					success : function(result) {
						Aicl.Util.setAuth(true);
						logoutButton.setDisabled(false);
						loginButton.setDisabled(true);
						windowLogin.hide();
						var ifr = Ext.getDom('iframe-win').contentWindow;
						ifr.document.open();
						ifr.document.write('Welcome : '
								+ result.UserName);
						ifr.document.close();
					},
					failure : function(response, options) {
						console.log(arguments);
					},
					params : record
				});
			}
		}]

	});

	var windowLogin = Ext.create('Ext.Window', {
				title : 'Login',
				closable : true,
				closeAction : 'hide',
				height : 150,
				width : 300,
				layout : 'fit',
				modal : true,
				y : 65,
				items : [formLogin]
			});

	var login = function() {
		windowLogin.show();
	}

	var logout = function() {

		Aicl.Util.executeRestRequest({
					url : Aicl.Util.getUrlApi() + logoutPath,
					method : 'POST',
					callback : function(result, success) {
						Aicl.Util.setAuth(false);
						logoutButton.setDisabled(true);
						loginButton.setDisabled(false);
						var ifr = Ext.getDom('iframe-win').contentWindow;
						ifr.document.open();
						ifr.document.write('by');
						ifr.document.close();
					}
				});
	}

});

// {"ResponseStatus":{"ErrorCode":"Invalid UserName or
// Password","Message":"Invalid UserName or Password","Errors":[]}}
// {"SessionId":"1","UserName":"admin","ResponseStatus":{}}

