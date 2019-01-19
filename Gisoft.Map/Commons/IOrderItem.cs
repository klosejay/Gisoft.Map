using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    /// <summary>
    /// 有顺序的元素
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// 序列
        /// </summary>
        int Index { get; set; }

    }
}
