using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logisticsApp2
{
    public static class DataGridHelper
    {
        public static string GetValueFromDataGridView(DataGridView dataGridView, string columnVlaue)
        {
            try
            {
                DataGridViewRow row = dataGridView.CurrentCell.OwningRow;
                return row.Cells[columnVlaue].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return String.Empty;

            }
        }

    }
}
