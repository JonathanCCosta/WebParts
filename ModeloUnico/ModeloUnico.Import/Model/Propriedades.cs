using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class Propriedades
    {
        public int idSPE { get; set; }
        public string tituloSPE { get; set; }
        public int idEmpreendimento { get; set; }
        public string tituloEmpreendimento { get; set; }
        public int idObra { get; set; }
        public string tituloObra { get; set; }
        public int idPN { get; set; }
        public Classificacao classificacao { get; set; }
        public TipoExcel tipomodelo { get; set; }
        public TipoDF tipodf { get; set; }
    }
    public enum Classificacao
    {
        Previsto = 1,
        Revisto = 2,
        Realizado = 3        
    }
    public enum TipoExcel
    {
        AvancoFisico = 1,
        AvancoFinanceiro = 2,
        DFDRE = 3,
        DFFluxoCaixa = 4,
        DFBP = 5
    }
    public enum TipoDF
    {
        Regulatorio = 1,
        Societario = 2
    }
}
