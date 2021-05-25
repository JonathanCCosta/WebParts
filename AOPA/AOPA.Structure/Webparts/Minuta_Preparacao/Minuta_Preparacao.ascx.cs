using Furnas.AOPA.Base.Service;
using Furnas.AOPA.Base.Util;
using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Furnas.AOPA.Structure.Webparts.Minuta_Preparacao
{
    [ToolboxItemAttribute(false)]
    public partial class Minuta_Preparacao : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Minuta_Preparacao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected static string diretoria;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = "0";

                try
                {
                    id = Page.Request.QueryString.GetValues("ID")[0];
                }
                catch { }

                Analista(id);

                if (VerificaPrazoRN(Convert.ToInt32(id)))
                {
                    DataTable items = AcoesMinuta.TodosItemsMinuta(SPContext.Current.Web, id);

                    grdPreparacao.DataSource = items;
                    grdPreparacao.DataBind();

                    grdPreparacao.Columns[0].Visible = false;
                }
                else
                {
                    LabelPrazo.Visible = true;
                    bts.Visible = false;
                }
            }

        }

        public bool VerificaPrazoRN(int id)
        {
            SPListItem item = ManipulaLista.RetornaLista("Ato", SPContext.Current.Web, id);

            if (item["Prazo RN"] != null)
            {
                DateTime dtPrazo = Convert.ToDateTime(item["Prazo RN"].ToString());
                if (DateTime.Compare(dtPrazo, DateTime.Now) < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public void Analista(string id)
        {
            SPList list = SPContext.Current.Web.Lists["Ato"];
            SPListItem item = list.GetItemById(Convert.ToInt32(id));

            SPFieldUserValueCollection flduserDA = new SPFieldUserValueCollection(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDA"].ToString()));
            SPFieldUserValueCollection flduserDE = new SPFieldUserValueCollection(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDE"].ToString()));
            SPFieldUserValueCollection flduserDF = new SPFieldUserValueCollection(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDF"].ToString()));
            SPFieldUserValueCollection flduserDN = new SPFieldUserValueCollection(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDN"].ToString()));
            SPFieldUserValueCollection flduserDP = new SPFieldUserValueCollection(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDP"].ToString()));
            SPFieldUserValueCollection flduserDO = new SPFieldUserValueCollection(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDO"].ToString()));

            foreach (SPFieldUserValue userValue in flduserDA)
            {
                if (userValue.LookupValue == SPContext.Current.Web.CurrentUser.Name)
                {
                    diretoria = "DA";
                }
            }

            foreach (SPFieldUserValue userValue in flduserDE)
            {
                if (userValue.LookupValue == SPContext.Current.Web.CurrentUser.Name)
                {
                    diretoria = "DE";
                }
            }

            foreach (SPFieldUserValue userValue in flduserDF)
            {
                if (userValue.LookupValue == SPContext.Current.Web.CurrentUser.Name)
                {
                    diretoria = "DF";
                }
            }

            foreach (SPFieldUserValue userValue in flduserDN)
            {
                if (userValue.LookupValue == SPContext.Current.Web.CurrentUser.Name)
                {
                    diretoria = "DN";
                }
            }

            foreach (SPFieldUserValue userValue in flduserDP)
            {
                if (userValue.LookupValue == SPContext.Current.Web.CurrentUser.Name)
                {
                    diretoria = "DP";
                }
            }

            foreach (SPFieldUserValue userValue in flduserDO)
            {
                if (userValue.LookupValue == SPContext.Current.Web.CurrentUser.Name)
                {
                    diretoria = "DO";
                }
            }

            //if (item["AnalistaDA"] != null)
            //{

            //    flduserDA = new SPFieldUserValueCollection(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDA"].ToString()));
            //    foreach (SPFieldUserValue userValue in flduserDA)
            //    {
            //        if (userValue.LookupValue == SPContext.Current.Web.CurrentUser.Name)
            //        {
            //            diretoria = "DA";
            //        }
            //    }
                //flduserDA = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDA"].ToString()));
                //if (flduserDA.User.Name == SPContext.Current.Web.CurrentUser.Name)
                //{
                //    diretoria = "DA";
                //}
            //}
            //else if (item["AnalistaDE"] != null)
            //{
            //    flduserDE = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDE"].ToString()));
            //    if (flduserDE.User.Name == SPContext.Current.Web.CurrentUser.Name)
            //    {
            //        diretoria = "DE";
            //    }
            //}
            //else if (item["AnalistaDF"] != null)
            //{
            //    flduserDF = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDF"].ToString()));
            //    if (flduserDF.User.Name == SPContext.Current.Web.CurrentUser.Name)
            //    {
            //        diretoria = "DF";
            //    }
            //}
            //else if (item["AnalistaDN"] != null)
            //{
            //    flduserDN = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDN"].ToString()));
            //    if (flduserDN.User.Name == SPContext.Current.Web.CurrentUser.Name)
            //    {
            //        diretoria = "DN";
            //    }
            //}
            //else if (item["AnalistaDP"] != null)
            //{
            //    flduserDP = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDP"].ToString()));
            //    if (flduserDP.User.Name == SPContext.Current.Web.CurrentUser.Name)
            //    {
            //        diretoria = "DP";
            //    }
            //}
            //else if (item["AnalistaDO"] != null)
            //{
            //    flduserDO = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDO"].ToString()));
            //    if (flduserDO.User.Name == SPContext.Current.Web.CurrentUser.Name)
            //    {
            //        diretoria = "DO";
            //    }
            //}
        }

        protected void grdPreparacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (diretoria == "DA")
            {
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
            }
            else if (diretoria == "DE")
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
            }
            else if (diretoria == "DF")
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
            }
            else if (diretoria == "DN")
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
            }
            else if (diretoria == "DP")
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
            }
            else if (diretoria == "DO")
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
            }
            else
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
            }
        }

        protected void salvar_Click(object sender, EventArgs e)
        {
            int rowindex = 0;


            //foreach (GridViewRow row in grdPreparacao.Rows)
            for (int i = 0; i < grdPreparacao.Rows.Count; i++)
            {

                TextBox txtComentarioRow = (TextBox)grdPreparacao.Rows[i].Cells[5].FindControl("txtComentario" + diretoria);
                /*InputFormTextBox txtJustificativaRow = row.FindControl("txtJustificativa") as InputFormTextBox;
                Label idRow = row.FindControl("ID") as Label;*/

                //InputFormTextBox txtComentarioRow = (InputFormTextBox)grdPreparacao.Rows[i].Cells[14].FindControl("txtComentario");
                //InputFormTextBox txtJustificativaRo
                //SalvaPreparacao(idRow.Text, txtComentarioRow.Text, txtJustificativaRow.Text);
                rowindex++;
            }
        }

        public void SalvaPreparacao(string id, string comentario, string justificativa)
        {
            SPList list = SPContext.Current.Web.Lists["Minuta"];
            SPListItem item = list.GetItemById(Convert.ToInt32(id));

            item["Comentário " + diretoria] = comentario;
            item["Justificativa " + diretoria] = justificativa;
            item["Data Análise " + diretoria] = DateTime.Now;

            item.Update();
        }

        public void ConcluiFasePreparacao()
        {
            try
            {
                SPListItem item = ManipulaLista.RetornaLista("Minuta", SPContext.Current.Web, Convert.ToInt32(Page.Request.QueryString.GetValues("ID")[0]));

                string DA; string DE; string DF; string DN; string DP; string DO;

                if (item["Data Análise DA"] != null) { DA = item["Data Análise DA"].ToString(); } else { DA = ""; }
                if (item["Data Análise DE"] != null) { DE = item["Data Análise DE"].ToString(); } else { DE = ""; }
                if (item["Data Análise DF"] != null) { DF = item["Data Análise DF"].ToString(); } else { DF = ""; }
                if (item["Data Análise DN"] != null) { DN = item["Data Análise DN"].ToString(); } else { DN = ""; }
                if (item["Data Análise DP"] != null) { DP = item["Data Análise DP"].ToString(); } else { DP = ""; }
                if (item["Data Análise DO"] != null) { DO = item["Data Análise DO"].ToString(); } else { DO = ""; }

                if (DA != "" && DE != "" && DF != "" && DN != "" && DP != "" && DO != "")
                {
                    SPListItem itemAto = ManipulaLista.RetornaLista("Ato", SPContext.Current.Web, Convert.ToInt32(Page.Request.QueryString.GetValues("ID")[0]));

                    itemAto["Fase da Revisão"] = new SPFieldLookupValue(5, "Consolidação");
                    itemAto.Update();
                }
            }
            catch { }
        }

        protected void btn_salva_Click(object sender, EventArgs e)
        {
            string campoComentario = "txtComentario" + diretoria;
            string campoJustificativa = "txtJustificativa" + diretoria;

            try
            {
                for (int i = 0; i < grdPreparacao.Rows.Count; i++)
                {
                    TextBox txtComentarioRow = (TextBox)grdPreparacao.Rows[i].Cells[5].FindControl(campoComentario);
                    TextBox txtJustificativaRow = (TextBox)grdPreparacao.Rows[i].Cells[6].FindControl(campoJustificativa);
                    string idRow = grdPreparacao.Rows[i].Cells[0].Text;

                    if (txtComentarioRow.Text != string.Empty || txtJustificativaRow.Text != string.Empty)
                    {
                        SalvaPreparacao(idRow, txtComentarioRow.Text, txtJustificativaRow.Text);
                    }
                }

                ConcluiFasePreparacao();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Comentários adicionados com sucesso!');", true);

            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Ocorreu um erro. Tente mais tarde!');", true);
            }
        }
    }
}
