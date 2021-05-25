<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ato_NovaRevisao.ascx.cs" Inherits="Furnas.AOPA.Structure.Webpart.Ato_NovaRevisao.Ato_NovaRevisao" %>

<script type="text/javascript">
    function CloseForm() {

        window.frameElement.cancelPopUp();

        return false;

    }
</script>
<style>
    .ms-webpartPage-root {
        border-spacing:0px!important;
    }
    .asteriscoRed {
        color: red !important;
    }
</style>

<link rel="stylesheet" href="../SiteAssets/Scripts/Datapicker/css/jquery-ui-1.9.2.custom.css">
<script src="../SiteAssets/Scripts/Datapicker/js/jquery-ui-1.9.2.custom.js"></script>
<script src="../SiteAssets/Scripts/Datapicker/js/datapicker.js"></script>

<div style="margin-top:25px;">
    <table  border="0" cellspacing="0" width="100%">
        <tr>
             <td width="390px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>&nbsp;&nbsp;</nobr>
				</H3>
            </td>
              <td width="400px" valign="top" class="ms-formbody">
                  <asp:RadioButton ID="revisao" runat="server" Text="Revisão" GroupName="Revisão" Checked="true" AutoPostBack="True" OnCheckedChanged="revisao_CheckedChanged"/>
                  <asp:RadioButton ID="validacao" runat="server" Text="Validação" GroupName="Revisão" AutoPostBack="True" OnCheckedChanged="validacao_CheckedChanged"/>
              </td>
         </tr>
        <tr>
            <td>&nbsp;&nbsp;</td>
            <td>&nbsp;&nbsp;</td>
        </tr>
    </table>
    <table border="0" cellspacing="0" width="100%" runat="server" id="tbValidacao" visible="false">
        <tr>
			<td width="390px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Conclusão da Preparação</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:Label ID="conclusaoPreparacao" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td width="390px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Conclusão do Ajuste</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:Label ID="conclusaoAjuste" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td width="390px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Conclusão da Análise</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:Label ID="conclusaoAnalise" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td width="390px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Conslusão da Consolidação</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:Label ID="conclusaoConsolidacao" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td width="390px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Conclusão Proposição</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:Label ID="conclusaoProposicao" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td width="390px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Conclusão da Aprovação</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:Label ID="conclusaoAprovacao" runat="server"></asp:Label>
			</td>
		</tr>
    </table>
     <table border="0" cellspacing="0" width="100%" runat="server" id="tbRevisao">
         <%--<tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Número da Revisão</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:TextBox ID="numRevisao" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
			</td>
		</tr>
         <tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Número Validação</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:TextBox ID="numValidacao" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
			</td>
		</tr>
          <tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Situação</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:TextBox ID="situacao" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
			</td>
		</tr>--%>
         
         <tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Solicitação de Abertura da Revisão/Elaboração</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:TextBox ID="solicitaRevisao" TextMode="MultiLine" runat="server" Height="73px" Width="468px" ClientIDMode="Static"></asp:TextBox>
			</td>
		</tr>
         <tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data da Solicitação da Abertura Revisão/Elaboração</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:TextBox ID="dtSolicitacao" runat="server" ClientIDMode="Static"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Justificativa Revisão Elaboração</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:TextBox ID="justificativa_revisao" TextMode="MultiLine" runat="server" Height="73px" Width="468px" ClientIDMode="Static"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data Início Revisão</nobr>
				</H3>
			</td>
			<td width="400px" valign="top"  class="ms-formbody">
                <asp:TextBox ID="data_inicio_revisao" runat="server" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="data_inicio_revisao_TextChanged"></asp:TextBox>
			</td>
		</tr>
         <tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Fase da Revisão</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:Label ID="nomeFase" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:Label>
			</td>
		</tr>
         <tr>
             <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Andamento da Fase</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
             <td width="400px" valign="top" class="ms-formbody">
                 <asp:DropDownList ID="andamentoFase" runat="server" ClientIDMode="Static"></asp:DropDownList>
                 
             </td>
         </tr>
         <tr>
             <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Ação</nobr>
				</H3>
            </td>
              <td width="400px" valign="top" class="ms-formbody">
                  <asp:TextBox ID="acao" TextMode="MultiLine" runat="server" Height="73px" Width="468px" ClientIDMode="Static"></asp:TextBox>
              </td>
         </tr>
         <tr>
             <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Destaque da semana</nobr>
				</H3>
            </td>
              <td width="400px" valign="top" class="ms-formbody">
                  <asp:RadioButton ID="destaqueSemana" runat="server" Text="Sim" ClientIDMode="Static" />
              </td>
         </tr>
          <tr>
             <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Pendência</nobr>
				</H3>
			</td>
             <td width="400px" valign="top" class="ms-formbody">
                 <asp:DropDownList ID="tipoPendencia" runat="server" ClientIDMode="Static"></asp:DropDownList>
             </td>
         </tr>
         <tr>
			<td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data Pendência</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:TextBox ID="datePendencia" runat="server" ClientIDMode="Static"></asp:TextBox>
			</td>
		</tr>
         <tr>
             <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Observação</nobr>
				</H3>
            </td>
              <td width="400px" valign="top" class="ms-formbody">
                  <asp:TextBox ID="observacao" TextMode="MultiLine" runat="server" Height="73px" Width="468px" ClientIDMode="Static"></asp:TextBox>
              </td>
         </tr>
      </table>
    <div style="margin:auto;padding-top:20px; text-align:left; width:100%;">
        <div style="width:30%; float:right">
            <asp:Button ID="save" runat="server" Text="Salvar" OnClick="save_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="cancel" runat="server" Text="Cancelar" OnClientClick="CloseForm()" />
        </div>
    </div>
</div>