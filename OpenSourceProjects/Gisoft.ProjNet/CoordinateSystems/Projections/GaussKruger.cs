using Gisoft.GeoAPI.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.ProjNet.CoordinateSystems.Projections
{
    internal class GaussKruger:TransverseMercator
    {
        public GaussKruger(IEnumerable<ProjectionParameter> parameters):base(parameters)
        {
            Name = "Gauss_Kruger";
        }
    }
}
