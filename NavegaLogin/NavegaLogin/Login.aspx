<%@ Page Language="c#" AutoEventWireup="True" Inherits="NavegaLogin.Forma" Codebehind="login.aspx.cs" %>

<%@ Register TagPrefix="cc1" Namespace="PruebaMe" Assembly="PREUBAME" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>:: Navega Plus Web ::</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>
<body leftmargin="0" topmargin="0" ms_positioning="GridLayout" marginheight="0" marginwidth="0"
    bgproperties="fixed" background="images/fondo_nuevo.jpg">

    <script language="JavaScript">
<!--        Begin
        if (document.all) {
            yourLogo = "NAVEGA PLUS <<GUATEMALA>>  ";  //Not less than 2 letters!
            logoFont = "Arial";
            logoColor = "FFFFFF";
            yourLogo = yourLogo.split('');
            L = yourLogo.length;
            TrigSplit = 360 / L;
            Sz = new Array()
            logoWidth = 100;
            logoHeight = -30;
            ypos = 0;
            xpos = 0;
            step = 0.03;
            currStep = 0;
            document.write('<div id="outer" style="position:absolute;top:0px;left:0px"><div style="position:relative">');
            for (i = 0; i < L; i++) {
                document.write('<div id="ie" style="position:absolute;top:0px;left:0px;'
+ 'width:10px;height:10px;font-family:' + logoFont + ';font-weight:bold;font-size:20px;'
+ 'color:' + logoColor + ';text-align:center">' + yourLogo[i] + '</div>');
            }
            document.write('</div></div>');
            function Mouse() {
                ypos = event.y;
                xpos = event.x - 5;
            }
            document.onmousemove = Mouse;
            function animateLogo() {
                outer.style.pixelTop = document.body.scrollTop;
                for (i = 0; i < L; i++) {
                    ie[i].style.top = ypos + logoHeight * Math.sin(currStep + i * TrigSplit * Math.PI / 180);
                    ie[i].style.left = xpos + logoWidth * Math.cos(currStep + i * TrigSplit * Math.PI / 180);
                    Sz[i] = ie[i].style.pixelTop - ypos;
                    if (Sz[i] < 5) Sz[i] = 5;
                    ie[i].style.fontSize = Sz[i] / 1.7;
                }
                currStep -= step;
                setTimeout('animateLogo()', 20);
            }
            window.onload = animateLogo;
        }
//  End -->
    </script>

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
                <asp:TextBox ID="txtUsuario" TabIndex="1" runat="server" BackColor="White" Height="20px"
                    Width="184px" Font-Names="Arial"></asp:TextBox>
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
                <asp:TextBox ID="txtClave" TabIndex="2" runat="server" BackColor="White" TextMode="Password"
                    Height="20px" Width="184px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="tr3" runat="server">
            <asp:TableCell ID="tc7" runat="server" Width="58%">
            </asp:TableCell>
            <asp:TableCell ID="tc8" runat="server" Width="8%">
            </asp:TableCell>
            <asp:TableCell ID="tc9" runat="server" Width="34%">
                <asp:ImageButton ID="cmdAcepta" TabIndex="3" runat="server" Height="32px" ImageUrl="images/btnLogin.jpg"
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
            <asp:Label ID="Label4" runat="server" Font-Names="Arial" ForeColor="Navy" Font-Size="XX-Small">Resolución de pantalla recomendada: 1024 x 768 pixeles</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <cc1:SSO_ctlMensaje ID="ctlMensaje" Style="z-index: 104; left: 476px; position: absolute;
        top: 608px" runat="server" Width="304px" Height="125px" ActionType="RaiseEvents"
        DockMode="BottomLeft" HideAfter="8000" AutoShow="False"></cc1:SSO_ctlMensaje>
    </form>
</body>
</html>
