using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public class GNotifyCollection<T> : ObservableCollection<T> where T:INotifyPropertyChanged
    {
        public GNotifyCollection()
        {
            
        }
        protected override void ClearItems()
        {
            foreach(var item in this)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
            base.ClearItems();
        }
        protected override void RemoveItem(int index)
        {
            this[index].PropertyChanged -= Item_PropertyChanged;
            base.RemoveItem(index);
        }

        protected override void InsertItem(int index, T item)
        {
            item.PropertyChanged += Item_PropertyChanged;
            base.InsertItem(index, item);
        }
        protected override void SetItem(int index, T item)
        {
            this[index].PropertyChanged -= Item_PropertyChanged;
            base.SetItem(index, item);
            item.PropertyChanged += Item_PropertyChanged;
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(sender, e);
        }

        public event PropertyChangedEventHandler ItemPropertyChanged;
    }
}
