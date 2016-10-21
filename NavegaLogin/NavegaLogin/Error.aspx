<%@ Page language="c#" AutoEventWireup="True" Inherits="NavegaLogin.ErrorClass" Codebehind="Error.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>- Error -</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgProperties="fixed" background="images/fondo_nuevo.jpg">
		<form id="Error" method="post" runat="server">
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
			<div align="center">
				<table width="80%" border="0">
					<tr>
						<td align="left">
						</td>
					</tr>
					<tr>
						<td align="center" style="HEIGHT: 17px"><STRONG><FONT face="Arial" color="#ff0000" size="4">Error:</FONT></STRONG></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<tr>
						<td align="center">
							<asp:Label id="lblMensaje" runat="server" Font-Names="Trebuchet MS" Font-Size="X-Small" ForeColor="Navy"></asp:Label></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<tr>
						<td align="center">
							<INPUT type="button" value="<- Regresar" onclick="javascript:history.go(-1);"></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
