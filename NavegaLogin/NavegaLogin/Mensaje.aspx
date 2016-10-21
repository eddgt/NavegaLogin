<%@ Page language="c#" AutoEventWireup="True" Inherits="NavegaLogin.Mensaje" Codebehind="Mensaje.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>- Notificación -</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgProperties="fixed" background="images/fondo_nuevo.jpg">
		<form id="FormMensaje" method="post" runat="server">
			<br>
			<br>
			<br>
			<br>
			<br>
			<div align="center">
				<table border="0" width="80%">
					<tr>
						<td align="center">
							<asp:Label id="lblTitulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Font-Bold="True"></asp:Label></td>
					</tr>
					<tr>
						<td align="center">&nbsp;</td>
					</tr>
					<tr>
						<td align="center">
							<asp:Label id="lblMensaje" runat="server" Font-Names="Arial" Font-Size="X-Small" ForeColor="Navy"></asp:Label></td>
					</tr>
					<tr>
						<td align="center"></td>
					</tr>
					<tr>
						<td align="center">
							<asp:Button id="Button1" runat="server" Text="Continuar" onclick="Button1_Click"></asp:Button></td>
					</tr>
					<tr>
						<td align="center" height="30"></td>
					</tr>
					<tr>
						<td align="center"></td>
					</tr>
					<tr>
						<td align="center">
							<asp:Label id="lblTitulo2" runat="server" Font-Bold="True" Font-Size="X-Small" Font-Names="Arial"></asp:Label></td>
					</tr>
					<tr>
						<td align="center"></td>
					</tr>
					<tr>
						<td align="center">
							<asp:Button id="btnSI" runat="server" Text="SI" Width="75px" onclick="btnSI_Click"></asp:Button>&nbsp;&nbsp;
							<asp:Button id="btnNO" runat="server" Text="NO" Width="75px" onclick="btnNO_Click"></asp:Button></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
