using Gisoft.NetTopologySuite.Features;
using Gisoft.NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.SharpMap.Data.Attributes
{
    public class AttributesHead : ObservableCollection<IAttributesField>
    {
        public string TableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public AttributesHead()
        {
            //this.OnListChanging += AttributesHead_OnListChanging;
        }

        //private void AttributesHead_OnListChanging(GList<IAttributesField> container, ListChangedEventArgs<IAttributesField> args)
        //{
        //    switch (args.ChangedType)
        //    {
        //        case ListChangedType.Add:
        //            if (FindField(args.Item.Name) != null)
        //            {
        //                AllowChange = false;
        //                throw new GException("已有同名字段");
        //            }
        //            break;
        //    }
        //}
        public IAttributesField this[string fieldName]
        {
            get
            {
                return FindField(fieldName);
            }
        }
        public IAttributesField FindField(string fieldName)
        {
            var q = (from t in this
                     where t.Name == fieldName
                     select t);
            if (q.Count() > 0)
            {
                return q.First();
            }
            else
            {
                return null;
            }
        }

        public IAttributesTable GetDefaultData()
        {
            var data = new AttributesTable();
            foreach (var item in this)
            {
                data.Add(item.Name, item.GetDefaultObject());
            }
            return data;
        }
    }
}
