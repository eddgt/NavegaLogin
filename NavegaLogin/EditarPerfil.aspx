<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="NavegaLogin.EditarPerfil" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
    <link href="App_Themes/CS/StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
            height: 54px;
        }
        .style4
        {
            width: 1187px;
        }
        .style5
        {
            width: 16px;
        }
        .style11
        {
            width: 22px;
        }
    </style>
    
    <link href="CS/StyleSheet.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table class="style4">
        <tr>
            <td class="titulopanelazul" colspan="6">
                <asp:Label ID="Label1" runat="server" Text="Editar Perfil" 
                    meta:resourcekey="Label1Resource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <asp:Label ID="Label2" runat="server" Text="Empresa" 
                    meta:resourcekey="Label2Resource1"></asp:Label>
                <asp:DropDownList ID="DDL_Empresa" runat="server" DataSourceID="ODS_Empresa" 
                    DataTextField="Descripcion" DataValueField="CodEmpresa" 
                    meta:resourcekey="DDL_EmpresaResource1">
                </asp:DropDownList>
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Buscar" 
                    meta:resourcekey="Button2Resource1" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Seleccionar Todos" meta:resourcekey="Button1Resource1" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <dxwgv:ASPxGridView ID="ASPxGV_Usuarios" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="ODS_Usuarios" 
                    KeyFieldName="CodUsuario" 
                    onselectionchanged="ASPxGV_Usuarios_SelectionChanged" 
                    CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                    CssPostfix="Office2003_Blue" meta:resourcekey="ASPxGV_UsuariosResource1">
                    <Templates>
                        <DetailRow>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <dxwgv:ASPxGridView ID="ASPxGV_Detalle" runat="server" 
                                            AutoGenerateColumns="False" 
                                            CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                                            CssPostfix="Office2003_Blue" DataSourceID="ODS_Detalle" 
                                            KeyFieldName="CodUsuario" 
                                            onbeforeperformdataselect="ASPxGV_Detalle_BeforePerformDataSelect" 
                                            meta:resourcekey="ASPxGV_DetalleResource1">
                                            <Styles CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                                                CssPostfix="Office2003_Blue">
                                                <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                </Header>
                                                <LoadingPanel ImageSpacing="10px">
                                                </LoadingPanel>
                                            </Styles>
                                            <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                                                <CollapsedButton Height="12px" 
                                                    Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png" 
                                                    Width="11px" />
                                                <ExpandedButton Height="12px" 
                                                    Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png" Width="11px" />
                                                <DetailCollapsedButton Height="12px" 
                                                    Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png" 
                                                    Width="11px" />
                                                <DetailExpandedButton Height="12px" 
                                                    Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png" Width="11px" />
                                                <FilterRowButton Height="13px" Width="13px" />
                                            </Images>
                                            <Columns>
                                                <dxwgv:GridViewDataTextColumn FieldName="CodUsuario" ReadOnly="True" 
                                                    Visible="False" VisibleIndex="0" 
                                                    meta:resourcekey="GridViewDataTextColumnResource1">
                                                </dxwgv:GridViewDataTextColumn>
                                                <dxwgv:GridViewDataComboBoxColumn Caption="Autenticación" 
                                                    FieldName="CodTipoAut" ReadOnly="True" VisibleIndex="0" 
                                                    meta:resourcekey="GridViewDataComboBoxColumnResource1">
                                                    <PropertiesComboBox DataSourceID="ODS_TiposdeAutenticacion" TextField="Nombre" 
                                                        ValueField="CodTipoAut" ValueType="System.String">
                                                    </PropertiesComboBox>
                                                </dxwgv:GridViewDataComboBoxColumn>
                                            </Columns>
                                            <StylesEditors>
                                                <ProgressBar Height="25px">
                                                </ProgressBar>
                                            </StylesEditors>
                                        </dxwgv:ASPxGridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </DetailRow>
                    </Templates>
                    <Styles CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                        CssPostfix="Office2003_Blue">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                        <CollapsedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png" 
                            Width="11px" />
                        <ExpandedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png" Width="11px" />
                        <DetailCollapsedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png" 
                            Width="11px" />
                        <DetailExpandedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png" Width="11px" />
                        <FilterRowButton Height="13px" Width="13px" />
                    </Images>
                    <Columns>
                        <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" 
                            meta:resourcekey="GridViewCommandColumnResource1">
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="CodUsuario" ReadOnly="True" 
                            VisibleIndex="1" Caption="Usuario" 
                            meta:resourcekey="GridViewDataTextColumnResource2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="Apellidos" VisibleIndex="2" 
                            Caption="Apellidos" meta:resourcekey="GridViewDataTextColumnResource3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="Nombres" VisibleIndex="3" 
                            Caption="Nombres" meta:resourcekey="GridViewDataTextColumnResource4">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <StylesEditors>
                        <ProgressBar Height="25px">
                        </ProgressBar>
                    </StylesEditors>
                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6" class="style3">
                <dxe:ASPxButton ID="ASPxButton1" runat="server" EnableDefaultAppearance="False" 
                    onclick="ASPxButton1_Click" meta:resourcekey="ASPxButton1Resource1">
                    <Image Url="~/images/Symbol-Check_32x32.png" />
                </dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6" class="style3">
                <asp:Label ID="lbl_error" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="Medium" ForeColor="Red" meta:resourcekey="lbl_errorResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                &nbsp;</td>
            <td align="center" colspan="2">
                <dxpc:ASPxPopupControl ID="ASPxPC_TipoAutenticacion" runat="server" 
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
                    CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                    CssPostfix="Office2003_Blue" EnableHotTrack="False" 
                    ImageFolder="~/App_Themes/Office2003 Blue/{0}/" 
                    HeaderText="Tipos de Autenticación" 
                    meta:resourcekey="ASPxPC_TipoAutenticacionResource1">
                    <SizeGripImage Height="16px" Width="16px" />
                    <ContentCollection>
<dxpc:PopupControlContentControl runat="server" meta:resourcekey="PopupControlContentControlResource1">
    <table class="style1">
        <tr>
            <td class="style2" colspan="2">
                <dxwgv:ASPxGridView ID="ASPxGV_TipoAutenticacion" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="ODS_TiposdeAutenticacion" 
                    KeyFieldName="CodTipoAut" 
                    OnSelectionChanged="ASPxGV_TipoAutenticacion_SelectionChanged" 
                    CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                    CssPostfix="Office2003_Blue" 
                    meta:resourcekey="ASPxGV_TipoAutenticacionResource1">
                    <Columns>
                        <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" 
                            meta:resourcekey="GridViewCommandColumnResource2">
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="CodTipoAut" ReadOnly="True" 
                            Visible="False" VisibleIndex="1" 
                            meta:resourcekey="GridViewDataTextColumnResource5">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="1" 
                            meta:resourcekey="GridViewDataTextColumnResource6">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <Images ImageFolder="~/App_Themes/Office2003 Blue/{0}/">
                        <CollapsedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png" 
                            Width="11px" />
                        <ExpandedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png" Width="11px" />
                        <DetailCollapsedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvCollapsedButton.png" 
                            Width="11px" />
                        <DetailExpandedButton Height="12px" 
                            Url="~/App_Themes/Office2003 Blue/GridView/gvExpandedButton.png" Width="11px" />
                        <FilterRowButton Height="13px" Width="13px" />
                    </Images>
                    <Styles CssFilePath="~/App_Themes/Office2003 Blue/{0}/styles.css" 
                        CssPostfix="Office2003_Blue">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <StylesEditors>
                        <ProgressBar Height="25px">
                        </ProgressBar>
                    </StylesEditors>
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <dxe:ASPxButton ID="ASPxButton_aceptar" runat="server" 
                    EnableDefaultAppearance="False" OnClick="ASPxButton_aceptar_Click" 
                    Width="100px" meta:resourcekey="ASPxButton_aceptarResource1">
                    <Image Url="~/images/Symbol-Check_32x32.png" />
                </dxe:ASPxButton>
            </td>
            <td>
                <dxe:ASPxButton ID="ASPxButton_canelar" runat="server" 
                    EnableDefaultAppearance="False" Width="100px" 
                    OnClick="ASPxButton_canelar_Click" 
                    meta:resourcekey="ASPxButton_canelarResource1">
                    <Image Url="~/images/Symbol-Delete_32x32.png" />
                </dxe:ASPxButton>
            </td>
        </tr>
    </table>
                        </dxpc:PopupControlContentControl>
</ContentCollection>
                    <CloseButtonImage Height="12px" Width="13px" />
                    <HeaderStyle>
                    <Paddings PaddingRight="6px" />
                    </HeaderStyle>
                </dxpc:ASPxPopupControl>
            </td>
            <td align="right" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style5">
                &nbsp;</td>
            <td colspan="2">
                <asp:ObjectDataSource ID="ODS_Usuarios" runat="server" DeleteMethod="Delete" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    
                    TypeName="NavegaLogin.DS.sso_usuariosTableAdapters.CTL_EMPLEADOTableAdapter">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CodUsuario" Type="String" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lbl_Empresa" DefaultValue="1" Name="empresa" 
                            PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODS_TiposdeAutenticacion" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="NavegaLogin.DS.sso_usuariosTableAdapters.SSO_TIPOAUTENTICACIONTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CodTipoAut" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Nombre" Type="String" />
                        <asp:Parameter Name="Original_CodTipoAut" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CodTipoAut" Type="Int32" />
                        <asp:Parameter Name="Nombre" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODS_Empresa" runat="server" DeleteMethod="Delete" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="NavegaLogin.DS.sso_usuariosTableAdapters.CTL_EMPRESATableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CodEmpresa" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Descripcion" Type="String" />
                        <asp:Parameter Name="Original_CodEmpresa" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODS_Detalle" runat="server" DeleteMethod="Delete" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="NavegaLogin.DS.sso_usuariosTableAdapters.SEG_EMPLEADO_TIPOAUTENTICACIONTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CodTipoAut" Type="Int32" />
                        <asp:Parameter Name="Original_CodUsuario" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Original_CodTipoAut" Type="Int32" />
                        <asp:Parameter Name="Original_CodUsuario" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lbl_Usuario" DefaultValue="1" Name="Usuario" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td colspan="2">
                <asp:Label ID="lbl_Empresa" runat="server" Visible="False" 
                    meta:resourcekey="lbl_EmpresaResource1"></asp:Label>
                <asp:Label ID="lbl_Usuario" runat="server" Visible="False" 
                    meta:resourcekey="lbl_UsuarioResource1"></asp:Label>
            </td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style5">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
