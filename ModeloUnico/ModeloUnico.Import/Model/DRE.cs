using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class DRE
    {
        public int ID { get; set; }
        public string TipoDRE { get; set; }
        public int Trimestre { get; set; }
        public int Ano { get; set; }
        public bool SPE { get; set; }
    }
}
