using ClosedXML.Excel;
using Excel;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnas.GestaoSPE.ModeloUnico.Import.Engine.Excel
{
    public class EngineExcel
    {
        //public static IExcelDataReader ReadExcel(Stream file = null)
        //{
        //    IExcelDataReader excelReader = null;
        //    bool existe = false;
        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {


        //        if (file != null)
        //        {
        //            //1. Reading Excel file
        //            if (false)
        //            {
        //                //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
        //                excelReader = ExcelReaderFactory.CreateBinaryReader(file);
        //            }
        //            else
        //            {
        //                //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
        //                excelReader = ExcelReaderFactory.CreateOpenXmlReader(file);
        //            }

        //        }



        //    });

        //    return excelReader;

        //    /*
        //    DataSet result = excelReader.AsDataSet();
        //    excelReader.IsFirstRowAsColumnNames = false;

        //    Console.WriteLine(result.Tables[0].Rows[1][1]);

        //    return result;
        //    */
        //}

        public static DataTable ReadExcel(Stream stream)
        {


            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(stream))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;

                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        IXLCells cells = row.Cells();
                        foreach (IXLCell cell in cells)
                        {
                            //if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                                dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        IXLCells cells = row.Cells();
                        //if (cells.First().Value != null && !string.IsNullOrEmpty(cells.First().Value.ToString()))
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int i = 0;
                            //int p = row.CellCount();
                            //TODO: Na hora de obter o valor do trimestre não estava obtendo quando a celula estava nula.
                            //Pra resolver tive que colocar o tipo, pelo menos nas celulas dos trimestres.
                            foreach (IXLCell cell in cells)
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = Convert.ToString(cell.Value);
                                i++;
                            }
                        }
                    }

                }

                return dt;
            }
        }
    }
}
