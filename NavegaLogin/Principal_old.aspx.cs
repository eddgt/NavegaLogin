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
using ssoSeguridad;

namespace NavegaLogin
{
	/// <summary>
	/// Summary description for Principal.
	/// </summary>
	public partial class Principal_old : System.Web.UI.Page
	{
		protected clsValidaSesion vs=new clsValidaSesion();
		protected clsSeguridad os;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			vs.ValidaSesion();
			os=new clsSeguridad(vs.PathEIF);
			if(os.ObtieneAplicaciones(vs.Usuario))
			{
				if (os.DTAplicaciones.Rows.Count==1)
				{
					Response.Redirect("PasaAplicacion.aspx?codempresa="+os.DTAplicaciones.Rows[0]["codempresa"].ToString()+"&codaplicacion="+os.DTAplicaciones.Rows[0]["codaplicacion"].ToString());
				}
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
