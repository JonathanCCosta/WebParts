using Furnas.AOPA.Base.Resource;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.AOPA.Base.Util
{
    public class Permission
    {
        public static bool getGroupUserColab()
        {
            //SPGroup grupo_comissao = SPContext.Current.Web.Groups[Constants.Groups.ComissaoEtica];
            //SPGroup grupo_rh = SPContext.Current.Web.Groups[Constants.Groups.RH];
            SPGroup grupo_aopa = SPContext.Current.Web.Groups[Constants.Groups.AOPA];
            string retornaGrupo = string.Empty;

            if (grupo_aopa.ContainsCurrentUser)
            {
                return true;
            }

            return false;
        }
    }
}
