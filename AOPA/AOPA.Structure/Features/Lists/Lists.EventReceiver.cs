using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Furnas.AOPA.Base.Service;
using Furnas.AOPA.Base.Util;
using Furnas.AOPA.Base.Resource;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI.WebControls.WebParts;

namespace Furnas.AOPA.Structure.Features.Lists
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("8af61e19-ca74-4089-be86-aca938db394c")]
    public class ListsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb _Web = properties.Feature.Parent as SPWeb;

            SPList listModuloManual = null;
            SPList listTipoManual = null;
            SPList listTipoAtoNormativo = null;
            SPList listSituacaoAtoNormativo = null;
            SPList listFaseRevisaoElaboracao = null;
            SPList listTipoDocAprovacao = null;
            SPList listRodapeDocumento = null;
            SPList listRepresentantesNormativos = null;
            SPList listAndamentoFase = null;
            SPList listPendencias = null;

            SPList listAto = null;
            SPList listAtosNormativos = null;

            Base.Util.List.ChangeField(_Web, Constants.Lists.TipoManual, SPBuiltInFieldId.Title, Constants.Fields.NomeManual, out listTipoManual, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.ModuloManual, SPBuiltInFieldId.Title, Constants.Fields.NomeModulo, out listModuloManual, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.TipoAtoNormativo, SPBuiltInFieldId.Title, Constants.Fields.NomeTipoAtoNormativo, out listTipoAtoNormativo, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.SituacaoAtoNormativo, SPBuiltInFieldId.Title, Constants.Fields.NomeSituacao, out listSituacaoAtoNormativo, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.FaseRevisaoElaboracao, SPBuiltInFieldId.Title, Constants.Fields.NomeFase, out listFaseRevisaoElaboracao, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.TipoDocumentoAprovacao, SPBuiltInFieldId.Title, Constants.Fields.NomeTipoDocumentoAprovacao, out listTipoDocAprovacao, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.RodapeDocumento, SPBuiltInFieldId.Title, Constants.Fields.NomeRodape, out listRodapeDocumento, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.TipoPendencia, SPBuiltInFieldId.Title, Constants.Fields.NomePendencia, out listPendencias, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.Ato, SPBuiltInFieldId.Title, Constants.Fields.Ato, out listAto, true, true);
            Base.Util.List.ChangeField(_Web, Constants.Lists.AtosNormativos, SPBuiltInFieldId.Title, Constants.Fields.AtosNormativos, out listAtosNormativos, true, true);

            ServiceList.SetRepresentantesNormativosListSettings(_Web, out listRepresentantesNormativos);
            ServiceList.SetAtosNormativosListSettings(_Web, out listAto);
            ServiceList.SetAndamentoFaseListSettings(_Web, out listAndamentoFase);
            /* WebParts Display Forms Ato Normativo */ 
            AddWPDisplayForm(_Web);
            AddWPMinuta(_Web);
            AddWPObservacao(_Web);
            AddWPOHistoricoRN(_Web);
            AddWPAcoesMinuta(_Web);
            AddWPCentralDocs(_Web);

            /* WebParts New Form Minuta */
            //AddWPNewFormMinuta(_Web);

            SPUser userDefault = _Web.SiteAdministrators[0];
            ServiceList.CreateGroup(_Web, Constants.Groups.RN_AD, "Representantes AD", SPRoleType.Contributor, userDefault);
            ServiceList.CreateGroup(_Web, Constants.Groups.RN_DA, "Representantes DA", SPRoleType.Contributor, userDefault);
            ServiceList.CreateGroup(_Web, Constants.Groups.RN_DE, "Representantes DE", SPRoleType.Contributor, userDefault);
            ServiceList.CreateGroup(_Web, Constants.Groups.RN_DF, "Representantes DF", SPRoleType.Contributor, userDefault);
            ServiceList.CreateGroup(_Web, Constants.Groups.RN_DN, "Representantes DN", SPRoleType.Contributor, userDefault);
            ServiceList.CreateGroup(_Web, Constants.Groups.RN_DP, "Representantes DP", SPRoleType.Contributor, userDefault);
            ServiceList.CreateGroup(_Web, Constants.Groups.RN_DO, "Representantes DO", SPRoleType.Contributor, userDefault);

        }

        public void AddWPNewFormMinuta(SPWeb web)
        {
            try
            {
                SPList mainList = web.Lists["Minuta"];
                SPFile dispForm = web.GetFile(mainList.DefaultNewFormUrl);
                SPLimitedWebPartManager wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                using (Webparts.Minuta_Lista_E_Edicao.Minuta_Lista_E_Edicao wp = new Webparts.Minuta_Lista_E_Edicao.Minuta_Lista_E_Edicao())
                {
                    wp.ChromeType = PartChromeType.TitleAndBorder;
                    wp.Title = "Todos os Items";
                    wp.Height = 350;
                    wpm.AddWebPart(wp, "Zone 1", 0);
                    wpm.SaveChanges(wp);
                }
            }
            catch { }
        }

        public void AddWPAcoesMinuta(SPWeb web)
        {
            try
            {
                SPList mainList = web.Lists["Ato"];
                SPFile dispForm = web.GetFile(mainList.DefaultDisplayFormUrl);
                SPLimitedWebPartManager wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
                using (Webparts.Minuta_Display.Minuta_Display wp = new Webparts.Minuta_Display.Minuta_Display())
                {
                    wp.ChromeType = PartChromeType.None;
                    wpm.AddWebPart(wp, "Zone 1", 3);
                    wpm.SaveChanges(wp);
                }
            }
            catch { }
        }

        public void AddWPCentralDocs(SPWeb web)
        {
            try
            {
                SPList mainList = web.Lists["Ato"];
                SPFile dispForm = web.GetFile(mainList.DefaultDisplayFormUrl);
                SPLimitedWebPartManager wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                SPList ct = web.Lists["Central de Anexos"];
                ListViewWebPart webp = new ListViewWebPart();

                webp.ChromeType = PartChromeType.TitleOnly;
                webp.ListName = ct.ID.ToString("B").ToUpper();
                webp.ViewGuid = ct.DefaultView.ID.ToString("B").ToUpper();
                wpm.AddWebPart(webp, "Zone 1", 7);
                dispForm.Publish("");
                dispForm.Approve("");
            }
            catch { }
        }

        public void AddWPObservacao(SPWeb web)
        {
            try
            {
                SPList mainList = web.Lists["Ato"];
                SPFile dispForm = web.GetFile(mainList.DefaultDisplayFormUrl);
                SPLimitedWebPartManager wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                SPList minuta = web.Lists["Observação"];
                ListViewWebPart webp = new ListViewWebPart();

                webp.ChromeType = PartChromeType.TitleOnly;
                webp.ListName = minuta.ID.ToString("B").ToUpper();
                webp.ViewGuid = minuta.DefaultView.ID.ToString("B").ToUpper();
                wpm.AddWebPart(webp, "Zone 1", 3);
                dispForm.Publish("");
                dispForm.Approve("");
            }
            catch { }
        }

        public void AddWPOHistoricoRN(SPWeb web)
        {
            try
            {
                SPList mainList = web.Lists["Ato"];
                SPFile dispForm = web.GetFile(mainList.DefaultDisplayFormUrl);
                SPLimitedWebPartManager wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                SPList minuta = web.Lists["Histórico Retorno RN"];
                ListViewWebPart webp = new ListViewWebPart();

                webp.ChromeType = PartChromeType.TitleOnly;
                webp.ListName = minuta.ID.ToString("B").ToUpper();
                webp.ViewGuid = minuta.DefaultView.ID.ToString("B").ToUpper();
                wpm.AddWebPart(webp, "Zone 1", 3);
                dispForm.Publish("");
                dispForm.Approve("");
            }
            catch { }
        }

        public void AddWPMinuta(SPWeb web)
        {
            try
            {
                SPList mainList = web.Lists["Ato"];
                SPFile dispForm = web.GetFile(mainList.DefaultDisplayFormUrl);
                SPLimitedWebPartManager wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                SPList minuta = web.Lists["Minuta"];
                ListViewWebPart webp = new ListViewWebPart();
                webp.ChromeType = PartChromeType.TitleOnly;
                webp.ListName = minuta.ID.ToString("B").ToUpper();
                webp.ViewGuid = minuta.DefaultView.ID.ToString("B").ToUpper();
                wpm.AddWebPart(webp, "Zone 1", 2);
                dispForm.Publish("");
                dispForm.Approve("");
            }
            catch { }
        }

        public void AddWPDisplayForm(SPWeb web)
        {
            SPList mainList = web.Lists["Ato"];
            SPFile dispForm = web.GetFile(mainList.DefaultDisplayFormUrl);
            SPLimitedWebPartManager wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
            using (Webpart.Ato_Display_Revisao.Ato_Display_Revisao wp = new Webpart.Ato_Display_Revisao.Ato_Display_Revisao())
            {
                wp.ChromeType = PartChromeType.None;
                wpm.AddWebPart(wp, "Zone 1", 0);
                wpm.SaveChanges(wp);
            }
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWeb _Web = properties.Feature.Parent as SPWeb;

            Base.Util.List.ChangeDeleteRestriction(_Web, Constants.Lists.ModuloManual, Constants.Fields.NomeManual, SPRelationshipDeleteBehavior.None);
            Base.Util.List.ChangeDeleteRestriction(_Web, Constants.Lists.RodapeDocumento, Constants.Fields.TipoAtoNormativo, SPRelationshipDeleteBehavior.None);
            Base.Util.List.ChangeDeleteRestriction(_Web, Constants.Lists.AndamentoFase, Constants.Fields.FaseRevisaoElaboracao, SPRelationshipDeleteBehavior.None);

            Base.Util.List.RemoveList(_Web,
                Constants.Lists.RodapeDocumento,
                Constants.Lists.ModuloManual,
                Constants.Lists.TipoAtoNormativo, 
                Constants.Lists.SituacaoAtoNormativo,
                Constants.Lists.AndamentoFase,
                Constants.Lists.FaseRevisaoElaboracao,
                Constants.Lists.TipoDocumentoAprovacao,
                Constants.Lists.TipoManual,
                Constants.Lists.RepresentanteNormativo,
                Constants.Lists.OrgaosFurnas,
                Constants.Lists.TipoPendencia,Constants.Lists.Noticias, Constants.Lists.Formulario, Constants.Lists.DocumentoAprovacaoExt, Constants.Lists.LinksPromovidos,// Constants.Lists.AtosNormativos,
                Constants.Lists.HistoricoRetornoRN, Constants.Lists.AtosNormativos, Constants.Lists.CentralAnexo, Constants.Lists.Minuta, Constants.Lists.Observacao, Constants.Lists.Ato);
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
