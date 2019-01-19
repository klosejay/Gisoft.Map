using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    /// <summary>
    /// 具有名称的元素
    /// </summary>
    public interface INameItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }
    }
}
