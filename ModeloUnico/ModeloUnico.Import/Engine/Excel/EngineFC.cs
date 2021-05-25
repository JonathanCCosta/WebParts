using Excel;
using Furnas.GestaoSPE.ModeloUnico.Import.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Engine.Excel
{
    public class EngineFC
    {

        private static string ultimoNivel1;
        private static string ultimoNivel2;
        private static int numeroPeriodos;
        public static List<ItemFC> ImportarExcel(DataTable result)
        {
          
            List<ItemFC> lstFC = new List<ItemFC>();
            DataRowCollection dataRowCollection = result.Rows;
            DataColumnCollection dataColumnCollection = result.Columns;

            numeroPeriodos = dataColumnCollection.Count;
            int linha = 0;
            int coluna = 0;
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
                        DateTime mesreferencia;
                        int mes = -1;
                        int ano = -1;
                        if (DateTime.TryParse(Convert.ToString(dataColumnCollection[col].ColumnName), out mesreferencia))
                        {
                            ano = mesreferencia.Year;
                            mes = mesreferencia.Month;
                        }

                        //if (!int.TryParse(dataRowCollection[1][col].ToString().Split('/').FirstOrDefault(), out ano))
                        //    ano = -1;

                        //if (!int.TryParse(dataRowCollection[1][col].ToString().Split('/').LastOrDefault(), out mes))
                        //    mes = -1;

                        int valor;
                        if (!int.TryParse(row[col].ToString(), out valor))
                            valor = -1;

                        var itemFC = new ItemFC
                        {
                            FC = new FC()
                            {
                                Ano = ano,
                                TipoFC = 0,
                                Mes = mes,
                                DataReferencia = mesreferencia
                            },
                            //  Nivel1FC = new Nivel1FC() { },
                            //Nivel2FC = new Nivel2FC() { },
                            // Nivel3FC = new Nivel3FC() { },
                            valor = valor

                        };

                        lstFC.Add(GetNivel(itemFC, row));
                    }

                }


                linha++;

            }
 

            bool[] ultimo = new bool[3] { false, false, false };
            foreach (var item in lstFC)
            {

                bool[] novo = new bool[3] { item.Nivel1FC == null, item.Nivel2FC == null, item.Nivel3FC == null };

                var hasDuplicates = new HashSet<bool>(novo).SetEquals(ultimo);
                IStructuralEquatable se1 = novo;
                Console.WriteLine(hasDuplicates);
                //Next returns True
                Console.WriteLine(se1.Equals(ultimo, StructuralComparisons.StructuralEqualityComparer));

                if (!hasDuplicates)
                {
                    string r = "";

                }


                if (!se1.Equals(ultimo, StructuralComparisons.StructuralEqualityComparer))
                {
                    string r = "";

                }

                ultimo = novo;

            }
            return lstFC;
        }

        private static ItemFC GetNivel(ItemFC itemFC, DataRow row)
        {
            bool comtemNivel1 = string.IsNullOrEmpty(row.ItemArray[0].ToString());
            bool comtemNivel2 = string.IsNullOrEmpty(row.ItemArray[1].ToString());
            bool comtemNivel3 = string.IsNullOrEmpty(row.ItemArray[2].ToString());


            if (!comtemNivel1 && comtemNivel2 && comtemNivel3)
            {
                ultimoNivel1 = row.ItemArray[0].ToString();
                itemFC.Nivel1FC = new Nivel1FC() { Nome = ultimoNivel1 };
                return itemFC;
            }

            if (comtemNivel1 && !comtemNivel2 && comtemNivel3)
            {
                ultimoNivel2 = row.ItemArray[1].ToString();
                itemFC.Nivel2FC = new Nivel2FC { Nivel1FC = new Nivel1FC() { Nome = ultimoNivel1 }, Nome = ultimoNivel2 };
                return itemFC;
            }

            if (comtemNivel1 && comtemNivel2 && !comtemNivel3)
            {
                var ultimoNivel3 = row.ItemArray[2].ToString();
                itemFC.Nivel3FC = new Nivel3FC { Nivel2FC = new Nivel2FC() { Nome = ultimoNivel2 }, Nome = ultimoNivel3 };
                return itemFC;

            }

            return itemFC;
        }


    }
}
