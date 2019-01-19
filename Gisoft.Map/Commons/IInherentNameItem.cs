using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    /// <summary>
    /// 具有固有名称的元素
    /// </summary>
    public interface IInherentNameItem
    {
        /// <summary>
        /// 固有名称
        /// </summary>
        string Name { get;}
    }
}
