using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using System.Text;

/// <summary>
/// Summary description for clsSesionAD
/// </summary>
public partial class clsSesionAD : System.Web.UI.Page
{

    public string _Dominio;// = "LDAP://navega.com.gt";
    private string _NombreUsuario = "";
    private string _NivelUsuario = "";
    private string _CodEmpresa = "";
    private string _CodArea = "";
    private string _Error = "";

    private AuthenticationTypes TiposAutenticacion = AuthenticationTypes.Secure;
   
	public clsSesionAD()
    { 
        try
        {
            _Dominio = "LDAP://navega.com.gt";
            if (_Dominio == "")
            {
                throw new Exception("No se ha podido contactar el dominio.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    public string GetUsuario()
    {
        return Session["usuario"].ToString();
    }

    public string Error
    {
        get
        { return _Error; }
    }

    /// <summary>
    /// Función que valida el login contra el Active Directory
    /// </summary>
    /// <param name="Usuario">Login asignado en el active directory</param>
    /// <param name="PassWord">Password asignado en el active directory</param>
    /// <returns>Devuelve verdadero si se encuentra en el active directory</returns>
    public bool Loguearse(string Usuario, string PassWord)
    {
        _Error = "";
        bool EsValido = true;
        if (Usuario.Trim() != "")
        {
            string criterio = "distinguishedName";
            DirectoryEntry objDirectoryEntry = new DirectoryEntry(_Dominio, Usuario, PassWord, TiposAutenticacion);
            try
            {
                DirectorySearcher search = new DirectorySearcher(objDirectoryEntry);
                search.Filter = "(SAMAccountName=" + Usuario + ")";
                search.PropertiesToLoad.Add(criterio);
                SearchResult result = search.FindOne();
                if (null != result)
                {
                    if (!(result.Properties[criterio].Count > 0))
                    {
                        EsValido = false;
                    }
                }
            }
            catch (Exception ex)
            {
                _Error = ex.Message;
                EsValido = false;
                //throw ex;
            }
        }
        else
        {

            _Error = "Usuario y contraseña inválidos";
            EsValido = false;
            //throw new Exception(_Error);
        }
        return EsValido;
    }

    

    #region Propiedades

    public string NombreUsuario
    {
        get
        {
            return _NombreUsuario;
        }
    }

    public string Nivel
    {
        get
        {
            return _NivelUsuario;
        }
    }

    public string CodEmpresa
    { 
        get
        { return _CodEmpresa; }
        set
        { _CodEmpresa = value; }
    }

    public string CodArea
    {
        get
        { return _CodArea; }
        set
        { _CodArea = value; }
    }

    #endregion

}
