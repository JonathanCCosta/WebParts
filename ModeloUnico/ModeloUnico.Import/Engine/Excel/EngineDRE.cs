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
    public class EngineDRE
    {

        private static string ultimoNivel1;
        private static string ultimoNivel2;
        private static int numeroPeriodos;
        public static List<ItemDRE> ImportarExcel(DataTable result)
        {

            List<ItemDRE> lstDRE = new List<ItemDRE>();
            DataRowCollection dataRowCollection = result.Rows;
            DataColumnCollection dataColumnCollection = result.Columns;

            numeroPeriodos = dataColumnCollection.Count;
            int linha = 0;
            int coluna = 0;
            DataRow linhaPeriodo = dataRowCollection[1];
            dataColumnCollection[0].ColumnName = "Nivel1";
            dataColumnCollection[1].ColumnName = "Nivel2";
            dataColumnCollection[2].ColumnName = "Nivel3";

            //Aqui estou sobreescrevendo a coluna do trimestre. Preciso desta informação.
            //for (int i = 3; i < dataColumnCollection.Count; i++)
            //{
            //    var dataColumnCollection1 = dataColumnCollection[i].ColumnName;
            //    var dataRowCollection2 = dataRowCollection[1][i].ToString();

            //    if (!string.IsNullOrEmpty(dataRowCollection2))
            //        dataColumnCollection[i].ColumnName = dataRowCollection[1][i].ToString();
            //}





            //foreach (DataRow row in dataRowCollection)
            for (int col = 3; col < dataColumnCollection.Count; col++)
            {
                //if (linha > 0)//Deve ser maior que zero, já que a primeira linha é 0.
                {
                    //for (int col = 3; col < dataColumnCollection.Count; col++)
                    foreach (DataRow row in dataRowCollection)
                    {
                        //int ano;
                        //if (!int.TryParse(dataRowCollection[1][col].ToString().Split('/').FirstOrDefault(), out ano))
                        //    ano = -1;

                        //int trimestre;
                        //if (!int.TryParse(dataRowCollection[1][col].ToString().Split('/').LastOrDefault(), out trimestre))
                        //    trimestre = -1;




                        int valor;
                        if (!int.TryParse(row[col].ToString(), out valor))
                            valor = -1;
                        //Se não tem valor no trimestre não precisa adicionar.
                        if (valor > 0)
                        {
                            int ano = Convert.ToInt32(dataColumnCollection[col].ColumnName.Split('/')[0]);
                            int trimestre = Convert.ToInt32(dataColumnCollection[col].ColumnName.Split('/')[1]);

                            var itemDRE = new ItemDRE
                            {
                                DRE = new DRE() 
                                {
                                    ID = col,
                                    Ano = ano,
                                    TipoDRE = "0",//TODO: Colocar o valor da página aqui.
                                    Trimestre = trimestre
                                },
                                //  Nivel1DRE = new Nivel1DRE() { },
                                //Nivel2DRE = new Nivel2DRE() { },
                                // Nivel3DRE = new Nivel3DRE() { },
                                valor = valor

                            };

                            lstDRE.Add(GetNivel(itemDRE, row));
                        }
                    }

                }


                linha++;

            }

            //Não é necessário.
            //bool[] ultimo = new bool[3] { false, false, false };
            //foreach (var item in lstDRE)
            //{

            //    bool[] novo = new bool[3] { item.Nivel1DRE == null, item.Nivel2DRE == null, item.Nivel3DRE == null };

            //    var hasDuplicates = new HashSet<bool>(novo).SetEquals(ultimo);
            //    IStructuralEquatable se1 = novo;
            //    Console.WriteLine(hasDuplicates);
            //    //Next returns True
            //    Console.WriteLine(se1.Equals(ultimo, StructuralComparisons.StructuralEqualityComparer));

            //    if (!hasDuplicates)
            //    {
            //        string r = "";

            //    }


            //    if (!se1.Equals(ultimo, StructuralComparisons.StructuralEqualityComparer))
            //    {
            //        string r = "";

            //    }

            //    ultimo = novo;

            //}
            return lstDRE;
        }

        private static ItemDRE GetNivel(ItemDRE itemDRE, DataRow row)
        {
            bool comtemNivel1 = string.IsNullOrEmpty(row.ItemArray[0].ToString());
            bool comtemNivel2 = string.IsNullOrEmpty(row.ItemArray[1].ToString());
            bool comtemNivel3 = string.IsNullOrEmpty(row.ItemArray[2].ToString());


            if (!comtemNivel1 && comtemNivel2 && comtemNivel3)
            {
                ultimoNivel1 = row.ItemArray[0].ToString();
                itemDRE.Nivel1DRE = new Nivel1DRE() { Nome = ultimoNivel1 };
                return itemDRE;
            }

            if (comtemNivel1 && !comtemNivel2 && comtemNivel3)
            {
                ultimoNivel2 = row.ItemArray[1].ToString();
                itemDRE.Nivel2DRE = new Nivel2DRE { Nivel1DRE = new Nivel1DRE() { Nome = ultimoNivel1 }, Nome = ultimoNivel2 };
                return itemDRE;
            }

            if (comtemNivel1 && comtemNivel2 && !comtemNivel3)
            {
                var ultimoNivel3 = row.ItemArray[2].ToString();
                itemDRE.Nivel3DRE = new Nivel3DRE { Nivel2DRE = new Nivel2DRE() { Nome = ultimoNivel2 }, Nome = ultimoNivel3 };
                return itemDRE;

            }

            return itemDRE;
        }


    }
}
