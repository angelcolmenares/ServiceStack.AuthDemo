using System;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace AuthDemo.Host.Web
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string redirect= ConfigurationManager.AppSettings.Get("RedirectTo");
			if(!string.IsNullOrEmpty(redirect))
				Response.Redirect(redirect);
		}		
		
	}
}

