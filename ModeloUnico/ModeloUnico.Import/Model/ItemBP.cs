using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class ItemBP
    {
        public BP BP { get; set; }
        public double valor { get; set; }
        public Nivel1BP Nivel1BP { get; set; }
        public Nivel2BP Nivel2BP { get; set; }
        public Nivel3BP Nivel3BP { get; set; }
    }
}
