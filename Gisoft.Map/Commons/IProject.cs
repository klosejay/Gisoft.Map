using Gisoft.GeoAPI.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public interface IProject
    {
        ICoordinateSystem CoordinateSystem { get; set; }

        void Reproject(ICoordinateSystem toCoordinateSystem);
    }
}
