<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Minuta_Display.ascx.cs" Inherits="Furnas.AOPA.Structure.Webparts.Minuta_Display.Minuta_Display" %>

<script type="text/javascript">
    function OpenDialog(url, title) {
        var options = {
            url: url,
            title: title,
            dialogReturnValueCallback: Function.createDelegate(null, CloseDialogCallback)
        };
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    function CloseDialogCallback(dialogResult, returnValue) {
        //SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.RefreshPage', SP.UI.DialogResult.OK);
        location.reload();
    }
    </script>

<style type="text/css">
    fieldset {
        padding:20px;
    }
</style>

<fieldset runat="server" id="actionsMinutaNIouPolitica">
    <legend>Ações dos Items da Minuta</legend>
    <div>
        <!-- Fase iniciaç -->
        <asp:Button ID="add_item_minuta" runat="server" Text="Adicionar/Editar itens na Minuta" ClientIDMode="Static" Visible="false" OnClick="add_item_minuta_Click" />&nbsp;&nbsp;
        <!-- Fase preparação e Ajuste-->
        <%--<asp:Button ID="revisar_conteudo_ajuste" runat="server" Text="Revisar Minuta na Preparação/Ajuste" ClientIDMode="Static" Visible="false" />--%>
        <!-- Fase do Quadro de Analise para areas-->
        <%--<asp:Button ID="add_analise" runat="server" Text="Analisar Minuta" ClientIDMode="Static" Visible="false" />--%>
        <asp:Button ID="fazer_analise_diretorias" runat="server" Text="Análise dos Itens Minuta" ClientIDMode="Static" Visible="false" OnClick="fazer_analise_diretorias_Click" />&nbsp;&nbsp;
        <!-- Fase Consolidação -->
        <asp:Button ID="fazer_consolidacao" runat="server" Text="Consolidar Itens da Minuta" ClientIDMode="Static" Visible="false" OnClick="fazer_consolidacao_Click" />&nbsp;&nbsp;
        <!-- proposição -->
        <%--<asp:Button ID="fazer_proposição" runat="server" Text="Proposição da Minuta" ClientIDMode="Static" Visible="false" />--%>&nbsp;&nbsp;
        <!-- Fase Aprovação e Emissão da PRD-->
        <asp:Button ID="aprovacao_minuta" runat="server" Text="Aprovação e Publicação da Minuta" ClientIDMode="Static" Visible="false" OnClick="aprovacao_minuta_Click" />&nbsp;&nbsp;
        <!-- Fase Publicar Ato-->
        <%--<asp:Button ID="publicacao_minuta" runat="server" Text="Publicação da Minuta" ClientIDMode="Static" Visible="false" />--%>&nbsp;&nbsp;
        <!-- Revisar Minuta-->
        <%--<asp:Button ID="criar_revisão_minuta" runat="server" Text="Revisar Minuta" ClientIDMode="Static" Visible="false" />--%>
    </div>
</fieldset>