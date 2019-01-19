using System;
using System.Collections.Generic;
using System.Text;

namespace Gisoft.Map
{
    /// <summary>
    /// 度分秒形式的角度
    /// </summary>
    public struct DegreeMS
    {
        /// <summary>
        /// 度
        /// </summary>
        public int Degree;
        /// <summary>
        /// 分
        /// </summary>
        public int Minute;
        /// <summary>
        /// 秒
        /// </summary>
        public double Second;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        public DegreeMS(int degree, int minute, double second)
        {
            Degree = degree;
            Minute = minute;
            Second = second;
        }

        /// <summary>
        /// 0度
        /// </summary>
        public static DegreeMS Zero
        {
            get { return new DegreeMS(0, 0, 0); }
        }
        /// <summary>
        /// 从弧度创建角度
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static DegreeMS FromRadian(double radian)
        {
            return (radian / Math.PI) * 180.0;
        }

        /// <summary>
        /// 转为弧度
        /// </summary>
        /// <returns></returns>
        public double ToRandian()
        {
            return (((double)this) / 180.0) * Math.PI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degree"></param>
        public static implicit operator DegreeMS(double degree)
        {
            DegreeMS degreeMS;
            degreeMS.Degree = Convert.ToInt16(Math.Truncate(degree));
            degree = degree - degreeMS.Degree;
            degreeMS.Minute = Convert.ToInt16(Math.Truncate(degree * 60.0));
            degree = degree - degreeMS.Minute;
            degreeMS.Second = degree * 60.0;
            return degreeMS;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="degreeMS"></param>
        public static implicit operator double(DegreeMS degreeMS)
        {
            double degree = 0;
            degree += degreeMS.Degree;
            degree += (degreeMS.Minute / 60.0);
            degree += (degreeMS.Second / 3600.0);
            return degree;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static DegreeMS operator +(DegreeMS d1, DegreeMS d2)
        {
            double degree = (double)d1 + (double)d2;
            return (DegreeMS)degree;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static DegreeMS operator -(DegreeMS d1, DegreeMS d2)
        {
            double degree = (double)d1 - (double)d2;
            return (DegreeMS)degree;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator >(DegreeMS d1, DegreeMS d2)
        {
            return (((double)d1) > ((double)d2)) ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator <(DegreeMS d1, DegreeMS d2)
        {
            return (((double)d1) < ((double)d2)) ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator ==(DegreeMS d1, DegreeMS d2)
        {
            return (((double)d1) == ((double)d2)) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator !=(DegreeMS d1, DegreeMS d2)
        {
            return (((double)d1) != ((double)d2)) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator >=(DegreeMS d1, DegreeMS d2)
        {
            return (((double)d1) >= ((double)d2)) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator <=(DegreeMS d1, DegreeMS d2)
        {
            return (((double)d1) <= ((double)d2)) ? true : false;
        }

        /// <summary>
        /// 转为字符串表达
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.Degree.ToString());
            stringBuilder.Append("°");
            stringBuilder.Append(this.Minute.ToString());
            stringBuilder.Append("′");
            stringBuilder.Append(this.Second.ToString("f2"));
            stringBuilder.Append("″");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Degree ^ Minute ^ (Second.GetHashCode());
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
        /// <param name="degreeMS"></param>
        /// <returns></returns>
        public bool Equals(DegreeMS degreeMS)
        {
            return degreeMS == this;
        }
    }
}
