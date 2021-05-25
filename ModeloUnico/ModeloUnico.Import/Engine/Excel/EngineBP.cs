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
    public class EngineBP
    {
        private static string ultimoNivel1;
        private static string ultimoNivel2;
        private static int numeroPeriodos;
        public static List<ItemBP> ImportarExcel(DataTable result)
        {

         

            List<ItemBP> ItemBP = new List<ItemBP>();
            DataRowCollection dataRowCollection = result.Rows;
            DataColumnCollection dataColumnCollection = result.Columns;

            numeroPeriodos = dataColumnCollection.Count;
            int linha = 0;
       
            DataRow linhaPeriodo = dataRowCollection[1];
            dataColumnCollection[0].ColumnName = "Nivel1";
            dataColumnCollection[1].ColumnName = "Nivel2";
            dataColumnCollection[2].ColumnName = "Nivel3";

            for (int i = 3; i < dataColumnCollection.Count; i++)
            {
                var dataColumnCollection1 = dataColumnCollection[i].ColumnName;
                var dataRowCollection2 = dataRowCollection[1][i].ToString();

                if (!string.IsNullOrEmpty(dataRowCollection2))
                    dataColumnCollection[i].ColumnName = dataRowCollection[1][i].ToString();
            }

         


            foreach (DataRow row in dataRowCollection)
            {
                if (linha > 1)
                {
                    for (int col = 3; col < dataColumnCollection.Count; col++)
                    {
                        int ano;
                        if (!int.TryParse(dataRowCollection[1][col].ToString().Split('/').FirstOrDefault(), out ano))
                            ano = -1;

                        int trimestre;
                        if (!int.TryParse(dataRowCollection[1][col].ToString().Split('/').LastOrDefault(), out trimestre))
                            trimestre = -1;

                        int valor;
                        if (!int.TryParse(row[col].ToString(), out valor))
                            valor = -1;

                        var itemBP = new ItemBP
                        {
                            BP = new BP()
                            {
                                Ano = ano,
                                TipoBP = 0,
                                Trimestre = trimestre
                            },
                            //  Nivel1DRE = new Nivel1DRE() { },
                            //Nivel2DRE = new Nivel2DRE() { },
                            // Nivel3DRE = new Nivel3DRE() { },
                            valor = valor

                        };

                        ItemBP.Add(GetNivel(itemBP, row));
                    }

                }


                linha++;

            }

        


            return ItemBP;
        }

        private static ItemBP GetNivel(ItemBP itemBP, DataRow row)
        {
            bool comtemNivel1 = string.IsNullOrEmpty(row.ItemArray[0].ToString());
            bool comtemNivel2 = string.IsNullOrEmpty(row.ItemArray[1].ToString());
            bool comtemNivel3 = string.IsNullOrEmpty(row.ItemArray[2].ToString());


            if (!comtemNivel1 && comtemNivel2 && comtemNivel3)
            {
                ultimoNivel1 = row.ItemArray[0].ToString();
                itemBP.Nivel1BP = new Nivel1BP() { Nome = ultimoNivel1 };
                return itemBP;
            }

            if (comtemNivel1 && !comtemNivel2 && comtemNivel3)
            {
                ultimoNivel2 = row.ItemArray[1].ToString();
                itemBP.Nivel2BP = new Nivel2BP { Nivel1BP = new Nivel1BP() { Nome = ultimoNivel1 }, Nome = ultimoNivel2 };
                return itemBP;
            }

            if (comtemNivel1 && comtemNivel2 && !comtemNivel3)
            {
                var ultimoNivel3 = row.ItemArray[2].ToString();
                itemBP.Nivel3BP = new Nivel3BP { Nivel2BP = new Nivel2BP() { Nome = ultimoNivel2 }, Nome = ultimoNivel3 };
                return itemBP;

            }

            return itemBP;
        }


    }
}
