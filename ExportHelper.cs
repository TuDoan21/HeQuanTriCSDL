using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_SuKienHoiNghi
{
    public static class ExportHelper
    {
        public static void ExportToExcelCSV(DataTable dt, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName);
                    if (i < dt.Columns.Count - 1)
                        sw.Write(",");
                }
                sw.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string value = row[i].ToString().Replace(",", " ");
                        sw.Write(value);
                        if (i < dt.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();
                }
            }
        }

        public static void ExportToPDFSimple(DataTable dt, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine("========= BÁO CÁO THỐNG KÊ =========");
                sw.WriteLine("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy"));
                sw.WriteLine("");

                foreach (DataColumn col in dt.Columns)
                    sw.Write(col.ColumnName + "\t");
                sw.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                        sw.Write(item.ToString() + "\t");
                    sw.WriteLine();
                }

                sw.WriteLine("=====================================");
                sw.WriteLine("            KẾT THÚC BÁO CÁO         ");
            }
        }
    }
}
