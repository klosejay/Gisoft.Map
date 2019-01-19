using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public class GContainer<T>:GList<T>,IGContainer<T>
    {
        public GContainer()
        {
            this.OnListChanged += GContainer_OnListChanged;
        }

        private void GContainer_OnListChanged(GList<T> container, ListChangedEventArgs<T> args)
        {
        }

    }
}
