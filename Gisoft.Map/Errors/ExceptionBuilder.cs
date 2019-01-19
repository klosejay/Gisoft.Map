using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.Errors
{
    internal static class ExceptionBuilder
    {
        private static void TraceException(string trace, Exception e)
        {
            Debug.Assert(null != e, "TraceException: null Exception");
            if (e != null)
            {
                Gisoft.Map.Commons.GLogs.Instance.Error(trace, e.Message);
            }
        }
        internal static Exception TraceExceptionWithoutRethrow(Exception e)
        {
            TraceException("<comm.ADP.TraceException|ERR|CATCH> '{0}'", e);
            return e;
        }
        public static Exception InvalidStorageType(TypeCode typecode) => new Exception(typecode.ToString());
    }
}
