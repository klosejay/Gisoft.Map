using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gisoft.Map
{
    public class GList<T> : IGList<T>
    {
        protected List<T> MyList;
        public event ListChangedEventHandle<T> OnListChanged;
        public event ListChangedEventHandle<T> OnListChanging;
        public bool AllowChange = true;
        public GList()
        {
            MyList = new List<T>();
            OnListChanged += CList_OnListChanged;
        }

        private void CList_OnListChanged(GList<T> container, ListChangedEventArgs<T> args)
        {
            if (args.ChangedType == ListChangedType.Add)
            {
                INotifyPropertyChanged obj = args.Item as INotifyPropertyChanged;
                if (obj != null)
                {
                    obj.PropertyChanged += T_PropertyChanged;
                }
            }
            else if (args.ChangedType == ListChangedType.Remove)
            {
                INotifyPropertyChanged obj = args.Item as INotifyPropertyChanged;
                if (obj != null)
                {
                    obj.PropertyChanged -= T_PropertyChanged;
                }
            }
        }

        private void T_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnListChanged?.Invoke(this, ListChangedEventArgs<T>.ModifyEventArgs((T)sender, e.PropertyName));
        }

        public virtual T this[int index] { get => MyList[index]; set => MyList[index] = value; }

        public virtual int Count => MyList.Count;

        public virtual bool IsReadOnly => false;

        public virtual void Add(T item)
        {
            OnListChanging?.Invoke(this, ListChangedEventArgs<T>.AddEventArgs(item));
            if (AllowChange)
            {
                MyList.Add(item);
                OnListChanged?.Invoke(this, ListChangedEventArgs<T>.AddEventArgs(item));
            }
            AllowChange = true;
        }

        public virtual void Clear()
        {
            List<T> list = new List<T>(MyList);
            foreach (var item in list)
            {
                Remove(item);
            }
        }

        public virtual bool Contains(T item)
        {
            return MyList.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            MyList.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return MyList.GetEnumerator();
        }

        public virtual int IndexOf(T item)
        {
            return MyList.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            OnListChanging?.Invoke(this, ListChangedEventArgs<T>.AddEventArgs(item));
            if (AllowChange)
            {
                MyList.Insert(index, item);
                OnListChanged?.Invoke(this, ListChangedEventArgs<T>.AddEventArgs(item));
            }
            AllowChange = true;
        }

        public virtual bool Remove(T item)
        {
            OnListChanging?.Invoke(this, ListChangedEventArgs<T>.RemoveEventArgs(item));
            if (AllowChange)
            {
                bool b = MyList.Remove(item);
                if (b)
                {
                    OnListChanged?.Invoke(this, ListChangedEventArgs<T>.RemoveEventArgs(item));
                }
                return b;
            }
            else
            {
                AllowChange = true;
                return false;
            }

        }

        public void RemoveAt(int index)
        {
            T item = MyList[index];
            OnListChanging?.Invoke(this, ListChangedEventArgs<T>.RemoveEventArgs(item));
            if (AllowChange)
            {
                MyList.RemoveAt(index);
                OnListChanged?.Invoke(this, ListChangedEventArgs<T>.RemoveEventArgs(item));
            }
            AllowChange = true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return MyList.GetEnumerator();
        }

        protected void SendModifyEvent(ListChangedEventArgs<T> args)
        {
            OnListChanged?.Invoke(this, args);
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                Add(item);
            }
        }
    }
    public delegate void ListChangedEventHandle<T>(GList<T> container, ListChangedEventArgs<T> args);

    public class ListChangedEventArgs<T> : EventArgs
    {
        public ListChangedType ChangedType { get; }

        public T Item { get; }

        public string ModifiedPropertyName { get; }

        public ListChangedEventArgs(ListChangedType changedType, T item)
        {
            ChangedType = changedType;
            Item = item;
        }
        public ListChangedEventArgs(ListChangedType changedType, T item, string propertyName)
        {
            ChangedType = changedType;
            Item = item;
            ModifiedPropertyName = propertyName;
        }
        public static ListChangedEventArgs<T> AddEventArgs(T item)
        {
            return new ListChangedEventArgs<T>(ListChangedType.Add, item);
        }
        public static ListChangedEventArgs<T> RemoveEventArgs(T item)
        {
            return new ListChangedEventArgs<T>(ListChangedType.Remove, item);
        }
        public static ListChangedEventArgs<T> ModifyEventArgs(T item, string propertyName)
        {
            return new ListChangedEventArgs<T>(ListChangedType.Modify, item, propertyName);
        }
    }
    public enum ListChangedType
    {
        Add,
        Remove,
        Modify,
    }


}
