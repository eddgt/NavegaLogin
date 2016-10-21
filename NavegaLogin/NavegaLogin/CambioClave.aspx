<%@ Page language="c#" AutoEventWireup="True" Inherits="NavegaLogin.CambioClave" Codebehind="CambioClave.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>- Cambio de Contraseña -</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgProperties="fixed" background="images/fondo_nuevo.jpg">
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%">
				<tr>
					<td>
						<asp:Image id="Image1" runat="server" ImageUrl="images/change_password.jpg" Width="120px" Height="104px"></asp:Image></td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td align="center"><STRONG><FONT face="Arial">Cambio de Contraseña</FONT></STRONG></td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td align="center"><FONT face="Arial" size="2">Contraseña Actual: </FONT>
						<asp:TextBox id="txtActual" runat="server" TextMode="Password"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center"><FONT face="Arial" size="2">Contraseña Nueva: </FONT>
						<asp:TextBox id="txtNueva1" runat="server" TextMode="Password"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center"><FONT face="Arial" size="2">Contraseña Nueva:</FONT>
						<asp:TextBox id="txtNueva2" runat="server" TextMode="Password"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center">&nbsp;</td>
				</tr>
				<tr>
					<td align="center">&nbsp;
						<asp:Button id="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click"></asp:Button>&nbsp;
						<asp:Button id="btnCancelar" runat="server" Text="Cancelar" Visible="False" onclick="btnCancelar_Click"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
