using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace logisticsApp2.data_access_layer
{
    internal class excel_open
    {
       
        string path = @"Localhost\\Documents\\gestion logistique\\planification.xlsx\";
         _Application excell = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public excel_open(string path, int sheet)
        {
            this.path = path;
            wb = excell.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }
        public string readcells(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].value != null)
            {
                return ws.Cells[i, j].value;
            }
            else return " ";
        }
    }
}
