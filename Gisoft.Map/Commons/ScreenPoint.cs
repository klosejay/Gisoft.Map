using System;
using System.Collections.Generic;
using System.Text;

namespace Gisoft.Map
{
    /// <summary>
    /// 屏幕坐标
    /// </summary>
    public struct ScreenPoint
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public double X;

        /// <summary>
        /// Y坐标
        /// </summary>
        public double Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ScreenPoint(double x=0,double y = 0)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("X:");
            stringBuilder.Append(X.ToString("f2"));
            stringBuilder.Append(",");
            stringBuilder.Append("Y:");
            stringBuilder.Append(Y.ToString("f2"));
            return stringBuilder.ToString();
        }
        public static ScreenPoint operator +(ScreenPoint p1,ScreenPoint p2)
        {
            return new ScreenPoint(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static ScreenPoint operator -(ScreenPoint p1, ScreenPoint p2)
        {
            return new ScreenPoint(p1.X - p2.X, p1.Y - p2.Y);
        }

        public int CompareTo(ScreenPoint point)
        {
            if (X > point.X) return 1;
            if (X < point.X) return -1;
            if (Y > point.Y) return 1;
            if (Y < point.Y) return -1;
            return 0;
        }
        public static ScreenPoint NaNPoint
        {
            get
            {
                return new ScreenPoint(double.NaN, double.NaN);
            }
        }
        public static bool IsNaN(ScreenPoint point)
        {
            return double.IsNaN(point.X) && double.IsNaN(point.Y);
        }
    }
}
