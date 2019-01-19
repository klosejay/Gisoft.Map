using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public interface IGList<T>:IList<T>
    {
        void AddRange(IEnumerable<T> range);
        event ListChangedEventHandle<T> OnListChanged;
        event ListChangedEventHandle<T> OnListChanging;
    }
}
