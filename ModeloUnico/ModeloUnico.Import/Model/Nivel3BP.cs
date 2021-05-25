using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class Nivel3BP
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nivel2BP Nivel2BP { get; set; }
    }
}
