<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ato_Editar_Revisao.ascx.cs" Inherits="Furnas.AOPA.Structure.Webparts.Ato_Editar_Revisao.Ato_Editar_Revisao" %>


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
    .nomeSite {
        display:none;
    }
</style>

<link rel="stylesheet" href="../SiteAssets/Scripts/Datapicker/css/jquery-ui-1.9.2.custom.css">
<script src="../SiteAssets/Scripts/Datapicker/js/jquery-ui-1.9.2.custom.js"></script>
<script src="../SiteAssets/Scripts/Datapicker/js/datapicker.js"></script>

<div style="margin-top:25px;">
    <table border="0" cellspacing="0" width="100%" runat="server" id="tbRevisao">       			
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
        <tr runat="server" visible="false" id="trDataConclusaoFase">
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data Conslusão Fase</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:TextBox ID="dataConclusaoFase" runat="server" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="dataConclusaoFase_TextChanged"></asp:TextBox>
			</td>
        </tr>
        <tr>
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Situação</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
             <td width="400px" valign="top" class="ms-formbody">
                 <asp:DropDownList ID="dprSituacao" runat="server" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="dprSituacao_SelectedIndexChanged"></asp:DropDownList>
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
					<nobr>Data Vencimento</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:Label ID="dataVencimento" runat="server" ClientIDMode="Static"></asp:Label>
			</td>
        </tr>
        <tr>
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data Limite para Entrada em Revisão(d-60)</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
				<asp:Label ID="dataEntradRevisao" runat="server" ClientIDMode="Static"></asp:Label>
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
					<nobr>Conclusão do Ajuste</nobr>
				</H3>
            </td>
              <td width="400px" valign="top" class="ms-formbody">
                  <asp:TextBox ID="conclusaoAjuste" runat="server" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="conclusaoAjuste_TextChanged"></asp:TextBox>
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
        <tr runat="server" id="trPrazoRN" visible="false">
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Prazo RN</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:TextBox ID="prazoRN" runat="server" ClientIDMode="Static"></asp:TextBox>
			</td>
        </tr>
        <tr runat="server" id="trRetornoRN" visible="false">
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Retorno RN</nobr>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:TextBox ID="retornoRN" runat="server" ClientIDMode="Static"></asp:TextBox>
			</td>
        </tr>
        <tr runat="server" id="trDatSuspensao" visible="false">
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data Suspensão</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:TextBox ID="datSuspensao" runat="server" ClientIDMode="Static"></asp:TextBox>
			</td>
        </tr>
        <tr>
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data Extinção</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:TextBox ID="dataExtincao" runat="server" ClientIDMode="Static"></asp:TextBox>
			</td>
        </tr>
        <tr runat="server" id="trDatInterrupcao" visible="false">
            <td width="190px" valign="top" class="ms-formlabel">
				<H3 class="ms-standardheader">
					<nobr>Data Interrupção</nobr>
                    <span class="asteriscoRed">* </span>
				</H3>
			</td>
			<td width="400px" valign="top" class="ms-formbody">
                <asp:TextBox ID="dataInterrupcao" runat="server" ClientIDMode="Static"></asp:TextBox>
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
            <asp:Button ID="save" runat="server" Text="Salvar" />
            &nbsp;&nbsp;
            <asp:Button ID="cancel" runat="server" Text="Cancelar" OnClientClick="CloseForm()" />
        </div>
    </div>
</div>