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
	/// Summary description for PasaAplicacion.
	/// </summary>
	public partial class PasaAplicacion : System.Web.UI.Page
	{
		protected clsValidaSesion vs=new clsValidaSesion();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			vs.ValidaSesion();
			string ids=Session.SessionID+DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()+DateTime.Now.Second.ToString();
			string codempresa=Request.QueryString["codempresa"];
			string codaplicacion=Request.QueryString["codaplicacion"];
			if (codempresa==null || codaplicacion==null || codempresa.Length==0 || codaplicacion.Length==0)
			{
				Response.Redirect("error.aspx?errd=Acceso no autorizado");
			}
			clsSeguridad seg=new clsSeguridad(vs.PathEIF);
			seg.RegistraAcceso(vs.Usuario,codempresa,codaplicacion,ids,Request.UserHostAddress);
			string urlx=seg.URLAplicacion(codempresa,codaplicacion);
			urlx+="?ids="+ids;
			RegisterStartupScript(Guid.NewGuid().ToString(), "<script language='JavaScript'>parent.location='"+urlx+"'</script>");
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
