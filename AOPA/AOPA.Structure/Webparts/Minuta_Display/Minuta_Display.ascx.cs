using Furnas.AOPA.Base.Util;
using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace Furnas.AOPA.Structure.Webparts.Minuta_Display
{
    [ToolboxItemAttribute(false)]
    public partial class Minuta_Display : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Minuta_Display()
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

            SPListItem item = Minuta(Convert.ToInt32(id));


            if (item.ContentType.Name == "Instrução Normativa" || item.ContentType.Name == "Política")
            {
                string fase = new SPFieldLookupValue(item["Fase da Revisão"].ToString()).LookupValue;
                if (fase == "Não Iniciado" || fase == "Preparação" || fase == "Ajuste")
                {
                    add_item_minuta.Visible = true;
                }
                else if (fase == "Análise")
                {
                    if (Analista(id) || Permission.getGroupUserColab())
                    {
                        fazer_analise_diretorias.Visible = true;
                    }
                }
                else if (fase == "Consolidação")
                {
                    fazer_consolidacao.Visible = true;
                }
                //else if (fase == "Proposição")
                //{
                //    fazer_proposição.Visible = true;
                //}
                if(fase == "Aprovação")
                {
                    actionsMinutaNIouPolitica.Visible = false;
                }

                if (new SPFieldLookupValue(item["Situação"].ToString()).LookupValue == "Obsoleto")
                {
                    actionsMinutaNIouPolitica.Visible = false;
                }
            }
        }

        public SPListItem Minuta(int id)
        {
            SPList list = SPContext.Current.Web.Lists["Ato"];
            SPListItem item = list.GetItemById(id);

            return item;
        }

        protected void add_item_minuta_Click(object sender, EventArgs e)
        {
            //SPList list = SPContext.Current.Web.Lists["Minuta"];

            Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/Lists/Minuta/NewFormCustom.aspx?Ato=" + Page.Request.QueryString.GetValues("ID")[0]); //+ "&Source=/aopa/Lists/Ato/DispForm.aspx?ID=" + Page.Request.QueryString.GetValues("ID")[0]);//Source=" + HttpContext.Current.Request.Url.AbsoluteUri.ToString());

            //Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/SitePages/ItemMinuta.aspx?ID" + Page.Request.QueryString.GetValues("ID")[0] + "&#InplviewHashe" + list.Views[list.DefaultView.ID]);
        }

        public bool Analista(string id)
        {
            SPList list = SPContext.Current.Web.Lists["Ato"];
            SPListItem item = list.GetItemById(Convert.ToInt32(id));

            SPFieldUserValue flduserDA = null;
            SPFieldUserValue flduserDE = null;
            SPFieldUserValue flduserDF = null;
            SPFieldUserValue flduserDN = null;
            SPFieldUserValue flduserDP = null;
            SPFieldUserValue flduserDO = null;

            if (item["AnalistaDA"] != null)
            {
                flduserDA = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDA"].ToString()));
                if (flduserDA.User.Name == SPContext.Current.Web.CurrentUser.Name)
                {
                    return true;
                }
            }
            else if (item["AnalistaDE"] != null)
            {
                flduserDE = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDE"].ToString()));
                if (flduserDE.User.Name == SPContext.Current.Web.CurrentUser.Name)
                {
                    return true;
                }
            }
            else if (item["AnalistaDF"] != null)
            {
                flduserDF = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDF"].ToString()));
                if (flduserDF.User.Name == SPContext.Current.Web.CurrentUser.Name)
                {
                    return true;
                }
            }
            else if (item["AnalistaDN"] != null)
            {
                flduserDN = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDN"].ToString()));
                if (flduserDN.User.Name == SPContext.Current.Web.CurrentUser.Name)
                {
                    return true;
                }
            }
            else if (item["AnalistaDP"] != null)
            {
                flduserDP = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDP"].ToString()));
                if (flduserDP.User.Name == SPContext.Current.Web.CurrentUser.Name)
                {
                    return true;
                }
            }
            else if (item["AnalistaDO"] != null)
            {
                flduserDO = new SPFieldUserValue(SPContext.Current.Web, SupportFormatting.ValidaTextField(item["AnalistaDO"].ToString()));
                if (flduserDO.User.Name == SPContext.Current.Web.CurrentUser.Name)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        protected void fazer_analise_diretorias_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/SitePages/FasePreparacao.aspx?ID=" + Page.Request.QueryString.GetValues("ID")[0]);
        }

        protected void fazer_consolidacao_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/SitePages/AnaliseConsolidacao.aspx?ID=" + Page.Request.QueryString.GetValues("ID")[0]);
        }

        protected void aprovacao_minuta_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/SitePages/AnaliseConsolidacao.aspx?ID=" + Page.Request.QueryString.GetValues("ID")[0]);
        }
    }
}
