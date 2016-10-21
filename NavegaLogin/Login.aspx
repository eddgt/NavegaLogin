<%@ Page Language="c#" AutoEventWireup="True" Inherits="NavegaLogin.Forma" Codebehind="login.aspx.cs" %>

<%@ Register TagPrefix="cc1" Namespace="PruebaMe" Assembly="PREUBAME" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>:: Navega Plus Web ::</title>
    <link href="CS/newStyle.css" rel="stylesheet" type="text/css" />
</head>
<body leftmargin="0" topmargin="0" >

   

    <form id="Forma1" method="post" runat="server">
    <div align="center">
        <img src="images/fondologin2.jpg"></div>
    <asp:Label ID="lblMensaje" runat="server" Height="18px" Width="327px" Font-Names="Arial"
        Visible="False" ForeColor="Navy" Font-Size="Small"></asp:Label>
    
    <asp:Table ID="TablaBotones" Style="z-index: 104; left: 4px; position: absolute;
        top: 280px" runat="server" Width="100%">
        <asp:TableRow ID="tr1" runat="server">
            <asp:TableCell ID="tc1" runat="server" Width="58%">
            </asp:TableCell>
            <asp:TableCell ID="tc2" runat="server" Width="8%">
                <asp:Label ID="lbUsuario" runat="server" ForeColor="Navy" Text="Usuario:" Font-Bold="True"
                    Font-Size="10"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="tc3" runat="server" Width="34%">
                <asp:TextBox ID="txtUsuario" TabIndex="1" runat="server" Height="25px"
                    Width="175px" Font-Names="Arial" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="tr2" runat="server">
            <asp:TableCell ID="tc4" runat="server" Width="58%">
            </asp:TableCell>
            <asp:TableCell ID="tc5" runat="server" Width="8%">
                <asp:Label ID="lbContrasena" runat="server" ForeColor="Navy" Text="Contraseña:" Font-Bold="True"
                    Font-Size="10"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="tc6" runat="server" Width="34%">
                <asp:TextBox ID="txtClave" TabIndex="2" runat="server" TextMode="Password"
                    Height="25px" CssClass="textbox" Width="175px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="tr3" runat="server">
            <asp:TableCell ID="tc7" runat="server" Width="58%">
            </asp:TableCell>
            <asp:TableCell ID="tc8" runat="server" Width="8%">
            </asp:TableCell>
            <asp:TableCell ID="tc9" runat="server" Width="34%" >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnIngresar" CssClass="button" runat="server" Text="Ingresar" Width="120px" 
        onclick="btnIngresar_Click" />
        <br />
        <br />
        <strong><a style="text-decoration:none" href="https://www.google.com" target="_blank">¿Olvidaste tu clave?</a></strong>
                <asp:ImageButton ID="cmdAcepta" TabIndex="3" runat="server" Height="32px" Visible="false" ImageUrl="images/btnLogin.jpg"
                    OnClick="cmdAcepta_Click"></asp:ImageButton>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="TablaResolucion" Style="z-index: 103; left: 0px; position: absolute;
        top: 415px" runat="server" Width="100%">
        <asp:TableRow ID="tre1" runat="server">
            <asp:TableCell ID="tcr1" runat="server" Width="48%">
            </asp:TableCell>
            <asp:TableCell ID="tcr2" runat="server" Width="8%">
            </asp:TableCell>
            <asp:TableCell ID="tcr3" runat="server" Width="44%">
            <asp:Label ID="Label4" runat="server" Font-Names="Arial" ForeColor="Navy" Font-Size="XX-Small">Resolución de pantalla recomendada: 1364 x 768 pixeles</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <cc1:SSO_ctlMensaje ID="ctlMensaje" Style="z-index: 104; left: 476px; position: absolute;
        top: 608px" runat="server" Width="304px" Height="125px" ActionType="RaiseEvents"
        DockMode="BottomLeft" HideAfter="8000" AutoShow="False"></cc1:SSO_ctlMensaje>
    </form>
</body>
</html>
