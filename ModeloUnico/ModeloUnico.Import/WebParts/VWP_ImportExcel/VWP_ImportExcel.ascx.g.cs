﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36366
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Furnas.GestaoSPE.ModeloUnico.Import.WebParts.VWP_ImportExcel {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    
    
    public partial class VWP_ImportExcel {
        
        protected global::System.Web.UI.WebControls.DropDownList ddlTipos;
        
        protected global::System.Web.UI.WebControls.DropDownList ddlSPE;
        
        protected global::System.Web.UI.WebControls.DropDownList ddlEmpreendimento;
        
        protected global::System.Web.UI.WebControls.DropDownList ddlPN;
        
        protected global::System.Web.UI.WebControls.DropDownList ddlObra;
        
        protected global::System.Web.UI.WebControls.DropDownList ddlTipo;
        
        protected global::System.Web.UI.WebControls.DropDownList ddlPrevistoRevistoRealizado;
        
        protected global::System.Web.UI.WebControls.FileUpload flpArquivo;
        
        protected global::System.Web.UI.WebControls.Button btnCarregar;
        
        protected global::System.Web.UI.WebControls.Button btnUpload;
        
        protected global::System.Web.UI.WebControls.GridView grvDados;
        
        public static implicit operator global::System.Web.UI.TemplateControl(VWP_ImportExcel target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control3() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "Tipos de Importação";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control4() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "1";
            @__ctrl.Text = "Avanço Fisíco";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control5() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "2";
            @__ctrl.Text = "Avanço Financeiro";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control6() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "3";
            @__ctrl.Text = "DRE";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control7() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "4";
            @__ctrl.Text = "Balanço Patrimonial";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control8() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "5";
            @__ctrl.Text = "Fluxo de Caixa";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control2(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control3();
            @__ctrl.Add(@__ctrl1);
            global::System.Web.UI.WebControls.ListItem @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control4();
            @__ctrl.Add(@__ctrl2);
            global::System.Web.UI.WebControls.ListItem @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control5();
            @__ctrl.Add(@__ctrl3);
            global::System.Web.UI.WebControls.ListItem @__ctrl4;
            @__ctrl4 = this.@__BuildControl__control6();
            @__ctrl.Add(@__ctrl4);
            global::System.Web.UI.WebControls.ListItem @__ctrl5;
            @__ctrl5 = this.@__BuildControl__control7();
            @__ctrl.Add(@__ctrl5);
            global::System.Web.UI.WebControls.ListItem @__ctrl6;
            @__ctrl6 = this.@__BuildControl__control8();
            @__ctrl.Add(@__ctrl6);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlTipos() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlTipos = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlTipos";
            this.@__BuildControl__control2(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control10() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "--SPE--";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control9(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control10();
            @__ctrl.Add(@__ctrl1);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlSPE() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlSPE = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlSPE";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            this.@__BuildControl__control9(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control12() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "--Empreendimento--";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control11(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control12();
            @__ctrl.Add(@__ctrl1);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlEmpreendimento() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlEmpreendimento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlEmpreendimento";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            this.@__BuildControl__control11(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control14() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "--Plano de Negócio--";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control13(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control14();
            @__ctrl.Add(@__ctrl1);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlPN() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlPN = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlPN";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            this.@__BuildControl__control13(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control16() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "--Obra--";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control15(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control16();
            @__ctrl.Add(@__ctrl1);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlObra() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlObra = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlObra";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            this.@__BuildControl__control15(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control18() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "--Tipo--";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control19() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "1";
            @__ctrl.Text = "Regulatório";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control20() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "2";
            @__ctrl.Text = "Societário";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control17(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control18();
            @__ctrl.Add(@__ctrl1);
            global::System.Web.UI.WebControls.ListItem @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control19();
            @__ctrl.Add(@__ctrl2);
            global::System.Web.UI.WebControls.ListItem @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control20();
            @__ctrl.Add(@__ctrl3);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlTipo() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlTipo = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlTipo";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            this.@__BuildControl__control17(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control22() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "--Previsto, Revisto ou Realizado--";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control23() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "1";
            @__ctrl.Text = "Previsto";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control24() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "2";
            @__ctrl.Text = "Revisto";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control25() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Value = "3";
            @__ctrl.Text = "Realizado";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control21(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control22();
            @__ctrl.Add(@__ctrl1);
            global::System.Web.UI.WebControls.ListItem @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control23();
            @__ctrl.Add(@__ctrl2);
            global::System.Web.UI.WebControls.ListItem @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control24();
            @__ctrl.Add(@__ctrl3);
            global::System.Web.UI.WebControls.ListItem @__ctrl4;
            @__ctrl4 = this.@__BuildControl__control25();
            @__ctrl.Add(@__ctrl4);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlPrevistoRevistoRealizado() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlPrevistoRevistoRealizado = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlPrevistoRevistoRealizado";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            this.@__BuildControl__control21(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.FileUpload @__BuildControlflpArquivo() {
            global::System.Web.UI.WebControls.FileUpload @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.FileUpload();
            this.flpArquivo = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "flpArquivo";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Button @__BuildControlbtnCarregar() {
            global::System.Web.UI.WebControls.Button @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Button();
            this.btnCarregar = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.Text = "Carregar";
            @__ctrl.ID = "btnCarregar";
            @__ctrl.CssClass = "btnPrimary";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            @__ctrl.Click -= new System.EventHandler(this.btnCarregar_Click);
            @__ctrl.Click += new System.EventHandler(this.btnCarregar_Click);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Button @__BuildControlbtnUpload() {
            global::System.Web.UI.WebControls.Button @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Button();
            this.btnUpload = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.Text = "Upload";
            @__ctrl.ID = "btnUpload";
            @__ctrl.ClientIDMode = global::System.Web.UI.ClientIDMode.Static;
            @__ctrl.Click -= new System.EventHandler(this.btnUpload_Click);
            @__ctrl.Click += new System.EventHandler(this.btnUpload_Click);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.GridView @__BuildControlgrvDados() {
            global::System.Web.UI.WebControls.GridView @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.GridView();
            this.grvDados = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "grvDados";
            @__ctrl.BorderStyle = global::System.Web.UI.WebControls.BorderStyle.None;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::Furnas.GestaoSPE.ModeloUnico.Import.WebParts.VWP_ImportExcel.VWP_ImportExcel @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"

<script type=""text/javascript"" src=""../SitePages/js/importexcel.js""></script>
<link href='http://fonts.googleapis.com/css?family=Lato:100,400,900' rel='stylesheet' type='text/css' />
<link rel=""stylesheet"" type=""text/css"" href=""../SitePages/css/importexcel.css"" />

<div id=""spe-report-aporte"" class=""ConteudoPagina "">
    <header>
        <h1>IMPORTAÇÃO DE DADOS</h1>
        <h2>TELA DE IMPORTAÇÃO A PARTIR DE PLANILHAS MODELO</h2>
    </header>

    <div class=""propriedades"">
        <div class=""propriedadesTipo filter"">
            "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl1;
            @__ctrl1 = this.@__BuildControlddlTipos();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n        </div>\r\n        <div class=\"propriedadesDados filter\">\r\n            <" +
                        "span>\r\n                "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl2;
            @__ctrl2 = this.@__BuildControlddlSPE();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("</span>\r\n            <span>\r\n                "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl3;
            @__ctrl3 = this.@__BuildControlddlEmpreendimento();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("</span>\r\n            <span>\r\n                "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl4;
            @__ctrl4 = this.@__BuildControlddlPN();
            @__parser.AddParsedSubObject(@__ctrl4);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("</span>\r\n            <span>\r\n                "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl5;
            @__ctrl5 = this.@__BuildControlddlObra();
            @__parser.AddParsedSubObject(@__ctrl5);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("</span>\r\n            <span>\r\n                "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl6;
            @__ctrl6 = this.@__BuildControlddlTipo();
            @__parser.AddParsedSubObject(@__ctrl6);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("</span>\r\n            <span>\r\n                "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl7;
            @__ctrl7 = this.@__BuildControlddlPrevistoRevistoRealizado();
            @__parser.AddParsedSubObject(@__ctrl7);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            </span>\r\n        </div>\r\n    </div>\r\n    <div class=\"tabelaDados\">\r" +
                        "\n        <div class=\"propriedadesfile\">\r\n            "));
            global::System.Web.UI.WebControls.FileUpload @__ctrl8;
            @__ctrl8 = this.@__BuildControlflpArquivo();
            @__parser.AddParsedSubObject(@__ctrl8);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.Button @__ctrl9;
            @__ctrl9 = this.@__BuildControlbtnCarregar();
            @__parser.AddParsedSubObject(@__ctrl9);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.Button @__ctrl10;
            @__ctrl10 = this.@__BuildControlbtnUpload();
            @__parser.AddParsedSubObject(@__ctrl10);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n            \r\n        <div class=\"tabelaDados content\">\r\n      " +
                        "      "));
            global::System.Web.UI.WebControls.GridView @__ctrl11;
            @__ctrl11 = this.@__BuildControlgrvDados();
            @__parser.AddParsedSubObject(@__ctrl11);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"
        </div>
        <div class=""resultado"" id=""dvResultado"">
        </div>
    </div>
    <div class=""modelos"">
        <span>
            <h1>Modelos para Upload</h1>
        </span>
        <div class=""itemModelo"">
            <span>
                <h2>Avanço Físico</h2>
                <img src=""../SitePages/img/excel2.png"" alt=""Avanço Físico"" /></span>
        </div>
        <div class=""itemModelo"">
            <span>
                <h2>Avanço Financeiro</h2>
                <img src=""../SitePages/img/excel2.png"" alt=""Avanço Físico"" /></span>
        </div>
        <div class=""itemModelo"">
            <span>
                <h2>DRE</h2>
                <img src=""../SitePages/img/excel2.png"" alt=""Avanço Físico"" /></span>
        </div>
        <div class=""itemModelo"">
            <span>
                <h2>Fluxo de Caixa</h2>
                <img src=""../SitePages/img/excel2.png"" alt=""Avanço Físico"" /></span>
        </div>
        <div class=""itemModelo"">
            <span>
                <h2>Balanço Patrimonial</h2>
                <img src=""../SitePages/img/excel2.png"" alt=""Avanço Físico"" /></span>
        </div>
    </div>
</div>
"));
        }
        
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}