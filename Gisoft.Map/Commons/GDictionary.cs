using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.Commons
{
    public class GDictionary<Tkey, TValue> :IDictionary<Tkey,TValue>
    {
        private Dictionary<Tkey, TValue> _pairs;
        public GDictionary()
        {
            _pairs = new Dictionary<Tkey, TValue>();
        }

        public TValue this[Tkey key] { get => _pairs[key]; set => _pairs[key]=value; }

        public ICollection<Tkey> Keys => _pairs.Keys;

        public ICollection<TValue> Values => _pairs.Values;

        public int Count => _pairs.Count;

        public bool IsReadOnly => false;

        public void Add(Tkey key, TValue value)
        {
            ((IDictionary<Tkey, TValue>)_pairs).Add(key,value);
            DictionaryChanged?.Invoke(this, new DictionaryChangedEventArgs<Tkey, TValue>()
            {
                Action = DictionaryChangedType.Add,
                Item = new KeyValuePair<Tkey, TValue>(key,value),
            });
        }

        public void Add(KeyValuePair<Tkey, TValue> item)
        {
            ((IDictionary<Tkey,TValue>)_pairs).Add(item);
            DictionaryChanged?.Invoke(this, new DictionaryChangedEventArgs<Tkey, TValue>()
            {
                Action = DictionaryChangedType.Add,
                Item = item,
            });
        }

        public void Clear()
        {
            var dc = new Dictionary<Tkey, TValue>(_pairs);
            foreach(var item in dc)
            {
                _pairs.Remove(item.Key);
            }
        }

        public bool Contains(KeyValuePair<Tkey, TValue> item)
        {
            return _pairs.Contains(item);
        }

        public bool ContainsKey(Tkey key)
        {
            return _pairs.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<Tkey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            return _pairs.GetEnumerator();
        }

        public bool Remove(Tkey key)
        {
            var args= new DictionaryChangedEventArgs<Tkey, TValue>()
            {
                Action = DictionaryChangedType.Remove,
                Item = new KeyValuePair<Tkey, TValue>(key,_pairs[key]),
            };
            DictionaryChanged?.Invoke(this, args);
            var b = _pairs.Remove(key);
            return b;
        }

        public bool Remove(KeyValuePair<Tkey, TValue> item)
        {
            var b= ((IDictionary<Tkey, TValue>)_pairs).Remove(item);
            DictionaryChanged?.Invoke(this, new DictionaryChangedEventArgs<Tkey, TValue>()
            {
                Action = DictionaryChangedType.Remove,
                Item = item,
            });
            return b;
        }

        public bool TryGetValue(Tkey key, out TValue value)
        {
           return _pairs.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return _pairs.GetEnumerator();
        }

        public event DictionaryChangedEventHandler<Tkey, TValue> DictionaryChanged;
    }
    public delegate void DictionaryChangedEventHandler<TKey,TSource>(object sender, DictionaryChangedEventArgs<TKey,TSource> e);
    public class DictionaryChangedEventArgs
    {
        public DictionaryChangedType Action { get; set; }

        public KeyValuePair<object,object> Item { get; set; }
    }
    public class DictionaryChangedEventArgs<TKey, TSource> : DictionaryChangedEventArgs
    {
        public new KeyValuePair<TKey,TSource> Item { get; set; }
    }
    public enum DictionaryChangedType
    {
        Add=0,
        Modify=1,
        Remove=2,
    }
}
