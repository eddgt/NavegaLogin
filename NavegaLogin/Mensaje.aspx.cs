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
	/// Summary description for Mensaje.
	/// </summary>
	public partial class Mensaje : System.Web.UI.Page
	{
		string paginadestino="", paginasi="", paginano="";
		string dato1="", dato2="", dato3="", dato4="";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			lblTitulo.Text=Request.QueryString["titulo"];
			lblMensaje.Text=Request.QueryString["mensaje"];

			lblTitulo2.Text=Request.QueryString["titulo2"];

			
			this.lblTitulo2.Visible = false;
			this.btnSI.Visible = false;
			this.btnNO.Visible = false;

			try
			{
				paginadestino=Request.QueryString["pagina"];
				if (paginadestino ==null)
				{
					paginadestino="principal.aspx";
				}
			}
			catch
			{
				paginadestino="principal.aspx";
			}

			try
			{
				paginasi=Request.QueryString["paginasi"];
				if (paginasi ==null)
				{
					paginasi="principal.aspx";
				}
			}
			catch
			{
				paginasi="principal.aspx";
			}

			try
			{
				paginano=Request.QueryString["paginano"];
				if (paginano ==null)
				{
					paginano="principal.aspx";
				}
			}
			catch
			{
				paginano="principal.aspx";
			}

			if (this.lblTitulo2.Text != "")
			{
				this.lblTitulo2.Visible = true;
				this.btnSI.Visible = true;
				this.btnNO.Visible = true;
			}


			try
			{
				dato1=Request.QueryString["dato1"];
				if (dato1 ==null)
				{
					dato1="";
				}
			}
			catch
			{
				dato1="";
			}

			try
			{
				dato2=Request.QueryString["dato2"];
				if (dato2 ==null)
				{
					dato2="";
				}
			}
			catch
			{
				dato2="";
			}

			try
			{
				dato3=Request.QueryString["dato3"];
				if (dato3 ==null)
				{
					dato3="";
				}
			}
			catch
			{
				dato3="";
			}

			try
			{
				dato4=Request.QueryString["dato4"];
				if (dato4 ==null)
				{
					dato4="";
				}
			}
			catch
			{
				dato4="";
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(paginadestino);
		}

		protected void btnSI_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(paginasi+"&"+dato1+"&"+dato2+"&"+dato3+"&"+dato4);
		}

		protected void btnNO_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(paginano);
		}
	}
}
