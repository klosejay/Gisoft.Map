using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Gisoft.Map.Languages
{
    public class ExceptionDescriptions
    {
        public static CultureInfo CurrentCultrue = Thread.CurrentThread.CurrentCulture;
        public static string ItemParentExistsDescription
        {
            get
            {
                string value = "";
                switch (CurrentCultrue.Name.ToLower())
                {
                    case "zh-cn":
                        value = "元素已存在其他父容器中";
                        break;
                    case "es-bo":
                    case "en-us":
                        value = "Item's parent is exists";
                        break;
                }
                return value;
            }
        }
    }
}
