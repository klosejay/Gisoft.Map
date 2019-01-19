using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public class ShallowCopy : Attribute
    {
    }
    public class CopyBase:ICloneable
    {
        protected CopyBase()
        {
        }

        object ICloneable.Clone()
        {
            var copy = MemberwiseClone() as CopyBase;

            OnCopy(copy);
            return copy;
        }

        protected static PropertyInfo[] DistinctNames(IEnumerable<PropertyInfo> allProperties)
        {
            List<string> names = new List<string>();
            List<PropertyInfo> result = new List<PropertyInfo>();
            foreach (PropertyInfo property in allProperties)
            {
                if (names.Contains(property.Name)) continue;
                result.Add(property);
                names.Add(property.Name);
            }

            return result.ToArray();
        }

        protected virtual void OnCopy(CopyBase copy)
        {
            // This checks any property on copy, and if it is cloneable, it
            // creates a clone instead
            Type copyType = copy.GetType();

            PropertyInfo[] copyProperties = DistinctNames(copyType.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            PropertyInfo[] myProperties = DistinctNames(GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance));
            foreach (PropertyInfo p in copyProperties)
            {
                if (p.CanWrite == false) continue;
                if (myProperties.Contains(p.Name) == false) continue;
                PropertyInfo myProperty = myProperties.GetFirst(p.Name);
                object myValue = myProperty.GetValue(this, null);
                if (myProperty.GetCustomAttributes(typeof(ShallowCopy), true).Length > 0)
                {
                    // This property is marked as shallow, so skip cloning it
                    continue;
                }

                ICloneable cloneable = myValue as ICloneable;
                if (cloneable == null) continue;
                p.SetValue(copy, cloneable.Clone(), null);
            }

            FieldInfo[] copyFields = copyType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] myFields = GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo f in copyFields)
            {
                if (myFields.Contains(f.Name) == false) continue;
                FieldInfo myField = myFields.GetFirst(f.Name);
                object myValue = myField.GetValue(copy);

                if (myField.GetCustomAttributes(typeof(ShallowCopy), true).Length > 0)
                {
                    // This field is marked as shallow, so skip cloning it
                    continue;
                }

                ICloneable cloneable = myValue as ICloneable;
                if (cloneable == null) continue;
                f.SetValue(copy, cloneable.Clone());
            }
        }
    }
    internal static class MemberInfoExtensions
    {
        public static bool Contains(this IEnumerable<MemberInfo> self, string name)
        {
            return self.Any(info => info.Name == name);
        }

        public static T GetFirst<T>(this IEnumerable<T> self, string name)
            where T : MemberInfo
        {
            Func<T, bool> criteria = current => (current.Name == name);
            return self.First(criteria);
        }
    }
}
