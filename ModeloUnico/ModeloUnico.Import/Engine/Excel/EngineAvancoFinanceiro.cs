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
    public class EngineAvancoFinanceiro
    {
        public static List<AvancoFinanceiro> ImportarExcel(IExcelDataReader excelReader)
        {
            excelReader.IsFirstRowAsColumnNames = true;
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();


            foreach (DataRow row in result.Tables[0].Rows)
            {
                //need to set value to NewColumn column
                row["NewColumn"] = 0;   // or set it to some other value
            }
            Console.WriteLine(result.Tables[0].Rows[1][1]);

            var lstAvancoFínanceiroPrevisto = new List<AvancoFinanceiro>();
            DataRowCollection p = result.Tables[0].Rows;

            int i = 0;
            foreach (DataRow row in result.Tables[0].Rows)
            {
                if (i > 4)
                {

                    int realizado;
                    if (!int.TryParse((row).ItemArray[4].ToString(), out realizado))
                        realizado = -1;

                    int pn0;
                    if (!int.TryParse((row).ItemArray[2].ToString(), out pn0))
                        pn0 = -1;

                    int pnMaisAtual;
                    if (!int.TryParse((row).ItemArray[3].ToString(), out pnMaisAtual))
                        pnMaisAtual = -1;

                    //  SPE spe =  lstSPE.Add(new SPE() { };
                    /*  DateTime dataBase;

                      if (!int.TryParse((row).ItemArray[3].ToString(), out pnMaisAtual))
                          Convert.ToDateTime(row["% avanço acumulado"])*/
                    lstAvancoFínanceiroPrevisto.Add(

                        new AvancoFinanceiro
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

            excelReader.IsFirstRowAsColumnNames = false;






            return lstAvancoFínanceiroPrevisto;
        }


        public static List<AvancoFinanceiro> ImportarExcel(DataTable result)
        {



            
            var lstAvancoFínanceiroPrevisto = new List<AvancoFinanceiro>();
            DataRowCollection p = result.Rows;

            int i = 0;
            foreach (DataRow row in result.Rows)
            {
                if (i > 4)
                {

                    int realizado;
                    if (!int.TryParse((row).ItemArray[4].ToString(), out realizado))
                        realizado = -1;

                    int pn0;
                    if (!int.TryParse((row).ItemArray[2].ToString(), out pn0))
                        pn0 = -1;

                    int pnMaisAtual;
                    if (!int.TryParse((row).ItemArray[3].ToString(), out pnMaisAtual))
                        pnMaisAtual = -1;

                    //  SPE spe =  lstSPE.Add(new SPE() { };
                    /*  DateTime dataBase;

                      if (!int.TryParse((row).ItemArray[3].ToString(), out pnMaisAtual))
                          Convert.ToDateTime(row["% avanço acumulado"])*/
                    lstAvancoFínanceiroPrevisto.Add(

                        new AvancoFinanceiro
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






            return lstAvancoFínanceiroPrevisto;
        }


    }
}
