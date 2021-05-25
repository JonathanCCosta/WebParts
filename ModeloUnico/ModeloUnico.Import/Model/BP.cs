using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class BP
    {
        public int TipoBP { get; set; }
        public int Trimestre { get; set; }
        public int Ano { get; set; }



        private void GetAllItems( int ItemID)
        {
            //using (SPSite site = new SPSite(SPContext.Current.Site.ID))
            //{
            //    using (SPWeb web = site.OpenWeb())
            //    {
            //        SPList list = web.Lists["Balanço Patrimonial"];
            //        SPListItemCollection items = list.Items;
            //        List<BP> lstBP = new List<BP>();
            //        foreach (SPListItem item in items)
            //        {
            //          /*  lstBP.Add(new BP
            //            {
            //                Ano = item["Ano"],
            //                TipoBP = item["Ano"],
            //                Trimestre = item["Ano"]
            //            });*/
            //        }
			 
            //    }
            //}
        }
    }
}
