<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Minuta_Lista_E_Edicao.ascx.cs" Inherits="Furnas.AOPA.Structure.Webparts.Minuta_Lista_E_Edicao.Minuta_Lista_E_Edicao" %>

<style>
    .div_tb {
        width:800px;
        margin:auto;
    }

    .margin-div {
        margin-bottom:20px;
        width:100%;
        float:left;
    }
    /*.nomeSite {
        display:none;
    }*/
</style>

<script type="text/javascript">

</script>



        <Sharepoint:RenderingTemplate runat="server" ID="resnd">
            <Template>
                <SharePoint:ListViewByQuery runat="server" ID="quadroMinuta" />
            </Template>
        </Sharepoint:RenderingTemplate>
   

   <div style="margin-top:40px; margin-bottom:20px; width:1000px;">
       <div class="nomeSite">
            <span class="ms-core-pageTitle">Adicionar Novo Item de Minuta</span>
        </div>
   </div>

<%--    <div class="margin-div">
        <span>Adicionar um Item da Minuta</span>
        <table border="0" cellspacing="0" width="100%">
            <tr>
			    <td width="120px" valign="top" class="ms-formlabel">
				    <H3 class="ms-standardheader">
					    <nobr>Título</nobr>
				    </H3>
			    </td>
			    <td width="350px" valign="top" class="ms-formbody">
                    <asp:TextBox ID="txt_titulo" runat="server" Width="100%"></asp:TextBox>
			    </td>
		    </tr>
            <tr>
			    <td width="120px" valign="top" class="ms-formlabel">
				    <H3 class="ms-standardheader">
					    <nobr>SubNível</nobr>
				    </H3>
			    </td>
			    <td width="350px" valign="top" class="ms-formbody">
                    <asp:DropDownList ID="dpr_SubNivel" runat="server"></asp:DropDownList>
			    </td>
		    </tr>
             <tr>
			    <td width="120px" valign="top" class="ms-formlabel">
				    <H3 class="ms-standardheader">
					    <nobr>Conteúdo</nobr>
				    </H3>
			    </td>
			    <td width="450px" valign="top" class="ms-formbody">
                    <SharePoint:InputFormTextBox ID="txt_conteudo" runat="server" RichText="true" RichTextMode="FullHtml" Rows="12" TextMode="MultiLine" Width="100%" Columns="10"></SharePoint:InputFormTextBox>
                    <SharePoint:RichTextField ID="txt_conteudo" ClientIDMode="Static" runat="server" ControlMode="New" FieldName="teste"></SharePoint:RichTextField>
                    <asp:TextBox ID="txt_conteudo" runat="server" TextMode="MultiLine" Height="350px"></asp:TextBox>
			   </td>
		    </tr>
        </table>
    </div>

    <div class="bt">   
        <asp:Button ID="btnSubmit" Text="Salvar" runat="server" OnClick="btnSubmit_Click" />
    </div>--%>
