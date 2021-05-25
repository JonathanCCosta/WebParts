using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Furnas.AOPA.Base.Service;
using Furnas.AOPA.Base.Util;

namespace Furnas.AOPA.Structure.Webpart.Ato_Display_Revisao
{
    [ToolboxItemAttribute(false)]
    public partial class Ato_Display_Revisao : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Ato_Display_Revisao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Page.Request.QueryString.GetValues("ID")[0];
            string url = SPContext.Current.Site.RootWeb.Url + "/SitePages/NovaRevisao.aspx?ID=" + id;
            //incluir_revisao.OnClientClick = "javascript:OpenDialog('" + url + "','Nova Revisão');return false;";

            SPListItem item = Ato(Convert.ToInt32(id));

            if (item.ContentType.Name == "Instrução Normativa" || item.ContentType.Name == "Política"){
                
            }

            //if (Convert.ToInt32(item["Número Revisão"].ToString()) > 0)
            //{
            //    //actions.Visible = true;
            //    actionsAtoNIouPolitica.Visible = false;
            //    if (new SPFieldLookupValue(item["Situação"].ToString()).LookupValue != "Obsoleto")
            //    {
            //        //editar_revisao.Visible = true;
            //        //string urlEditaRevisao = SPContext.Current.Site.RootWeb.Url + "/SitePages/EditaRevisao.aspx?ID=" + id;
            //        string urlEditaRevisao = SPContext.Current.Site.RootWeb.Url + "/Lists/Ato/EditForm.aspx?ID=" + id;
            //        editar_Ato.OnClientClick = "javascript:OpenDialog('" + urlEditaRevisao + "','Editar Ato Normativo');return false;";
            //        //editar_revisao.OnClientClick = "javascript:OpenDialog('" + urlEditaRevisao + "','Editar Revisão');return false;";
            //    }
            //    else
            //    {
            //        //incluir_revisao.Visible = false;
            //        actionsAtoNIouPolitica.Visible = false;
            //    }
            //}
            //else
            //{
                
                if (new SPFieldLookupValue(item["Situação"].ToString()).LookupValue == "Obsoleto")
                {
                    actionsAtoNIouPolitica.Visible = false;
                    //incluir_revisao.Visible = false;
                    //actions.Visible = false;
                }
                else if (new SPFieldLookupValue(item["Situação"].ToString()).LookupValue == "Vigente")
                {
                    editar_Ato.Visible = false;
                    revisao.Visible = true;
                    validacao.Visible = true;
                }
                else
                {
                    //actions.Visible = false;
                    string urlMinuta = "";
                    if (item.ContentType.Name == "Instrução Normativa" || item.ContentType.Name == "Política")
                    {
                        string fase = new SPFieldLookupValue(item["Fase da Revisão"].ToString()).LookupValue;
                        if (fase != "Publicação" || fase != "Aprovação")
                        {
                            /*add_minuta.Visible = true;
                            urlMinuta = SPContext.Current.Site.RootWeb.Url + "/Lists/Minuta/NewForm.aspx?ID=" + id;
                            add_minuta.OnClientClick = "javascript:OpenDialog('" + urlMinuta + "','Adicionar Minuta');return false;";*/
                        }
                        else
                        {
                            /*criar_revisão_minuta.Visible = true;
                            urlMinuta = SPContext.Current.Site.RootWeb.Url + "/Lists/Minuta/NewForm.aspx?ID=" + id;
                            criar_revisão_minuta.OnClientClick = "javascript:OpenDialog('" + urlMinuta + "','Criar Revisão Minuta');return false;";*/
                        }

                        if (fase == "Análise")
                        {
                            prazoRN.Visible = true;
                            prazoRN.OnClientClick = "javascript:OpenDialog('" + SPContext.Current.Site.RootWeb.Url + "/Lists/historicoRetornoRN/NewForm.aspx?ID=" + id + "','Adicionar Novo Prazo RN');return false;";
                        }

                        string urlProcessaAto;
                        //if (new SPFieldLookupValue(item["Fase da Revisão"].ToString()).LookupValue == "Não Iniciado")
                        //{
                        urlProcessaAto = SPContext.Current.Site.RootWeb.Url + "/Lists/Ato/EditForm.aspx?ID=" + id;
                        editar_Ato.OnClientClick = "javascript:OpenDialog('" + urlProcessaAto + "','Editar Ato Normativo');return false;";
                        //}
                    }
                }
            //}
        }

        public SPListItem Ato(int id)
        {
            SPList list = SPContext.Current.Web.Lists["Ato"];
            SPListItem item = list.GetItemById(id);

            return item;
        }

        protected void revisao_Click(object sender, EventArgs e)
        {
            EventFiring eventFiring = new EventFiring();
            try
            {
                eventFiring.DisableHandleEventFiring();

                // 0 = Revisão
                int novoItem = RevisaValida(0);

                eventFiring.EnableHandleEventFiring();

                Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/Lists/Ato/DispForm.aspx?ID=" + novoItem);
            }
            catch {  }
        }

        protected void validacao_Click(object sender, EventArgs e)
        {
            EventFiring eventFiring = new EventFiring();
            try
            {
                eventFiring.DisableHandleEventFiring();

                // 1 = Validação
                int novoItem = RevisaValida(1);

                eventFiring.EnableHandleEventFiring();

                Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/Lists/Ato/DispForm.aspx?ID=" + novoItem);
            }
            catch { }
        }

        public int RevisaValida(int revisao)
        {
            string id = Page.Request.QueryString.GetValues("ID")[0];
            SPListItem item = Ato(Convert.ToInt32(id));

            SPListItem itemNovo = copyItem.CopyItemAto(item, item.ParentList);
            if (revisao == 0)
            {
                int novoNumRevisao = Convert.ToInt32(item["Número Revisão"].ToString()) + 1;
                itemNovo["Número Revisão"] = SupportFormatting.FormataRevisaoValidacao(novoNumRevisao);
                itemNovo.Update();
            }
            else
            {
                DateTime dt_hoje = DateTime.Now;
                itemNovo["Conclusão da Preparação"] = dt_hoje;
                itemNovo["Conclusão do Ajuste"] = dt_hoje;
                itemNovo["Conclusão da Análise"] = dt_hoje;
                itemNovo["Conslusão da Consolidação"] = dt_hoje;
                itemNovo["Conclusão Proposição"] = dt_hoje;
                itemNovo["Conclusão da Aprovação"] = dt_hoje;

                int novoNumRevisao = Convert.ToInt32(item["Número Validação"].ToString()) + 1;
                itemNovo["Número Validação"] = SupportFormatting.FormataRevisaoValidacao(novoNumRevisao);

                itemNovo.Update();
            }

            item["Situação"] = new SPFieldLookupValue(4, "Obsoleto");
            item.Update();

            SPListItemCollection items = CarregamentoMinuta.ItemsMinutaCopy(SPContext.Current.Web, id);

            foreach (SPListItem itemMinuta in items)
            {
                copyItem.CopyItemMinuta(itemMinuta, itemMinuta.ParentList, itemNovo["Ato"].ToString(), itemNovo.ID);
            }

            return item.ID;
        }
    }
}
