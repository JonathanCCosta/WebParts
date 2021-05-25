using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using Furnas.AOPA.Base.Resource;
using Furnas.AOPA.Base.Util;
using Furnas.AOPA.Base.Service;

namespace Furnas.AOPA.Structure.EventReceiver.ER_HistoricoRN
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_HistoricoRN : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            
            base.EventFiringEnabled = false;

            try
            {
                SPList ato = properties.Web.Lists[Constants.Lists.Ato];
                SPListItem item = ato.GetItemById(new SPFieldLookupValue(properties.ListItem["Ato Normativo"].ToString()).LookupId);

                var data_antiga = item["Prazo RN"];
                item["Prazo RN"] = properties.ListItem["Data Retorno RN"];
                item.Update();


                properties.ListItem["Data Retorno RN"] = data_antiga;
                


                //ver se ato tem mais item
                //if() se sim só inseri uma linha com a data antiga e atualiza nova adata no ato
                

                //item["Data Retorno RN"] = SupportFormatting.ConvertDatas(properties.BeforeProperties["Prazo RN"].ToString());
                

                
                properties.ListItem.Update();
            }
            catch { }
        }

    }
}