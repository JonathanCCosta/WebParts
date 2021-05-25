using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.AOPA.Base.Service
{
    public class ManipulaLista
    {
        public static SPListItem RetornaLista(string list, SPWeb web, int id)
        {
            SPList lista = web.Lists[list];
            SPListItem item = lista.GetItemById(id);

            return item;
        }
    }
}
