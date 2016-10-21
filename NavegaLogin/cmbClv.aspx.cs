using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using System.Threading;

namespace NavegaLogin
{
    public partial class cmbClv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUser.Text = Request.QueryString["txtUsuario"];
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPass.Text))
            {
            //Trust all certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (se, cert, chain, sslerror) =>
                {
                    return true;
                };
            try
            {
                //invoke the web service reference            
                WebReference.Service1 wr = new WebReference.Service1();

                //set the variables
                string usr = txtUser.Text;
                string psw = txtPass.Text;
                string wsusr = "pruebas";
                string wspsw = "pruebas";

                //call ws Method that we need            
                wr.CambioClave(wsusr, wspsw, usr, psw);

                lblMensaje.Visible = true;
                lblMensaje.Text = "Se cambio tu contraseña correctamente";
                lblMensaje2.Visible = true;
                lblMensaje2.Text = "Redirigiendo a login... ";
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "history.go(-(history.length - 1));", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setTimeout(function(){  var Backlen=history.length;   history.go(-Backlen); window.location.href = 'https://172.16.5.19/navegalogin/Login.aspx'; }, 3000);", true);
                txtPass.Enabled = false;

            }
            catch (Exception ex){
                ex.Message.ToString();
            }

            }
            else{
                lblMensaje.Text = "Usuario y Contraseña son obligatorios";
            }
        }
    }
}
