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
	/// Summary description for SeleccionAplicacion.
	/// </summary>
	public partial class SeleccionAplicacion : System.Web.UI.Page
	{
		private string codpais="";
		private clsSeguridad cs;
		protected clsValidaSesion vs=new clsValidaSesion();
		protected string esventana="";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			vs.ValidaSesion();
			cs=new clsSeguridad(vs.PathEIF);
			codpais=Request.QueryString["codpais"];
			esventana=Request.QueryString["esventana"];
			if (esventana==null || esventana.Length==0)
			{
				esventana="N";
			}

			if (codpais==null || codpais.Length==0)
			{
				Response.Redirect("error.aspx?errd=Acceso no autorizado.");
			}
			if (!IsPostBack)
			{
				if (cs.ObtieneAplicaciones(vs.Usuario,codpais))
				{
					if (cs.DTAplicaciones.Rows.Count==1)
					{
						Response.Redirect("PasaAplicacion.aspx?codempresa="+cs.DTAplicaciones.Rows[0]["codempresa"].ToString()+"&codaplicacion="+cs.DTAplicaciones.Rows[0]["codaplicacion"].ToString());
					}
					else
					{
						if (esventana=="S")
						{
							foreach(DataRow dr in cs.DTAplicaciones.Rows)
							{
								TableRow tr=new TableRow();
								TableCell tc= new TableCell();
								HyperLink hp=new HyperLink();
								hp.BorderWidth=Unit.Pixel(0);
								hp.ImageUrl=dr["imagen"].ToString();
								hp.Target="contenido";
								hp.NavigateUrl="PasaAplicacion.aspx?codempresa="+dr["codempresa"].ToString()+"&codaplicacion="+dr["codaplicacion"].ToString();
								hp.Attributes.Add("onClick","closeRemote();");
								tc.Controls.Add(hp);
								tr.Cells.Add(tc);
								Tabla.Rows.Add(tr);
							}
						}
						else
						{
							DisplayPopup("seleccionaplicacion.aspx?esventana=S&codpais="+codpais,"width=250,height=250,toolbar=no,resizable=no,scrollbars=yes");
						}
					}
				}
				else
				{
					TableRow tx=new TableRow();
					TableCell tcx=new TableCell();
					System.Web.UI.WebControls.Image myimg=new System.Web.UI.WebControls.Image();
					myimg.ImageUrl="images/noacceso2.gif";
					myimg.Attributes.Add("onClick","closeRemote();");
					tcx.Controls.Add(myimg);
					tx.Cells.Add(tcx);
					Tabla.Rows.Add(tx);
				}
			}
		}

		private void DisplayPopup(string url, string options)
		{
			RegisterStartupScript(Guid.NewGuid().ToString(), "<script language='JavaScript'>"+GetPopupScript(url, options)+ "</script>");
		}

		private string  GetPopupScript(string url,string options)
		{
			return "var w = window.open('" + url + "', null, '"+ options + "');";
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
