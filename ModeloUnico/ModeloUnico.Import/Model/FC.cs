using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class FC
    {
        public int ID { get; set; }
        public int TipoFC { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public DateTime DataReferencia { get; set; }
        public int idPN { get; set; }
        public int idSPE { get; set; }
    }
}
