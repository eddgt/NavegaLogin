using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ssoData;

namespace NavegaLogin
{
    public partial class respondePregunta : System.Web.UI.Page
    {
        private clsOperadorDB odb = new clsOperadorDB("seguridad");//using ssoData
        private clsSeguridad oseg;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Request.QueryString["txtUsuario"];
        }

        protected void btnResponder_Click(object sender, EventArgs e)
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
                    string query = "SELECT count(*) FROM  CTL_PREGUNTA WHERE CodUsuario =";
                    query += clsOperadorDB.scm(xusr) ;
                    query += "AND Pregunta = " +clsOperadorDB.scm(xpre) ;
                    query += "AND Respuesta = " + clsOperadorDB.scm(xresp);

                    int tienePregunta = Convert.ToInt32(odb.EjecutaEscalar(query));
                    
                    if(tienePregunta>0){

                        Response.Redirect("cmbClv.aspx?txtUsuario="+xusr);
                    }else{
                        ctlMensaje.AutoShow = true;                        
                        ctlMensaje.mMensaje("Selecciona tu pregunta correcta e indica la respuesta! ", PruebaMe.BoTipoMensaje.tError);
                    }
                }
                catch (Exception ex)
                {
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje("Ocurrio una excepcion al buscar Pregunta ", PruebaMe.BoTipoMensaje.tError);
                    ex.ToString();
                }
            }
            else
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("Debe llenar todos los campos! ", PruebaMe.BoTipoMensaje.tError);
            }
        }
    }
}
