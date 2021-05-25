using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furnas.AOPA;
using System.Data;
using Furnas.AOPA.Base.Util;

namespace Furnas.AOPA.Base.Service
{
    public class AcoesMinuta
    {
        public SPWeb _Web { get; set; }
        public SPList _List { get; set; }

        public AcoesMinuta(SPItemEventProperties properties)
        {
            _Web = properties.Web;
            _List = properties.List;
        }

        #region Add Item Minuta
        public static void AddMinutaNivel(SPItemEventProperties properties)
        {
            DataTable items = null;
            int proximo = 0;

            if (properties.ListItem["SubNível"] == null)
            {
                //quero pegar o utlimo sem nivel
                items = AcoesMinuta.ItemsMinuta(properties.Web, 0, Convert.ToString(new SPFieldLookupValue(properties.ListItem["Ato Normativo"].ToString()).LookupValue));

                if (items != null)
                {
                    DataRow last_row = items.Rows[items.Rows.Count - 1];

                    if (items.Rows.Count > 0)
                    {
                        if (last_row.ItemArray[2].ToString() == string.Empty)
                        {
                            proximo = 1;
                        }
                        else
                        {
                            proximo = Convert.ToInt32(last_row.ItemArray[2].ToString()) + 1;
                        }
                    }
                    else
                    {
                        proximo = 1;
                    }
                }
                else
                {
                    proximo = 1;
                }

                properties.ListItem["Nível"] = proximo.ToString();
                properties.ListItem.Update();

            }
            else
            {
                //quero pegar a seção
                string proximo_SubNivel = string.Empty;

                string Nivel = new SPFieldLookupValue(properties.ListItem["SubNível"].ToString()).LookupValue;
                items = AcoesMinuta.ItemsMinutaComSubNivel(properties.Web, new SPFieldLookupValue(properties.ListItem["Ato Normativo"].ToString()).LookupValue, Nivel);

                if (items != null)
                {
                    DataRow last_row = items.Rows[items.Rows.Count - 1];

                    if (items.Rows.Count > 0)
                    {
                        if (last_row.ItemArray[2].ToString() == string.Empty)
                        {
                            if (CountStringOccurrences(Nivel, ".") > 0)
                            {
                                proximo_SubNivel = CalculaNivel(Nivel, true, true);
                            }
                            else
                            {
                                proximo_SubNivel = CalculaNivel(Nivel, true, false);
                            }
                        }
                        else
                        {
                            if (CountStringOccurrences(last_row.ItemArray[2].ToString(), ".") > 0)
                            {
                                proximo_SubNivel = CalculaNivel(last_row.ItemArray[2].ToString(), false,true);
                            }
                            else
                            {
                                proximo_SubNivel = CalculaNivel(last_row.ItemArray[2].ToString(), true,false);
                            }
                        }
                    }
                }
                else
                {
                    //nunca será nulo, pois terá o útltimo inserido
                    //proximo_SubNivel = float.Parse(Nivel) + 0.1f;
                }

                properties.ListItem["Nível"] = proximo_SubNivel.ToString();
                properties.ListItem.Update();

            }
        }

        protected static string CalculaNivel(string nivel, bool E_pai, bool E_nivel)
        {
            if (E_pai == false)
            {
                int ultima_casa = Convert.ToInt32(nivel.Substring(nivel.Length - 1));
               
                int calc_casa = ultima_casa + 1;
                string calc = nivel.Remove(nivel.Length - 1)+calc_casa.ToString();

                return calc;
            }
            else
            {
                int casas = CountStringOccurrences(nivel, ".");
                float calc = 0;
                string aux_calc = string.Empty;
                if (E_nivel == true)
                {
                    aux_calc = nivel + "." + "1";
                    return aux_calc;
                }
                else
                {
                    calc = (float.Parse(nivel)) + Nivelamento(0);
                    return calc.ToString().Replace(",", ".");
                }
                
            }
        }

        protected static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }

        protected static float Nivelamento(int nivel)
        {
            switch (nivel)
            {
                case 0: { return (1.0f / 10.0f); }
                case 1: { return (1.0f / 100.0f); }
                case 2: { return (1.0f / 1000.0f); }
                case 3: { return (1.0f / 10000.0f); }
                case 4: { return (1.0f / 100000.0f); }
                case 5: { return (1.0f / 1000000.0f); }
                case 6: { return (1.0f / 10000000.0f); }
                case 7: { return (1.0f / 100000000.0f); }
                case 8: { return (1.0f / 1000000000.0f); }
                default:return 10;
            }
        }

        protected static float NivelamentoParaAtualizacao(int nivel)
        {
            switch (nivel)
            {
                case 1: { return (1.0f / 10.0f); }
                case 2: { return (1.0f / 100.0f); }
                case 3: { return (1.0f / 1000.0f); }
                case 4: { return (1.0f / 10000.0f); }
                case 5: { return (1.0f / 100000.0f); }
                case 6: { return (1.0f / 1000000.0f); }
                case 7: { return (1.0f / 10000000.0f); }
                case 8: { return (1.0f / 100000000.0f); }
                case 9: { return (1.0f / 1000000000.0f); }
                default: return 0.1f;
            }
        }

        protected static float NivelamentoParaDividir(int nivel)
        {
            switch (nivel)
            {
                case 1: { return (10); }
                case 2: { return (100); }
                case 3: { return (1000); }
                case 4: { return (10000); }
                case 5: { return (100000); }
                case 6: { return (1000000); }
                case 7: { return (10000000); }
                case 8: { return (100000000); }
                case 9: { return (1000000000); }
                default: return 0.1f;
            }
        }

        protected static DataTable ItemsMinuta(SPWeb web, int flag, string ato, string lista = "Minuta")
        {

            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            DataTable dt = null;

            string strQuery = "<Where><And><Eq><FieldRef Name='atoNormativo' /><Value Type='Lookup'>" + ato + "</Value></Eq><IsNull><FieldRef Name='SubNivel' /></IsNull></And></Where>";//<Eq><FieldRef Name='E_Subnivel' /><Value Type='Boolean'>" + flag + "</Value></Eq></And></Where>";
            strQuery += "<OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";

             query.Query = strQuery;
            dt = list.GetItems(query).GetDataTable();

            return dt;
        }

        protected static DataTable ItemsMinutaComSubNivel(SPWeb web, string ato, string nivel, string lista = "Minuta")
        {

            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            DataTable dt = null;

            string strQuery = "<Where><And><Eq><FieldRef Name='atoNormativo' /><Value Type='Lookup'>" + ato + "</Value></Eq><Eq><FieldRef Name='SubNivel' /><Value Type='Lookup'>"+ nivel +"</Value></Eq></And></Where>";
            strQuery += "<OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";

            query.Query = strQuery;
            dt = list.GetItems(query).GetDataTable();

            return dt;
        }

        #endregion

        #region Update Item minuta

        public void UpdatedMinutaNivel(SPItemEventProperties properties, int alteracao)
        {
            DataTable items = null;
            
            //Nível
            if (alteracao == 1)
            {
                items = ItemsMinutaNivelUpdate(properties.Web, new SPFieldLookupValue(properties.ListItem["Ato Normativo"].ToString()).LookupValue, SupportFormatting.ValidaTextField(properties.ListItem["Nível"]), new SPFieldLookupValue(properties.ListItem["SubNível"].ToString()).LookupValue);

                ReorganizarNiveis(items, properties);
            }
        }

        protected static DataTable ItemsMinutaNivelUpdate(SPWeb web, string ato, string nivel, string subnivel, string lista = "Minuta"){

            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            DataTable dt = null;

            string strQuery = "<Where><And><Eq><FieldRef Name='atoNormativo' /><Value Type='Lookup'>"+ ato +"</Value></Eq><Eq><FieldRef Name='SubNivel' /><Value Type='Lookup'>" + subnivel + "</Value></Eq></And></Where>";
                //"<Where><Or><And><Eq><FieldRef Name='atoNormativo' /><Value Type='Lookup'>" + ato + "</Value></Eq><Eq><FieldRef Name='SubNivel' /><Value Type='Lookup'>" + nivel + "</Value></Eq></And><Eq><FieldRef Name='Nivel' /><Value Type='Text'>" + nivel + "</Value></Eq></Or></Where>";
            strQuery += "<OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";

            query.Query = strQuery;
            dt = list.GetItems(query).GetDataTable();

            return dt;
        }

        #endregion

        protected void ReorganizarNiveis(DataTable items, SPItemEventProperties properties)
        {
            int acionaAlteracao = 0;
            string ato = new SPFieldLookupValue(properties.ListItem["Ato Normativo"].ToString()).LookupValue;
            string calc_proximo = string.Empty;
            for (int i=0;i<items.Rows.Count;i++)
            {
                if (acionaAlteracao == 0)
                {
                    if (SupportFormatting.ValidaTextField(properties.ListItem["Nível"]) == items.Rows[i].ItemArray[2].ToString())
                    {
                        acionaAlteracao = 1;
                        //AlterarNiveis(properties.Web, ato, SupportFormatting.ValidaTextField(properties.ListItem["Nível"]), items.Rows[i], properties.List);
                        AlterarNiveis(properties.Web, ato, SupportFormatting.ValidaTextField(properties.ListItem["Nível"]));
                        //break;
                        //calc_proximo = CalculaNivel();
                    }
                }
                else
                {
                    string nivel_antigo = items.Rows[i].ItemArray[2].ToString();
                    int casas = CountStringOccurrences(nivel_antigo, ".");
                    float muda_inicio = (float.Parse(nivel_antigo)/NivelamentoParaDividir(casas)) + NivelamentoParaAtualizacao(casas);
                    string nivel_novo = muda_inicio.ToString().Replace(",",".") + nivel_antigo.Remove(0, nivel_antigo.Length);

                    AlterarNiveisProximo(properties.Web, ato, nivel_novo, items.Rows[i].ItemArray[13].ToString());
                    
                    //AlterarNiveis(properties.Web, ato, SupportFormatting.ValidaTextField(properties.ListItem["Nível"]));
                }
            }
        }

        protected void AlterarNiveisProximo(SPWeb web, string ato, string nivel, string id)
        {
            SPList list = _Web.Lists[_List.Title];
            SPListItem item = list.GetItemById(Convert.ToInt32(id));

            item["Nível"] = nivel;
            item.Update();

            AlterarNiveis(web, ato, SupportFormatting.ValidaTextField(item["Nível"]));
        }

        //protected static void AlterarNiveis(SPWeb web, string ato, string nivel, DataRow mudar_nivel,SPList lista)
        protected static void AlterarNiveis(SPWeb web, string ato, string nivel)
        {
            SPListItemCollection SubNiveis = null;

            if (nivel.Length > 1)
            {
                SubNiveis = ItemsMinutaComSubNivelNovo(web, ato, nivel);

                if (SubNiveis != null)
                {
                    foreach (SPListItem item in SubNiveis)
                    {
                        string nivel_antigo = item["Nível"].ToString();
                        item["Nível"] = nivel + nivel_antigo.Remove(0, nivel.Length);
                        item.Update();
                    }
                }
            }
            else
            {
                SubNiveis = ItemsMinutaSemSubNivelNovo(web);
                int subirNivel = 0;

                if (SubNiveis != null)
                {
                    foreach (SPListItem item in SubNiveis)
                    {
                        if (subirNivel == 0)
                        {
                            if (nivel == item["Nível"].ToString())
                            {
                                item["Nivel"] = Convert.ToInt32(nivel) + 1;
                                item.Update();
                                subirNivel = 1;
                            }
                        }
                        else
                        {
                            item["Nivel"] = Convert.ToInt32(nivel) + 1;
                            item.Update();
                        }
                    }
                }
            }
        }

        protected static SPListItemCollection ItemsMinutaComSubNivelNovo(SPWeb web, string ato, string nivel, string lista = "Minuta")
        {
            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            SPListItemCollection items = null;

            string strQuery = "<Where><Contains><FieldRef Name='SubNivel' /><Value Type='Lookup'>"+nivel+"</Value></Contains></Where>";
            strQuery += "<OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";

            query.Query = strQuery;
            items = list.GetItems(query);

            return items;
        }


        protected static SPListItemCollection ItemsMinutaSemSubNivelNovo(SPWeb web, string lista = "Minuta")
        {
            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            SPListItemCollection items = null;

            string strQuery = "<Where><IsNull><FieldRef Name='SubNivel' /></IsNull></Where>";
            strQuery += "<OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";

            query.Query = strQuery;
            items = list.GetItems(query);

            return items;
        }

        public static DataTable TodosItemsMinuta(SPWeb web, string ato, string lista = "Minuta")
        {
            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            DataTable items = null;

            query.ViewFields = "";

            string strQuery = "<Where><Eq><FieldRef Name='atoNormativo' LookupId='True' /><Value Type='Lookup'>" + ato + "</Value></Eq></Where>";
            strQuery += "<OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";

            query.Query = strQuery;
            items = list.GetItems(query).GetDataTable();

            return items;
        }
        
    }
}
