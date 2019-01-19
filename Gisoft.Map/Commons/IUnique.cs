using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    /// <summary>
    /// 具有唯一ID的元素
    /// </summary>
    public interface IUnique
    {
        /// <summary>
        /// 唯一序列号
        /// </summary>
        string ID { get; set; }
    }
}
