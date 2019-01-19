using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    /// <summary>
    /// 拥有固有描述字符串的元素
    /// </summary>
    public interface IInherentDescriptionItem
    {
        /// <summary>
        /// 固有元素描述
        /// </summary>
        string Description { get; }
    }

    public interface IDescriptionItem
    {
        string Description { get; set; }
    }
}
