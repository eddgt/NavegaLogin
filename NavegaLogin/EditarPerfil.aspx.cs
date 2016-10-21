using System;
using System.Collections;
using System.Collections.Generic;
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
using DevExpress.Web.ASPxGridView;
using ssoData;

namespace NavegaLogin
{
    public partial class EditarPerfil : System.Web.UI.Page
    {
        List<Object> lista_TipoAutenticacion;
        List<Object> lista_usuarios;
        private clsValidaSesion vs = new clsValidaSesion();
        private clsOperadorDB odb = new clsOperadorDB("sysnavega");

        protected override void OnPreInit(EventArgs e)
        {
            //base.OnPreInit(e);
            //vs.ValidaSesion();
            //odb.NombreConexion = "sysnavega";
            //odb.CargaInfoSSO(this.MapPath("..") + "\\ssonp.eif", "ssNavega");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("error.aspx?errd=Pagina no autorizada.");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ASPxGV_Usuarios.Selection.Count == 0)
            {
                ASPxGV_Usuarios.Selection.SelectAll();
            }

           else ASPxGV_Usuarios.Selection.UnselectAll();

        }

        protected void ASPxGV_Usuarios_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView usuarios = (ASPxGridView)sender;

           lista_usuarios =usuarios.GetSelectedFieldValues("CodUsuario");
        }




        protected void ASPxGV_TipoAutenticacion_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView TipoAutenticacion = (ASPxGridView)sender;

            lista_TipoAutenticacion = TipoAutenticacion.GetSelectedFieldValues("CodTipoAut");

        }

        protected void ASPxButton_aceptar_Click(object sender, EventArgs e)
        {
            
            String codigotipo;
            String codigousuario;
            String respuesta;
            string qry;
            lista_usuarios = ASPxGV_Usuarios.GetSelectedFieldValues("CodUsuario");
            lista_TipoAutenticacion = ASPxGV_TipoAutenticacion.GetSelectedFieldValues("CodTipoAut");

            if (verifica())
            {

                foreach (object k in lista_TipoAutenticacion)
                {
                    codigotipo = k.ToString();

                    foreach (object j in lista_usuarios)
                    {
                        codigousuario = j.ToString();
                        respuesta = codigotipo + " " + codigousuario;
                        qry = "exec sso_seg_insertatipoautenticacion " + "'" + codigousuario + "'" + "," + codigotipo + "," + "'S'";
                        odb.EjecutaSql(qry);
                        string error = odb.DescripcionError;
                    }

                }
                

            }

            else { lbl_error.Text = "Debe elegir por lo menos 1 usuario y 1 Tipo de Auntenticacion."; }
            ASPxPC_TipoAutenticacion.ShowOnPageLoad = false;
            limpiar();
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            ASPxPC_TipoAutenticacion.ShowOnPageLoad = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            lbl_Empresa.Text = DDL_Empresa.SelectedValue.ToString();
        }

        public bool verifica()//metodo que verifica que por lo menos se eliga 1 usuario y 1 tipo de autenticacion
        {
            if (ASPxGV_Usuarios.Selection.Count == 0 || ASPxGV_TipoAutenticacion.Selection.Count == 0)
            {
                return false;
            }
            else { return true; };
        }

        public void limpiar()
        {
            ASPxGV_Usuarios.Selection.UnselectAll();
            ASPxGV_TipoAutenticacion.Selection.UnselectAll();
        }

        protected void ASPxButton_canelar_Click(object sender, EventArgs e)
        {
            ASPxPC_TipoAutenticacion.ShowOnPageLoad = false;
        }

 

        protected void ASPxGV_Detalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            string llave = (sender as ASPxGridView).GetMasterRowKeyValue().ToString();
            lbl_Usuario.Text = llave;
        }

    }
}
