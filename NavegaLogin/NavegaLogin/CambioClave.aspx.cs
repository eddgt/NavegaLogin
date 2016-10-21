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
	/// Summary description for CambioClave.
	/// </summary>
	public partial class CambioClave : System.Web.UI.Page
	{
		private clsValidaSesion vs=new clsValidaSesion();
		private string principal="";
		private clsSeguridad oseg;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			vs.ValidaSesion();
			oseg=new clsSeguridad(vs.PathEIF);
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

		protected void btnCancelar_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("principal.aspx");
		}

		protected void btnAceptar_Click(object sender, System.EventArgs e)
		{
			vs.ValidaSesion();
			if (txtNueva1.Text==txtNueva2.Text && txtNueva1.Text.Trim().Length>0 && txtNueva2.Text.Trim().Length>0)
			{
				if (oseg.CambioClave(vs.Usuario,txtActual.Text,txtNueva1.Text))
				{
					Response.Redirect("mensaje.aspx?titulo=Cambio de Clave&mensaje=Clave modificada exitosamente.");
				}
				else
				{
					Response.Redirect("error.aspx?errd="+oseg.DescripcionError);
				}
				
			}
			else
			{
				Response.Redirect("Error.aspx?errd=La clave nueva y su confirmacion no son iguales.");
			}
		}

		
	}
}
