using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.SharpMap.Data.Attributes
{
    public class AttributesField : IAttributesField
    {

        public AttributesField()
        {

        }
        public AttributesField(string name, FieldType fieldType, int length, int decimalLength,string displayName)
        {
            Name = name;
            DisplayName = displayName;
            Length = length;
            DecimalLength = DecimalLength;
            FieldType = fieldType;
        }

        public AttributesField(string name, FieldType fieldType, int length, int decimalLength) :
            this(name, fieldType, length, decimalLength,string.Empty)
        { }
        public AttributesField(string name, FieldType fieldType, int length, string displayName) :
            this(name, fieldType, length, 0, displayName)
        { }
        public AttributesField(string name, FieldType fieldType, int length) :
            this(name, fieldType, length, 0)
        { }
        public AttributesField(string name,FieldType fieldType):
            this(name, fieldType, 0)
        { }

        public string Name { get; set; }
        public string DisplayName { get; set; }

        public int Length { get; set; }

        public int DecimalLength { get; set; }

        public FieldType FieldType { get; set; }
        public bool NotNull { get; set; } = false;

        public object GetDefaultObject()
        {
            switch (FieldType)
            {
                case FieldType.Bool:
                    return new bool();
                case FieldType.Char:
                    return string.Empty;
                case FieldType.DateTime:
                    return DateTime.MinValue;
                case FieldType.Int:
                    return new int();
                case FieldType.Long:
                    return new long();
                case FieldType.Float:
                    return new float();
                case FieldType.Double:
                    return new double();
                default:
                    throw new NotSupportedException("不支持的字段类型");
            }
        }
        public static Type GetFieldType(FieldType fieldType)
        {
            switch (fieldType)
            {
                case FieldType.Bool:
                    return typeof(bool);
                case FieldType.Char:
                    return typeof(string);
                case FieldType.DateTime:
                    return typeof(DateTime);
                case FieldType.Int:
                    return typeof(int);
                case FieldType.Long:
                    return typeof(long);
                case FieldType.Float:
                    return typeof(float);
                case FieldType.Double:
                    return typeof(double);
                case FieldType.Decimal:
                    return typeof(decimal);
                case FieldType.Varbin:
                    return typeof(string);
                default:
                    throw new NotSupportedException("不支持的字段类型");
            }
        }

        internal Type GetDataType()
        {
            return GetFieldType(FieldType);
        }

        public override string ToString()
        {
            return Name;
        }
    }




}
