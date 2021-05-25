using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using Furnas.AOPA.Base.Service;
using System.Web.UI.WebControls;

namespace Furnas.AOPA.Structure.Webparts.Minuta_Lista_E_Edicao
{
    [ToolboxItemAttribute(false)]
    public partial class Minuta_Lista_E_Edicao : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Minuta_Lista_E_Edicao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            string id = "0";
            try
            {
                id = Page.Request.QueryString.GetValues("Ato")[0];
            }
            catch { }

            ListViewByQuery view = new ListViewByQuery();

            SPWeb currentweb = SPContext.Current.Web;
            SPList list = currentweb.Lists["Minuta"];
            view.List = list;
            SPQuery query = new SPQuery(view.List.Views["Minutas"]);
            //query.ViewFields = "<FieldRef Name='Title'/>";
            query.Query = "<Where><Eq><FieldRef Name='atoNormativo' LookupId='TRUE'/><Value Type='Lookup' >" + id + "</Value></Eq></Where><OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";
            view.Query = query;
            EnsureChildControls();
            view.RenderControl(writer);
            RenderChildren(writer);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string id = Page.Request.QueryString.GetValues("Ato")[0];


                    //PopulateDropDown_SubNivel(CarregamentoMinuta.ItemsMinuta(SPContext.Current.Web, id));
                    //dpr_SubNivel.Items.Add(new ListItem() { Text = "Nenhum", Value = "0" });

                }
                catch { }
            }
        }

        public void PopulateDropDown_SubNivel(DataTable dt)
        {
            //dpr_SubNivel.DataSource = dt;
            //dpr_SubNivel.DataTextField = "Nivel";
            //dpr_SubNivel.DataValueField = "ID";
            //dpr_SubNivel.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect(SPContext.Current.Web.Url.ToString() + "/SitePages/ItemMinuta.aspx?ID=" + Page.Request.QueryString.GetValues("ID")[0]);//Source=" + HttpContext.Current.Request.Url.AbsoluteUri.ToString());
        }


    }
}
