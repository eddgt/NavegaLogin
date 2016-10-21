using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NavegaLogin
{
	/// <summary>
	/// Summary description for pgfinsession.
	/// </summary>
	public partial class pgfinsession : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Request.QueryString["tipo"]=="1")
			{
				Label1.Text="";
				Label2.Text="";
				Label3.Text="";
				Session.Abandon();
			}
			else
			{
				Label1.Text="Esto pudo suceder por las siguientes razones:";
				Label2.Text=" - No ha inciado sesión.";
				Label3.Text=" - Ha estado inactivo durante más de 20 minutos.";
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
