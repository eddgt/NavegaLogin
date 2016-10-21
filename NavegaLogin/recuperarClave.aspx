<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testPage.aspx.cs" Inherits="NavegaLogin.testPage" %>
<%@ Register TagPrefix="cc1" Namespace="PruebaMe" Assembly="PREUBAME" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
        <link href="CS/newStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 162px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
        <br />
        
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;</div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server"  Text="Indique su Usuario:" ForeColor="Navy" Font-Bold="True" Font-Size="10"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style2">
            &nbsp;&nbsp;</td>
            <td>
            <asp:TextBox ID="txtUsuario" runat="server" Height="23px" Width="221px" CssClass="textbox"></asp:TextBox>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
            <asp:Button ID="Button1" runat="server" Text="Cambiar mi Contraseña" onclick="Button1_Click" 
                    CssClass="button" Width="181px" Height="36px"/>
                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <cc1:SSO_ctlMensaje ID="ctlMensaje" Style="z-index: 104; left: -25px; position: absolute;
        top: 205px" runat="server" Width="304px" Height="125px" ActionType="RaiseEvents"
        DockMode="BottomLeft" HideAfter="8000" AutoShow="False"></cc1:SSO_ctlMensaje>
    </form>
    </body>
</html>
