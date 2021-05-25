using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Model
{
    public class SPE
    {
        public int Id { get; set; }
        public string Nome { get; set; }



        public List<SPE> CarregarSPE()
        {

            List<SPE> lstSPE = new List<SPE>();
            lstSPE.Add(new SPE { Nome = "BAGUARI ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "Consórcio UHE BAGUARI" });
            lstSPE.Add(new SPE { Nome = "BELO MONTE TRANSMISSORA DE ENERGIA SPE S.A." });
            lstSPE.Add(new SPE { Nome = "BRASIL VENTOS ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "COMPANHIA CENTROESTE DE MINAS" });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS I S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS II S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS III S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS IV S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS X S.A." });
            lstSPE.Add(new SPE { Nome = "BALEIA - BOM JESUS EÓLICA S.A" });
            lstSPE.Add(new SPE { Nome = "BALEIA - CACHOEIRA EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "BALEIA - PITIMBU EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "BALEIA - SÃO CAETANO EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "BALEIA - SÃO CAETANO I EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "BALEIA - SÃO GALVÃO EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "ACARAÚ - VENTOS DE SANTA ROSA S.A." });
            lstSPE.Add(new SPE { Nome = "ACARAÚ - VENTOS DE UIRAPURU S.A." });
            lstSPE.Add(new SPE { Nome = "ACARAÚ - VENTOS DE ANGELIM S.A." });
            lstSPE.Add(new SPE { Nome = "FAMOSA III -GERADORA EÓLICA ARARA AZUL S.A." });
            lstSPE.Add(new SPE { Nome = "FAMOSA III -GERADORA EÓLICA BENTEVI S.A." });
            lstSPE.Add(new SPE { Nome = "FAMOSA III -GERADORA EÓLICA OURO VERDE I S.A." });
            lstSPE.Add(new SPE { Nome = "FAMOSA III -GERADORA EÓLICA OURO VERDE II S.A." });
            lstSPE.Add(new SPE { Nome = "FAMOSA III -GERADORA EÓLICA OURO VERDE III S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS V S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS VI S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS VII S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS VIII S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA DOS VENTOS IX S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA SERRA DO MEL I S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA SERRA DO MEL II S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA SERRA DO MEL III S.A." });
            lstSPE.Add(new SPE { Nome = "BRASVENTOS EOLO GERADORA DE ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "BRASVENTOS MIASSABA 3 GERADORA DE ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "REI DOS VENTOS 3 GERADORA DE ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA ITAGUAÇU DA BAHIA SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SANTA LUIZA SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SANTA MADALENA SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SANTA MARCELLA SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SANTA VERA SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SANTO ANTÔNIO SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SÃO BENTO SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SÃO CIRILO SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SÃO JOÃO SPE S.A." });
            lstSPE.Add(new SPE { Nome = "GERADORA EÓLICA VENTOS SÃO RAFAEL SPE S.A." });
            lstSPE.Add(new SPE { Nome = "ITAGUAÇU DA BAHIA ENERGIAS RENOVÁVEIS S.A." });
            lstSPE.Add(new SPE { Nome = "CENTRAL EÓLICA FAMOSA I S.A." });
            lstSPE.Add(new SPE { Nome = "CENTRAL EÓLICA PAU BRASIL S.A." });
            lstSPE.Add(new SPE { Nome = "CENTRAL EÓLICA ROSADA S.A." });
            lstSPE.Add(new SPE { Nome = "CENTRAL EÓLICA SÃO PAULO S.A." });
            lstSPE.Add(new SPE { Nome = "PUNAÚ - CARNAÚBA I EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "PUNAÚ - CARNAÚBA II EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "PUNAÚ - CARNAÚBA III EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "PUNAÚ - CARNAÚBA V EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "PUNAÚ - CERVANTES I EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "PUNAÚ - CERVANTES II EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "PUNAÚ - PUNAÚ I EÓLICA S.A." });
            lstSPE.Add(new SPE { Nome = "CSE - CENTRO DE SOLUÇÕES ESTRATÉGICAS S.A." });
            lstSPE.Add(new SPE { Nome = "ENERPEIXE S.A." });
            lstSPE.Add(new SPE { Nome = "CHAPECOENSE GERAÇÃO S.A." });
            lstSPE.Add(new SPE { Nome = "FOZ DO CHAPECÓ ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "MGE TRANSMISSÃO S.A." });
            lstSPE.Add(new SPE { Nome = "GOIÁS TRANSMISSÃO S.A." });
            lstSPE.Add(new SPE { Nome = "INTERLIGAÇÃO ELÉTRICA DO MADEIRA S.A." });
            lstSPE.Add(new SPE { Nome = "INAMBARI GERAÇÃO DE ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "LAGO AZUL TRANSMISSÃO S.A." });
            lstSPE.Add(new SPE { Nome = "LUZIÂNIA – NIQUELÂNDIA TRANSMISSORA S.A." });
            lstSPE.Add(new SPE { Nome = "MADEIRA ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "SANTO ANTÔNIO ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "MATA DE SANTA GENEBRA TRANSMISSORA S.A." });
            lstSPE.Add(new SPE { Nome = "ENERGIA OLÍMPICA S.A." });
            lstSPE.Add(new SPE { Nome = "PARANAÍBA TRANSMISSORA DE ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "RETIRO BAIXO ENERGÉTICA S.A." });
            lstSPE.Add(new SPE { Nome = "EMPRESA DE ENERGIA SÃO MANOEL S.A." });
            lstSPE.Add(new SPE { Nome = "SERRA DO FACÃO ENERGIA S.A." });
            lstSPE.Add(new SPE { Nome = "TELES PIRES PARTICIPAÇÕES S.A." });
            lstSPE.Add(new SPE { Nome = "COMPANHIA HIDRELÉTRICA TELES PIRES" });
            lstSPE.Add(new SPE { Nome = "TRANSENERGIA RENOVÁVEL S.A." });
            lstSPE.Add(new SPE { Nome = "TRANSENERGIA SÃO PAULO S.A." });
            lstSPE.Add(new SPE { Nome = "TRANSENERGIA GOIÁS S.A." });
            lstSPE.Add(new SPE { Nome = "COMPANHIA TRANSIRAPÉ DE TRANSMISSÃO" });
            lstSPE.Add(new SPE { Nome = "COMPANHIA TRANSUDESTE DE TRANSMISSÃO" });
            lstSPE.Add(new SPE { Nome = "COMPANHIA TRANSLESTE DE TRANSMISSÃO" });
            lstSPE.Add(new SPE { Nome = "TIJOÁ PARTICIPAÇÕES E INVESTIMENTOS S.A." });
            lstSPE.Add(new SPE { Nome = "TRIÂNGULO MINEIRO TRANSMISSORA S.A." });
            lstSPE.Add(new SPE { Nome = "VALE DO SÃO BARTOLOMEU TRANSMISSORA DE ENERGIA S.A." });

            return lstSPE;
        }
    }
}
