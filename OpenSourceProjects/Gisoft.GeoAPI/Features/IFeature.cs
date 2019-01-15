using Gisoft.GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.GeoAPI.Features
{
    public interface IFeature
    {
        IGeometry Geometry { get; set; }

        Envelope Extent { get; set; }
    }
}
