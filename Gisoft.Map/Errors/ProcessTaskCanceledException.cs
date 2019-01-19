using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.Errors
{
    public class ProcessTaskCanceledException : GException
    {
        public ProcessTaskCanceledException(string code, string description) : base(code, description)
        {
        }
        public ProcessTaskCanceledException() : base("30001", "任务已取消")
        {

        }
    }
    public class ProcessTaskErrorException : GException
    {
        public ProcessTaskErrorException(string code, string description) : base(code, description)
        {
        }
    }
}
