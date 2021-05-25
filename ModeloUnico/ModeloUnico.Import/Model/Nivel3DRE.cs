using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
     public class Nivel3DRE
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nivel2DRE Nivel2DRE { get; set; }
    }
}
