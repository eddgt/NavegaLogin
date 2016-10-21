<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmbClv.aspx.cs" Inherits="NavegaLogin.cmbClv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
<link href="CS/newStyle.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 213px;
        }
        .style4
        {
            height: 41px;
        }
        .style5
        {
            width: 876px;
            height: 41px;
        }
        .style6
        {
            width: 128px;
            height: 41px;
        }
        .style7
        {
            height: 13px;
        }
        .style8
        {
            width: 876px;
            height: 13px;
        }
        .style9
        {
            width: 128px;
            height: 42px;
        }
        .style10
        {
            width: 876px;
            height: 42px;
        }
        .style11
        {
            height: 13px;
            width: 197px;
        }
        .style12
        {
            width: 197px;
            height: 42px;
        }
        .style13
        {
            width: 197px;
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 204px; width: 540px;">
    
        <table class="style1">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style4" colspan="2" >
                    <asp:Label ID="Label1" runat="server" Text="Ya puedes Modificar Tu Contraseña"  ForeColor="Navy" Font-Bold="True" Font-Size="10"></asp:Label></td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
                <td class="style11">
                </td>
                <td class="style8">
                </td>
            </tr>
            <tr>
                <td class="style9">
                    </td>
                <td class="style12">
        <asp:Label ID="lblUser" runat="server" Text="Usuario:"  ForeColor="Navy" Font-Bold="True" Font-Size="10"></asp:Label>
                </td>
                <td class="style10">
        <asp:TextBox ID="txtUser" runat="server" CssClass="textbox" Width="169px" Height="23px" 
                        Enabled="False" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validaTxtUsuario" runat="server" 
                        ControlToValidate="txtUser" ErrorMessage="El usuario es requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    </td>
                <td class="style12">
        <asp:Label ID="lblPass" runat="server" Text="Indica tu Nueva Contraseña:" ForeColor="Navy" Font-Bold="True" Font-Size="10"></asp:Label>
                </td>
                <td class="style10">
        <asp:TextBox ID="txtPass" runat="server" CssClass="textbox" Width="170px" Height="23px" 
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validaTxtContrasena" runat="server" 
                        ControlToValidate="txtPass" ErrorMessage="La contraseña es requerida"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    </td>
                <td class="style13">
                    </td>
                <td class="style5">
                <asp:Button ID="btnGuardar" runat="server" Text="Cambiar Contraseña" CssClass="button"
            onclick="btnGuardar_Click" Width="172px" /> 
    
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#009933" Text="Label" 
                        Visible="False"></asp:Label>
    
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="lblMensaje2" runat="server" ForeColor="#009933" Text="Label" Visible="False"></asp:Label>
    
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
        </table>
    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    
    </div>
    </form>
     <div class="loading" align="center">
    Loading. Please wait.<br />
    <br />
    <img src="../images/loader.gif" alt="" />
</div>
</body>
 <script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });

    function redirect() {
        // defer the execution of anonymous function for 
        // 3 seconds and go to next line of code.
        setTimeout(function() {
            alert('hello');
        }, 2000);

        window.location.href = "https://172.16.5.19/navegalogin/Login.aspx";
    }
    
</script>
</html>