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
	/// Summary description for widgetlg.
	/// </summary>
	public partial class widgetlg : System.Web.UI.Page
	{
		string usuario="";
		string clave="";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			usuario=Request.QueryString["us"];
			clave=Request.QueryString["pc"];
			if (clave==null || usuario==null ||clave.Length==0 || usuario.Length==0)
			{
				EscribeMensaje("ERROR","0","LOGIN INCORRECTO");
			}
			else
			{
				clsSeguridad oseg=new clsSeguridad(MapPath("")+"\\ssonp.eif");
				if (!oseg.Valida(usuario,clave))
				{
					EscribeMensaje("ERROR","0",oseg.DescripcionError);
				}
				else
				{
					EscribeMensaje("OK",Session.SessionID,oseg.NombreUsuario);
				}
			}
		}

		private void EscribeMensaje(string presultado, string pidsession, string pmensaje)
		{
			string msgrespuesta="";
			msgrespuesta+="<RESPUESTA>";
			msgrespuesta+="<RESULTADO>"+presultado+"</RESULTADO>";
			msgrespuesta+="<IDS>"+pidsession+"</IDS>";
			msgrespuesta+="<MENSAJE>"+pmensaje+"</MENSAJE>";
			msgrespuesta+="</RESPUESTA>";
			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType="text/xml";
			Response.Write(msgrespuesta);
			Response.End();				
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
