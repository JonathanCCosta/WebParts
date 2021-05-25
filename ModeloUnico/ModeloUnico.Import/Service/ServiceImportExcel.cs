using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Furnas.GestaoSPE.ModeloUnico.Import.Model;
using Microsoft.SharePoint.Utilities;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Service
{
    public static class ServiceImportExcel
    {

        #region Geral
        internal static void LoadDropDown(System.Web.UI.WebControls.DropDownList ddlItems, SPWeb sPWeb, string listname, string lookupcolumn = null)
        {
            SPList list = sPWeb.Lists[listname];

            foreach (SPListItem item in list.Items)
            {
                string text = string.Empty;
                if (listname == "SPE")
                    text = string.Format("{0} :: {1}", new SPFieldLookupValue(Convert.ToString(item["Complexo"])).LookupValue, item.Title);
                else
                    text = item.Title;

                ListItem lt = new ListItem();
                if (!string.IsNullOrEmpty(lookupcolumn))
                    lt.Attributes.Add("lookup", new SPFieldLookupValue(Convert.ToString(item[lookupcolumn])).LookupId.ToString());
                lt.Text = text;
                lt.Value = item.ID.ToString();
                ddlItems.Items.Add(lt);
            }

            List<ListItem> itemsDDL = ddlItems.Items.Cast<ListItem>().OrderBy(lt => lt.Text).ToList();

            ddlItems.Items.Clear();
            ddlItems.Items.AddRange(itemsDDL.ToArray());
        }

        #endregion

        #region Fluxo de Caixa

        private static void LoadNivelFC(SPWeb web, ref List<Nivel1FC> lstNivel1FC, ref List<Nivel2FC> lstNivel2FC, ref List<Nivel3FC> lstNivel3FC)
        {
            SPList _listNivel1FC = web.Lists["Nivel 1 FC"];
            SPList _listNivel2FC = web.Lists["Nível 2 FC"];
            SPList _listNivel3FC = web.Lists["Nível 3 FC"];

            foreach (SPListItem itemNivel1FC in _listNivel1FC.Items)
            {
                Nivel1FC objNivel1FC = new Nivel1FC();
                objNivel1FC.Id = itemNivel1FC.ID;
                objNivel1FC.Nome = itemNivel1FC.Title;
                lstNivel1FC.Add(objNivel1FC);
            }

            foreach (SPListItem itemNivel2FC in _listNivel2FC.Items)
            {
                Nivel2FC objNivel2FC = new Nivel2FC();
                objNivel2FC.Id = itemNivel2FC.ID;
                objNivel2FC.Nome = itemNivel2FC.Title;
                SPFieldLookupValue ltNivel1FC = new SPFieldLookupValue(Convert.ToString(itemNivel2FC["Nivel_x0020_1_x0020_FC"]));
                objNivel2FC.Nivel1FC = lstNivel1FC.Where(p => p.Id == ltNivel1FC.LookupId).FirstOrDefault();
                lstNivel2FC.Add(objNivel2FC);
            }

            foreach (SPListItem itemNivel3FC in _listNivel3FC.Items)
            {
                Nivel3FC objNivel3FC = new Nivel3FC();
                objNivel3FC.Id = itemNivel3FC.ID;
                objNivel3FC.Nome = itemNivel3FC.Title;
                SPFieldLookupValue ltNivel2FC = new SPFieldLookupValue(Convert.ToString(itemNivel3FC["Nivel_x0020_2_x0020_FC"]));
                objNivel3FC.Nivel2FC = lstNivel2FC.Where(p => p.Id == ltNivel2FC.LookupId).FirstOrDefault();
                lstNivel3FC.Add(objNivel3FC);
            }

        }

        internal static void UploadFluxoCaixa(SPWeb web, DataTable dt, Propriedades prop)
        {
            List<Nivel1FC> lstNivel1FC = new List<Nivel1FC>();
            List<Nivel2FC> lstNivel2FC = new List<Nivel2FC>();
            List<Nivel3FC> lstNivel3FC = new List<Nivel3FC>();

            LoadNivelFC(web, ref lstNivel1FC, ref lstNivel2FC, ref lstNivel3FC);


            SPList _listItemFC = null;
            SPList _listFC = null;
            string columnRefName = (prop.classificacao == Classificacao.Realizado) ? "SPE" : "PlanoNegocio";
            string columItemRefName = (prop.classificacao == Classificacao.Realizado) ? "FC" : "FluxoCaixaPN";

            if (prop.idPN > 0)
            {
                _listItemFC = web.Lists["Item FC PN"];
                _listFC = web.Lists["Fluxo de Caixa PN"];
            }
            else
            {
                _listItemFC = web.Lists["Item FC"];
                _listFC = web.Lists["Fluxo de Caixa"];
            }

            List<Model.ItemFC> list = Engine.Excel.EngineFC.ImportarExcel(dt);

            list = list.OrderBy(p => p.FC.Ano).ThenBy(p => p.FC.Mes).ToList();

            FC currentFC = new FC();
            foreach (ItemFC item in list)
            {
                SPListItem itfluxocaixa = null;
                SPListItem ititemFC = null;

                if (currentFC.ID <= 0 || (item.FC.Ano != currentFC.Ano || item.FC.Mes != currentFC.Mes))
                {
                    currentFC = item.FC;
                    itfluxocaixa = _listFC.AddItem();
                    itfluxocaixa["Title"] = "Ver detalhes";
                    itfluxocaixa[columnRefName] = (prop.classificacao == Classificacao.Realizado) ? new SPFieldLookupValue(prop.idSPE, string.Empty) : new SPFieldLookupValue(prop.idPN, string.Empty);
                    itfluxocaixa["Ano"] = item.FC.Ano;
                    itfluxocaixa["Trimestre"] = ServiceImportExcel.GetTrimestre(item.FC.Mes);
                    itfluxocaixa["DataReferencia"] = item.FC.DataReferencia;
                    itfluxocaixa["Tipo_x0020_FC"] = prop.tipodf;

                    itfluxocaixa.Update();
                    currentFC.ID = itfluxocaixa.ID;
                }

                Nivel1FC nivel1 = lstNivel1FC.Where(p => (item.Nivel1FC != null) && p.Nome == item.Nivel1FC.Nome).FirstOrDefault();
                Nivel2FC nivel2 = lstNivel2FC.Where(p => (item.Nivel2FC != null) && p.Nome == item.Nivel2FC.Nome).FirstOrDefault();
                Nivel3FC nivel3 = lstNivel3FC.Where(p => (item.Nivel3FC != null) && p.Nome == item.Nivel3FC.Nome).FirstOrDefault();
                if (nivel1 != null || nivel2 != null || nivel3 != null)
                {
                    ititemFC = _listItemFC.AddItem();
                    ititemFC[columItemRefName] = new SPFieldLookupValue(currentFC.ID, string.Empty);

                    if (nivel1 != null)
                        ititemFC["N_x00ed_vel_x0020_1_x0020_FC"] = new SPFieldLookupValue(nivel1.Id, nivel1.Nome);
                    if (nivel2 != null)
                        ititemFC["N_x00ed_vel_x0020_2_x0020_FC"] = new SPFieldLookupValue(nivel2.Id, nivel2.Nome);
                    if (nivel3 != null)
                        ititemFC["N_x00ed_vel_x0020_3_x0020_FC"] = new SPFieldLookupValue(nivel3.Id, nivel3.Nome);

                    ititemFC["Valor"] = item.valor;
                    //ititemFC["Title"] = string.Format("N1: {0} | N2: {1} | N3:{0}",
                    //    (item.Nivel1FC != null) ? item.Nivel1FC.Nome : string.Empty,
                    //    (item.Nivel2FC != null) ? item.Nivel2FC.Nome : string.Empty,
                    //    (item.Nivel3FC != null) ? item.Nivel3FC.Nome : string.Empty);
                    ititemFC["Title"] = "Ver detalhes";
                    ititemFC.Update();

                }
            }
        }

        private static int GetTrimestre(int month)
        {
            if (month > 0 && month <= 3)
                return 1;
            else if (month > 3 && month <= 6)
                return 2;
            else if (month > 6 && month <= 9)
                return 3;
            else
                return 4;
        }

        #endregion

#region DRE
        internal static void UploadDRE(SPWeb sPWeb, DataTable dt, Propriedades prop)
        {
            SPList _listNível1DRE = sPWeb.Lists["Nível 1 DRE"];
            SPList _listNível2DRE = sPWeb.Lists["Nível 2 DRE"];
            SPList _listNível3DRE = sPWeb.Lists["Nível 3 DRE"];

            SPList _ListComumPai = null, _ListComumFilho = null;

            List<Model.ItemDRE> list = Engine.Excel.EngineDRE.ImportarExcel(dt);

            var CollDREsGroups = list.GroupBy(x => x.DRE.ID).ToList();

            string tipo = prop.tipodf == TipoDF.Societario ? "Societário" : "Regulatório";
            string nomeColunaLookup = prop.idSPE > 0 ? "SPE" : "PlanoNegocio";
            SPFieldLookupValue valorConulaLookup = prop.idSPE > 0 ? new SPFieldLookupValue(prop.idSPE, prop.tituloSPE) : new SPFieldLookupValue(prop.idPN, string.Empty);
            int IdRef = 0;
            bool isDRE = false;

            if (prop.idSPE > 0)
            {
                _ListComumPai = sPWeb.Lists["DRE"];
                _ListComumFilho = sPWeb.Lists["Item DRE"];
                IdRef = prop.idSPE;
                isDRE = true;
            }
            else
            {
                _ListComumPai = sPWeb.Lists["DRE PN"];
                _ListComumFilho = sPWeb.Lists["Item DRE PN"];
                IdRef = prop.idPN;
            }

            List<SPListItem> collDRE = _ListComumPai.Items.OfType<SPListItem>().Where(p =>
                    new SPFieldLookupValue(Convert.ToString(p[nomeColunaLookup])).LookupId == IdRef).ToList();

            #region DRE PN

            foreach (var itemGroup in CollDREsGroups)
            {
                int valid = 0;
                foreach (var itemDRE in itemGroup)
                {
                    SPListItem newDRE = null, DREExistente = null;
                    bool DREExist = ExistDRE(collDRE, itemDRE.DRE, tipo, out DREExistente);

                    List<ItemDRE> ItensDRE = list.Where(p => p.DRE.ID == itemDRE.DRE.ID).ToList();
                    if (valid == 0 && !DREExist)//Adiciono primeiro o DRE
                    {
                        newDRE = _ListComumPai.AddItem();
                        newDRE[nomeColunaLookup] = valorConulaLookup;
                        newDRE["Tipo_x0020_DRE"] = tipo;
                        newDRE["Trimestre"] = itemDRE.DRE.Trimestre;
                        newDRE["Ano"] = itemDRE.DRE.Ano;
                        newDRE.Update();

                        //Adiciona os itens do DRE PN
                        foreach (ItemDRE itDRE in ItensDRE)
                        {
                            AdcionaItemDRE(_ListComumFilho, _listNível1DRE, _listNível2DRE, _listNível3DRE, newDRE, itDRE, isDRE);
                        }
                    }
                    else
                    {
                        //Verifica se os itens Existem na DRE
                        //Adiciona os itens do DRE
                        if (DREExistente != null)
                        {
                            foreach (ItemDRE itDRE in ItensDRE)
                            {
                                AdcionaItemDRE(_ListComumFilho, _listNível1DRE, _listNível2DRE, _listNível3DRE, DREExistente, itDRE, isDRE);
                            }
                        }
                    }
                    valid++;
                }
            #endregion
            }
        }

        private static void AdcionaItemDRE(SPList _listItemDRE, SPList _listNível1DRE, SPList _listNível2DRE, SPList _listNível3DRE, SPListItem newDRE, ItemDRE itDRE, bool isDRE)
        {
            SPListItem newItemDRE = null;
            ItemDRE item = new ItemDRE();

            SPFieldLookupValue nivel1DRE = null, nivel2DRE = null, nivel3DRE = null;
            if (itDRE.Nivel1DRE != null)
            {
                nivel1DRE = ObterNivel1DRE(itDRE.Nivel1DRE.Nome, _listNível1DRE);//ver porque esta vindo nulo
                if (nivel1DRE != null)
                    itDRE.Nivel1DRE.Id = nivel1DRE.LookupId;
            }
            if (itDRE.Nivel2DRE != null)
            {
                nivel2DRE = ObterNivel2DRE(itDRE.Nivel2DRE.Nome, _listNível2DRE, out nivel1DRE);
                if (nivel2DRE != null)
                {
                    itDRE.Nivel2DRE.Id = nivel2DRE.LookupId;
                    itDRE.Nivel1DRE = new Nivel1DRE();
                    itDRE.Nivel1DRE.Id = nivel1DRE.LookupId;
                    itDRE.Nivel1DRE.Nome = nivel1DRE.LookupValue;
                }
            }
            if (itDRE.Nivel3DRE != null)
            {
                nivel3DRE = ObterNivel2DRE(itDRE.Nivel2DRE.Nome, _listNível2DRE, out nivel2DRE);
                if (nivel3DRE != null)
                {
                    itDRE.Nivel3DRE.Id = nivel3DRE.LookupId;
                    itDRE.Nivel2DRE = new Nivel2DRE();
                    itDRE.Nivel2DRE.Id = nivel2DRE.LookupId;
                    itDRE.Nivel2DRE.Nome = nivel2DRE.LookupValue;
                }
            }

            if (nivel1DRE != null)
            {
                string nivel1, nivel2, nivel3;
                if (isDRE)
                {
                    nivel1 = "Grupo_x0020_1_x0020_DRE";
                    nivel2 = "Grupo_x0020_2_x0020_DRE";
                    nivel3 = "Grupo_x0020_3_x0020_DRE";
                }
                else
                {
                    nivel1 = "Nivel1DRE";
                    nivel2 = "Nivel2DRE";
                    nivel3 = "Nivel3DRE";
                }

                bool ItemDREExist = ExistItemDRE(itDRE, _listItemDRE, newDRE.ID, out newItemDRE, isDRE);
                if (!ItemDREExist)
                    newItemDRE = _listItemDRE.AddItem();

                newItemDRE[nivel1] = nivel1DRE;
                newItemDRE[nivel2] = nivel2DRE;
                newItemDRE[nivel3] = nivel3DRE;
                newItemDRE["DRE"] = new SPFieldLookupValue(newDRE.ID, newDRE.Title);
                newItemDRE["Valor"] = itDRE.valor;
                newItemDRE.Update();
            }
        }

        private static bool ExistItemDRE(ItemDRE itDRE, SPList _listItemDRE, int IdDRE, out SPListItem ItemExistente, bool isDRE)
        {
            List<SPListItem> CollItensDRE = _listItemDRE.Items.OfType<SPListItem>().Where(p => new SPFieldLookupValue(Convert.ToString(p["DRE"])).LookupId == IdDRE).ToList();

            string valueDefault = string.Empty;
            string newValue = string.Empty;
            bool Exist = false;
            ItemExistente = null;

            string nivel1, nivel2, nivel3;
            if (isDRE)
            {
                nivel1 = "Grupo_x0020_1_x0020_DRE";
                nivel2 = "Grupo_x0020_2_x0020_DRE";
                nivel3 = "Grupo_x0020_3_x0020_DRE";
            }
            else
            {
                nivel1 = "Nivel1DRE";
                nivel2 = "Nivel2DRE";
                nivel3 = "Nivel3DRE";
            }
            foreach (SPListItem item in CollItensDRE)
            {
                if (item[nivel1] != null)
                    valueDefault += new SPFieldLookupValue(Convert.ToString(item[nivel1])).LookupValue.ToLower();
                if (item[nivel2] != null)
                    valueDefault += new SPFieldLookupValue(Convert.ToString(item[nivel2])).LookupValue.ToLower();
                if (item[nivel3] != null)
                    valueDefault += new SPFieldLookupValue(Convert.ToString(item[nivel3])).LookupValue.ToLower();
                if (item["Valor"] != null)
                    valueDefault += Convert.ToString(item["Valor"]).ToLower();


                if (itDRE.Nivel1DRE != null && !string.IsNullOrEmpty(itDRE.Nivel1DRE.Nome))
                    newValue += itDRE.Nivel1DRE.Nome.ToLower();
                if (itDRE.Nivel2DRE != null && !string.IsNullOrEmpty(itDRE.Nivel2DRE.Nome))
                    newValue += itDRE.Nivel2DRE.Nome.ToLower();
                if (itDRE.Nivel3DRE != null && !string.IsNullOrEmpty(itDRE.Nivel3DRE.Nome))
                    newValue += itDRE.Nivel3DRE.Nome.ToLower();
                if (itDRE.valor > 0)
                    newValue += itDRE.valor;

                if (string.Compare(valueDefault, newValue, true) == 0)
                {
                    Exist = true;
                    ItemExistente = item;
                    break;
                }

                valueDefault = string.Empty;
                newValue = string.Empty;
            }

            return Exist;
        }

        private static SPFieldLookupValue ObterNivel1DRE(string nomeNivel, SPList list)
        {
            SPFieldLookupValue ValorNivel = null;
            SPListItem item = list.Items.OfType<SPListItem>().Where(p => p.Title == nomeNivel).FirstOrDefault();

            if (item != null)
                ValorNivel = new SPFieldLookupValue(item.ID, item.Title);

            return ValorNivel;
        }

        private static SPFieldLookupValue ObterNivel2DRE(string nomeNivel, SPList list, out SPFieldLookupValue nivel1DRE)
        {
            SPFieldLookupValue ValorNivel = null;
            nivel1DRE = null;
            SPListItem item = list.Items.OfType<SPListItem>().Where(p => p.Title == nomeNivel).FirstOrDefault();

            if (item != null)
            {
                ValorNivel = new SPFieldLookupValue(item.ID, item.Title);
                nivel1DRE = new SPFieldLookupValue(Convert.ToString(item["Grupo_x0020_1_x0020_DRE"]));
            }

            return ValorNivel;
        }

        private static SPFieldLookupValue ObterNivel3DRE(string nomeNivel, SPList list, out SPFieldLookupValue nivel2DRE)
        {
            SPFieldLookupValue ValorNivel = null;
            nivel2DRE = null;
            SPListItem item = list.Items.OfType<SPListItem>().Where(p => p.Title == nomeNivel).FirstOrDefault();

            if (item != null)
            {
                ValorNivel = new SPFieldLookupValue(item.ID, item.Title);
                nivel2DRE = new SPFieldLookupValue(Convert.ToString(item["Grupo_x0020_2_x0020_DRE"]));
            }

            return ValorNivel;
        }

        private static bool ExistDRE(List<SPListItem> CollItens, DRE dre, string tipo, out SPListItem ItemExistente)
        {
            ItemExistente = null;
            string valueDefault = string.Empty;
            string newValue = string.Empty;
            bool Exist = false;
            foreach (SPListItem item in CollItens)
            {
                if (item["Tipo_x0020_DRE"] != null)
                    valueDefault += Convert.ToString(item["Tipo_x0020_DRE"]).ToLower();
                if (item["Trimestre"] != null)
                    valueDefault += Convert.ToString(item["Trimestre"]).ToLower();
                if (item["Ano"] != null)
                    valueDefault += Convert.ToString(item["Ano"]).ToLower();

                newValue += tipo.ToLower();
                if (dre.Trimestre > 0)
                    newValue += Convert.ToString(dre.Trimestre);
                if (dre.Ano > 0)
                    newValue += Convert.ToString(dre.Ano);

                int CompareExist = string.Compare(valueDefault, newValue, true);

                if (CompareExist == 0)
                {
                    Exist = true;
                    ItemExistente = item;
                    break;
                }
                valueDefault = string.Empty;
                newValue = string.Empty;
            }
            return Exist;
        }
        #endregion
    }
}
