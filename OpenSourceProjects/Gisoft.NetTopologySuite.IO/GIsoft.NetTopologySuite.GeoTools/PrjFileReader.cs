using Gisoft.GeoAPI.CoordinateSystems;
using Gisoft.ProjNet.Converters.WellKnownText;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.NetTopologySuite.IO
{
    public class PrjFileReader
    {
        public static ICoordinateSystem Read(string fileName, Encoding encoding = null)
        {
            string csStr = encoding == null ? File.ReadAllText(fileName, Encoding.Default) : File.ReadAllText(fileName, encoding);
            var cs = (encoding == null ? CoordinateSystemWktReader.Parse(csStr, Encoding.Default) : CoordinateSystemWktReader.Parse(csStr, encoding)) as ICoordinateSystem;
            return cs;
        }

    }
}
