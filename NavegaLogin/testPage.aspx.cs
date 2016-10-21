using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ssoData;
using ssoSeguridad;
using System.Net;
using System.Collections.Specialized;


namespace NavegaLogin
{
    public partial class testPage : System.Web.UI.Page
    {
        private clsOperadorDB odb = new clsOperadorDB("seguridad");//using ssoData
        private clsSeguridad oseg;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            this.lblMensaje.Visible = false;
            oseg = new clsSeguridad(MapPath("") + "\\ssonp.eif");
            //oseg.Ip = IP();
            odb.CargaInfoSSO(MapPath("") + "\\ssonp.eif", "ssNavega");

            string query = "";
            string usuario = txtUsuario.Text.Trim();            

            if (!string.IsNullOrEmpty(usuario))//solo valido el usuario
            {
                query = "SELECT CodUsuario FROM CTL_EMPLEADO where CodUsuario=" + clsOperadorDB.scm(usuario) + " AND ActivoInactivo='S'";
                query = odb.EjecutaEscalar(query);

                //validando que el usuario ya tenga pregunta secrete registrada
                if (query == usuario)
                {
                    //verificar si tiene pregunta registrada
                    int tienePregunta = 0;
                    query = "SELECT count(1) FROM CTL_PREGUNTA where CodUsuario=" + clsOperadorDB.scm(usuario);
                    

                    //ejecutar consulta de la autenticación
                    try
                    {
                        //asigno total de usuarios existentes a variable tienePregunta
                        tienePregunta = Convert.ToInt32(odb.EjecutaEscalar(query));
                    }
                    catch (Exception ex)
                    {
                        ctlMensaje.AutoShow = true;
                        //oseg.IngresoBitacora(usuario, "AUTENTICACION", "No existe tipo de autenticación al usuario deseado");
                        ctlMensaje.mMensaje("Sucedio un error al buscar pregunta usuario", PruebaMe.BoTipoMensaje.tError);
                        return;
                    }

                    //comprobar que tipo de autenticación tiene
                    switch (tienePregunta)
                    {
                        case 1: //caso 1 si tiene pregunta
                            
                                ctlMensaje.AutoShow = true;
                                
                                ctlMensaje.mMensaje("Redireccionando a reseteo de clave aspx", PruebaMe.BoTipoMensaje.tCorrecto);
                                lblMensaje.Visible = true;
                                lblMensaje.Text = "ingreso a case 1";
                                Response.Redirect("respondePregunta.aspx?txtUsuario="+txtUsuario.Text);
                                /*var dato = new NameValueCollection();
                                dato["user"] = txtUsuario.Text;
                                using (var wb = new WebClient()) 
                                wb.UploadValues("respondePregunta.aspx", "POST", dato);*/

                                break;
                        case 0: 
                            //caso 0 no tiene pregunta, debe registrarla
                            //autenticacionDominio();
                            lblMensaje.Text = "ingreso a case 0";
                            ctlMensaje.AutoShow = true;
                            ctlMensaje.mMensaje("Su usuario no tiene pregunta secreta", PruebaMe.BoTipoMensaje.tError);
                            Response.Redirect("guardaPregunta.aspx?ref=" + txtUsuario.Text);
                            break;             
                         

                    }//fin switch(tienePregunta)
                } // Valida usuario activo
                else
                {
                    try
                    {
                        string estado = "SELECT ActivoInactivo FROM CTL_EMPLEADO where CodUsuario=" + clsOperadorDB.scm(usuario) + " AND ActivoInactivo='N'";
                        estado = odb.EjecutaEscalar(estado);
                        if (estado == "N")
                        {
                            ctlMensaje.AutoShow = true;
                            ctlMensaje.mMensaje("El Usuario esta bloqueado", PruebaMe.BoTipoMensaje.tError);
                        }
                        else {
                            ctlMensaje.AutoShow = true;
                            ctlMensaje.mMensaje("No se encontro el usuario: " + usuario, PruebaMe.BoTipoMensaje.tError);
                        }
                    }
                    catch (Exception ex){
                        ex.Message.ToString();
                    }
                    
                }
            }
            else
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("Debe indicar un usuario", PruebaMe.BoTipoMensaje.tError);
            }

        }

        //metodo para autenticar por medio de navega+
        public void autenticacionNavega()
        {
            //comprobar aqui si existe clave temporal a travez de clsSeguridad
            if (!string.IsNullOrEmpty(txtUsuario.Text))
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje(oseg.DescripcionError, PruebaMe.BoTipoMensaje.tError);
                return;
            }
            else
            {
                Session["nombre"] = oseg.NombreUsuario;
                Session["usuario"] = txtUsuario.Text.ToLower();
                Session["eif"] = MapPath("") + "\\ssonp.eif";

                //comprobando si fue temporal
                if (oseg.CodigoError == -102)
                {
                    Response.Redirect("mensaje.aspx?titulo=Contraseña&mensaje=Su contraseña es temporal, necesita cambiar la contraseña.&pagina=cambioclave.aspx?principal=1");
                }//fin if (oseg.CodigoError = -102)

                //llamar a clsSeguridad y comprobar el timepo de expiración
                if (oseg.comprobarContraseña(txtUsuario.Text))
                {
                    Response.Redirect("mensaje.aspx?titulo=Contraseña&mensaje=Su contraseña ha expirado, cambie su contraseña.&pagina=cambioclave.aspx?principal=1");
                }//fin if(comprobarContraseña)

                //comprobando si hay errores en comprobar contraseña
                if (oseg.CodigoError == -100)
                {
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje(oseg.DescripcionError, PruebaMe.BoTipoMensaje.tError);
                    return;
                }//fin if(oseg.codigoError == -100)

                //comprobando si hay error de cercania de expiración de contraseña
                if (oseg.CodigoError == -105)
                {
                    Response.Redirect("mensaje.aspx?titulo=Contraseña&mensaje=expirado, " + oseg.DescripcionError + ".&pagina=principal.aspx?principal=1");
                }//fin if(oseg.codigoError = -105)

                //eliminar los intentos
                Session.Remove(txtUsuario.Text);
                string numeroIntentos = "UPDATE CTL_EMPLEADO SET NumeroIntentos = 0 WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
                odb.EjecutaSql(numeroIntentos);
                Response.Redirect("principal.aspx");
            }
        }//fin metodo autenticacionNavega

    }
}
