using System;
using System.Data;
using ssoData;
//using System.Windows.Forms;
using ssoEncrypt;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;

namespace ssoSeguridad
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class clsSeguridad
	{

        private int intentos = 0; //lleva los intentos que tiene el usuario que esta accesando a la aplicación
		private string usuario="";
		private string clave="";
		private string codempresa="";
		private string nombreusuario="";
		private string nombreempresa="";
		private string codaplicacion="";
		private DataTable dtMenus =new DataTable();
		private DataTable dtAplicaciones =new DataTable();
		private clsOperadorDB odb=new clsOperadorDB("seguridad");
		private clsEncrypt oen=new clsEncrypt("ssNavega");
		private string descripcionerror="";
		private double codigoerror=0;
		private string patheif="";
		private string codempresaerp="";
		protected string codpuesto="";
		protected string descpuesto="";
		protected string nombres="";
		protected string apellidos="";
		protected string activo="";
		protected string observacion="";
		protected string codorganizacion="";
		protected string descorganizacion="";
		protected string correo="";
		protected string pathimagen="";
		protected string pathfirma="";
		protected Image imagen=null;
		protected Image firma=null;
		protected string extensionFirma="";
		protected string extensionImagen="";
		protected int nivel=0;
        private static Random random = new Random(0);
          
        public string user = "";
        public int emp = 0;

        public string CodEmpresaERP
        {
            get { return codempresaerp; }
        }

        public string Clave
        {
            set { clave = value; }
        }

        public string CodEmpresa
        {
            get { return codempresa; }
        }

        public string NombreEmpresa
        {
            get { return nombreempresa; }
        }

        public string CodUsuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string NombreUsuario
        {
            get { return nombreusuario; }
        }

        public string CodAplicacion
        {
            get { return codaplicacion; }
        }

        public string DescripcionError
        {
            get { return descripcionerror; }
        }

        public double CodigoError
        {
            get { return codigoerror; }
        }

        public DataTable DTMenus
        {
            get { return dtMenus; }
        }

        public DataTable DTAplicaciones
        {
            get { return dtAplicaciones; }
        }

        public int Nivel
        {
            get { return nivel; }
        }

        public Image Imagen
        {
            get { return this.imagen; }
        }

        public Image Firma
        {
            get { return this.firma; }
        }

        public string CodPuesto
        {
            set { this.codpuesto = value; }
            get { return this.codpuesto; }
        }

        public string DescPuesto
        {
            get { return this.descpuesto; }
        }

        public string Nombres
        {
            set { this.nombres = value; }
            get { return this.nombres; }
        }

        public string Apellidos
        {
            set { this.apellidos = value; }
            get { return this.apellidos; }
        }

        public string Activo
        {
            set { this.activo = value; }
            get { return this.activo; }
        }

        public string Observacion
        {
            set { this.observacion = value; }
            get { return this.observacion; }
        }

        public string codOrganizacion
        {
            set { this.codorganizacion = value; }
            get { return this.codorganizacion; }
        }

        public string DescOrganizacion
        {
            get { return this.descorganizacion; }
        }

        public string Correo
        {
            set { this.correo = value; }
            get { return this.correo; }
        }

        public string ExtensionFirma
        {
            set { this.extensionFirma = value; }
            get { return this.extensionFirma; }
        }

        public string ExtensionImagen
        {
            set { this.extensionImagen = value; }
            get { return this.extensionImagen; }
        }



        //constructor
        public clsSeguridad(string peif)
        {
            odb.CargaInfoSSO(peif, "ssNavega");
            patheif = peif;
        }

        public bool MenusUsuario(string pCodEmpresa, string pCodAplicacion, string pCodUsuario)
        {
            string sqry = "";
            /*
			sqry+="SELECT     CTL_MENUS.CodEmpresa, CTL_MENUS.CodAplicacion, CTL_MENUS.IdMenu, CTL_MENUS.IndicePadre, CTL_MENUS.IndiceMenu, ";
			sqry+="CTL_MENUS.PadreWeb, CTL_MENUS.IndiceWeb, CTL_MENUS.Descripcion, CTL_MENUS.Pagina, CTL_MENUS.Target ";
			sqry+="FROM         CTL_ROL_MENU INNER JOIN ";
			sqry+="CTL_ROL_USUARIO ON CTL_ROL_MENU.CodEmpresa = CTL_ROL_USUARIO.CodEmpresa AND ";
			sqry+="CTL_ROL_MENU.CodAplicacion = CTL_ROL_USUARIO.CodAplicacion AND CTL_ROL_MENU.CodRol = CTL_ROL_USUARIO.CodRol INNER JOIN ";
			sqry+="CTL_EMPLEADO ON CTL_ROL_USUARIO.CodUsuario = CTL_EMPLEADO.CodUsuario INNER JOIN ";
			sqry+="CTL_MENUS ON CTL_ROL_MENU.CodEmpresa = CTL_MENUS.CodEmpresa AND CTL_ROL_MENU.CodAplicacion = CTL_MENUS.CodAplicacion AND  ";
			sqry+="CTL_ROL_MENU.IdMenu = CTL_MENUS.IdMenu ";
			sqry+="WHERE CTL_EMPLEADO.CodUsuario = "+clsOperadorDB.scm(pCodUsuario)+" and ctl_menus.codempresa="+pCodEmpresa+" and ctl_menus.codaplicacion="+clsOperadorDB.scm(pCodAplicacion);
			sqry+=" AND CTL_MENUS.ACTIVOINACTIVO='S' ";
			sqry+="ORDER BY CTL_MENUS.IndicePadre, CTL_MENUS.IndiceMenu, CTL_MENUS.PadreWeb, CTL_MENUS.IndiceWeb ";
            */

            sqry = "exec menus " + clsOperadorDB.scm(pCodUsuario) + ", " + clsOperadorDB.scm(pCodAplicacion) + ", " + pCodEmpresa;

            odb.ConsultaSql(sqry, "menu");
            if (odb.DS.Tables["menu"].Rows.Count > 0)
            {
                dtMenus = odb.DS.Tables["menu"].Copy();
                codigoerror = 0;
                descripcionerror = "";
                return true;
            }
            else
            {
                dtMenus = new DataTable();
                this.codigoerror = 99;
                this.descripcionerror = "No tiene acceso a ningun menu de esta aplicacion.";
                return false;
            }
        }

        public bool ValidaSesion(string pSesion)
        {
            odb.ConsultaSql("select codusuario, codempresa, codaplicacion, activa from SEG_LOGINCONTROL WHERE Idsesion=" + clsOperadorDB.scm(pSesion) + " order by fecha desc", "u");
            if (odb.DS.Tables["u"].Rows.Count > 0)
            {
                if (odb.DS.Tables["u"].Rows[0]["activa"].ToString() == "S")
                {
                    this.codempresa = odb.DS.Tables["u"].Rows[0]["codempresa"].ToString();
                    this.usuario = odb.DS.Tables["u"].Rows[0]["codusuario"].ToString();
                    this.codaplicacion = odb.DS.Tables["u"].Rows[0]["codaplicacion"].ToString();
                    this.nombreusuario = odb.EjecutaEscalar("select nombres+' '+apellidos from ctl_empleado where codusuario=" + clsOperadorDB.scm(usuario));
                    this.codempresaerp = odb.EjecutaEscalar("select codempresaerp from ctl_empresa where codempresa=" + codempresa);
                    this.codigoerror = 0;
                    this.descripcionerror = "";
                    return true;
                }
                else
                {
                    this.codigoerror = 99;
                    this.descripcionerror = "Id no valido.";
                    return false;
                }
            }
            else
            {
                this.codigoerror = 99;
                this.descripcionerror = "Id no valido.";
                return false;
            }
        }

        public bool ValidaSesion(string pSesion, string pCodApp)
        {
            odb.ConsultaSql("select codusuario, codempresa, codaplicacion, activa from SEG_LOGINCONTROL WHERE codaplicacion" + clsOperadorDB.scm(pCodApp) + " and Idsesion=" + clsOperadorDB.scm(pSesion) + " order by fecha desc", "u");
            if (odb.DS.Tables["u"].Rows.Count > 0)
            {
                if (odb.DS.Tables["u"].Rows[0]["activa"].ToString() == "S")
                {
                    this.codempresa = odb.DS.Tables["u"].Rows[0]["codempresa"].ToString();
                    this.usuario = odb.DS.Tables["u"].Rows[0]["codusuario"].ToString();
                    this.codaplicacion = odb.DS.Tables["u"].Rows[0]["codaplicacion"].ToString();
                    this.nombreusuario = odb.EjecutaEscalar("select nombres+' '+apellidos from ctl_empleado where codusuario=" + clsOperadorDB.scm(usuario));
                    this.codempresaerp = odb.EjecutaEscalar("select codempresaerp from ctl_empresa where codempresa=" + codempresa);
                    this.codigoerror = 0;
                    this.descripcionerror = "";
                    return true;
                }
                else
                {
                    this.codigoerror = 99;
                    this.descripcionerror = "Id no valido.";
                    return false;
                }
            }
            else
            {
                this.codigoerror = 99;
                this.descripcionerror = "Id no valido.";
                return false;
            }
        }

        public bool ValidaSesion(string pSesion, string pCodApp, string pCodEmpresa)
        {
            odb.ConsultaSql("select codusuario, codempresa, codaplicacion, activa from SEG_LOGINCONTROL WHERE Codempresa=" + pCodEmpresa + " and codaplicacion" + clsOperadorDB.scm(pCodApp) + " and Idsesion=" + clsOperadorDB.scm(pSesion) + " order by fecha desc", "u");
            if (odb.DS.Tables["u"].Rows.Count > 0)
            {
                if (odb.DS.Tables["u"].Rows[0]["activa"].ToString() == "S")
                {
                    this.codempresa = odb.DS.Tables["u"].Rows[0]["codempresa"].ToString();
                    this.usuario = odb.DS.Tables["u"].Rows[0]["codusuario"].ToString();
                    this.codaplicacion = odb.DS.Tables["u"].Rows[0]["codaplicacion"].ToString();
                    this.nombreusuario = odb.EjecutaEscalar("select nombres+' '+apellidos from ctl_empleado where codusuario=" + clsOperadorDB.scm(usuario));
                    this.codempresaerp = odb.EjecutaEscalar("select codempresaerp from ctl_empresa where codempresa=" + codempresa);
                    this.codigoerror = 0;
                    this.descripcionerror = "";
                    return true;
                }
                else
                {
                    this.codigoerror = 99;
                    this.descripcionerror = "Id no valido.";
                    return false;
                }
            }
            else
            {
                this.codigoerror = 99;
                this.descripcionerror = "Id no valido.";
                return false;
            }
        }

        public bool ObtieneAplicaciones(string pcodusuario)
        {
            string sqry = "";
            sqry += "SELECT     CTL_APLICACION.CodEmpresa, CTL_APLICACION.CodAplicacion, CTL_EMPRESA.Descripcion AS NombreEmpresa, ";
            sqry += "CTL_APLICACION.Descripcion AS NombreAplicacion, CTL_APLICACION.Version, CTL_APLICACION.Imagen ";
            sqry += "FROM         CTL_EMPRESA INNER JOIN ";
            sqry += "CTL_APLICACION ON CTL_EMPRESA.CodEmpresa = CTL_APLICACION.CodEmpresa INNER JOIN ";
            sqry += "CTL_ROL ON CTL_APLICACION.CodEmpresa = CTL_ROL.CodEmpresa AND CTL_APLICACION.CodAplicacion = CTL_ROL.CodAplicacion INNER JOIN ";
            sqry += "CTL_ROL_USUARIO ON CTL_ROL.CodEmpresa = CTL_ROL_USUARIO.CodEmpresa AND ";
            sqry += "CTL_ROL.CodAplicacion = CTL_ROL_USUARIO.CodAplicacion AND CTL_ROL.CodRol = CTL_ROL_USUARIO.CodRol ";
            sqry += "WHERE      (CTL_ROL_USUARIO.CodUsuario = " + clsOperadorDB.scm(pcodusuario) + ") ";
            sqry += "ORDER BY CTL_APLICACION.CodEmpresa, CTL_APLICACION.CodAplicacion ";
            odb.ConsultaSql(sqry, "app");
            try
            {
                if (odb.DS.Tables["app"].Rows.Count > 0)
                {
                    dtAplicaciones = odb.DS.Tables["app"].Copy();
                    return true;
                }
                else
                {
                    dtAplicaciones = new DataTable();
                    return false;
                }
            }
            catch
            {
                dtAplicaciones = new DataTable();
                return false;
            }
        }

        public bool ObtieneAplicaciones(string pcodusuario, string pcodpais)
        {
            string sqry = "";
            sqry += "SELECT     CTL_APLICACION.CodEmpresa, CTL_APLICACION.CodAplicacion, CTL_EMPRESA.Descripcion AS NombreEmpresa, ";
            sqry += "CTL_APLICACION.Descripcion AS NombreAplicacion, CTL_APLICACION.Version, CTL_APLICACION.Imagen ";
            sqry += "FROM         CTL_EMPRESA INNER JOIN ";
            sqry += "CTL_APLICACION ON CTL_EMPRESA.CodEmpresa = CTL_APLICACION.CodEmpresa INNER JOIN ";
            sqry += "CTL_ROL ON CTL_APLICACION.CodEmpresa = CTL_ROL.CodEmpresa AND CTL_APLICACION.CodAplicacion = CTL_ROL.CodAplicacion INNER JOIN ";
            sqry += "CTL_ROL_USUARIO ON CTL_ROL.CodEmpresa = CTL_ROL_USUARIO.CodEmpresa AND ";
            sqry += "CTL_ROL.CodAplicacion = CTL_ROL_USUARIO.CodAplicacion AND CTL_ROL.CodRol = CTL_ROL_USUARIO.CodRol ";
            sqry += "WHERE     (CTL_EMPRESA.CodPais = " + clsOperadorDB.scm(pcodpais) + ") AND (CTL_ROL_USUARIO.CodUsuario = " + clsOperadorDB.scm(pcodusuario) + ") ";
            sqry += "ORDER BY CTL_APLICACION.CodEmpresa, CTL_APLICACION.CodAplicacion ";
            odb.ConsultaSql(sqry, "app");
            try
            {
                if (odb.DS.Tables["app"].Rows.Count > 0)
                {
                    dtAplicaciones = odb.DS.Tables["app"].Copy();
                    return true;
                }
                else
                {
                    dtAplicaciones = new DataTable();
                    return false;
                }
            }
            catch
            {
                dtAplicaciones = new DataTable();
                return false;
            }
        }

        public string URLAplicacion(string pcodempresa, string pcodaplicacion)
        {
            return odb.EjecutaEscalar("select url from ctl_aplicacion where codempresa=" + pcodempresa + " and codaplicacion=" + clsOperadorDB.scm(pcodaplicacion));
        }

        public void RegistraAcceso(string pcodusuario, string pcodempresa, string pcodaplicacion, string pidsesion)
        {
            odb.EjecutaSql("update SEG_LOGINCONTROL Set ACTIVA='N', fechalogout=getdate() where activa='S' and codempresa=" + clsOperadorDB.scm(pcodempresa) + " and codaplicacion=" + clsOperadorDB.scm(pcodaplicacion) + " and codusuario=" + clsOperadorDB.scm(pcodusuario));
            string sqry = "insert into SEG_LOGINCONTROL (codusuario, codempresa, codaplicacion, fecha, idsesion, activa) values (";
            sqry += clsOperadorDB.scm(pcodusuario) + "," + pcodempresa + "," + clsOperadorDB.scm(pcodaplicacion) + ",getdate()," + clsOperadorDB.scm(pidsesion) + ",";
            sqry += "'S')";
            odb.EjecutaSql(sqry);
        }

        public void RegistraAcceso(string pcodusuario, string pcodempresa, string pcodaplicacion, string pidsesion, string pipcliente)
        {
            odb.EjecutaSql("update SEG_LOGINCONTROL Set ACTIVA='N', fechalogout=getdate() where activa='S' and codempresa=" + clsOperadorDB.scm(pcodempresa) + " and codaplicacion=" + clsOperadorDB.scm(pcodaplicacion) + " and codusuario=" + clsOperadorDB.scm(pcodusuario));
            string sqry = "insert into SEG_LOGINCONTROL (codusuario, codempresa, codaplicacion, fecha, idsesion, activa, ipcliente) values (";
            sqry += clsOperadorDB.scm(pcodusuario) + "," + pcodempresa + "," + clsOperadorDB.scm(pcodaplicacion) + ",getdate()," + clsOperadorDB.scm(pidsesion) + ",";
            sqry += "'S'," + clsOperadorDB.scm(pipcliente) + ")";
            odb.EjecutaSql(sqry);
        }

        public bool Valida(string pUsuario, string pClave)
        {

            MemoryStream ms = oen.EncriptaDatos(pClave);
            byte[] ba = ms.ToArray();
            codigoerror = 0;
            descripcionerror = "";

            //comprobar si la contraseña es temporal
            string query = "SELECT ClaveTemporal, FechaTemporal FROM SEG_EMPLEADO_TIPOAUTENTICACION " +
                "WHERE CodUsuario = " + clsOperadorDB.scm(pUsuario) + " AND CodTipoAut = 0";
            odb.ConsultaSql(query, "SEG_EMPLEADO_TIPOAUTENTICACION");
            if (odb.DS.Tables["SEG_EMPLEADO_TIPOAUTENTICACION"].Rows.Count > 0)
            {

                DateTime fechaTemporal = new DateTime();
                //comprobando tiempo activo de la contraseña temporal
                try
                {
                    fechaTemporal =
                        Convert.ToDateTime(odb.DS.Tables["SEG_EMPLEADO_TIPOAUTENTICACION"].Rows[0]["FechaTemporal"]);

                    int count = contarDia(fechaTemporal, System.DateTime.Now);
                    if (count > 1)
                    {

                        codigoerror = 99;
                        descripcionerror = "La contraseña temporal a caducado, por favor solicite otra";
                        this.IngresoBitacora(pUsuario, "LOGIN", "Resultado de Login: " + descripcionerror);
                        return false;

                    }//fin if count<1

                    //comprobando si la contraseña es identica
                    Byte[] passTemporal = new Byte[0];
                    passTemporal =
                        (Byte[])(odb.DS.Tables["SEG_EMPLEADO_TIPOAUTENTICACION"].Rows[0]["ClaveTemporal"]);

                    if (ba.Length == passTemporal.Length)
                    {

                        for (int i = 0; i < ba.Length; i++)
                        {
                            if (ba[i] != passTemporal[i])
                            {

                                codigoerror = 99;
                                descripcionerror = "Usuario o contraseña incorrecta";
                                this.IngresoBitacora(pUsuario, "LOGIN", "Resultado de Login: " + descripcionerror);
                                return false;

                            }//fin comparacion de contraseña
                        }

                    }//fin si las contraseñas tienen el mismo tamaño
                    else
                    {

                        codigoerror = 99;
                        descripcionerror = "Usuario o contraseña incorrecta";
                        this.IngresoBitacora(pUsuario, "LOGIN", "Resultado de Login: " + descripcionerror);
                        return false;

                    }//fin else si las contraseñas tienen el mismo tamaño

                    codigoerror = -102;
                    descripcionerror = "Login correcto con clave temporal";
                    this.IngresoBitacora(pUsuario, "LOGIN", "Resultado de Login: " + descripcionerror);
                    return true;

                }
                catch (Exception ex)
                {

                    /*el error es por la fecha null del temporal lo que indica que
                     * no existe temporal, por eso no hay nada aqui
                    */
                    
                }


            }//fin if conteo de filas
            bool ok = true;
            descripcionerror = "Login Correcto";
            codigoerror = 0;
            odb.ConsultaSql("select palabraclave, activoinactivo from ctl_empleado where codusuario=" + clsOperadorDB.scm(pUsuario), "seg");
            if (odb.DS.Tables["seg"].Rows.Count > 0)
            {
                if (odb.DS.Tables["seg"].Rows[0]["activoinactivo"].ToString() == "S")
                {
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])(odb.DS.Tables["seg"].Rows[0]["palabraclave"]);

                    if (ba.Length == byteBLOBData.Length)
                    {
                        for (int x = 0; x < ba.Length; x++)
                        {
                            if (ba[x] != byteBLOBData[x])
                            {
                                ok = false;
                                descripcionerror = "Usuario o contraseña incorrecta";
                                codigoerror = 99;
                                break;
                            }
                        }
                    }
                    else
                    {
                        ok = false;
                        descripcionerror = "Usuario o contraseña incorrecta";
                        codigoerror = 99;
                    }
                }
                else
                {
                    ok = false;
                    descripcionerror = "Usuario inactivo";
                    codigoerror = 99;
                }
            }
            else
            {
                ok = false;
                descripcionerror = "Usuario o contraseña incorrecta";
                codigoerror = 99;
            }
            //odb.EjecutaSql("exec SSO_INSERTABITACORA "+clsOperadorDB.scm(pUsuario)+",'LOGIN',"+clsOperadorDB.scm("Resultado de Login: "+descripcionerror));
            this.IngresoBitacora(pUsuario, "LOGIN", "Resultado de Login: " + descripcionerror);
            if (ok)
            {
                nombreusuario = odb.EjecutaEscalar("select nombres + ' ' + apellidos from ctl_empleado where codusuario=" + clsOperadorDB.scm(pUsuario));

            }
            return ok;
        }

        public void IngresoBitacora(string pCodUsuario, string pTipo, string pMensaje)
        {
            clsOperadorDB odbxb = new clsOperadorDB("seguridad");
            odbxb.CargaInfoSSO(this.patheif, "ssNavega");
            odbxb.EjecutaSql("exec SSO_INSERTABITACORA " + clsOperadorDB.scm(pCodUsuario) + "," + clsOperadorDB.scm(pTipo) + "," + clsOperadorDB.scm(pMensaje));
        }

        public bool CambioClave(string pcodusuario, string pclaveactual, string pclavenueva)
        {
            bool resultado = true;
            resultado = this.Valida(pcodusuario, pclaveactual);
            if (resultado)
            {


                if ((compruebaNivelPass(pclavenueva, pcodusuario)) && (verificarHistorialPass(pcodusuario,
                    pclavenueva, pclaveactual)))
                {
                    //Actualizacion de la clave
                    clsOperadorDB mydb = new clsOperadorDB("seguridad");
                    mydb.CargaInfoSSO(this.patheif, "ssNavega");
                    MemoryStream ms = oen.EncriptaDatos(pclavenueva);
                    byte[] ba = ms.ToArray();
                    string sqry = "update ctl_empleado set PalabraClave=@File, FechaInicioTemporal = " +
                        " getDate() where codusuario=" + clsOperadorDB.scm(pcodusuario);
                    SqlConnection con = new SqlConnection(mydb.CadenaConexion);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqry, con);
                    cmd.Parameters.Add("@File", ba);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //limpiando la clave temporal
                    string query = "UPDATE SEG_EMPLEADO_TIPOAUTENTICACION SET FechaTemporal = null, " +
                        "ClaveTemporal = null WHERE CodUsuario = " + clsOperadorDB.scm(pcodusuario) +
                        " AND CodTipoAut = 0";
                    odb.EjecutaSql(query);

                    //agregando la clave al historial
                    query = "INSERT INTO SSO_HISTORIAL_PASS(CodUsuario, PalabraClave, Fecha) VALUES( " +
                        clsOperadorDB.scm(pcodusuario) + ", @File, getDate())";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@File", ba);
                    cmd.ExecuteNonQuery();
                    con.Close();


                    codigoerror = 0;
                    descripcionerror = "";
                    this.IngresoBitacora(pcodusuario, "CAMBIO CLAVE", "Resultado del cambio de clave: Contraseña cambiada correctamente.");
                }
                else
                {
                    resultado = false;
                }
            }
            return resultado;
        }

        public bool RestableceClave(string pUsuarioIT, string pCodUsuario, string pClave1, string pClave2)
        {
            bool resultado = true;
            this.codigoerror = 0;
            this.descripcionerror = "";

            if (pClave1 != pClave2)
            {
                resultado = false;
                codigoerror = 99;
                descripcionerror = "La contraseña y su confirmacion no coinciden.";
            }
            else
            {

                if ((compruebaNivelPass(pClave1, pCodUsuario)) && (verificarHistorialPass(pCodUsuario,
                    pClave1, "")))
                {
                    clsOperadorDB mydb = new clsOperadorDB("seguridad");
                    mydb.CargaInfoSSO(this.patheif, "ssNavega");
                    MemoryStream ms = oen.EncriptaDatos(pClave1);
                    byte[] ba = ms.ToArray();
                    string sqry = "update ctl_empleado set PalabraClave=@File, FechaInicioTemporal = " +
                        " getDate() where codusuario=" + clsOperadorDB.scm(pCodUsuario);
                    SqlConnection con = new SqlConnection(mydb.CadenaConexion);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqry, con);
                    cmd.Parameters.Add("@File", ba);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //limpiando la clave temporal
                    string query = "UPDATE SEG_EMPLEADO_TIPOAUTENTICACION SET FechaTemporal = null, " +
                        "ClaveTemporal = null WHERE CodUsuario = " + clsOperadorDB.scm(pCodUsuario) +
                        " AND CodTipoAut = 0";
                    odb.EjecutaSql(query);

                    //agregando la clave al historial
                    query = "INSERT INTO SSO_HISTORIAL_PASS(CodUsuario, PalabraClave, Fecha) VALUES( " +
                        clsOperadorDB.scm(pCodUsuario) + ", @File, getDate())";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@File", ba);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    codigoerror = 0;
                    descripcionerror = "";
                    this.IngresoBitacora(pUsuarioIT, "RESTABLECER CLAVE", "Resultado de restablecer de clave del usuario " + pCodUsuario + ": Contraseña cambiada correctamente.");
                }
                else
                {

                    resultado = false;
                }
            }
            return resultado;
        }

        public bool Buscar(string pCodusuario)
        {
            this.codigoerror = 0;
            this.descripcionerror = "";
            odb.ConsultaSql("select * from CTL_EMPLEADO where codusuario=" + clsOperadorDB.scm(pCodusuario), "informacion");
            if (odb.CodigoError != 0)
            {
                this.descripcionerror = odb.DescripcionError;
                this.codigoerror = odb.CodigoError;
                return false;
            }
            else
            {
                if (odb.DS.Tables["informacion"].Rows.Count < 1)
                {
                    this.descripcionerror = "El usuario no existe";
                    this.codigoerror = -2;
                    return false;
                }
                else
                {
                    //carga codigos y datos de la tabla principal
                    this.CodUsuario = odb.DS.Tables["informacion"].Rows[0]["codusuario"].ToString();
                    this.apellidos = odb.DS.Tables["informacion"].Rows[0]["apellidos"].ToString();
                    this.nombres = odb.DS.Tables["informacion"].Rows[0]["nombres"].ToString();
                    this.correo = odb.DS.Tables["informacion"].Rows[0]["DireccionElectronica"].ToString();
                    this.activo = odb.DS.Tables["informacion"].Rows[0]["ActivoInactivo"].ToString().ToUpper();
                    //this.noempresa=odb.DS.Tables["informacion"].Rows[0]["noempresa"].ToString();
                    this.codorganizacion = odb.DS.Tables["informacion"].Rows[0]["CodOrganizacion"].ToString();
                    this.codpuesto = odb.DS.Tables["informacion"].Rows[0]["codPuesto"].ToString();
                    this.observacion = odb.DS.Tables["informacion"].Rows[0]["Observacion"].ToString();
                    this.nombreusuario = this.nombres + " " + this.apellidos;

                    //obtiene la info de la imagen.
                    try
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(odb.DS.Tables["informacion"].Rows[0]["imagen"]);
                        System.IO.MemoryStream stmBLOBData = new System.IO.MemoryStream(byteBLOBData);
                        this.imagen = Image.FromStream(stmBLOBData);
                        this.ExtensionImagen = odb.DS.Tables["informacion"].Rows[0]["extensionImagen"].ToString();
                    }
                    catch
                    {
                        this.imagen = null;
                        this.ExtensionImagen = null;
                    }
                    //fin obtiene

                    //obtiene la info de la firma 
                    try
                    {
                        Byte[] byteBLOBDatax = new Byte[0];
                        byteBLOBDatax = (Byte[])(odb.DS.Tables["informacion"].Rows[0]["firma"]);
                        System.IO.MemoryStream stmBLOBDatax = new System.IO.MemoryStream(byteBLOBDatax);
                        this.firma = Image.FromStream(stmBLOBDatax);
                        this.ExtensionFirma = odb.DS.Tables["informacion"].Rows[0]["extensionFirma"].ToString();
                    }
                    catch
                    {
                        this.firma = null;
                        this.ExtensionFirma = null;
                    }

                    //Busca descripcion de la informacion
                    this.descorganizacion = odb.EjecutaEscalar("select nombre from ctl_organizacion where codorganizacion=" + this.codorganizacion);
                    this.descpuesto = odb.EjecutaEscalar("select descripcion from ctl_puesto where codpuesto='" + this.codpuesto + "'");
                    this.nivel = int.Parse(odb.EjecutaEscalar("select nivelinicial from ctl_organizacion where codorganizacion=" + this.codorganizacion));

                    return true;
                }
            }

        }

        public bool Insertar()
        {
            string strqry = "";

            if (clave == null || clave.Length == 0)
            {
                this.codigoerror = 99;
                this.descripcionerror = "Contraseña no valida";
                return false;
            }
            else
            {
                strqry = "insert into CTL_EMPLEADO (codusuario,codpuesto,apellidos,nombres,activoinactivo,direccionelectronica,observacion,codorganizacion) values(";
                strqry += clsOperadorDB.scm(this.usuario) + "," + clsOperadorDB.scm(this.codpuesto) + "," + clsOperadorDB.scm(this.apellidos) + "," + clsOperadorDB.scm(this.nombres) + ",";
                strqry += clsOperadorDB.scm(this.activo) + "," + clsOperadorDB.scm(this.correo) + "," + clsOperadorDB.scm(this.observacion) + "," + clsOperadorDB.VNSQL(this.codorganizacion) + ")";
                this.codigoerror = 0;
                this.descripcionerror = "";
                odb.EjecutaSql(strqry);
                if (odb.CodigoError != 0)
                {
                    this.codigoerror = odb.CodigoError;
                    this.descripcionerror = odb.DescripcionError;
                    return false;
                }
                else
                {
                    //////////////////////////////////////////////
                    //////////////////////////////////////////////
                    GrabaBitacora(0, "CTL_EMPLEADO", this.usuario);
                    //////////////////////////////////////////////
                    //////////////////////////////////////////////

                    //Actualizacion de la clave										
                    clsOperadorDB mydb = new clsOperadorDB("seguridad");
                    mydb.CargaInfoSSO(this.patheif, "ssNavega");
                    MemoryStream ms = oen.EncriptaDatos(this.clave);

                    byte[] ba = ms.ToArray();
                    string sqry = "update ctl_empleado set PalabraClave=@File where codusuario=" + clsOperadorDB.scm(this.usuario);
                    SqlConnection con = new SqlConnection(mydb.CadenaConexion);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqry, con);
                    cmd.Parameters.Add("@File", ba);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
        }
        public bool Actualizar()
        {
            string strqry = "";
            //////////////////////////////////////////////
            //////////////////////////////////////////////
            GrabaBitacora(2, "CTL_EMPLEADO", this.usuario);
            //////////////////////////////////////////////
            //////////////////////////////////////////////

            strqry = "update CTL_EMPLEADO set codpuesto=" + clsOperadorDB.scm(this.codpuesto) + ",apellidos=" + clsOperadorDB.scm(this.apellidos) + ",nombres=" + clsOperadorDB.scm(this.nombres);
            strqry += ",activoinactivo=" + clsOperadorDB.scm(this.activo) + ",direccionelectronica=" + clsOperadorDB.scm(this.correo) + ",observacion=" + clsOperadorDB.scm(this.observacion);
            strqry += ",codorganizacion=" + clsOperadorDB.VNSQL(this.codorganizacion) + " where codusuario=" + clsOperadorDB.scm(this.usuario);
            this.codigoerror = 0;
            this.descripcionerror = "";
            odb.EjecutaSql(strqry);
            if (odb.CodigoError != 0)
            {
                this.codigoerror = odb.CodigoError;
                this.descripcionerror = odb.DescripcionError;
                return false;
            }
            else
            {
                //////////////////////////////////////////////
                //////////////////////////////////////////////
                GrabaBitacora(1, "CTL_EMPLEADO", this.usuario);
                //////////////////////////////////////////////
                //////////////////////////////////////////////

                //Actualizacion de la clave
                if (this.clave != "")
                {
                    clsOperadorDB mydb = new clsOperadorDB("seguridad");
                    mydb.CargaInfoSSO(this.patheif, "ssNavega");
                    MemoryStream ms = oen.EncriptaDatos(this.clave);
                    byte[] ba = ms.ToArray();
                    string sqry = "update ctl_empleado set PalabraClave=@File where codusuario=" + clsOperadorDB.scm(this.usuario);
                    SqlConnection con = new SqlConnection(mydb.CadenaConexion);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqry, con);
                    cmd.Parameters.Add("@File", ba);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
        }

        public void LogOutCliente(string pids)
        {
            odb.EjecutaSql("update SEG_LOGINCONTROL Set ACTIVA='N', fechalogout=getdate() where IdSesion='" + pids);
        }

        private void GrabaBitacora(int i, string tabla, string usuario)
        {
            string query = "exec navegasys.dbo.sso_bitacora_mantenimientos '" + this.user + "' , " + this.emp;
            query += " , '" + tabla + "' , ";
            string dato = "select 'Nombres: '+apellidos+',' +nombres+'  Puesto: '+codpuesto+'  Organizacion: '+Convert(varchar,codorganizacion)+'   Estado: '+activoinactivo ";
            dato += "  as Datos  ";
            dato += " from sso_appadmin.dbo." + tabla + "   where  codusuario= '" + usuario + "' ";

            dato = odb.EjecutaEscalar(dato);
            switch (i)
            {
                case 0: query += "'Se agrego registro. " + dato + "' "; break;
                case 1: query += "'Se actualizo. " + dato + "' "; break;
                case 2: query += "'Antes de actualizar. " + dato + "' "; break;
                case 3: query += "'ERROR: No se pudo actualizar.' "; break;
                case 4: query += "'Se elimino registro. " + dato + ".' "; break;
            }
            odb.EjecutaSql(query);
        }

        //metodo para bloquear a un usuario por falta de intentos
        public bool bloquearUsuario(string codUsuairo)
        {

            codigoerror = 0;
            descripcionerror = "";
            string query = "UPDATE CTL_EMPLEADO SET ActivoInactivo = N, FechaInicioTemporal = " +
                clsOperadorDB.scm(System.DateTime.Today.ToString()) +
                " WHERE CodUsuario = " + clsOperadorDB.scm(CodUsuario);

            try
            {

                odb.EjecutaSql(query);
                //falta insertar en bitacora
                return true;

            }
            catch (Exception ex)
            {

                //grabar a bitacora el error
                return false;

            }



        }//fin del metodo bloquearUsuario()

        //metodo para poder verificar si la contraseña ya se paso de su tiempo
        //retorna true si ya se paso y false si no
        public bool comprobarContraseña(string usuario)
        {

            codigoerror = 0;
            descripcionerror = "";

            //buscando el perido de solicitud de la tabla parametros
            string query = "SELECT PeriodoSol FROM SSO_PARAMETROS WHERE CodParametros = 1";
            int periodoSol = 0;
            try
            {

                periodoSol = Convert.ToInt32(odb.EjecutaEscalar(query));

            }
            catch (Exception ex)
            {

                codigoerror = -100;
                descripcionerror = "No se pudo encontrar la Parametrización, avisar al administrador";
                this.IngresoBitacora(usuario, "PASS", "Resultado de PASS: " + descripcionerror);
                return false;

            }

            //verificando la fecha de la creación de la contraseña
            query = "SELECT FechaInicioTemporal FROM CTL_EMPLEADO WHERE CodUsuario = " +
                clsOperadorDB.scm(usuario);
            DateTime fecha;
            try
            {

                fecha = Convert.ToDateTime(odb.EjecutaEscalar(query));

            }
            catch (Exception ex)
            {

                codigoerror = -100;
                descripcionerror = ex.ToString();
                this.IngresoBitacora(usuario, "PASS", "Resultado de PASS: " + ex.ToString());
                return false;

            }

            //calculando los meses que tiene la contraseña
            int count = contarMeses(fecha, System.DateTime.Now);

            if (count < periodoSol)
            {

                //comprobación de los días para el mensaje de prevención de expiración de contraseña
                DateTime fechaActual = System.DateTime.Now; //contiene la fecha actual
                DateTime fechaFinal = fecha.AddMonths(periodoSol);  //contiene la fecha en que finaliza el pass
                int dias = contarDia(fechaActual, fechaFinal);
                if (dias <= 7)
                {

                    codigoerror = -105;
                    switch (dias)
                    {

                        case 0:

                            //contar la horas que quedan
                            int horas = contarHoras(fechaActual, fechaFinal);
                            switch (horas)
                            {

                                case 0:

                                    descripcionerror = "Su contraseña expirara en menos de una hora, " +
                                        "por favor proceda a cambiarla";

                                    break;
                                case 1:


                                    descripcionerror = "Su contraseña expirara en una hora, por favor" +
                                        "proceda a cambiarla lo más pronto posible";

                                    break;
                                default:

                                    descripcionerror = "Su contraseña expirara en " + horas + " horas, " +
                                        "por favor proceda a cambiarla lo más pronto posible";

                                    break;


                            }//fin switch(horas)

                            break;
                        case 1:

                            descripcionerror = "Falta un día para que su contraseña expire, por favor " +
                                "proceda a cambiarla pronto";

                            break;
                        default:

                            descripcionerror = "Faltan " + dias.ToString() + " días para que su contraseña " +
                                "expire, por favor proceda a cambiarla pronto";

                            break;

                    }//fin switch(dias)

                }//fin if (dias <= 7)

                return false;

            }
            else//fin if (count < periodoSol)
            {

                this.IngresoBitacora(usuario, "PASS", "Contraseña ha expirado");
                return true;

            }
        }//fin metodo comprobarContraseña

        //metodo que comprueba si el usuario esta bloqueado
        //retorn true si esta bloqueado y false si no
        public bool comprobarBloqueoUsuario(string usuario)
        {

            codigoerror = 0;
            descripcionerror = "";

            string query = "SELECT ActivoInactivo FROM CTL_EMPLEADO WHERE CodUsuario = " +
                    clsOperadorDB.scm(usuario);
            string act = "";
            try
            {

                act = odb.EjecutaEscalar(query);

            }//fin try de bloqueo
            catch (Exception ex)
            {

                codigoerror = -101;
                descripcionerror = "No se puede verificar si el usuario esta activo";
                this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: " + descripcionerror);
                return false;

            }//fin cath

            //verificando el bloqueo
            if (act != "S")
            {

                //si es temporal ver cuanto tiempo lleva bloqueado
                query = "SELECT TipoBloqueo FROM SSO_PARAMETROS WHERE CodParametros = 1";
                int tipoBloqueo = 0;
                try
                {

                    tipoBloqueo = Convert.ToInt32(odb.EjecutaEscalar(query));

                }
                catch (Exception ex)
                {

                    codigoerror = -101;
                    descripcionerror = "No se puede verificar el tipo de bloqueo en los parametros";
                    this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: " + descripcionerror);
                    return false;

                }
                if (tipoBloqueo == 1)
                {
                    //contiene el bloqueo completo por lo que no se puede agregar
                    this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: Usuario está bloqueado completo, acceso denegado");
                    return true;

                }//fin if (tipoBloqueo == 1)
                else
                {

                    //verificar cuanto tiempo lleva bloqueado el usuario.

                    //verificando el periodo posterior
                    query = "SELECT PeriodoPost FROM SSO_PARAMETROS WHERE CodParametros = 1";
                    //verificando el tipo de metrica del periodo posterior
                    string query2 = "SELECT TipoPeriodo FROM SSO_PARAMETROS WHERE CodParametros = 1";
                    //verificando fecha en la que ocurrio el bloqueo
                    string query3 = "SELECT FechaTemp FROM CTL_EMPLEADO WHERE CodUsuario = " +
                        clsOperadorDB.scm(usuario);


                    int periodoPost = 0;
                    string tipoPeriodo = "";
                    DateTime fechaBloqueo = new DateTime();
                    //ejecutando queries anteriores
                    try
                    {

                        periodoPost = Convert.ToInt32(odb.EjecutaEscalar(query));
                        tipoPeriodo = odb.EjecutaEscalar(query2);
                        fechaBloqueo = Convert.ToDateTime(odb.EjecutaEscalar(query3));

                    }
                    catch (Exception ex)
                    {

                        codigoerror = -101;
                        descripcionerror = "No se puede obtener el periodo de bloqueo temporal";
                        this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: " + descripcionerror);
                        return false;

                    }

                    //viendo que metrica es
                    if (tipoPeriodo.ToLower().Equals("mes"))
                    {

                        int count = contarMeses(fechaBloqueo, System.DateTime.Now);
                        if (count < periodoPost)
                        {

                            this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: Usuario esta bloqueado" +
                                "temporalmente, acceso denegado");
                            return true;

                        }
                        else
                        {

                            //quitar bloqueo
                            return !quitarBloqueo(usuario);

                        }//fin else if (count < periodoPost)

                    }
                    else if (tipoPeriodo.ToLower().Equals("dia"))//fin si es mes
                    {

                        //se comprueba el numero de días que lleva
                        int count = contarDia(fechaBloqueo, System.DateTime.Now);
                        if (count < periodoPost)
                        {

                            this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: Usuario esta bloqueado" +
                                "temporalmente, acceso denegado");
                            return true;

                        }
                        else
                        {

                            //quitar bloqueo
                            return !quitarBloqueo(usuario);

                        }//fin else count<perdiodoPost

                    }
                    else if (tipoPeriodo.ToLower().Equals("hora"))//fin if es dia
                    {

                        int count = contarHoras(fechaBloqueo, System.DateTime.Now);
                        if (count < periodoPost)
                        {

                            this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: Usuario esta bloqueado" +
                                "temporalmente, acceso denegado");
                            return true;

                        }
                        else
                        {

                            return !quitarBloqueo(usuario);

                        }//fin else count<periodoPost

                    }
                    else if (tipoPeriodo.ToLower().Equals("año"))//fin si es hora
                    {

                        int count = contarAnio(fechaBloqueo, System.DateTime.Now);
                        if (count < periodoPost)
                        {

                            this.IngresoBitacora(usuario, "LOGIN", "Resultado de Login: Usuario esta bloqueado" +
                                "temporalmente, acceso denegado");
                            return true;

                        }
                        else
                        {

                            return !quitarBloqueo(usuario);

                        }//fin else count<periodoPost

                    }//fin si es año
                }

            }//fin si esta bloqueado
            return false;

        }//fin metodo de comprobarBloqueoUsuario

        private int contarMeses(DateTime fechaInicio, DateTime fechaFin)
        {

            int count = -1;
            while (fechaInicio < fechaFin)
            {

                fechaInicio = fechaInicio.AddMonths(1);
                count++;

            }//fin while(fecha < fechaActual)

            return count;

        }//fin metodo contarMeses(inicio, fin)

        private int contarDia(DateTime fechaInicio, DateTime fechaFin)
        {

            int count = -1;
            while (fechaInicio < fechaFin)
            {

                fechaInicio = fechaInicio.AddDays(1);
                count++;

            }//fin while (fecha < fechaActual)
            return count;

        }//fin metodo contarDia(inicio,fin)

        private int contarHoras(DateTime fechaInicio, DateTime fechaActual)
        {

            int count = -1;
            while (fechaInicio < fechaActual)
            {

                fechaInicio = fechaInicio.AddHours(1);
                count++;

            }//fin while (fecha, fechaActual)
            return count;

        }//fin metodo contarHoras(inicio,fin)

        private int contarAnio(DateTime fechaInicio, DateTime fechaActual)
        {

            int count = -1;
            while (fechaInicio < fechaActual)
            {

                fechaInicio = fechaInicio.AddYears(1);
                count++;

            }
            return count;

        }//fin metodo contarAnio(inicio,fin)

        public bool quitarBloqueo(string usuario)
        {

            codigoerror = 0;
            descripcionerror = "";
            string query = "UPDATE CTL_EMPLEADO SET ActivoInactivo = \'S\', FechaTemp = null WHERE " +
                                "CodUsuario = " + clsOperadorDB.scm(usuario);
            try
            {

                odb.EjecutaSql(query);
                this.IngresoBitacora(usuario, "DESBLOQUEO", "Resultado de Desbloqueo: El usuario fue desbloqueado");
                return true;

            }
            catch (Exception ex)
            {

                codigoerror = -101;
                descripcionerror = "No se pudo quitar el bloqueo temporal del usuario";
                this.IngresoBitacora(usuario, "DESBLOQUEO", "Resultado de Desbloqueo: " + descripcionerror);
                return false;

            }

        }//fiin metodo quitarBloqueo

        //metodo utilizado para generar la contraseña aleatoria
        public string generarPassTemporal(String codUsuario)
        {
            codigoerror = 0;
            descripcionerror = "";

            StringBuilder passGenerado = new StringBuilder();

            /*
             * Variables para generar la contraseña
             */

            string charPool1 = "abcdefghijklmnopqrstuvwxyz";
            string charPool2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numPool = "1234567890";
            string simPool = "&%$#+-*";

            
            /*
             * Obtenemos el nivel de seguridad de la contraseña
             * y también la longitud deseada para la contraseña
             */
            string query = "SELECT NivelPass FROM SSO_PARAMETROS WHERE CodParametros = 1";
            string query2 = "SELECT LongitudPass FROM SSO_PARAMETROS WHERE CodParametros = 1";
            int nivelPass = 0;
            int longitudPass = 0;

            try
            {

                nivelPass = Convert.ToInt32(odb.EjecutaEscalar(query));
                longitudPass = Convert.ToInt32(odb.EjecutaEscalar(query2));

            }
            catch (Exception ex)
            {

                codigoerror = -103;
                descripcionerror = "No existen parametros suficientes para generar contraseña temporal";
                this.IngresoBitacora(codUsuario, "PASS", "Resultado de PASS: " + descripcionerror);
                return null;

            }

            switch (nivelPass)
            {

                case 0: //random de nivel basico

                    //agregando valor alfabetico
                    passGenerado.Append(charPool1[random.Next(charPool1.Length)]);

                    while (passGenerado.Length < longitudPass)
                    {

                        
                        int valPool = random.Next(2);
                        switch (valPool)
                        {

                            case 0:

                                passGenerado.Append(charPool1[random.Next(charPool1.Length)]);

                                break;
                            case 1:

                                passGenerado.Append(numPool[random.Next(numPool.Length)]);

                                break;
                             

                        }//fin switch valPool
                        

                    }//fin while(tamaño contraseña)

                    //agregando el ultimo caracter de tipo numerico
                    passGenerado.Append(numPool[random.Next(numPool.Length)]);


                    break;

                case 1: //nivel intermedio

                    //agregando valor alfabetico mayuscula
                    passGenerado.Append(charPool2[random.Next(charPool2.Length)]);
                    while (passGenerado.Length < longitudPass-1)
                    {

                        int valpool = random.Next(3);
                        switch (valpool)
                        {

                            case 0: //valor alfabetico minuscula

                                passGenerado.Append(charPool1[random.Next(charPool1.Length)]);

                                break;
                            case 1: //valor numerico

                                passGenerado.Append(numPool[random.Next(numPool.Length)]);

                                break;
                            case 2: //valor alfabetico mayuscula

                                passGenerado.Append(charPool2[random.Next(charPool2.Length)]);

                                break;
                            
                        }//fin switch(valpool)

                    }//fin while (tamaño contraseña)

                    //agregando valor alfabetico minuscula
                    passGenerado.Append(charPool1[random.Next(charPool1.Length)]);
                    //agregando valor numerico
                    passGenerado.Append(numPool[random.Next(numPool.Length)]);

                    break;
                case 2: //nivel avanzado

                    //agregando valor alfabetico mayuscula
                    passGenerado.Append(charPool2[random.Next(charPool2.Length)]);
                    while (passGenerado.Length < longitudPass - 2)
                    {

                        int valpool = random.Next(4);
                        switch (valpool)
                        {

                            case 0: //valor alfabetico minuscula

                                passGenerado.Append(charPool1[random.Next(charPool1.Length)]);

                                break;
                            case 1: //valor numerico

                                passGenerado.Append(numPool[random.Next(numPool.Length)]);

                                break;
                            case 2: //valor alfabetico mayuscula

                                passGenerado.Append(charPool2[random.Next(charPool2.Length)]);

                                break;
                            case 3: //valor caracter especial

                                passGenerado.Append(simPool[random.Next(simPool.Length)]);

                                break;

                        }//fin switch(valpool)

                    }//fin while (tamaño contraseña)

                    //agregando valor alfabetico minuscula
                    passGenerado.Append(charPool1[random.Next(charPool1.Length)]);
                    //agregando valor numerico
                    passGenerado.Append(numPool[random.Next(numPool.Length)]);
                    //agregando valor caracter especial
                    passGenerado.Append(simPool[random.Next(simPool.Length)]);

                    break;


            }//fin switch nivelPass

            //encriptando clave
            clsOperadorDB mydb = new clsOperadorDB("seguridad");
            mydb.CargaInfoSSO(this.patheif, "ssNavega");
            MemoryStream ms = oen.EncriptaDatos(passGenerado.ToString());
            byte[] ba = ms.ToArray();

            //guardar el nuevo pass en el temporal del usuario
            query = "UPDATE SEG_EMPLEADO_TIPOAUTENTICACION SET ClaveTemporal = @File, FechaTemporal = "
                + "getDate() WHERE CodUsuario = " + clsOperadorDB.scm(codUsuario) + " AND CodTipoAut = 0";
            SqlConnection con = new SqlConnection(mydb.CadenaConexion);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@File", ba);
            cmd.ExecuteNonQuery();
            con.Close();
            codigoerror = 0;
            descripcionerror = "";

            this.IngresoBitacora(codUsuario, "PASS", "Resultado de PASS: Se genero contraseña temporal.");

            return passGenerado.ToString();


        }//fin metodo generarPassTemporal(codUsuario)

        //metodo para comprobar el nivel de seguridad de la contraseña
        private bool compruebaNivelPass(string pass, string usuario)
        {

            /*
             * variables para comprobar el nivel y longitud de la contraseña
             */
            int nivelPass = 0;
            int longPass = 0;

            //variables con los pools de cada nivel
            string pool1 = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
            string pool2 = "1 2 3 4 5 6 7 8 9 0";
            string pool3 = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            string pool4 = "& % $ # + - *";

            //obteniendo valores del nivel y longitud
            string query = "SELECT NivelPass FROM SSO_PARAMETROS WHERE CodParametros = 1";
            string query2 = "SELECT LongitudPass FROM SSO_PARAMETROS WHERE CodParametros = 1";
            try
            {

                nivelPass = Convert.ToInt32(odb.EjecutaEscalar(query));
                longPass = Convert.ToInt32(odb.EjecutaEscalar(query2));

            }
            catch (Exception ex)
            {

                codigoerror = 99;
                descripcionerror = "No existe configuración de parametros, informe al administrador";
                this.IngresoBitacora(usuario, "PASS", "Resultado de PASS: " + ex.ToString());
                return false;

            }

            //iniciando comprobación de la longitud del password
            if (pass.Length < longPass)
            {

                codigoerror = 99;
                descripcionerror = "La contraseña no es de la longitud deseada, Ingrese una contraseña " +
                    "de longitud igual o mayor a " + longPass;
                this.IngresoBitacora(usuario, "PASS", "Resultado de PASS: " + descripcionerror);
                return false;

            }//fin if longitud de la contraseña

            bool encontroAlfaMin = false;
            bool encontroNum = false;
            bool encontroAlfaMay = false;
            
            //iniciando comprobación del tipo de longitud
            switch (nivelPass)
            {

                case 0://nivel basico

                    
                    for (int i = 0; i < pass.Length; i++)
                    {

                        if (pool1.Contains(pass[i].ToString()))
                        {

                            encontroAlfaMin = true;

                        }//fin if contiene poorl1[i]
                        else if (pool2.Contains(pass[i].ToString()))
                        {

                            encontroNum = true;

                        }

                    }//fin for pass

                    if ((!encontroAlfaMin) || (!encontroNum))
                    {

                        codigoerror = 99;
                        descripcionerror = "La contraseña no contiene los caracteres minimos del " +
                            "nivel de seguridad Basico";
                        this.IngresoBitacora(usuario, "PASS", "Resultado de PASS: " + descripcionerror);
                        return false;

                    }

                    break;//case 0
                case 1: //nivel intermedio

                    for (int i = 0; i < pass.Length; i++)
                    {

                        if (pool1.Contains(pass[i].ToString()))
                        {

                            encontroAlfaMin = true;

                        }//fin if contiene poorl1[i]
                        else if (pool2.Contains(pass[i].ToString()))
                        {

                            encontroNum = true;

                        }else if (pool3.Contains(pass[i].ToString()))
                            encontroAlfaMay = true;

                    }//fin for pass

                    if ((!encontroAlfaMin) || (!encontroAlfaMay) || (!encontroNum))
                    {

                        codigoerror = 99; 
                        descripcionerror = "La contraseña no contiene los caracteres minimos del " +
                            "nivel de seguridad Intermedio";
                        this.IngresoBitacora(usuario, "PASS", "Resultado de PASS: " + descripcionerror);
                        return false;

                    }//fin if
                        break; //case 1
                case 2:

                    bool encontroSym = false;
                        for (int i = 0; i < pass.Length; i++)
                        {

                            if (pool1.Contains(pass[i].ToString()))
                            {

                                encontroAlfaMin = true;

                            }//fin if contiene poorl1[i]
                            else if (pool2.Contains(pass[i].ToString()))
                            {

                                encontroNum = true;

                            }
                            else if (pool3.Contains(pass[i].ToString()))
                                encontroAlfaMay = true;
                            else if (pool4.Contains(pass[i].ToString()))
                                encontroSym = true;

                        }//fin for pass

                        if ((!encontroAlfaMin) || (!encontroAlfaMay) || (!encontroNum) || (!encontroSym))
                        {

                            codigoerror = 99;
                            descripcionerror = "La contraseña no contiene los caracteres minimos del " +
                                "nivel de seguridad Avanzado";
                            this.IngresoBitacora(usuario, "PASS", "Resultado de PASS: " + descripcionerror);
                            return false;

                        }//fin if

                        break; //case 2

            }//fin switch(nivelPass)

            return true;

        }//fin del metodo compruebaNivelPass(string pass)

        //metodo que verifica el historial de las contraseñas
        //regresa true si no encuentra nada, y false si hay uno identico
        private bool verificarHistorialPass(string codUsuario, string pass, string passActual)
        {

            if (pass.Equals(passActual, StringComparison.Ordinal))
            {

                codigoerror = 99;
                descripcionerror = "No se puede utilizar una contraseña antigua";
                return false;

            }

            //verificar si hay recordatorio de historial de contraseñas
            string query = "SELECT RecordarPass FROM SSO_PARAMETROS WHERE CodParametros = 1";
            int historialPass = 0;
            try
            {

                historialPass = Convert.ToInt32(odb.EjecutaEscalar(query));

            }
            catch(Exception ex)
            {

                codigoerror = 99;
                descripcionerror = "No se puede verificar los parametros para el historial, " + 
                    "notificar al administrador";
                return false;

            }//fin try y catch

            if (historialPass == 0)
                return true;

            //si esta activada, se verifica la contraseña con las demas contraseñas
            query = "SELECT TOP 3 PalabraClave FROM SSO_HISTORIAL_PASS WHERE CodUsuario = " + 
                clsOperadorDB.scm(codUsuario) + " ORDER BY Fecha";
            try
            {

                odb.ConsultaSql(query, "SSO_HISTORIAL_PASS");

            }
            catch (Exception ex)
            {

                codigoerror = 99;
                descripcionerror = "No se puede verificar el historial de contraseña";
                return false;

            }

            int countfilas = odb.DS.Tables["SSO_HISTORIAL_PASS"].Rows.Count;
            if ( countfilas == 0)
                return true;
            
            
            //comprobando en los historiales que hay

            MemoryStream ms = oen.EncriptaDatos(pass);
            byte[] ba = ms.ToArray();
            codigoerror = 0;
            bool encontro = false;

            for (int i = 0; i < countfilas; i++)
            {
                
                //comprobar la contraseña que existe
                Byte[] passTemporal = new Byte[0];
                passTemporal =
                    (Byte[])(odb.DS.Tables["SSO_HISTORIAL_PASS"].Rows[i]["PalabraClave"]);

                int igual = 0;

                if (ba.Length == passTemporal.Length)
                {

                    for (int j = 0; j < ba.Length; j++)
                    {

                        if (ba[j] == passTemporal[j])
                        {

                            igual += 1;

                        }
                        else//fin comparacion de contraseña
                            break;
                    }//fin for

                    if (igual == ba.Length)
                    {
                        encontro = true;
                        break;
                    }

                }//fin si las contraseñas tienen el mismo tamaño   
               
            }

            if (encontro)
            {

                codigoerror = 99;
                descripcionerror = "No se puede utilizar una contraseña antigua";
                return false;

            }

            return true;

        }//fin metodo verificarHistorialPass(codUsuario,pass)



	}

}
