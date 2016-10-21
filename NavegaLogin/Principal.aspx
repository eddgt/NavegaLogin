<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="NavegaLogin.Principal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CS/newStyle.css" />

    <script type="text/javascript" src="scripts/jquery.min.js"></script>
    <script type="text/javascript" src="scripts/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">

  <h1>Seleccion de Aplicación</h1>
  
  
  
  
  
  <div id="gallery">
	
    <div id="slides">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
	
    </div>
    
    <div id="menu">
    
    <ul>
        <li class="fbar">&nbsp;</li>
        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    </ul>
    
    
    </div>
    
    
  </div>
  
  <div style="width:920px;height:266px;">
    <table border="0" width="100%" bgcolor="white">
    <tr><td width="50%" valign="top" align="left"><asp:Label ID="lblSaludo" runat="server" Text=""></asp:Label><br /><br />
    <asp:Button ID="btnSalir" CssClass="button" runat="server" Text="Salir" 
            Width="120px" onclick="btnSalir_Click" 
         />
    </td><td width="50%" align="right" >
        <img src="images/tb.png" alt="Tigo Business" /></td></tr>
        <tr><td align="right" colspan="2"><h2>Utilice los iconos de las banderas para navegar entre los paises disponibles en el sistema para su usuario.</h2></td></tr>
    </table>
    </div>
    </div>
    </form>
</body>
</html>
