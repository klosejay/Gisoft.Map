using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.SharpMap.Data.Attributes
{
    public interface IAttributesField
    {
        string Name { get; set; }

        int Length { get; set; }

        int DecimalLength { get; set; }

        FieldType FieldType { get; set; }

        object GetDefaultObject();

        bool NotNull { get; set; }

    }

    public static class IAttributesFieldListExtensions
    {
        public static IAttributesField GetField(this IEnumerable<IAttributesField> fields,string fieldName)
        {
            foreach(var item in fields)
            {
                if (item.Name.CultureAwareCompare(fieldName)==0)
                {
                    return item;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// 字段类型
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        /// 文字(最长255）
        /// </summary>
        Char=0,
        /// <summary>
        /// 
        /// </summary>
        Bool=1,
        /// <summary>
        /// 
        /// </summary>
        Int=2,
        /// <summary>
        /// 
        /// </summary>
        Long=3,
        /// <summary>
        /// 
        /// </summary>
        DateTime=4,
        /// <summary>
        /// 
        /// </summary>
        Float=5,
        /// <summary>
        /// 
        /// </summary>
        Double=6,
        /// <summary>
        /// 
        /// </summary>
        Decimal=7,
        /// <summary>
        /// 
        /// </summary>
        Varbin=8,
    }
}
