using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class Nivel2BP
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nivel1BP Nivel1BP { get; set; }
    }
}
