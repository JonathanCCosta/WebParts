using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class Nivel2FC
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nivel1FC Nivel1FC { get; set; }

    }
}
