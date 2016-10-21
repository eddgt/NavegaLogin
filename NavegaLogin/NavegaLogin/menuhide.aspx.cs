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
	/// Summary description for menuhide.
	/// </summary>
	public partial class menuhide : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Session["oculto"]="N";
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

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Session["oculto"].ToString()=="N")
			{
				RegisterStartupScript(Guid.NewGuid().ToString(), "<script language='JavaScript'>if(document.body)parent.document.body.cols='0,20,*'</script>");
				Session["oculto"]="S";
			}
			else
			{
				RegisterStartupScript(Guid.NewGuid().ToString(), "<script language='JavaScript'>if(document.body)parent.document.body.cols='184,20,*'</script>");
				Session["oculto"]="N";
			}
			RegisterStartupScript(Guid.NewGuid().ToString(), "<script language='JavaScript'>parent.frames(0).location='multipais.aspx'</script>");
		}
	}
}
