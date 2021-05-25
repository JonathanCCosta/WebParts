using Furnas.GestaoSPE.ModeloUnico.Import.Engine.Excel;
using Furnas.GestaoSPE.ModeloUnico.Import.Model;
using Furnas.GestaoSPE.ModeloUnico.Import.Service;
using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace Furnas.GestaoSPE.ModeloUnico.Import.WebParts.VWP_ImportExcel
{
    [ToolboxItemAttribute(false)]
    public partial class VWP_ImportExcel : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VWP_ImportExcel()
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
                ServiceImportExcel.LoadDropDown(ddlSPE, SPContext.Current.Web, "SPE");
                ServiceImportExcel.LoadDropDown(ddlEmpreendimento, SPContext.Current.Web, "Empreendimento", "SPE");
                ServiceImportExcel.LoadDropDown(ddlObra, SPContext.Current.Web, "Obra", "Empreendimento");
                ServiceImportExcel.LoadDropDown(ddlPN, SPContext.Current.Web, "Plano de Negócio", "Empreendimento");
            }
        }


        protected void btnCarregar_Click(object sender, EventArgs e)
        {
            if (flpArquivo.FileBytes.Length <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Selecione um arquivo para iniciar o carregamento.');", true);
                return;
            }
            DataTable dt = EngineExcel.ReadExcel(flpArquivo.FileContent);

            grvDados.DataSource = dt;
            grvDados.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            SPContext.Current.Web.AllowUnsafeUpdates = true;
            Model.Propriedades prop = new Model.Propriedades();
            prop.idSPE = Convert.ToInt32(ddlSPE.SelectedValue);
            prop.tituloSPE = ddlSPE.Items[ddlSPE.SelectedIndex].Text;
            prop.idEmpreendimento = Convert.ToInt32(ddlEmpreendimento.SelectedValue);
            prop.tituloEmpreendimento = ddlEmpreendimento.Items[ddlEmpreendimento.SelectedIndex].Text;
            prop.idObra = Convert.ToInt32(ddlObra.SelectedValue);
            prop.tituloObra = ddlObra.Items[ddlObra.SelectedIndex].Text;
            prop.idPN = Convert.ToInt32(ddlPN.SelectedValue);
            prop.classificacao = (Classificacao)Convert.ToInt32(ddlPrevistoRevistoRealizado.SelectedValue);
            prop.tipomodelo = (TipoExcel)Convert.ToInt32(ddlTipos.SelectedValue);
            prop.tipodf = (TipoDF)Convert.ToInt32(ddlTipo.SelectedValue);


            DataTable dt = EngineExcel.ReadExcel(flpArquivo.FileContent);

            switch (prop.tipomodelo)
            {
                case TipoExcel.AvancoFisico:
                    break;
                case TipoExcel.AvancoFinanceiro:
                    break;
                case TipoExcel.DFDRE:
                    Service.ServiceImportExcel.UploadDRE(SPContext.Current.Web, dt, prop);
                    break;
                case TipoExcel.DFFluxoCaixa:
                    Service.ServiceImportExcel.UploadFluxoCaixa(SPContext.Current.Web, dt, prop);
                    break;
                case TipoExcel.DFBP:
                    break;
                default:
                    break;
            }

            SPContext.Current.Web.AllowUnsafeUpdates = false;
        }
    }
}
