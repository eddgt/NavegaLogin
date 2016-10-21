<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bloqueo_Usuario.aspx.cs" Inherits="NavegaLogin.Bloqueo_Usuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="App_Themes/CS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <link href="CS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table class="style1">
        <tr>
            <td class="titulopanelazul" colspan="3">
                <asp:Label ID="Label1" runat="server" Text="Bloqueo de Usuario"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_usuario" runat="server"></asp:TextBox>
                <asp:Button ID="btn_buscar" runat="server" Text="Buscar" 
                    onclick="btn_buscar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_nombre" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Apellido"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_apellido" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_estado" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_generarclave" runat="server" Text="Generar Clave" />
            </td>
            <td>
                <asp:Label ID="lbl_Clave" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
