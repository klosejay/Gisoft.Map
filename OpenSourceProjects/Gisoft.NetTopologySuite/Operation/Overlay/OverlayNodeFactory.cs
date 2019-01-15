using Gisoft.GeoAPI.Geometries;
using Gisoft.NetTopologySuite.GeometriesGraph;

namespace Gisoft.NetTopologySuite.Operation.Overlay
{
    /// <summary>
    /// Creates nodes for use in the <c>PlanarGraph</c>s constructed during
    /// overlay operations.
    /// </summary>
    public class OverlayNodeFactory : NodeFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public override Node CreateNode(Coordinate coord)
        {
            return new Node(coord, new DirectedEdgeStar());
        }
    }
}
