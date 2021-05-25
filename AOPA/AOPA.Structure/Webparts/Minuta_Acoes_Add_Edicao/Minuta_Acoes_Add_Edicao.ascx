<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Minuta_Acoes_Add_Edicao.ascx.cs" Inherits="Furnas.AOPA.Structure.Webparts.Minuta_Acoes_Add_Edicao.Minuta_Acoes_Add_Edicao" %>


<script type="text/javascript">
    function OpenDialog(url, title) {
        var options = {
            url: url,
            title: title,
            dialogReturnValueCallback: Function.createDelegate(null, CloseDialogCallback)
            //function DialogCallback(dialogResult, returnValue)
            //{
            //if (returnValue == "1") {
            //    //var meesageId = SP.UI.Notify.addNotification("Loading", false);
            //    SP.UI.ModalDialog.RefreshPage(SP.UI.DialogResult.OK);
            //}
            //}
        };
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    function CloseDialogCallback(dialogResult, returnValue) {
        //SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.RefreshPage', SP.UI.DialogResult.OK);
        location.reload();
    }
    </script>


<style type="text/css">
    .ms-webpartzone-cell {
        margin:0;
    }
</style>

<div style="margin-bottom:20px;">
        <asp:Button ID="voltar_Ato" runat="server" Text="Voltar ao Ato Normativo" ClientIDMode="Static" OnClick="voltar_Ato_Click" />
        <%--<asp:Button ID="novo_item" runat="server" Text="Adicionar Novo Item" ClientIDMode="Static" />--%>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="finalizar" runat="server" Text="Enviar para a Fase de Análise" ClientIDMode="Static" OnClick="finalizar_Click" />
</div>