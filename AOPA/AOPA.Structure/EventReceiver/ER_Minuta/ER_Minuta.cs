using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using Furnas.AOPA.Base.Service;
using Furnas.AOPA.Base.Util;
using System.Data;

namespace Furnas.AOPA.Structure.EventReceiver.ER_Minuta
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_Minuta : SPItemEventReceiver
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

            base.EventFiringEnabled = false;

            AcoesMinuta.AddMinutaNivel(properties);

            base.EventFiringEnabled = true;
        }

        /// <summary>
        /// An item was updated
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);

            //0 - Nível / 1 - Nível e SubNível / 2 - SubNível
            if (SupportFormatting.ValidaTextField(properties.ListItem["Nível"]) != ValueAnterior)//SupportFormatting.ValidaTextField(properties.BeforeProperties["Nível"]))
            {
                if (ValueAnterior != string.Empty)
                {
                    base.EventFiringEnabled = false;

                    AcoesMinuta minuta = new AcoesMinuta(properties);
                    minuta.UpdatedMinutaNivel(properties, 1);

                    base.EventFiringEnabled = true;
                }
            }
            else if (SupportFormatting.ValidaTextField(properties.ListItem["Nível"]) != SupportFormatting.ValidaTextField(properties.BeforeProperties["Nível"]) && SupportFormatting.ValidaTextField(properties.ListItem["SubNível"]) != SupportFormatting.ValidaTextField(properties.BeforeProperties["SubNível"]))
            {

            }
            else if (SupportFormatting.ValidaTextField(properties.ListItem["SubNível"]) != SupportFormatting.ValidaTextField(properties.BeforeProperties["SubNível"]))
            {

            }
            
        }

        protected static string ValueAnterior = string.Empty;

        /// <summary>
        /// An item is being updated
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            //0 - Nível / 1 - Nível e SubNível / 2 - SubNível
            //if (SupportFormatting.ValidaTextField(properties.ListItem["Nível"]) != SupportFormatting.ValidaTextField(properties.AfterProperties["Nível"]))
            //{
            //    if (SupportFormatting.ValidaTextField(properties.AfterProperties["Nível"]) != string.Empty)
            //    {
            //        base.EventFiringEnabled = false;

            //        AcoesMinuta minuta = new AcoesMinuta(properties);
            //        minuta.UpdatedMinutaNivel(properties, 1);

            //        base.EventFiringEnabled = true;
            //    }
            //}
            //else if (SupportFormatting.ValidaTextField(properties.ListItem["Nível"]) != SupportFormatting.ValidaTextField(properties.BeforeProperties["Nível"]) && SupportFormatting.ValidaTextField(properties.ListItem["SubNível"]) != SupportFormatting.ValidaTextField(properties.BeforeProperties["SubNível"]))
            //{

            //}
            //else if (SupportFormatting.ValidaTextField(properties.ListItem["SubNível"]) != SupportFormatting.ValidaTextField(properties.BeforeProperties["SubNível"]))
            //{

            //}

            ValueAnterior = SupportFormatting.ValidaTextField(properties.ListItem["Nível"]);

            base.ItemUpdating(properties);           
        }


    }
}