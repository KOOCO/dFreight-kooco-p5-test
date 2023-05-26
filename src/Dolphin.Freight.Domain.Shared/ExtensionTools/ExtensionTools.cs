using System;

namespace Dolphin.Freight.ExtensionTools
{
    public static class ExtensionTools
    {

        #region DataRow 欄位操作

        /// <summary>
        /// 自動判別該欄位是否存在，不存在直接回傳 null，存在則運行原有的.ToString()
        /// </summary>
        /// <param name="columnName">欄位名稱</param>
        /// <returns></returns>
        public static string ToStringFromColumnName(this System.Data.DataRow source, string columnName, bool emptyToNull = false)
        {

            if (source == null) return null;
            if (columnName == null) return null;

            string ans = source.Table.Columns.Contains(columnName) ? source[columnName]?.ToString() : null;
            if (emptyToNull) ans = ans.EmptyToNull();

            return ans;

        }

        #endregion

    }
}
