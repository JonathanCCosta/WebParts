<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ato_Display_Revisao.ascx.cs" Inherits="Furnas.AOPA.Structure.Webpart.Ato_Display_Revisao.Ato_Display_Revisao" %>

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

<fieldset runat="server" id="actionsAtoNIouPolitica">
    <legend>Ações Ato Normativo</legend>
    <div>
        <asp:Button ID="editar_Ato" runat="server" Text="Editar Ato Normativo" ClientIDMode="Static" />
       <%-- <asp:Button ID="add_minuta" runat="server" Text="Adicionar Minuta" ClientIDMode="Static" Visible="false" />
        <asp:Button ID="criar_revisão_minuta" runat="server" Text="Revisar Minuta" ClientIDMode="Static" Visible="false" />--%>
        <asp:Button ID="prazoRN" runat="server" Text="Adicionar Prazo RN" ClientIDMode="Static" Visible="false" />
        <asp:Button ID="revisao" runat="server" Text="Iniciar Revisão" Visible="false" OnClick="revisao_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="validacao" runat="server" Text="Validar Revisão" Visible="false" OnClick="validacao_Click" />
    </div>
</fieldset>
<%--<fieldset runat="server" id="actions">
    <legend>Ações Revisão/Validação</legend>
    <div style="width:500px;">
        <asp:Button ID="incluir_revisao" runat="server" Text="Incluir Revisão" ClientIDMode="Static" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="editar_revisao" runat="server" Text="Editar Revisão" Visible="false" ClientIDMode="Static" />
    </div>
</fieldset>--%>