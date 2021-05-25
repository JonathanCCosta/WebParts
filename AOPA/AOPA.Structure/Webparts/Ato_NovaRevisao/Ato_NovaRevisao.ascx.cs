using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Furnas.AOPA.Base.Resource;
using Furnas.AOPA.Base.Util;
using Furnas.AOPA.Base.Service;
using System.Data;
using System.Web.UI.WebControls;

namespace Furnas.AOPA.Structure.Webpart.Ato_NovaRevisao
{
    [ToolboxItemAttribute(false)]
    public partial class Ato_NovaRevisao : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Ato_NovaRevisao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){
                string id = Page.Request.QueryString.GetValues("ID")[0];
                SPList list = SPContext.Current.Web.Lists["Ato Normativo"];
                SPListItem item = list.GetItemById(Convert.ToInt32(id));

                /*Preenche campos do ato*/
                /*numRevisao.Text = item["Número Revisão"].ToString();
                numValidacao.Text = item["Número Validação"].ToString();
                situacao.Text = new SPFieldLookupValue(item["Situação"].ToString()).LookupValue;*/
                nomeFase.Text = new SPFieldLookupValue(item["Fase da Revisão"].ToString()).LookupValue;

                /*Preenche os DropDowns*/
                PopulateDropDown_AndamentoFase(FieldsFillLookups.fillDropDownQuery("Andamento da Fase", SPContext.Current.Web, new SPFieldLookupValue(Convert.ToString(item["Fase da Revisão"])).LookupValue));
                PopulateDropDown_TipoPendencia(FieldsFillLookups.fillDropDown("Tipo de Pendência", SPContext.Current.Web));
            }
        }

        public void PopulateDropDown_AndamentoFase(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                float percentual = float.Parse(row["percentualandamento"].ToString()) * 100;
                andamentoFase.Items.Add(new ListItem() { Text = Convert.ToInt32(percentual).ToString() + "%", Value = row["ID"].ToString() });
            }
        }

        public void PopulateDropDown_TipoPendencia(DataTable dt)
        {
            tipoPendencia.DataSource = dt;
            tipoPendencia.DataTextField = "Title";
            tipoPendencia.DataValueField = "ID";
            tipoPendencia.DataBind();
        }

        protected void save_Click(object sender, EventArgs e)
        {
            string id = Page.Request.QueryString.GetValues("ID")[0];
            SPList list = SPContext.Current.Web.Lists["Ato Normativo"];
            
            //Item antigo
            SPListItem item = list.GetItemById(Convert.ToInt32(id));

            if (revisao.Checked == true)
            {
                if (ValidarCamposRevisao())
                {
                    try
                    {
                        SPListItem new_item = copyItem.CopyItem(item, list);
                        if (revisao.Checked == true)
                        {
                            int novoNumRevisao = Convert.ToInt32(item["Número Revisão"].ToString()) + 1;
                            new_item["Número Revisão"] = SupportFormatting.FormataRevisaoValidacao(novoNumRevisao);
                            new_item["Solicitação de Abertura da Revisão/Elaboração"] = solicitaRevisao.Text;

                            if (dtSolicitacao.Text != string.Empty)
                            {
                                new_item["Data da Solicitação da Abertura Revisão/Elaboração"] = SupportFormatting.ConvertDatas(dtSolicitacao.Text);
                            }
                            new_item["Justificativa Revisão Elaboração"] = justificativa_revisao.Text;

                            if (data_inicio_revisao.Text != string.Empty)
                            {
                                new_item["Data Início Revisão"] = SupportFormatting.ConvertDatas(data_inicio_revisao.Text);
                            }
                            new_item["Fase da Revisão"] = new SPFieldLookupValue(2, "Preparação");
                            float perncent = float.Parse(andamentoFase.SelectedItem.Text.Remove(andamentoFase.SelectedItem.Text.Length - 1));
                            new_item["Percentual de Andamento"] = perncent / 100;
                            new_item["Ação"] = acao.Text;
                            new_item["Pendência"] = new SPFieldLookupValue(Convert.ToInt32(tipoPendencia.SelectedItem.Value), tipoPendencia.SelectedItem.Text);

                            if (datePendencia.Text != string.Empty)
                            {
                                new_item["Data Pendência"] = SupportFormatting.ConvertDatas(datePendencia.Text);
                            }

                            if (item["Observação"] != null)
                            {
                                new_item["Observação"] = "Data: " + DateTime.Now.ToShortDateString() + " </br>" + observacao.Text + "</br>****************************</br>" + item["Observação"].ToString();
                            }
                            else
                            {
                                new_item["Observação"] = "Data: " + DateTime.Now.ToShortDateString() + " </br>" + observacao.Text + "</br>****************************</br>";
                            }
                            
                            new_item["Destaque Da Semana"] = (destaqueSemana.Checked == true) ? true : false;
                            new_item.Update();

                            item["Situação"] = new SPFieldLookupValue(4, "Obsoleto");
                            item.Update();

                            

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Dados salvos com sucesso!');", true);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Close", "CloseForm();", true);
                        }
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Erro! Tente mais tarde ou contate o administrador');", true);
                        //escrever log
                    }
                }
                else
                {
                    //validar canpos revisao
                }
            }
            else
            {
                try
                {
                    DateTime dt_hoje = DateTime.Now;
                    item["Conclusão da Preparação"] = dt_hoje;
                    item["Conclusão do Ajuste"] = dt_hoje;
                    item["Conclusão da Análise"] = dt_hoje;
                    item["Conslusão da Consolidação"] = dt_hoje;
                    item["Conclusão Proposição"] = dt_hoje;
                    item["Conclusão da Aprovação"] = dt_hoje;

                    int novoNumRevisao = Convert.ToInt32(item["Número Validação"].ToString()) + 1;
                    item["Número Validação"] = SupportFormatting.FormataRevisaoValidacao(novoNumRevisao);

                    item.Update();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Dados salvos com sucesso!');", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Close", "CloseForm();", true);
                }
                catch{}
            }
        }

        public bool ValidarCamposRevisao(){
            /*solicitação revisao
             * data solciitacao
             * justifica revisao*/

            return true;
        }

        protected void data_inicio_revisao_TextChanged(object sender, EventArgs e)
        {
            if (data_inicio_revisao.Text != string.Empty)
            {
                andamentoFase.Items.Clear();
                PopulateDropDown_AndamentoFase(FieldsFillLookups.fillDropDownQuery("Andamento da Fase", SPContext.Current.Web, "Preparação"));
                nomeFase.Text = "Prepração";
            }
        }

        protected void validacao_CheckedChanged(object sender, EventArgs e)
        {
            tbRevisao.Visible = false;
            tbValidacao.Visible = true;

             string data_hoje = DateTime.Now.ToShortDateString();
             conclusaoPreparacao.Text = data_hoje;
             conclusaoAjuste.Text = data_hoje;
             conclusaoAnalise.Text = data_hoje;
             conclusaoConsolidacao.Text = data_hoje;
             conclusaoProposicao.Text = data_hoje;
             conclusaoAprovacao.Text = data_hoje;
        }

        protected void revisao_CheckedChanged(object sender, EventArgs e)
        {
            tbRevisao.Visible = true;
            tbValidacao.Visible = false;
        }
    }
}
