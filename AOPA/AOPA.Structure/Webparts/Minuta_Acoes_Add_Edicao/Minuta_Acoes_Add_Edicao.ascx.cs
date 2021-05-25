using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Furnas.AOPA.Base.Service;

namespace Furnas.AOPA.Structure.Webparts.Minuta_Acoes_Add_Edicao
{
    [ToolboxItemAttribute(false)]
    public partial class Minuta_Acoes_Add_Edicao : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Minuta_Acoes_Add_Edicao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //string id = Page.Request.QueryString.GetValues("Ato")[0];
            /*string url = SPContext.Current.Site.RootWeb.Url + "/Lists/minuta/NewForm.aspx?ID=" + id;
            novo_item.OnClientClick = "javascript:OpenDialog('" + url + "','Novo Item');return false;";*/
        }

        protected void voltar_Ato_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/Lists/Ato/DispForm.aspx?ID=" + Page.Request.QueryString.GetValues("Ato")[0]);
        }

        protected void finalizar_Click(object sender, EventArgs e)
        {
            try
            {
                SPListItem item  = ManipulaLista.RetornaLista("Ato", SPContext.Current.Web, Convert.ToInt32(Page.Request.QueryString.GetValues("Ato")[0]));

                item["Fase da Revisão"] = new SPFieldLookupValue(4, "Análise");
                item.Update();

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoAlert", "alert('Fase avançada com sucesso!');", true);

                Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/Lists/Ato/DispForm.aspx?ID=" + Page.Request.QueryString.GetValues("Ato")[0]);
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "InfoAlert", "alert('Ocorreu um erro. Tente mais tarde!');", true);
            }
        }
    }
}
