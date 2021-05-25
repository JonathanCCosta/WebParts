using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class ItemFC
    {
        public FC FC { get; set; }
        public double valor { get; set; }
        public Nivel1FC Nivel1FC { get; set; }
        public Nivel2FC Nivel2FC { get; set; }
        public Nivel3FC Nivel3FC { get; set; }
    }
}
