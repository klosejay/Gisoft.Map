using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public interface IContainerItem<T> where T:IContainerItem<T>
    {
        IGContainer<T> Parent { get; set; }
    }
}
