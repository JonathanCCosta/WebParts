using Furnas.AOPA.Base.Service;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Furnas.AOPA.Structure.Webparts.Minuta_AnaliseConsolidacao
{
    [ToolboxItemAttribute(false)]
    public partial class Minuta_AnaliseConsolidacao : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Minuta_AnaliseConsolidacao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected static string idRequest;

        protected static string Fase;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idRequest = "0";

                try
                {
                    idRequest = Page.Request.QueryString.GetValues("ID")[0];
                }
                catch { }

                //Analista(id);

                RetornaFase();

                DataTable items = AcoesMinuta.TodosItemsMinuta(SPContext.Current.Web, idRequest);

                grdAnaliseConsolidacao.DataSource = items;
                grdAnaliseConsolidacao.DataBind();

                grdAnaliseConsolidacao.Columns[0].Visible = false;

                if (Fase == "Aprovação")
                {
                    btn_Aprovacao.Visible = true;
                }

                if (Fase == "Análise" || Fase == "Consolidação")
                {
                    string url = SPContext.Current.Site.RootWeb.Url + "/Lists/Minuta/NewForm.aspx?Ato=" + idRequest;
                    btn_addNovoItem.OnClientClick = "javascript:OpenDialog('" + url + "','Novo Item Minuta');return false;";
                    btn_addNovoItem.Visible = true;
                }
            }
        }

        public void RetornaFase()
        {
            SPListItem itemAto = ManipulaLista.RetornaLista("Ato", SPContext.Current.Web, Convert.ToInt32(Page.Request.QueryString.GetValues("ID")[0]));

            //if (new SPFieldLookupValue(itemAto["Fase da Revisão"].ToString()).LookupValue == "Consolidação")
            //{
                Fase = new SPFieldLookupValue(itemAto["Fase da Revisão"].ToString()).LookupValue;
            //}
            //else
            //{
            //    Fase = string.Empty;
            //}
        }

        protected void grdAnaliseConsolidacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var dropDA = e.Row.Cells[5].FindControl("dprStatusDA") as DropDownList;
                var dropDE = e.Row.Cells[5].FindControl("dprStatusDE") as DropDownList;
                var dropDF = e.Row.Cells[5].FindControl("dprStatusDF") as DropDownList;
                var dropDN = e.Row.Cells[5].FindControl("dprStatusDN") as DropDownList;
                var dropDP = e.Row.Cells[5].FindControl("dprStatusDP") as DropDownList;
                var dropDO = e.Row.Cells[5].FindControl("dprStatusDO") as DropDownList;

                if (dropDA != null)
                {
                    dropDA.Items.FindByText(((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[17].ToString()).Selected = true;
                }
                if (dropDE != null)
                {
                    dropDE.Items.FindByText(((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[18].ToString()).Selected = true;
                }
                if (dropDF != null)
                {
                    dropDF.Items.FindByText(((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[19].ToString()).Selected = true;
                }
                if (dropDN != null)
                {
                    dropDN.Items.FindByText(((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[20].ToString()).Selected = true;
                }
                if (dropDP != null)
                {
                    dropDP.Items.FindByText(((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[21].ToString()).Selected = true;
                }
                if (dropDO != null)
                {
                    dropDO.Items.FindByText(((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[22].ToString()).Selected = true;
                }

                /*var comentarioDA = e.Row.Cells[5].FindControl("ComentarioDA") as Label;
                var comentarioDE = e.Row.Cells[5].FindControl("ComentarioDE") as Label;
                var comentarioDF = e.Row.Cells[5].FindControl("ComentarioDF") as Label;
                var comentarioDN = e.Row.Cells[5].FindControl("ComentarioDN") as Label;
                var comentarioDP = e.Row.Cells[5].FindControl("ComentarioDP") as Label;
                var comentarioDO = e.Row.Cells[5].FindControl("ComentarioDO") as Label;
                */
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[5].ToString() == string.Empty) { e.Row.FindControl("trDA").Visible = false; }
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[7].ToString() == string.Empty) { e.Row.FindControl("trDE").Visible = false; }
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[9].ToString() == string.Empty) { e.Row.FindControl("trDF").Visible = false; }
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[11].ToString() == string.Empty) { e.Row.FindControl("trDN").Visible = false;}
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[13].ToString() == string.Empty) { e.Row.FindControl("trDP").Visible = false;}
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[15].ToString() == string.Empty) { e.Row.FindControl("trDO").Visible = false;}
                
                if (Fase != "Consolidação")
                {
                    dropDA.Enabled = false;
                    dropDE.Enabled = false;
                    dropDF.Enabled = false;
                    dropDN.Enabled = false;
                    dropDP.Enabled = false;
                    dropDO.Enabled = false;

                    TextBox AnaliseDA = (TextBox)e.Row.Cells[5].FindControl("txtAnaliseDA");
                    TextBox AnaliseDE = (TextBox)e.Row.Cells[5].FindControl("txtAnaliseDE");
                    TextBox AnaliseDF = (TextBox)e.Row.Cells[5].FindControl("txtAnaliseDF");
                    TextBox AnaliseDN = (TextBox)e.Row.Cells[5].FindControl("txtAnaliseDN");
                    TextBox AnaliseDP = (TextBox)e.Row.Cells[5].FindControl("txtAnaliseDP");
                    TextBox AnaliseDO = (TextBox)e.Row.Cells[5].FindControl("txtAnaliseDO");

                    AnaliseDA.Enabled = false;
                    AnaliseDE.Enabled = false;
                    AnaliseDF.Enabled = false;
                    AnaliseDN.Enabled = false;
                    AnaliseDP.Enabled = false;
                    AnaliseDO.Enabled = false;
                }
            }
            
        }

        protected SPListItem ConsultaAto()
        {
            SPList list = SPContext.Current.Web.Lists["Ato"];
            SPListItem item = list.GetItemById(Convert.ToInt32(idRequest));

            return item;
        }

        protected void btn_salva_Click(object sender, EventArgs e)
        {
            
            try
            {
                for (int i = 0; i < grdAnaliseConsolidacao.Rows.Count; i++)
                {
                    string dropDA = ((DropDownList)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("dprStatusDA")).SelectedItem.Text;
                    string dropDE = ((DropDownList)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("dprStatusDE")).SelectedItem.Text;
                    string dropDF = ((DropDownList)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("dprStatusDF")).SelectedItem.Text;
                    string dropDN = ((DropDownList)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("dprStatusDN")).SelectedItem.Text;
                    string dropDP = ((DropDownList)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("dprStatusDP")).SelectedItem.Text;
                    string dropDO = ((DropDownList)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("dprStatusDO")).SelectedItem.Text;

                    TextBox AnaliseDA = (TextBox)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("txtAnaliseDA");
                    TextBox AnaliseDE = (TextBox)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("txtAnaliseDE");
                    TextBox AnaliseDF = (TextBox)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("txtAnaliseDF");
                    TextBox AnaliseDN = (TextBox)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("txtAnaliseDN");
                    TextBox AnaliseDP = (TextBox)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("txtAnaliseDP");
                    TextBox AnaliseDO = (TextBox)grdAnaliseConsolidacao.Rows[i].Cells[4].FindControl("txtAnaliseDO");

                    TextBox TextoFinal = (TextBox)grdAnaliseConsolidacao.Rows[i].Cells[5].FindControl("txtTextoFinal");

                    string idRow = grdAnaliseConsolidacao.Rows[i].Cells[0].Text;

                    //Pega Item da Lista
                    SPListItem item = ManipulaLista.RetornaLista("Minuta", SPContext.Current.Web, Convert.ToInt32(idRow));

                    if (dropDA != string.Empty) { item["StatusDA"] = dropDA; }
                    if (dropDE != string.Empty) { item["StatusDE"] = dropDE; }
                    if (dropDF != string.Empty) { item["StatusDF"] = dropDF; }
                    if (dropDN != string.Empty) { item["StatusDN"] = dropDN; }
                    if (dropDP != string.Empty) { item["StatusDP"] = dropDP; }
                    if (dropDO != string.Empty) { item["StatusDO"] = dropDO; }

                    if (AnaliseDA.Text != string.Empty) { item["AvaliacaoDA"] = AnaliseDA.Text; }
                    if (AnaliseDE.Text != string.Empty) { item["AvaliacaoDE"] = AnaliseDE.Text; }
                    if (AnaliseDF.Text != string.Empty) { item["AvaliacaoDF"] = AnaliseDF.Text; }
                    if (AnaliseDN.Text != string.Empty) { item["AvaliacaoDN"] = AnaliseDN.Text; }
                    if (AnaliseDP.Text != string.Empty) { item["AvaliacaoDP"] = AnaliseDP.Text; }
                    if (AnaliseDO.Text != string.Empty) { item["AvaliacaoDO"] = AnaliseDO.Text; }

                    if (TextoFinal.Text != string.Empty) { item["Texto Final"] = TextoFinal.Text; }

                    item.Update();

                    //if (txtComentarioRow.Text != string.Empty || txtJustificativaRow.Text != string.Empty)
                    //{
                    //    SalvaPreparacao(idRow, txtComentarioRow.Text, txtJustificativaRow.Text);
                    //}
                }

                SPListItem itemAto = ManipulaLista.RetornaLista("Ato", SPContext.Current.Web, Convert.ToInt32(Page.Request.QueryString.GetValues("ID")[0]));

                if (new SPFieldLookupValue(itemAto["Fase da Revisão"].ToString()).LookupValue == "Análise")
                {
                    itemAto["Fase da Revisão"] = new SPFieldLookupValue(5, "Consolidação");
                    itemAto.Update();
                }
                else if (new SPFieldLookupValue(itemAto["Fase da Revisão"].ToString()).LookupValue == "Consolidação")
                {
                    itemAto["Fase da Revisão"] = new SPFieldLookupValue(7, "Aprovação");
                    itemAto["Situação"] = new SPFieldLookupValue(8, "Vigente");
                    itemAto.Update();
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Análises adicionadas com sucesso!');", true);

            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Ocorreu um erro. Tente mais tarde!');", true);
            }
        }

        public void SalvaPreparacao(string id, string comentario, string justificativa)
        {
            SPList list = SPContext.Current.Web.Lists["Minuta"];
            SPListItem item = list.GetItemById(Convert.ToInt32(id));

            //item["Comentário " + diretoria] = comentario;
            //item["Justificativa " + diretoria] = justificativa;

            item.Update();
        }

        protected void btn_Aprovacao_Click(object sender, EventArgs e)
        {
            try
            {
                CarregamentoMinuta.AprovaMinuta(SPContext.Current.Web, idRequest);

                SPListItem itemAto = ManipulaLista.RetornaLista("Ato", SPContext.Current.Web, Convert.ToInt32(Page.Request.QueryString.GetValues("ID")[0]));
                itemAto["Fase da Revisão"] = new SPFieldLookupValue(8, "Publicação");
                itemAto.Update();

                Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/Lists/Ato/DispForm.aspx?ID=" + Page.Request.QueryString.GetValues("ID")[0]);
            }
            catch { }

        }
    }
}
