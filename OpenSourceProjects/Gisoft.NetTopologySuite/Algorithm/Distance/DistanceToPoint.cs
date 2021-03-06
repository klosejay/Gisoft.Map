using Gisoft.GeoAPI.Geometries;
using Gisoft.NetTopologySuite.Geometries;

namespace Gisoft.NetTopologySuite.Algorithm.Distance
{
    ///<summary>
    /// Computes the Euclidean distance (L2 metric) from a <see cref="Coordinate"/> to a <see cref="IGeometry"/>.
    ///</summary>
    /// <remarks>
    /// Also computes two points on the geometry which are separated by the distance found.
    /// </remarks>
    public static class DistanceToPoint
    {
        ///<summary>
        /// Computes the Euclidean distance (L2 metric) from a <see cref="Coordinate"/> to a <see cref="IGeometry"/>.
        ///</summary>
        /// <param name="geom">The geometry</param>
        /// <param name="pt">The Point</param>
        /// <param name="ptDist">The <c>PointPairDistance</c></param>
        public static void ComputeDistance(IGeometry geom, Coordinate pt, PointPairDistance ptDist)
        {
            if (geom is ILineString)
            {
                ComputeDistance((ILineString) geom, pt, ptDist);
            }
            else if (geom is IPolygon)
            {
                ComputeDistance((IPolygon) geom, pt, ptDist);
            }
            else if (geom is IGeometryCollection)
            {
                var gc = (IGeometryCollection) geom;
                for (var i = 0; i < gc.NumGeometries; i++)
                {
                    var g = gc.GetGeometryN(i);
                    ComputeDistance(g, pt, ptDist);
                }
            }
            else
            {
                // assume geom is Point
                ptDist.SetMinimum(geom.Coordinate, pt);
            }
        }

        ///<summary>
        /// Computes the Euclidean distance (L2 metric) from a <see cref="Coordinate"/> to a <see cref="ILineString"/>.
        ///</summary>
        /// <param name="line">The <c>LineString</c></param>
        /// <param name="pt">The Point</param>
        /// <param name="ptDist">The <c>PointPairDistance</c></param>
        public static void ComputeDistance(ILineString line, Coordinate pt, PointPairDistance ptDist)
        {
            var coords = line.Coordinates;
            var tempSegment = new LineSegment();
            for (var i = 0; i < coords.Length - 1; i++)
            {
                tempSegment.SetCoordinates(coords[i], coords[i + 1]);
                // this is somewhat inefficient - could do better
                var closestPt = tempSegment.ClosestPoint(pt);
                ptDist.SetMinimum(closestPt, pt);
            }
        }

        ///<summary>
        /// Computes the Euclidean distance (L2 metric) from a <see cref="Coordinate"/> to a <see cref="LineSegment"/>.
        ///</summary>
        /// <param name="segment">The <c>LineSegment</c></param>
        /// <param name="pt">The Point</param>
        /// <param name="ptDist">The <c>PointPairDistance</c></param>
        public static void ComputeDistance(LineSegment segment, Coordinate pt, PointPairDistance ptDist)
        {
            var closestPt = segment.ClosestPoint(pt);
            ptDist.SetMinimum(closestPt, pt);
        }

        ///<summary>
        /// Computes the Euclidean distance (L2 metric) from a <see cref="Coordinate"/> to a <see cref="Polygon"/>.
        ///</summary>
        /// <param name="poly">The <c>Polygon</c></param>
        /// <param name="pt">The Point</param>
        /// <param name="ptDist">The <c>PointPairDistance</c></param>
        public static void ComputeDistance(IPolygon poly, Coordinate pt, PointPairDistance ptDist)
        {
            ComputeDistance(poly.ExteriorRing, pt, ptDist);
            for (var i = 0; i < poly.NumInteriorRings; i++)
            {
                ComputeDistance(poly.GetInteriorRingN(i), pt, ptDist);
            }
        }
    }
}