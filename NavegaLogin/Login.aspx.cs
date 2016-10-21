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
using ssoSeguridad;
using System.Net;

namespace NavegaLogin
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
	public partial class Forma : System.Web.UI.Page
	{
        private clsSesionAD LogInAD = new clsSesionAD();
        private clsOperadorDB odb = new clsOperadorDB("seguridad");
        private clsSeguridad oseg;
        private clsValidaSesion vs = new clsValidaSesion();

		protected void Page_Load(object sender, System.EventArgs e)
		{
            txtUsuario.Focus();
		}

        protected string IP_Local()
        {
            string localIP = Request.UserHostAddress;
            string IP = Request.ServerVariables["REMOTE_ADDR"];
            if (IP == "127.0.0.1")// || IP.Contains("192.168.")) // == "192.168.115.1")    //Esta es la ip de la Wireless              
                return localIP;
            return IP;
        }
        protected string IP()
        {
            string Host = IP_Local();

            if (Host == "127.0.0.1")// || Host.Contains("192.168.")) // == "192.168.115.1")
            {
                IPHostEntry IPs = Dns.GetHostByName(Dns.GetHostName());
                IPAddress[] Direcciones = IPs.AddressList;

                //Se despliega la lista de IP's
                for (int i_cont = 0; i_cont < Direcciones.Length; i_cont++)
                {
                    if (Direcciones[i_cont].ToString() != "127.0.0.1" && Direcciones[i_cont].AddressFamily.ToString() == "InterNetwork") //&& !Direcciones[i_cont].ToString().Contains("192.168.")
                        Host = Direcciones[i_cont].ToString();
                    i_cont += 1;
                }
                if (Host == "127.0.0.1")// || Host.Contains("192.168.")) // == "192.168.115.1")
                    Host = "";
            }
            return Host;
        }



        protected void cmdAcepta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.lblMensaje.Visible = false;
            oseg = new clsSeguridad(MapPath("") + "\\ssonp.eif");
            oseg.Ip = IP();
            odb.CargaInfoSSO(MapPath("") + "\\ssonp.eif", "ssNavega");

            //modificacion para llenar espacios en blanco
            int r = txtClave.Text.Trim().Length % 4;

            string query = "";

            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtClave.Text))
            {
                query = "select ActivoInactivo from CTL_EMPLEADO where CodUsuario=" + clsOperadorDB.scm(txtUsuario.Text);
                query = odb.EjecutaEscalar(query);
                if (query == "S")
                {
                    //verificar que tipo de autenticación tiene el usuario
                    int tipAut = -1;
                    query = "SELECT CodTipoAut FROM SEG_EMPLEADO_TIPOAUTENTICACION WHERE Activo = 'S' and CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text) + "";

                    //ejecutar consulta de la autenticación
                    try
                    {
                        tipAut = Convert.ToInt32(odb.EjecutaEscalar(query));
                    }
                    catch (Exception ex)
                    {
                        ctlMensaje.AutoShow = true;
                        oseg.IngresoBitacora(txtUsuario.Text, "AUTENTICACION", "No existe tipo de autenticación al usuario deseado");
                        ctlMensaje.mMensaje("No existe tipo de autenticación al usuario deseado", PruebaMe.BoTipoMensaje.tError);
                        return;
                    }

                    //comprobar que tipo de autenticación tiene
                    switch (tipAut)
                    {
                        case 1: //autenticacion por medio de navega plus                        
                            //verificación de que el usuario no este bloqueado
                            if (oseg.comprobarBloqueoUsuario(txtUsuario.Text))
                            {
                                ctlMensaje.AutoShow = true;
                                oseg.IngresoBitacora(txtUsuario.Text, "BLOQUEADO", "El usuario esta bloqueado, porfavor consulte con el administrador");
                                ctlMensaje.mMensaje("Usuario bloqueado por exceder máximo número de intentos. Contacte con HelpDesk para desbloquear.", PruebaMe.BoTipoMensaje.tError);
                                //ctlMensaje.mMensaje("El usuario esta bloqueado, porfavor consulte con el administrador", PruebaMe.BoTipoMensaje.tError);
                                return;
                            }//fin si esta bloqueado el usuario
                            if (oseg.CodigoError == -101)
                            {
                                ctlMensaje.AutoShow = true;
                                ctlMensaje.mMensaje(oseg.DescripcionError, PruebaMe.BoTipoMensaje.tError);
                                return;
                            }
                            autenticacionNavega();
                            break;
                        case 2: //autenticación por medio de dominio
                            autenticacionDominio();
                            break;
                    }//fin switch(tipAut)
                } // Valida usuario activo
                else
                {
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje("Su usuario no tiene acceso autorizado al sistema, favor de tramitar por medio de RRHH.", PruebaMe.BoTipoMensaje.tError);
                }
            }
            else
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("Debe ingresar su usuario y contraseña", PruebaMe.BoTipoMensaje.tError);
            }

            //obteniendo el parametro de intentos de acceso por parte del usuario
            query = "SELECT TOP 1 NoIntentos FROM SSO_PARAMETROS";
            int intentos = 0;
            try
            {
                intentos = Convert.ToInt32(odb.EjecutaEscalar(query));
            }
            catch (Exception ex)
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("No existe configuración de parametros, notifique al administrador", PruebaMe.BoTipoMensaje.tError);
                return;
            }
            
            string numeroIntentos = "SELECT NumeroIntentos FROM CTL_EMPLEADO WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
            //int intent = Convert.ToInt32(Session[txtUsuario.Text].ToString());//sustituir por una consulta
            int intent = 0;
            try
            {
                intent = Convert.ToInt32(odb.EjecutaEscalar(numeroIntentos));
            }
            catch (Exception exx)
            {
                intent = 0;
            }
                
            //poner el if aqui, si la consulta del numero de intentos trae algo sigo con el try
            try
            {
                //incrementa el número de intentos                
                intent += 1; //le sumo al camp 1 intento (guardar en un int)
                if (intent == intentos)//si el numero de intentos que lleva el usuario es igual al parametro
                {
                    //bloquear usuario
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    query = "UPDATE CTL_EMPLEADO SET FechaTemp = getdate() " + // clsOperadorDB.scm(System.DateTime.Now.ToString()) +
                            ", Bloqueado = 'S' WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    odb.EjecutaSql(query);
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje("Usuario bloqueado por exceder máximo número de intentos. Contacte con HelpDesk para desbloquear.", PruebaMe.BoTipoMensaje.tError);
                    oseg.bloquearUsuario(txtUsuario.Text);
                    return;
                }//fin if intent = intento
            }
            catch (Exception ex)
            {
                intent = 1;
            }
            // Session[txtUsuario.Text] = intent; //guardar en la base de datos
            numeroIntentos = "UPDATE CTL_EMPLEADO SET NumeroIntentos = " + intent.ToString() + " WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
            odb.EjecutaSql(numeroIntentos);
        }		

        //metodo para autenticar por medio de navega+
        public void autenticacionNavega()
        {
            //comprobar aqui si existe clave temporal a travez de clsSeguridad
            if (!oseg.Valida(txtUsuario.Text, txtClave.Text))
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

        public void autenticacionDominio()
        {
            string sqry = "select a.usuarioDominio, b.dominio from ctl_empleado a ";
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

                        //Se agrego para que no lo bloqueara
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        string query = "UPDATE CTL_EMPLEADO SET Bloqueado = 'N', NumeroIntentos=0 WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        odb.EjecutaSql(query);

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
        //fin autenticacion dominio

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Visible = false;
            oseg = new clsSeguridad(MapPath("") + "\\ssonp.eif");
            oseg.Ip = IP();
            odb.CargaInfoSSO(MapPath("") + "\\ssonp.eif", "ssNavega");

            //modificacion para llenar espacios en blanco
            int r = txtClave.Text.Trim().Length % 4;

            string query = "";

            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtClave.Text))
            {
                query = "select ActivoInactivo from CTL_EMPLEADO where CodUsuario=" + clsOperadorDB.scm(txtUsuario.Text);
                query = odb.EjecutaEscalar(query);
                if (query == "S")
                {
                    //verificar que tipo de autenticación tiene el usuario
                    int tipAut = -1;
                    query = "SELECT CodTipoAut FROM SEG_EMPLEADO_TIPOAUTENTICACION WHERE Activo = 'S' and CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text) + "";

                    //ejecutar consulta de la autenticación
                    try
                    {
                        tipAut = Convert.ToInt32(odb.EjecutaEscalar(query));
                    }
                    catch (Exception ex)
                    {
                        ctlMensaje.AutoShow = true;
                        oseg.IngresoBitacora(txtUsuario.Text, "AUTENTICACION", "No existe tipo de autenticación al usuario deseado");
                        ctlMensaje.mMensaje("No existe tipo de autenticación al usuario deseado", PruebaMe.BoTipoMensaje.tError);
                        return;
                    }

                    //comprobar que tipo de autenticación tiene
                    switch (tipAut)
                    {
                        case 1: //autenticacion por medio de navega plus                        
                            //verificación de que el usuario no este bloqueado
                            if (oseg.comprobarBloqueoUsuario(txtUsuario.Text))
                            {
                                ctlMensaje.AutoShow = true;
                                oseg.IngresoBitacora(txtUsuario.Text, "BLOQUEADO", "El usuario esta bloqueado, porfavor consulte con el administrador");
                                ctlMensaje.mMensaje("Usuario bloqueado por exceder máximo número de intentos. Contacte con HelpDesk para desbloquear.", PruebaMe.BoTipoMensaje.tError);
                                //ctlMensaje.mMensaje("El usuario esta bloqueado, porfavor consulte con el administrador", PruebaMe.BoTipoMensaje.tError);
                                return;
                            }//fin si esta bloqueado el usuario
                            if (oseg.CodigoError == -101)
                            {
                                ctlMensaje.AutoShow = true;
                                ctlMensaje.mMensaje(oseg.DescripcionError, PruebaMe.BoTipoMensaje.tError);
                                return;
                            }
                            autenticacionNavega();
                            break;
                        case 2: //autenticación por medio de dominio
                            autenticacionDominio();
                            break;
                    }//fin switch(tipAut)
                } // Valida usuario activo
                else
                {
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje("Su usuario no tiene acceso autorizado al sistema, favor de tramitar por medio de RRHH.", PruebaMe.BoTipoMensaje.tError);
                }
            }
            else
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("Debe ingresar su usuario y contraseña", PruebaMe.BoTipoMensaje.tError);
            }

            //obteniendo el parametro de intentos de acceso por parte del usuario
            query = "SELECT TOP 1 NoIntentos FROM SSO_PARAMETROS";
            int intentos = 0;
            try
            {
                intentos = Convert.ToInt32(odb.EjecutaEscalar(query));
            }
            catch (Exception ex)
            {
                ctlMensaje.AutoShow = true;
                ctlMensaje.mMensaje("No existe configuración de parametros, notifique al administrador", PruebaMe.BoTipoMensaje.tError);
                return;
            }

            string numeroIntentos = "SELECT NumeroIntentos FROM CTL_EMPLEADO WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
            //int intent = Convert.ToInt32(Session[txtUsuario.Text].ToString());//sustituir por una consulta
            int intent = 0;
            try
            {
                intent = Convert.ToInt32(odb.EjecutaEscalar(numeroIntentos));
            }
            catch (Exception exx)
            {
                intent = 0;
            }

            //poner el if aqui, si la consulta del numero de intentos trae algo sigo con el try
            try
            {
                //incrementa el número de intentos                
                intent += 1; //le sumo al camp 1 intento (guardar en un int)
                if (intent == intentos)//si el numero de intentos que lleva el usuario es igual al parametro
                {
                    //bloquear usuario
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    query = "UPDATE CTL_EMPLEADO SET FechaTemp = getdate() " + // clsOperadorDB.scm(System.DateTime.Now.ToString()) +
                            ", Bloqueado = 'S' WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    odb.EjecutaSql(query);
                    ctlMensaje.AutoShow = true;
                    ctlMensaje.mMensaje("Usuario bloqueado por exceder máximo número de intentos. Contacte con HelpDesk para desbloquear.", PruebaMe.BoTipoMensaje.tError);
                    oseg.bloquearUsuario(txtUsuario.Text);
                    return;
                }//fin if intent = intento
            }
            catch (Exception ex)
            {
                intent = 1;
            }
            // Session[txtUsuario.Text] = intent; //guardar en la base de datos
            numeroIntentos = "UPDATE CTL_EMPLEADO SET NumeroIntentos = " + intent.ToString() + " WHERE CodUsuario = " + clsOperadorDB.scm(txtUsuario.Text);
            odb.EjecutaSql(numeroIntentos);
        }

	}
}
