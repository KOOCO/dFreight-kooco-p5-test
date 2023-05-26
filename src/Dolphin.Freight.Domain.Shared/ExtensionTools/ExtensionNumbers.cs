using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.ExtensionTools
{
    public static class ExtensionNumbers
    {

        #region 數字轉換、計算

        public static decimal ZeroToMax(this decimal source)
        {
            return source == 0 ? decimal.MaxValue : source;
        }

        public static decimal ZeroToMax(this decimal? source)
        {
            decimal temp = source.GetValueOrDefault(0);
            return temp == 0 ? decimal.MaxValue : temp;
        }

        #endregion

        #region 數字判斷

        public static bool IsNull(this decimal? source)
        {
            return source == null;
        }

        #endregion

    }
}
