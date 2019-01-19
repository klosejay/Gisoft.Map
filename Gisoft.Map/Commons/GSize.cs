using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    /// <summary>
    /// 尺寸
    /// </summary>
    public struct GSize
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public double Width;

        /// <summary>
        /// 高度
        /// </summary>
        public double Height;

        /// <summary>
        /// 创建一个尺寸
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public GSize(double width, double height)
        {
            Width = width;
            Height = height;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static GSize operator +(GSize size1, GSize size2)
        {
            return new GSize(size1.Width + size2.Width, size1.Height + size2.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static GSize operator -(GSize size1, GSize size2)
        {
            return new GSize(size1.Width - size2.Width, size1.Height - size2.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static bool operator >(GSize size1, GSize size2)
        {
            return size1.Area > size2.Area;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static bool operator <(GSize size1, GSize size2)
        {
            return size1.Area < size2.Area;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static bool operator ==(GSize size1, GSize size2)
        {
            return size1.Width == size2.Width && size1.Height == size2.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static bool operator !=(GSize size1, GSize size2)
        {
            return !(size1 == size2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static bool operator >=(GSize size1, GSize size2)
        {
            return size1.Area >= size2.Area;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        /// <returns></returns>
        public static bool operator <=(GSize size1, GSize size2)
        {
            return size1.Area <= size2.Area;
        }

        /// <summary>
        /// 是否为同一个
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            return (this.GetHashCode() == obj.GetHashCode()) ? true : false;
        }

        /// <summary>
        /// 值是否相等
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool Equals(GSize size)
        {
            return size == this;
        }
        /// <summary>
        /// 返回实例的哈希值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// 面积
        /// </summary>
        public double Area
        {
            get
            {
                return Math.Pow((Math.Pow(Width, 2) + Math.Pow(Height, 2)), 0.5);
            }
        }
        /// <summary>
        /// 返回该实例的字符串表达
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Width:");
            sb.Append(Width.ToString("f5"));
            sb.Append(",");
            sb.Append("Height:");
            sb.Append(Height.ToString("f5"));
            return sb.ToString();
        }
    }
}
