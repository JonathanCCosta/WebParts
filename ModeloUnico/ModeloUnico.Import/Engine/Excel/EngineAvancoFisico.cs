using Excel;
using Furnas.GestaoSPE.ModeloUnico.Import.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Engine.Excel
{
    public class EngineAvancoFisico
    {
        public static DataSet GetSet(IExcelDataReader excelReader)
        {
            return excelReader.AsDataSet();
        }
        public static List<AvancoFisico> ImportarExcel(DataTable result)
        {
 
            var lstAvancoFísicoPrevisto = new List<AvancoFisico>();
            DataRowCollection p = result.Rows;

            int i = 0;
            foreach (DataRow row in result.Rows)
            {
                if (i > 0)
                {

                   
                    int pn0;
                    if (!int.TryParse((row).ItemArray[1].ToString(), out pn0))
                        pn0 = -1;

                    int pnMaisAtual;
                    if (!int.TryParse((row).ItemArray[2].ToString(), out pnMaisAtual))
                        pnMaisAtual = -1;

                  int realizado;
                    if (!int.TryParse((row).ItemArray[3].ToString(), out realizado))
                        realizado = -1;

                    lstAvancoFísicoPrevisto.Add(

                        new AvancoFisico
                        {
                            DataBase = null,
                            Obra = new Obra() { Realizado = realizado },
                            Percentual = 0,
                            PN = new PN() { PN0 = pn0, PNMaisAtual = pnMaisAtual },
                            SPE = null
                        }
                    );
                }
                i++;

            }

   





            return lstAvancoFísicoPrevisto;
        }

    }

}
