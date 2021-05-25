using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class AvancoFinanceiro
    {
        public SPE SPE{ get; set; }
        public Obra Obra { get; set; }
        public PN PN { get; set; }
        public DateTime? DataBase { get; set; }
        public int Percentual { get; set; }       
        public int Id { get; set; }
    }
}
