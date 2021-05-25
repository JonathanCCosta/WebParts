<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VWP_ImportExcel.ascx.cs" Inherits="Furnas.GestaoSPE.ModeloUnico.Import.WebParts.VWP_ImportExcel.VWP_ImportExcel" %>

<script type="text/javascript" src="../SitePages/js/importexcel.js"></script>
<link href='http://fonts.googleapis.com/css?family=Lato:100,400,900' rel='stylesheet' type='text/css' />
<link rel="stylesheet" type="text/css" href="../SitePages/css/importexcel.css" />

<div id="spe-report-aporte" class="ConteudoPagina ">
    <header>
        <h1>IMPORTAÇÃO DE DADOS</h1>
        <h2>TELA DE IMPORTAÇÃO A PARTIR DE PLANILHAS MODELO</h2>
    </header>

    <div class="propriedades">
        <div class="propriedadesTipo filter">
            <asp:DropDownList ID="ddlTipos" runat="server">
                <asp:ListItem Selected="True" Text="Tipos de Importação" Value="0"></asp:ListItem>
                <asp:ListItem Value="1" Text="Avanço Fisíco" />
                <asp:ListItem Value="2" Text="Avanço Financeiro" />
                <asp:ListItem Value="3" Text="DRE" />
                <asp:ListItem Value="4" Text="Balanço Patrimonial" />
                <asp:ListItem Value="5" Text="Fluxo de Caixa" />
            </asp:DropDownList>

        </div>
        <div class="propriedadesDados filter">
            <span>
                <asp:DropDownList runat="server" ID="ddlSPE" ClientIDMode="Static">
                    <asp:ListItem Selected="True" Text="--SPE--" Value="0"></asp:ListItem>
                </asp:DropDownList></span>
            <span>
                <asp:DropDownList runat="server" ID="ddlEmpreendimento" ClientIDMode="Static">
                    <asp:ListItem Selected="True" Text="--Empreendimento--" Value="0"></asp:ListItem>
                </asp:DropDownList></span>
            <span>
                <asp:DropDownList runat="server" ID="ddlPN" ClientIDMode="Static">
                    <asp:ListItem Selected="True" Text="--Plano de Negócio--" Value="0"></asp:ListItem>
                </asp:DropDownList></span>
            <span>
                <asp:DropDownList runat="server" ID="ddlObra" ClientIDMode="Static">
                    <asp:ListItem Selected="True" Text="--Obra--" Value="0"></asp:ListItem>
                </asp:DropDownList></span>
            <span>
                <asp:DropDownList runat="server" ID="ddlTipo" ClientIDMode="Static">
                    <asp:ListItem Selected="True" Text="--Tipo--" Value="0"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Regulatório" />
                    <asp:ListItem Value="2" Text="Societário" />
                </asp:DropDownList></span>
            <span>
                <asp:DropDownList runat="server" ID="ddlPrevistoRevistoRealizado" ClientIDMode="Static">
                    <asp:ListItem Selected="True" Text="--Previsto, Revisto ou Realizado--" Value="0"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Previsto" />
                    <asp:ListItem Value="2" Text="Revisto" />
                    <asp:ListItem Value="3" Text="Realizado" />
                </asp:DropDownList>
            </span>
        </div>
    </div>
    <div class="tabelaDados">
        <div class="propriedadesfile">
            <asp:FileUpload runat="server" ID="flpArquivo" />
            <asp:Button Text="Carregar" runat="server" ID="btnCarregar" OnClick="btnCarregar_Click" CssClass="btnPrimary" ClientIDMode="Static" />
            <asp:Button Text="Upload" runat="server" ID="btnUpload" OnClick="btnUpload_Click" ClientIDMode="Static" />
        </div>
            
        <div class="tabelaDados content">
            <asp:GridView runat="server" ID="grvDados" BorderStyle="None"></asp:GridView>
        </div>
        <div class="resultado" id="dvResultado">
        </div>
    </div>
    <div class="modelos">
        <span>
            <h1>Modelos para Upload</h1>
        </span>
        <div class="itemModelo">
            <span>
                <h2>Avanço Físico</h2>
                <img src="../SitePages/img/excel2.png" alt="Avanço Físico" /></span>
        </div>
        <div class="itemModelo">
            <span>
                <h2>Avanço Financeiro</h2>
                <img src="../SitePages/img/excel2.png" alt="Avanço Físico" /></span>
        </div>
        <div class="itemModelo">
            <span>
                <h2>DRE</h2>
                <img src="../SitePages/img/excel2.png" alt="Avanço Físico" /></span>
        </div>
        <div class="itemModelo">
            <span>
                <h2>Fluxo de Caixa</h2>
                <img src="../SitePages/img/excel2.png" alt="Avanço Físico" /></span>
        </div>
        <div class="itemModelo">
            <span>
                <h2>Balanço Patrimonial</h2>
                <img src="../SitePages/img/excel2.png" alt="Avanço Físico" /></span>
        </div>
    </div>
</div>
