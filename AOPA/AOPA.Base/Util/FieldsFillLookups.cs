using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.AOPA.Base.Util
{
    public static class FieldsFillLookups
    {
        public static DataTable fillDropDown(string lista, SPWeb web)
        {
            SPList list = web.Lists[lista];
            DataTable dt = list.Items.GetDataTable();
            return dt;
        }

        public static DataTable fillDropDownQuery(string lista, SPWeb web, string fase)
        {
            SPList list = web.Lists[lista];
            SPQuery query = new SPQuery();
            DataTable dt = list.Items.GetDataTable();

            string strQuery = "<Where><Eq><FieldRef Name='nomefaserevisaoelaboracao' /><Value Type='Lookup'>" + fase +"</Value></Eq></Where>";
            query.Query = strQuery;
            dt = list.GetItems(query).GetDataTable();

            return dt;
        }
    }
}
