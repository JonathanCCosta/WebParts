using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class PN
    {
        public int Id { get; set; }
        public double PN0 { get; set; }
        public double PNMaisAtual { get; set; }
        public Empreendimento Empreendimento { get; set; }
        public string RevisaoPN { get; set; }

       

        public List<PN> CarregarPN()
        {
            List<PN> lstPN = new List<PN>();

 


            lstPN.Add(new PN
            {
                RevisaoPN = "BAGUARI - PREVISÃO 2016",
                Empreendimento = new Empreendimento()
                {
                    Nome = "UHE BAGUARI",
                    SPE = new SPE()
                    {
                        Nome = "BAGUARI ENERGIA S.A."
                    }
                }
            });




            lstPN.Add(new PN
            {
                RevisaoPN = "BAGUARI - REVISÃO 2",
                Empreendimento = new Empreendimento()
                {
                    Nome = "UHE BAGUARI",
                    SPE = new SPE()
                    { Nome = "BAGUARI ENERGIA S.A." }
                }
             });





            return lstPN;
        } 

    }
}
