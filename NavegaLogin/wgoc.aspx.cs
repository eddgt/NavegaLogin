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
using ssoData;

namespace NavegaLogin
{
	/// <summary>
	/// Summary description for wgoc.
	/// </summary>
	public partial class wgoc : System.Web.UI.Page
	{
		protected string pais;
		protected string usuario;
		protected clsOperadorDB odb;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			usuario=Request.QueryString["us"];
			pais=Request.QueryString["pa"];
			if (usuario==null || pais==null || usuario.Length==0 || pais.Length==0)
			{
				EscribeMensaje("ERROR","NULL");
			}
			else
			{
				odb=new clsOperadorDB("inventario_"+pais);
				odb.CargaInfoSSO(MapPath("")+"\\ssonp.eif","ssNavega");
			}
		}

		private void EscribeMensaje(string presultado, string pdato)
		{
			string msgrespuesta="";
			msgrespuesta+="<RESPUESTA>";
			msgrespuesta+="<RESULTADO>"+presultado+"</RESULTADO>";
			msgrespuesta+="<DATO>"+pdato+"</DATO>";
			msgrespuesta+="</RESPUESTA>";
			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType="text/xml";
			Response.Write(msgrespuesta);
			Response.End();				
		}

		private void AutorizacionesPendientes()
		{
			string cantidad="";
			cantidad=odb.EjecutaEscalar("select count(*) from AUTORIZACIONES_PENDIENTES where u_ssousuario="+clsOperadorDB.scm(usuario));
			EscribeMensaje("OK",cantidad);
		}


		private void SolicitudesOCPendientes()
		{
			string cantidad="";
			cantidad=odb.EjecutaEscalar("SELECT count(*) FROM [@SSO_PROVEEDORESNOHOMOLOGADOS] WHERE (Estado = 'JI')");
			EscribeMensaje("OK",cantidad);
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
