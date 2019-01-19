using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.ToolBox
{
    /// <summary>
    /// 工具箱基类
    /// </summary>
    public interface IToolBoxBase:IProcessTask,IInherentNameItem
    {
        

        /// <summary>
        /// 工具参数
        /// </summary>
        IToolBoxBaseArgs Args { get; set; }


    }
}
