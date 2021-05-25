using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.AOPA.Base.Service
{
    public class CarregamentoMinuta
    {
        public static DataTable ItemsMinuta(SPWeb web, string ato, string lista = "Minuta")
        {

            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            DataTable dt = null;

            string strQuery = "<Where><Eq><FieldRef Name='atoNormativo' LookupId='TRUE' /><Value Type='Lookup'>" + ato + "</Value></Eq></Where>";
            strQuery += "<OrderBy><FieldRef Name='SubNivel' Ascending='True' /></OrderBy>";
            
            query.ViewFields = "<FieldRef Name='Nivel'/>";

            query.Query = strQuery;
            dt = list.GetItems(query).GetDataTable();

            return dt;
        }

        public static SPListItemCollection ItemsMinutaCopy(SPWeb web, string ato, string lista = "Minuta")
        {

            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            SPListItemCollection items = null;

            string strQuery = "<Where><Eq><FieldRef Name='atoNormativo' LookupId='TRUE' /><Value Type='Lookup'>" + ato + "</Value></Eq></Where>";
            strQuery += "<OrderBy><FieldRef Name='Nivel' Ascending='True' /></OrderBy>";

            query.Query = strQuery;
            items = list.GetItems(query);

            return items;
        }

        public static bool AprovaMinuta(SPWeb web, string ato)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
