using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ssoData;
using ssoSeguridad;
using System.Net;

namespace NavegaLogin
{
    public partial class Bloqueo_Usuario : System.Web.UI.Page
    {
        private clsOperadorDB odb = new clsOperadorDB("sysnavega");
        private clsSeguridad oseg;
        private clsValidaSesion vs = new clsValidaSesion();

        protected void Page_Load(object sender, EventArgs e)
        {
            vs.ValidaSesion();
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            string qry;
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            qry = "SELECT Nombres FROM CTL_EMPLEADO WHERE Bloqueado = 'S' AND CodUsuario = " + txt_usuario.Text;
            lbl_nombre.Text = odb.EjecutaEscalar(qry).ToString();
            qry = "SELECT Apellidos FROM CTL_EMPLEADO WHERE Bloqueado = 'S' AND CodUsuario = " + txt_usuario.Text;
            lbl_apellido.Text = odb.EjecutaEscalar(qry).ToString();
            //bool b6 = "HoWdY".Equals("howdy", StringComparison.OrdinalIgnoreCase);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            oseg = new clsSeguridad(MapPath("") + "\\ssonp.eif");
            oseg.Ip = IP();
            oseg.IngresoBitacora(txt_usuario.Text, "CLAVE_TEMPORAL", "No existe tipo de autenticación al usuario deseado");
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
