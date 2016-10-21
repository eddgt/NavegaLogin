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
	/// Summary description for clsValidaSesion.
	/// </summary>
	public class clsValidaSesion : System.Web.UI.Page
	{

		private string usuario="";
		private int nivel=0;
		private string nombre="";
		private string patheif="";


		public string NombreUsuario
		{
			get { return nombre; }
		}

		public string Usuario
		{
			get { return usuario; }
		}

		public string PathEIF
		{
			get { return patheif; }
		}

		public clsValidaSesion()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void ValidaSesion()
		{
			
			try
			{
				if (Session["usuario"].ToString()=="" || Session["usuario"]==null)
				{
					Server.Transfer("pgfinsession.aspx");
				}
				else
				{
					this.usuario=Session["usuario"].ToString();
					this.nombre=Session["nombre"].ToString();
					this.patheif=Session["eif"].ToString();
				}
			}
			catch
			{
				Server.Transfer("pgfinsession.aspx");
			}
		}
	}
}
