using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.AOPA.Base.Util
{
    public class SupportFormatting
    {
        public static string FormataRevisaoValidacao(int num)
        {
            return (num < 9) ? "0" + num.ToString() : num.ToString();
        }

        public static DateTime ConvertDatas(string data)
        {
            DateTime dt = System.Convert.ToDateTime(data);
            return dt;
        }

        public static int ConvertDropDownValue(string value)
        {
            return Convert.ToInt32(value);
        }

        public static string ValidaTextField(object fieldvalue)
        {
            return (fieldvalue != null) ? Convert.ToString(fieldvalue) : string.Empty;
        }
    }
}
