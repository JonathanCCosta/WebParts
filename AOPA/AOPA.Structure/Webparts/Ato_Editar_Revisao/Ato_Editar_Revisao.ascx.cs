using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Furnas.AOPA.Base.Resource;
using Furnas.AOPA.Base.Util;
using Furnas.AOPA.Base.Service;
using System.Data;
using System.Web.UI.WebControls;

namespace Furnas.AOPA.Structure.Webparts.Ato_Editar_Revisao
{
    [ToolboxItemAttribute(false)]
    public partial class Ato_Editar_Revisao : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Ato_Editar_Revisao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Page.Request.QueryString.GetValues("ID")[0];
                SPList list = SPContext.Current.Web.Lists["Ato Normativo"];
                SPListItem item = list.GetItemById(Convert.ToInt32(id));

                PopulateDropDown_AndamentoFase(FieldsFillLookups.fillDropDownQuery("Andamento da Fase", SPContext.Current.Web, new SPFieldLookupValue(Convert.ToString(item["Fase da Revisão"])).LookupValue));
                PopulateDropDown_TipoPendencia(FieldsFillLookups.fillDropDown("Tipo de Pendência", SPContext.Current.Web));
                PopulateDropDown_Situacao(FieldsFillLookups.fillDropDown("Situação do Ato Normativo", SPContext.Current.Web));

                //Popular campos
                data_inicio_revisao.Text = SupportFormatting.ValidaTextField(item["Data Início Revisão"]);
                nomeFase.Text = new SPFieldLookupValue(Convert.ToString(item["Fase da Revisão"])).LookupValue;
                //andamentoFase.SelectedValue = new SPFieldLookupValue(Convert.ToString(item["Percentual de Andamento"])).LookupValue;
                dprSituacao.SelectedValue = new SPFieldLookupValue(Convert.ToString(item["Situação"])).LookupValue;
                dataVencimento.Text = SupportFormatting.ValidaTextField(item["Data Vencimento"]);
                dataEntradRevisao.Text = SupportFormatting.ValidaTextField(item["Data Limite para Entrada em Revisão"]);
                acao.Text = SupportFormatting.ValidaTextField(item["Ação"]);
                if (item["Destaque Da Semana"].ToString() == "False")
                {
                    destaqueSemana.Checked = false;
                }
                else
                {
                    destaqueSemana.Checked = false;
                }
                datePendencia.Text = SupportFormatting.ValidaTextField(item["Data Pendência"]);
                tipoPendencia.SelectedValue = new SPFieldLookupValue(Convert.ToString(item["Pendência"])).LookupValue;
                prazoRN.Text = SupportFormatting.ValidaTextField(item["Prazo RN"]);

                datSuspensao.Text = SupportFormatting.ValidaTextField(item["Data Suspensão"]);
                dataExtincao.Text = SupportFormatting.ValidaTextField(item["Data Extinção"]);
                dataInterrupcao.Text = SupportFormatting.ValidaTextField(item["Data Interrupção"]);

                dataConclusaoFase.Text = SupportFormatting.ValidaTextField(item["Data Conclusão Fase"]);

                //PopulateDropDown_AndamentoFase(FieldsFillLookups.fillDropDownQuery("Andamento da Fase", SPContext.Current.Web, new SPFieldLookupValue(Convert.ToString(item["Fase da Revisão"])).LookupValue));
                //PopulateDropDown_TipoPendencia(FieldsFillLookups.fillDropDown("Tipo de Pendência", SPContext.Current.Web));
            }
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

        public void PopulateDropDown_Situacao(DataTable dt)
        {
            dprSituacao.DataSource = dt;
            dprSituacao.DataTextField = "Title";
            dprSituacao.DataValueField = "ID";
            dprSituacao.DataBind();
        }

        protected void dprSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dprSituacao.SelectedItem.Text == "Suspenso")
            {
                trDatSuspensao.Visible = true;
            }
            else if(dprSituacao.SelectedItem.Text == "Interrompido")
            {
                trDatInterrupcao.Visible = true;
            }
        }

        protected void conclusaoAjuste_TextChanged(object sender, EventArgs e)
        {
            trPrazoRN.Visible = true;
            trRetornoRN.Visible = true;
        }

        protected void dataConclusaoFase_TextChanged(object sender, EventArgs e)
        {
            //fazer trocar as fases e andamentos
        }
    }
}
