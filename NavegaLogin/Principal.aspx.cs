using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace NavegaLogin
{
    public partial class Principal : System.Web.UI.Page
    {
        protected clsValidaSesion vs = new clsValidaSesion();
        protected clsSeguridad os;

        protected void Page_Load(object sender, EventArgs e)
        {
            vs.ValidaSesion();
            os = new clsSeguridad(vs.PathEIF);
            if (os.ObtieneAplicaciones(vs.Usuario))
            {
                if (os.DTAplicaciones.Rows.Count == 1)
                {
                    Response.Redirect("PasaAplicacion.aspx?codempresa=" + os.DTAplicaciones.Rows[0]["codempresa"].ToString() + "&codaplicacion=" + os.DTAplicaciones.Rows[0]["codaplicacion"].ToString());
                }
                else
                {
                    lblSaludo.Text = "Bienvenido(a) " + vs.NombreUsuario;
                    string pPaisAnterior = "";
                    bool pPrimero = true;
                    StringBuilder sbSlides = new StringBuilder();
                    StringBuilder sbMenu = new StringBuilder();
                    foreach (DataRow dr in os.DTAplicaciones.Rows)
                    {
                        if (pPaisAnterior != dr["CodPais"].ToString())
                        {

                            if (!pPrimero)
                            {
                                sbSlides.Append("</td><td><img src=\"images/mapas/" + pPaisAnterior + ".jpg\" width=\"300\" height=\"230\" alt=\"side\" /></td></tr>");
                                sbSlides.Append("</table></div></div>");
                            }
                            pPrimero = false;
                            sbMenu.Append("<li class=\"menuItem\"><a href=\"\"><img width=\"32\" height=\"32\" title=\"" + dr["Pais"].ToString() + "\" src=\"images/banderas/" + dr["CodPais"].ToString() + ".png\" alt=\"thumbnail\" /></a></li>");
                            pPaisAnterior = dr["CodPais"].ToString();
                            sbSlides.Append("<div class=\"slide\">");
                            sbSlides.Append("<div width=\"920\" height=\"400\">");
                            sbSlides.Append("<table border=\"0\" width=\"920\" height=\"400\">");
                            sbSlides.Append("<tr><td colspan=\"2\" align=\"center\" style=\"height:60px;\"><img src=\"images/titulo_" + dr["CodPais"].ToString() + ".jpg\" alt=\"side\" /></td></tr>");
                            sbSlides.Append("<tr><td style=\"width:500px;\">");
                            sbSlides.Append("<a href=\"PasaAplicacion.aspx?codempresa=" + dr["codempresa"].ToString() + "&codaplicacion=" + dr["codaplicacion"].ToString() + "\"><img src=\"" + dr["Imagen"].ToString() + "\" width=\"300\" height=\"30\" alt=\"side\" /></a><br/><br/>");
                            //"PasaAplicacion.aspx?codempresa="+os.DTAplicaciones.Rows[0]["codempresa"].ToString()+"&codaplicacion="+os.DTAplicaciones.Rows[0]["codaplicacion"].ToString()
                        }
                        else
                        {
                            sbSlides.Append("<a href=\"PasaAplicacion.aspx?codempresa=" + dr["codempresa"].ToString() + "&codaplicacion=" + dr["codaplicacion"].ToString() + "\"><img src=\"" + dr["Imagen"].ToString() + "\" width=\"300\" height=\"30\" alt=\"side\" /></a><br/><br/>");
                        }

                    }

                    sbSlides.Append("</td><td><img src=\"images/mapas/" + pPaisAnterior + ".jpg\" width=\"300\" height=\"230\" alt=\"side\" /></td></tr>");
                    sbSlides.Append("</table></div></div>");

                    Literal1.Text = sbSlides.ToString();
                    Literal2.Text = sbMenu.ToString();

                }
            }
            else
            {
                Response.Redirect("error.aspx?errd=Su usuario no tiene perfil asignado para utiliza la aplicacion.");
            }
            
            

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}
