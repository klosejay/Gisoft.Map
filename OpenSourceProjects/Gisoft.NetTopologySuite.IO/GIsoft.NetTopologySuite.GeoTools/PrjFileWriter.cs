using Gisoft.GeoAPI.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.NetTopologySuite.IO
{
    public class PrjFileWriter
    {
        public static void Write(string fileName,ICoordinateSystem coordinateSystem,Encoding encoding = null)
        {
            string prjStr = coordinateSystem.WKT;
            File.WriteAllText(fileName, prjStr);
            //File.WriteAllLines(fileName, new string[] { prjStr });
        }
    }
}
