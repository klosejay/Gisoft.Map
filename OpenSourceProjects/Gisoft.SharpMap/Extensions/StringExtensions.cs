using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        public static int CultureAwareCompare(this string strA, string strB)
        {
            return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB,
                CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase);
        }
        public static string Convert2UTF8(this string str)
        {
            string result = str;
            byte[] stcBytes = Encoding.Default.GetBytes(result);
            byte[] utf8Bytes = Encoding.Convert(Encoding.Default, Encoding.UTF8, stcBytes);
            result = Encoding.UTF8.GetString(utf8Bytes);
            return result;
        }
    }
}
