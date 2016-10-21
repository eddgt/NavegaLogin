<%@ Page language="c#" AutoEventWireup="True" Inherits="NavegaLogin.Principal_old" Codebehind="Principal_old.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>:: Pagina Principal ::</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="right"><a href="../ayuda/all/login.htm" target=_blank><FONT face="Arial" size="2"><STRONG>¿Ayuda?</STRONG></FONT></a></td>
				</tr>
				<tr>
					<td width="100%" align="center"><IMG alt="" src="images/mapa2.jpg" useMap="#m_mapa2" border="0" name="mapa">
						<map name="m_mapa2">
							<area shape="RECT" coords="365,397,413,420" href="SeleccionAplicacion.aspx?codpais=PAN"
								target="contenido" title="PANAMA" alt="PANAMA">
							<area shape="RECT" coords="293,351,340,374" href="SeleccionAplicacion.aspx?codpais=CRC"
								target="contenido" title="COSTA RICA" alt="COSTA RICA">
							<area shape="RECT" coords="254,268,302,291" href="SeleccionAplicacion.aspx?codpais=NIC"
								target="contenido" title="NICARAGUA" alt="NICARAGUA">
							<area shape="RECT" coords="154,239,193,257" href="SeleccionAplicacion.aspx?codpais=ELS"
								target="contenido" title="EL SALVADOR" alt="EL SALVADOR">
							<area shape="RECT" coords="209,212,256,233" href="SeleccionAplicacion.aspx?codpais=HON"
								target="contenido" title="HONDURAS" alt="HONDURAS">
							<area shape="RECT" coords="106,195,156,218" href="SeleccionAplicacion.aspx?codpais=GUA"
								target="contenido" title="GUATEMALA" alt="GUATEMALA">
						</map>
					</td>
				</tr>
				<tr>
					<td><iframe id="contenido" name="contenido" src="multipais.aspx" frameBorder="0" width="100"
							height="5"> </iframe>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
