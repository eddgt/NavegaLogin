<%@ Page language="c#" AutoEventWireup="True" Inherits="NavegaLogin.Mensaje" Codebehind="Mensaje.aspx.cs" %>
<html>
	<head>
		<title>- Notificación -</title>
	    <link href="CS/newStyleWhite.css" rel="stylesheet" type="text/css" />
	</head>
	<body >
		<form id="FormMensaje" method="post" runat="server">
		<img src="images/tb.png" alt="Tigo Business"  style="position:absolute;top:10px;right:10;"/>
			<br/>
			<br/>
			<br/>
			<br/>
			<div align="center">
				<table border="0" width="80%">
					<tr>
						<td align="center">
							<asp:Label id="lblTitulo" runat="server" Font-Names="Arial" Font-Size="Small" 
                                Font-Bold="True"></asp:Label></td>
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
							<asp:Button id="Button1" runat="server" Text="Continuar" 
                                onclick="Button1_Click" CssClass="button" Width="110px"></asp:Button></td>
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
							<asp:Button id="btnSI" runat="server" Text="SI" Width="75px" 
                                onclick="btnSI_Click" CssClass="button"></asp:Button>&nbsp;&nbsp;
							<asp:Button id="btnNO" runat="server" Text="NO" Width="75px" 
                                onclick="btnNO_Click" CssClass="button"></asp:Button></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</html>
