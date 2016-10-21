using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavegaLogin;
using ssoData;

namespace NavegaLogin
{
    public partial class guardaPregunta : System.Web.UI.Page
    {
        private clsOperadorDB odb = new clsOperadorDB("seguridad");//using ssoData
        private clsSeguridad oseg;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Request.QueryString["ref"];
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //this.lblMensaje.Visible = false;
            oseg = new clsSeguridad(MapPath("") + "\\ssonp.eif");
            //oseg.Ip = IP();
            odb.CargaInfoSSO(MapPath("") + "\\ssonp.eif", "ssNavega");

            string xusr = txtUsuario.Text.Trim();
            string xpre = rbtnPreguntas.Text.Trim();
            string xresp = txtRespuesta.Text.Trim();

            if (!string.IsNullOrEmpty(xusr) && !string.IsNullOrEmpty(xpre) && !string.IsNullOrEmpty(xresp))
                {
                    try
                    {
                        string query = "INSERT INTO CTL_PREGUNTA ( Pregunta ,Respuesta ,CodUsuario) VALUES(";
                        query += clsOperadorDB.scm(xpre) + ", " + clsOperadorDB.scm(xresp) + ", " + clsOperadorDB.scm(xusr) + ")";

                        odb.EjecutaSql(query);
                        ctlMensaje.AutoShow = true;
                        ctlMensaje.mMensaje("Cambio realizado correctamente ", PruebaMe.BoTipoMensaje.tCorrecto);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setTimeout(function(){ window.location.href = 'respondePregunta.aspx?txtUsuario="+xusr+"'; }, 3000);", true);
                    }
                    catch (Exception ex)
                    {
                        ctlMensaje.AutoShow = true;
                        ctlMensaje.mMensaje("Ocurrio una excepcion! ", PruebaMe.BoTipoMensaje.tError);
                        ex.ToString();
                    }
                }
                else {
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje("Deben llenar todos los campos! ", PruebaMe.BoTipoMensaje.tError);
                }
        }

        protected void insPregunta(string xuser, string xpregunta, string xrespuesta)
        {


            odb.CargaInfoSSO(MapPath("") + "\\ssonp.eif", "ssNavega");
            

            if (!string.IsNullOrEmpty(xuser) && !string.IsNullOrEmpty(xpregunta) && !string.IsNullOrEmpty(xrespuesta))
            {
                try
                {
                    string query = "INSERT INTO CTL_PREGUNTA ( Pregunta ,Respuesta ,CodUsuario) VALUES(";
                    query += clsOperadorDB.scm(xpregunta) + ", " + clsOperadorDB.scm(xrespuesta) + ", " + clsOperadorDB.scm(xuser) + ")";

                    odb.EjecutaSql(query);


                }
                catch (Exception ex)
                {
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje("Ocurrio una excepcion! ", PruebaMe.BoTipoMensaje.tError);
                    ex.ToString();
                }

            }
            else
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("El parametros no pueden ser vacios! ", PruebaMe.BoTipoMensaje.tError);

            }
        }

    }
}
