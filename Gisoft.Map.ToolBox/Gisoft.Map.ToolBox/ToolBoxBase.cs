using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.ToolBox
{
    /// <summary>
    /// 工具箱工具基类
    /// </summary>
    public abstract class ToolBoxBase: ProcessTaskBase, IToolBoxBase
    {
        /// <summary>
        /// 工具名
        /// </summary>
        public abstract string Name { get;}
        /// <summary>
        /// 工具参数
        /// </summary>
        public IToolBoxBaseArgs Args { get; set; }

        protected DateTime InitTime { get; } = DateTime.Now;

        /// <summary>
        /// 任务ID
        /// </summary>
        public override string TaskId => Name+InitTime.ToFileTimeUtc().ToString();

        
        protected void SendProgressMessage(int percent, string message)
        {
            SendProgressMessage(TaskId, percent, message);
        }
    }

    public abstract class ToolBoxBase<T>:ToolBoxBase,IToolBoxBase where T : class, IToolBoxBaseArgs,new()
    {
        public ToolBoxBase()
        {
            Args = new T();
        }
        public new T Args { get => base.Args as T; set => base.Args = value; }

    }
}
