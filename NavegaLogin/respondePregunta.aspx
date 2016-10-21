<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="respondePregunta.aspx.cs" Inherits="NavegaLogin.respondePregunta" %>
<%@ Register TagPrefix="cc1" Namespace="PruebaMe" Assembly="PREUBAME" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="CS/newStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 128px;
        }
        .style3
        {
            width: 876px;
        }
        .style4
        {
            width: 128px;
            height: 41px;
        }
        .style5
        {
            width: 876px;
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 148px">
    
        <table class="style1">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="lblPregMsg" runat="server" Text="Por favor responde tu pregunta" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style4">
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"  ForeColor="Navy" 
                        Font-Bold="True" Font-Size="10"></asp:Label>
                    </td>
                <td class="style5">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox" Width="151px" 
                        Height="23px" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUsuario" ErrorMessage="El campo usuario es obligatorio"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
        <asp:Label ID="lblPregunta" runat="server" Text="Mi Pregunta:"  ForeColor="Navy" Font-Bold="True" Font-Size="10"></asp:Label>
                </td>
                <td class="style3">
                    <asp:RadioButtonList ID="rbtnPreguntas" runat="server">
                        <asp:ListItem>Nombre Primer colegio</asp:ListItem>
                        <asp:ListItem>Nombre de mi mejor amigo(a) de la infancia</asp:ListItem>
                        <asp:ListItem Value="Nombre de mi mascota">Nombre de mi mascota</asp:ListItem>
                        <asp:ListItem>Numero de Identificacion</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="rbtnPreguntas" 
                        ErrorMessage="Debe seleccionar una pregunta"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
        <asp:Label ID="lblRespuesta" runat="server" Text="Mi respuesta:" ForeColor="Navy" Font-Bold="True" Font-Size="10"></asp:Label>
                </td>
                <td class="style3">
        <asp:TextBox ID="txtRespuesta" runat="server" CssClass="textbox" Width="253px" 
                        Height="24px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtRespuesta" 
                        ErrorMessage="El campo Respuesta es obligatorio"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
        <asp:Button ID="btnResponder" runat="server" Text="Responder Pregunta" CssClass="button"
             Width="172px" onclick="btnResponder_Click" />
    
                    &nbsp;
    
                </td>
            </tr>
        </table>        
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    
    </div>
    <cc1:SSO_ctlMensaje ID="ctlMensaje" Style="z-index: 104; left: 476px; position: absolute;
        top: 608px" runat="server" Width="304px" Height="125px" ActionType="RaiseEvents"
        DockMode="BottomLeft" HideAfter="8000" AutoShow="False"></cc1:SSO_ctlMensaje>
    </form>
</body>
</html>
