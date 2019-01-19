using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.ToolBox
{
    /// <summary>
    /// 工具箱工具参数
    /// </summary>
    public class ToolBoxBaseArgs : IToolBoxBaseArgs
    {
        private bool _canConfirm = false;
        public bool CanConfirm
        {
            get => _canConfirm;
            set
            {
                _canConfirm = value; SendPropertyChangedEvent(nameof(CanConfirm));
            }
        }

        /// <summary>
        /// 触发改变事件
        /// </summary>
        /// <param name="name"></param>
        protected void SendPropertyChangedEvent(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// 属性改变
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
