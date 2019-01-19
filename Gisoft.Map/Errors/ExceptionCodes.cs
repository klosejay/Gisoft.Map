using System;
using System.Collections.Generic;
using System.Text;

namespace Gisoft.Map
{
    public class ExceptionCodes
    {
        /* 
         * 0开头
         * 
         * */
        #region 通用错误
        /// <summary>
        /// 表示子项已存在于一个容器中
        /// </summary>
        public const string ItemParentExistsCode = "00001";
        #endregion

        /*
         * 1开头
         * 
         * */
        #region 几何错误

        /// <summary>
        /// 不支持的几何图形
        /// </summary>
        public const string GeometryNotSupport = "10001";

        #endregion

        /*
         * 
         * 
         * */
        #region IO相关错误
        
        #endregion

        /*
         * 3开头
         * 
         * */
        #region 坐标系统错误

        /// <summary>
        /// 需要用到坐标系统的时候，坐标系统未定义
        /// </summary>
        public const string CoordinateSystemNotDefinedCode = "30001";

        #endregion
    }
}
