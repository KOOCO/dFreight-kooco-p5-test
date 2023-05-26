using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.ExtensionTools
{
    public static class ExtensionStrings
    {

        #region 自動將字串中右方數字 +1

        /// <summary>
        /// 自動將字串中右方數字 +1，若為 99...99 則變成 00...00<br />
        /// 若 <paramref name="numDigits"/> 為負數則自動抓取位數
        /// </summary>
        /// <param name="numDigits">設定要轉換的數字有幾位數，負數則自動</param>
        /// <returns></returns>
        public static string Increment(this string source, int numDigits = -1)
        {

            if (numDigits < 0)
            {
                numDigits = 0;
                for (int i = source.Length - 1; i >= 0; i--)
                {
                    if (Char.IsDigit(source[i]))
                    {
                        numDigits++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // 無數字或為負值則回傳原本的字串
            if (numDigits <= 0) return source;

            string pattern = new string('9', numDigits); // 產生與數字位數相同的9字串
            System.Numerics.BigInteger num = System.Numerics.BigInteger.Parse(source.Substring(source.Length - numDigits, numDigits)) + 1;
            if (num > System.Numerics.BigInteger.Parse(pattern))
            {
                num = 0;
            }

            return String.Format("{0}{1:D" + numDigits + "}", source.Substring(0, source.Length - numDigits), num);
        }

        #endregion

        #region 空字串轉換為 Null

        /// <summary>
        /// 若為空字串則轉換為 Null
        /// </summary>
        /// <returns></returns>
        public static string EmptyToNull(this string source)
        {
            return source == "" ? null : source;
        }

        #endregion

    }
}
