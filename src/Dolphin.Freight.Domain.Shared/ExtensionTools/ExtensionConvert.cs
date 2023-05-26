using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dolphin.Freight.ExtensionTools
{
    public static class ExtensionConvert
    {

        #region 轉成陣列

        public static string[] ConvertToStringArray(this string source, string separator)
        {
            if (string.IsNullOrEmpty(source))
            {
                return new string[0];
            }

            return source.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        }

        #endregion

        #region DataSet 轉換為 Excel 的 byte[]

        public static byte[] ConvertToExcelByteArray(this DataSet source)
        {
            byte[] result = null;

            using (var ms = new MemoryStream())
            {
                NPOI.SS.UserModel.IWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(); // 2007

                for (int i = 0; i < source.Tables.Count; i++)
                {
                    NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet(source.Tables[i].TableName);

                    NPOI.SS.UserModel.IRow headerRow = sheet.CreateRow(0);
                    for (int j = 0; j < source.Tables[i].Columns.Count; j++)
                    {
                        headerRow.CreateCell(j).SetCellValue(source.Tables[i].Columns[j].ColumnName);
                    }

                    for (int k = 0; k < source.Tables[i].Rows.Count; k++)
                    {
                        NPOI.SS.UserModel.IRow row = sheet.CreateRow(k + 1);
                        for (int l = 0; l < source.Tables[i].Columns.Count; l++)
                        {
                            row.CreateCell(l).SetCellValue(source.Tables[i].Rows[k][l].ToString());
                        }
                    }
                }

                workbook.Write(ms, false);
                result = ms.ToArray();
            }

            return result;
        }

        #endregion

        #region DataTable 轉換成正常 Class 的 List<T>

        /// <summary>
        /// 將資料轉換到一般常用的資料模型
        /// </summary>
        /// <remarks>請注意大小寫</remarks>
        /// <returns></returns>
        public static List<T> ToModelList<T>(this DataTable dataTable) where T : new()
        {
            List<T> models = new();

            foreach (DataRow row in dataTable.Rows)
            {
                T model = new();

                foreach (DataColumn column in dataTable.Columns)
                {
                    string columnName = column.ColumnName;
                    PropertyInfo property = typeof(T).GetProperty(columnName);

                    if (property != null && row[columnName] != DBNull.Value)
                    {
                        object value = row[columnName];
                        property.SetValue(model, value);
                    }
                }

                models.Add(model);
            }

            return models;
        }

        #endregion

        #region DataTable 轉換成 List<String>

        /// <summary>
        /// 將 DataTable 的第一個欄位或指定欄位放入 List<string>
        /// </summary>
        /// <param name="columnName">指定的欄位名稱</param>
        /// <returns></returns>
        public static List<string> ToStringList(this DataTable dataTable, string columnName = null)
        {
            List<string> objs = new();

            if (dataTable.Columns.Count == 0) return objs;

            DataColumn dataColumn = dataTable.Columns[0];
            if (columnName != null)
                dataColumn = dataTable.Columns[columnName];

            foreach (DataRow row in dataTable.Rows)
                objs.Add(row[dataColumn].ToString());
            
            return objs;
        }

        #endregion


    }
}
