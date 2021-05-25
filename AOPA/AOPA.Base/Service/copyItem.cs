using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furnas.AOPA.Base.Util;
using System.Xml;
using Microsoft.SharePoint.BusinessData.Infrastructure;

namespace Furnas.AOPA.Base.Service
{
    public class copyItem
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public static SPListItem CopyItemMinuta(SPListItem sourceItem, SPList destinationList, string ato, int id)
        {
            SPListItem targetItem = destinationList.AddItem();

            targetItem[SPBuiltInFieldId.Title] = SupportFormatting.ValidaTextField(sourceItem[SPBuiltInFieldId.Title]);
            targetItem["Nível"] = sourceItem["Nível"];
            targetItem["SubNível"] = sourceItem["SubNível"];
            targetItem["Conteúdo"] = sourceItem["Texto Final"];
            targetItem["Ato Normativo"] = new SPFieldLookupValue(id, ato);

            targetItem.SystemUpdate();
            return targetItem;
        }

        public static SPListItem CopyItemAto(SPListItem sourceItem, SPList destinationList)
        {
            SPListItem targetItem = destinationList.AddItem();

            targetItem[SPBuiltInFieldId.Title] = sourceItem[SPBuiltInFieldId.Title];
            targetItem["Número Ato Normativo Antigo"] = sourceItem["Número Ato Normativo Antigo"];
            targetItem["Manual"] = sourceItem["Manual"];
            targetItem["Módulo"] = sourceItem["Módulo"];
            targetItem["Macroprocesso"] = sourceItem["Macroprocesso"];
            targetItem["Processo"] = sourceItem["Processo"];
            targetItem["Criticidade"] = sourceItem["Criticidade"];
            targetItem["Responsável Técnico"] = sourceItem["Responsável Técnico"];
            targetItem["Analista AOP.A"] = sourceItem["Analista AOP.A"];
            targetItem["Solicitação de Abertura da Revisão/Elaboração"] = sourceItem["Solicitação de Abertura da Revisão/Elaboração"];
            targetItem["Data da Solicitação da Abertura Revisão/Elaboração"] = sourceItem["Data da Solicitação da Abertura Revisão/Elaboração"];
            targetItem["Justificativa Revisão Elaboração"] = sourceItem["Justificativa Revisão Elaboração"];

            SPField myfield = sourceItem.Fields["Nome Órgao"];
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(myfield.SchemaXml);
            String entityName = xmlData.FirstChild.Attributes["RelatedFieldWssStaticName"].Value;
            string newValue = sourceItem["Nome Órgao"].ToString();
            targetItem[entityName] = EntityInstanceIdEncoder.EncodeEntityInstanceId(new object[] { newValue });
            targetItem["Nome Órgao"] = newValue;


            //targetItem["Nome Órgao"] = sourceItem["Nome Órgao"];

            targetItem["Situação"] = new SPFieldLookupValue(1, "Em Elaboração");
            targetItem["Fase da Revisão"] = new SPFieldLookupValue(1, "Não Iniciado");
            targetItem["Andamento da Fase"] = new SPFieldLookupValue(1, "0%");
            targetItem["Percentual de Andamento"] = 0;
            targetItem["Data Vencimento"] = DateTime.Now.AddYears(2);
            targetItem["Data Limite para Entrada em Revisão"] = DateTime.Now.AddMonths(22);
            targetItem["Analista DA"] = sourceItem["Analista DA"];
            targetItem["Analista DE"] = sourceItem["Analista DE"];
            targetItem["Analista DF"] = sourceItem["Analista DF"];
            targetItem["Analista DN"] = sourceItem["Analista DN"];
            targetItem["Analista DP"] = sourceItem["Analista DP"];
            targetItem["Analista DO"] = sourceItem["Analista DO"];

            targetItem.SystemUpdate();
            return targetItem;

        }

        public static SPListItem CopyItem(SPListItem sourceItem, SPList destinationList)
        {
            SPListItem targetItem = destinationList.AddItem();

            //loop over the soureitem, restore it
            for (int i = sourceItem.Versions.Count - 1; i >= 0; i--)
            {
                //set the values into the archive 
                foreach (SPField sourceField in sourceItem.Fields)
                {
                    SPListItemVersion version = sourceItem.Versions[i];

                    if ((!sourceField.ReadOnlyField) && (sourceField.InternalName != "Attachments"))
                    {
                        SetFields(targetItem, sourceField, version);
                    }
                }

                //update the archive item and 
                //loop over the the next version
                //targetItem["Data_x0020_de_x0020_Refer_x00ea_"] = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)); ;
                //targetItem.Update();
            }

            foreach (string fileName in sourceItem.Attachments)
            {
                SPFile file = sourceItem.ParentList.ParentWeb.GetFile(sourceItem.Attachments.UrlPrefix + fileName);
                targetItem.Attachments.Add(fileName, file.OpenBinary());
            }

            targetItem.SystemUpdate();
            return targetItem;
        }

        private static bool SetFields(SPListItem targetItem, SPField sourceField, SPListItemVersion version)
        {
            try
            {
                targetItem[sourceField.InternalName] = version.ListItem[sourceField.InternalName];
                return true;
            }
            catch (System.ArgumentException)//field not filled
            {
                return false;
            }
            catch (SPException)//field not filled
            {
                return false;
            }
        }
    }
}
