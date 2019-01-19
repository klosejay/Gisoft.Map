using Gisoft.GeoAPI.CoordinateSystems;
using Gisoft.SharpMap.Data.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.SharpMap.Data
{
    public class DataSetDescript
    {
        /// <summary>
        /// 数据集名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 数据集类型   
        /// </summary>
        public DataSetType DataSetType { get; set; }

        public ICoordinateSystem CoordinateSystem { get; set; }
        /// <summary>
        /// 表头
        /// </summary>
        public AttributesHead Fields { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// 数据集类型
    /// </summary>
    public enum DataSetType
    {
        /// <summary>
        /// 点
        /// </summary>
        Point = 0,
        /// <summary>
        /// 线
        /// </summary>
        Line = 1,
        /// <summary>
        /// 多边形
        /// </summary>
        Polygon = 2,
        /// <summary>
        /// 文字
        /// </summary>
        Text = 3,

        //Multi=4,

        /// <summary>
        /// 图像
        /// </summary>
        Raster = 5,
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 6,
    }
}
