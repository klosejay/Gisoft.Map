using Gisoft.GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public interface IExtentItem
    {
        Envelope Extent { get; set; }
    }
}
