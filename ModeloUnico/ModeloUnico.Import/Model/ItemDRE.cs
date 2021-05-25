using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class ItemDRE
    {
        public DRE DRE { get; set; }
        public double valor { get; set; }
        public Nivel1DRE Nivel1DRE { get; set; }
        public Nivel2DRE Nivel2DRE { get; set; }
        public Nivel3DRE Nivel3DRE { get; set; }
    }
}
