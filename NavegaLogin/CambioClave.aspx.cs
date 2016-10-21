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
using System.Net;

namespace NavegaLogin
{
	/// <summary>
	/// Summary description for CambioClave.
	/// </summary>
	public partial class CambioClave : System.Web.UI.Page
	{
		private clsValidaSesion vs=new clsValidaSesion();
        private clsOperadorDB odb = new clsOperadorDB("seguridad");
		private string principal="";
		private clsSeguridad oseg;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			vs.ValidaSesion();
			oseg=new clsSeguridad(vs.PathEIF);
            Informacion();
		}
        protected void Informacion()
        {
            odb.CargaInfoSSO(MapPath("") + "\\ssonp.eif", "ssNavega");
            string nivel = "";
            string query = "Select NivelPass from SSO_PARAMETROS ";
            nivel = odb.EjecutaEscalar(query);
            query = "select 'Nivel ' + Nombre + ':' from SSO_NivelPass where CodNivel=" + Convert.ToInt16(nivel);
            query = odb.EjecutaEscalar(query);
            lblReglas.Text = query;
            query = "select Decripcion from SSO_NivelPass where CodNivel=" + Convert.ToInt16(nivel);
            query = odb.EjecutaEscalar(query);
            lblReglas.Text += " " + query;
            query = "Select LongitudPass from SSO_PARAMETROS ";
            query = odb.EjecutaEscalar(query);
            lblReglas.Text += " La cantidad minima de caracteres es: " + Convert.ToInt16(query);
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

		protected void btnCancelar_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("principal.aspx");
		}

		protected void btnAceptar_Click(object sender, System.EventArgs e)
		{
			vs.ValidaSesion();
			if (txtNueva1.Text==txtNueva2.Text && txtNueva1.Text.Trim().Length>0 && txtNueva2.Text.Trim().Length>0)
			{
                oseg.Ip = IP();
				if (oseg.CambioClave(vs.Usuario,txtActual.Text,txtNueva1.Text))
				{
                    //eliminar los intentos
                    string numeroIntentos = "UPDATE CTL_EMPLEADO SET NumeroIntentos = 0 WHERE CodUsuario = " + clsOperadorDB.scm(vs.Usuario.ToString());
                    odb.EjecutaSql(numeroIntentos);
                    
                    oseg.IngresoBitacora(vs.Usuario.ToString(), "CAMBIO_CLAVE", "No existe tipo de autenticación al usuario deseado");
					Response.Redirect("mensaje.aspx?titulo=Cambio de Clave&mensaje=Clave modificada exitosamente.");
				}
				else
				{
					Response.Redirect("error.aspx?errd="+oseg.DescripcionError);
				}				
			}
			else
			{
				Response.Redirect("Error.aspx?errd=La clave nueva y su confirmacion no son iguales.");
			}
		}
        public string IP_Local()
        {
            string localIP = Request.UserHostAddress;
            string IP = Request.ServerVariables["REMOTE_ADDR"];
            if (IP == "127.0.0.1")// || IP.Contains("192.168.")) // == "192.168.115.1")                
                return localIP;
            return IP;
        }
        public string IP()
        {
            string Host = IP_Local();

            if (Host == "127.0.0.1")// || Host.Contains("192.168.")) // == "192.168.115.1")
            {
                IPHostEntry IPs = Dns.GetHostByName(Dns.GetHostName());
                IPAddress[] Direcciones = IPs.AddressList;

                //Se despliega la lista de IP's
                for (int i_cont = 0; i_cont < Direcciones.Length; i_cont++)
                {
                    if (Direcciones[i_cont].ToString() != "127.0.0.1" && Direcciones[i_cont].AddressFamily.ToString() == "InterNetwork") // && !Direcciones[i_cont].ToString().Contains("192.168.")
                        Host = Direcciones[i_cont].ToString();
                    i_cont += 1;
                }
                if (Host == "127.0.0.1")// || Host.Contains("192.168.")) // == "192.168.115.1")
                    Host = "";
            }
            return Host;
        }

		
	}
}
