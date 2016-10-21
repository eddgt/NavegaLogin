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
using ssoData;

namespace NavegaLogin
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
	public partial class Forma : System.Web.UI.Page
	{
        private clsSesionAD LogInAD = new clsSesionAD();
        private clsOperadorDB odb = new clsOperadorDB("seguridad");

		protected void Page_Load(object sender, System.EventArgs e)
		{
            txtUsuario.Focus();
		}
        		
        protected void cmdAcepta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.lblMensaje.Visible = false;
            clsSeguridad oseg = new clsSeguridad(MapPath("") + "\\ssonp.eif");
            odb.CargaInfoSSO(MapPath("") + "\\ssonp.eif", "ssNavega");

            //modificacion para llenar espacios en blanco
            int r = txtClave.Text.Trim().Length % 4;

            if (!string.IsNullOrEmpty(txtUsuario.Text)
                && !string.IsNullOrEmpty(txtClave.Text))
            {
                /*bool utilizaAD = false;
                string sqry = "select utilizaAD from ctl_empleado where codUsuario = "
                    + clsOperadorDB.scm(txtUsuario.Text);
                try
                {
                    utilizaAD = Convert.ToBoolean(odb.EjecutaEscalar(sqry));
                }
                catch { }

                if (utilizaAD)
                {
                    sqry = "select a.usuarioDominio, b.dominio from ctl_empleado a ";
                    sqry += "inner join ctl_Dominio b on a.codDominio = b.codDominio ";
                    sqry += "where a.codUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
                    odb.ConsultaSql(sqry, "dom");
                    if (string.IsNullOrEmpty(odb.DescripcionError))
                    {
                        if (odb.DS.Tables["dom"].Rows.Count > 0)
                        {
                            DataRow dr = odb.DS.Tables["dom"].Rows[0];
                            LogInAD._Dominio = dr["dominio"].ToString();
                            if (LogInAD.Loguearse(dr["usuarioDominio"].ToString(), txtClave.Text))
                            {
                                Session["nombre"] = txtUsuario.Text.ToLower();
                                Session["usuario"] = txtUsuario.Text.ToLower();
                                Session["eif"] = MapPath("") + "\\ssonp.eif";

                                if (txtClave.Text.IndexOf("navega", 0) >= 0 || txtClave.Text.Length < 5)
                                {
                                    if (txtClave.Text.IndexOf("navega", 0) >= 0)
                                    {
                                        Response.Redirect("mensaje.aspx?titulo=Contraseña&mensaje=Su contraseña es muy comun por favor de clic en continuar para cambiarla.&pagina=cambioclave.aspx?principal=1");
                                    }
                                    if (txtClave.Text.Length < 5)
                                    {
                                        Response.Redirect("mensaje.aspx?titulo=Contraseña&mensaje=Su contraseña no cumple con la longitud minima, por favor de clic en continuar para cambiarla.&pagina=cambioclave.aspx?principal=1");
                                    }
                                }

                                Response.Redirect("principal.aspx");
                            }
                            else
                            {
                                ctlMensaje.AutoShow = true;
                                ctlMensaje.mMensaje(LogInAD.Error, PruebaMe.BoTipoMensaje.tError);
                            }
                        }
                        else
                        {
                            ctlMensaje.AutoShow = true;
                            ctlMensaje.mMensaje("Usuario/Contraseña incorrecta o su usuario aun no ha sido configurado para loguearse con Active Directory", PruebaMe.BoTipoMensaje.tError);
                        }
                    }
                    else
                    {
                        ctlMensaje.AutoShow = true;
                        ctlMensaje.mMensaje(odb.DescripcionError, PruebaMe.BoTipoMensaje.tError);
                    }
                }
                else
                {*/
                    if (!oseg.Valida(txtUsuario.Text, txtClave.Text))
                    {
                        ctlMensaje.AutoShow = true;
                        ctlMensaje.mMensaje(oseg.DescripcionError, PruebaMe.BoTipoMensaje.tError);
                    }
                    else
                    {
                        Session["nombre"] = oseg.NombreUsuario;
                        Session["usuario"] = txtUsuario.Text.ToLower();
                        Session["eif"] = MapPath("") + "\\ssonp.eif";

                        if (txtClave.Text.IndexOf("navega", 0) >= 0 || txtClave.Text.Length < 5)
                        {
                            if (txtClave.Text.IndexOf("navega", 0) >= 0)
                            {
                                Response.Redirect("mensaje.aspx?titulo=Contraseña&mensaje=Su contraseña es muy comun por favor de clic en continuar para cambiarla.&pagina=cambioclave.aspx?principal=1");
                            }
                            if (txtClave.Text.Length < 5)
                            {
                                Response.Redirect("mensaje.aspx?titulo=Contraseña&mensaje=Su contraseña no cumple con la longitud minima, por favor de clic en continuar para cambiarla.&pagina=cambioclave.aspx?principal=1");
                            }
                        }

                        Response.Redirect("principal.aspx");
                    }
                /*}*/
            }
            else
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("Debe ingresar su usuario y contraseña", PruebaMe.BoTipoMensaje.tError);
            }
        }		

	}
}
