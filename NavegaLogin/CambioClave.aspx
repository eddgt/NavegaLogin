<%@ Page language="c#" AutoEventWireup="True" Inherits="NavegaLogin.CambioClave" Codebehind="CambioClave.aspx.cs" %>
<HTML>
	<HEAD>
		<title>- Cambio de Contraseña -</title>
	    <style type="text/css">
            .style3
            {
                font-size: large;
                font-weight: bold;
            }
        </style>
	    <link href="CS/newStyleWhite.css" rel="stylesheet" type="text/css" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%">
				<tr>
					<td  width="50%">
						<asp:Image id="Image1" runat="server" ImageUrl="~/images/seguridad.png" 
                            Width="100px" Height="85px"></asp:Image></td><td align="right"><img src="images/tb.png" alt="Tigo Business" /></td>
				</tr>
				
				<tr>
					<td align="center" colspan="2"><STRONG><FONT face="Arial">Cambio de Contraseña</FONT></STRONG></td>
				</tr>
				<tr>
					<td colspan="2"></td>
				</tr>
				<tr>
					<td align="right" ><FONT face="Arial" size="2" colspan="2">Contraseña Actual: </FONT></td><td align="left">
						<asp:TextBox id="txtActual" runat="server" TextMode="Password" 
                            CssClass="textbox"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="right"><FONT face="Arial" size="2" colspan="2">Contraseña Nueva: </FONT></td><td align="left">
						<asp:TextBox id="txtNueva1" runat="server" TextMode="Password" 
                            CssClass="textbox"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="right"><FONT face="Arial" size="2" colspan="2">Confirme Contraseña:</FONT></td><td align="left">
						<asp:TextBox id="txtNueva2" runat="server" TextMode="Password" 
                            CssClass="textbox"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center" colspan="2">&nbsp;</td>
				</tr>
				<tr>
					<td align="center" colspan="2">&nbsp;
						<asp:Button id="btnAceptar" runat="server" Text="Aceptar" 
                            onclick="btnAceptar_Click" CssClass="button" Width="100px"></asp:Button>&nbsp;
						<asp:Button id="btnCancelar" runat="server" Text="Cancelar" Visible="False" 
                            onclick="btnCancelar_Click" CssClass="button" Width="100px"></asp:Button></td>
				</tr>
			</table>
		    <br />
	    <table width="100%">
            <tr>
                <td align="center" class="style3">
                    Regla para nueva contraseña:</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblReglas" runat="server" style="font-size: medium"></asp:Label>
                </td>
            </tr>            
        </table>
        <br />
		    <asp:Panel ID="Panel1" runat="server" Visible="False">
                <table width="100%">
                    <tr>
                        <td align="right" width="47%" >
                            <FONT face="Arial" size="2">Nivel Básico:</FONT>
                        </td>
                        <td >
                            <FONT face="Arial" size="2">Debe incluir letras y números.</FONT>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="47%">
                            <FONT face="Arial" size="2">Nivel Intermedio:</FONT>
                        </td>
                        <td>
                            <FONT face="Arial" size="2">Debe incluir letras, numeros y letras mayúsculas.</FONT>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="47%">
                            <FONT face="Arial" size="2">Nivel Avanzado:</FONT>
                        </td>
                        <td>
                            <FONT face="Arial" size="2">Debe incluir letras, numeros y por lo menos &nbsp;1 de los siguientes caracteres especiales: &amp; % 
                    $ # + - *</FONT>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
		</form>
	    </body>
</HTML>
