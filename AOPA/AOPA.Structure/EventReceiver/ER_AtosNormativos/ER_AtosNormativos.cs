using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using Furnas.AOPA.Base.Resource;
using Furnas.AOPA.Base.Util;
using Furnas.AOPA.Base.Service;

namespace Furnas.AOPA.Structure.EventReceiver.ER_AtosNormativos
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_AtosNormativos : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            base.ItemAdding(properties);
        }

        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);


            if (properties.ListItem["Fase da Revisão"] == null)
            {
                properties.ListItem["Situação"] = new SPFieldLookupValue(1, "Em Elaboração");
                properties.ListItem["Fase da Revisão"] = new SPFieldLookupValue(1, "Não Iniciado");
                properties.ListItem["Andamento da Fase"] = new SPFieldLookupValue(1, "0%");
                properties.ListItem["Percentual de Andamento"] = 0;

                if (properties.ListItem.ContentType.Name == "Instrução Normativa")
                {
                    properties.ListItem["Data Vencimento"] = DateTime.Now.AddYears(2);
                    properties.ListItem["Data Limite para Entrada em Revisão"] = DateTime.Now.AddMonths(22);

                    SPGroup grupoDA = properties.Web.SiteGroups["Representantes DA"];
                    SPGroup grupoDE = properties.Web.SiteGroups["Representantes DE"];
                    SPGroup grupoDF = properties.Web.SiteGroups["Representantes DF"];
                    SPGroup grupoDN = properties.Web.SiteGroups["Representantes DN"];
                    SPGroup grupoDP = properties.Web.SiteGroups["Representantes DP"];
                    SPGroup grupoDO = properties.Web.SiteGroups["Representantes DO"];

                    SPFieldUserValueCollection userDA = new SPFieldUserValueCollection(); SPFieldUserValueCollection userDE = new SPFieldUserValueCollection(); SPFieldUserValueCollection userDF = new SPFieldUserValueCollection();
                    SPFieldUserValueCollection userDN = new SPFieldUserValueCollection(); SPFieldUserValueCollection userDP = new SPFieldUserValueCollection(); SPFieldUserValueCollection userDO = new SPFieldUserValueCollection();

                    foreach (SPUser user in grupoDA.Users)
                    {
                       userDA.Add(new SPFieldUserValue(properties.Web, user.ID, user.Name));
                    }

                    properties.ListItem["Analista DA"] = userDA;

                    foreach (SPUser user in grupoDE.Users)
                    {
                        userDE.Add(new SPFieldUserValue(properties.Web, user.ID, user.Name));
                    }

                    properties.ListItem["Analista DE"] = userDE;

                    foreach (SPUser user in grupoDF.Users)
                    {
                        userDF.Add(new SPFieldUserValue(properties.Web, user.ID, user.Name));
                    }

                    properties.ListItem["Analista DF"] = userDF;

                    foreach (SPUser user in grupoDN.Users)
                    {
                        userDN.Add(new SPFieldUserValue(properties.Web, user.ID, user.Name));
                    }

                    properties.ListItem["Analista DN"] = userDN;

                    foreach (SPUser user in grupoDP.Users)
                    {
                        userDP.Add(new SPFieldUserValue(properties.Web, user.ID, user.Name));
                    }

                    properties.ListItem["Analista DP"] = userDP;

                    foreach (SPUser user in grupoDO.Users)
                    {
                        userDO.Add(new SPFieldUserValue(properties.Web, user.ID, user.Name));
                    }

                    properties.ListItem["Analista DO"] = userDO;

                }

                properties.ListItem.Update();
            }

        }

        /// <summary>
        /// An item was updated
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);

            /*try
            {
                if (SupportFormatting.ValidaTextField(properties.ListItem["Prazo RN"]) != SupportFormatting.ValidaTextField(properties.BeforeProperties["Prazo RN"]))
                {
                    if (properties.BeforeProperties["Prazo RN"] != "")
                    {
                        SPList historico = properties.Web.Lists["Histórico Retorno RN"];
                        SPListItem item = historico.AddItem();

                        item["Data Retorno RN"] = SupportFormatting.ConvertDatas(properties.BeforeProperties["Prazo RN"].ToString());
                        item["Ato Normativo"] = new SPFieldLookupValue(Convert.ToInt32(properties.ListItem[SPBuiltInFieldId.ID].ToString()), properties.ListItem[SPBuiltInFieldId.Title].ToString());

                        item.Update();
                    }
                }
            }
            catch { }*/

        }

    }
}