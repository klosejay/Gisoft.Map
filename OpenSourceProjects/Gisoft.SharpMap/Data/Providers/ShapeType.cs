namespace Gisoft.SharpMap.Data.Providers
{
    /// <summary>
    /// Shapefile geometry type.
    /// </summary>
    public enum ShapeType
    {
        /// <summary>
        /// Null shape with no geometric data
        /// </summary>
        Null = 0,
        /// <summary>
        /// A point consists of a pair of double-precision coordinates.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.IPoint"/>
        /// </summary>
        Point = 1,
        /// <summary>
        /// PolyLine is an ordered set of vertices that consists of one or more parts. A part is a
        /// connected sequence of two or more points. Parts may or may not be connected to one
        ///	another. Parts may or may not intersect one another.
        /// Gisoft.SharpMap interprets this as either <see cref="Gisoft.GeoAPI.Geometries.ILineString"/> or <see cref="Gisoft.GeoAPI.Geometries.IMultiLineString"/>
        /// </summary>
        PolyLine = 3,
        /// <summary>
        /// A polygon consists of one or more rings. A ring is a connected sequence of four or more
        /// points that form a closed, non-self-intersecting loop. A polygon may contain multiple
        /// outer rings. The order of vertices or orientation for a ring indicates which side of the ring
        /// is the interior of the polygon. The neighborhood to the right of an observer walking along
        /// the ring in vertex order is the neighborhood inside the polygon. Vertices of rings defining
        /// holes in polygons are in a counterclockwise direction. Vertices for a single, ringed
        /// polygon are, therefore, always in clockwise order. The rings of a polygon are referred to
        /// as its parts.
        /// Gisoft.SharpMap interprets this as either <see cref="Gisoft.GeoAPI.Geometries.IPolygon"/> or <see cref="Gisoft.GeoAPI.Geometries.IMultiPolygon"/>
        /// </summary>
        Polygon = 5,
        /// <summary>
        /// A MultiPoint represents a set of points.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.IMultiPoint"/>
        /// </summary>
        Multipoint = 8,
        /// <summary>
        /// A PointZ consists of a triplet of double-precision coordinates plus a measure.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.IPoint"/>
        /// </summary>
        PointZ = 11,
        /// <summary>
        /// A PolyLineZ consists of one or more parts. A part is a connected sequence of two or
        /// more points. Parts may or may not be connected to one another. Parts may or may not
        /// intersect one another.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.ILineString"/> or <see cref="Gisoft.GeoAPI.Geometries.IMultiLineString"/>
        /// </summary>
        PolyLineZ = 13,
        /// <summary>
        /// A PolygonZ consists of a number of rings. A ring is a closed, non-self-intersecting loop.
        /// A PolygonZ may contain multiple outer rings. The rings of a PolygonZ are referred to as
        /// its parts.
        /// Gisoft.SharpMap interprets this as either <see cref="Gisoft.GeoAPI.Geometries.IPolygon"/> or <see cref="Gisoft.GeoAPI.Geometries.IMultiPolygon"/>
        /// </summary>
        PolygonZ = 15,
        /// <summary>
        /// A MultiPointZ represents a set of <see cref="PointZ"/>s.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.IMultiPoint"/>
        /// </summary>
        MultiPointZ = 18,
        /// <summary>
        /// A PointM consists of a pair of double-precision coordinates in the order X, Y, plus a measure M.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.IPoint"/>
        /// </summary>
        PointM = 21,
        /// <summary>
        /// A shapefile PolyLineM consists of one or more parts. A part is a connected sequence of
        /// two or more points. Parts may or may not be connected to one another. Parts may or may
        /// not intersect one another.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.ILineString"/> or <see cref="Gisoft.GeoAPI.Geometries.IMultiLineString"/>
        /// </summary>
        PolyLineM = 23,
        /// <summary>
        /// A PolygonM consists of a number of rings. A ring is a closed, non-self-intersecting loop.
        /// Gisoft.SharpMap interprets this as either <see cref="Gisoft.GeoAPI.Geometries.IPolygon"/> or <see cref="Gisoft.GeoAPI.Geometries.IMultiPolygon"/>
        /// </summary>
        PolygonM = 25,
        /// <summary>
        /// A MultiPointM represents a set of <see cref="PointM"/>s.
        /// Gisoft.SharpMap interprets this as <see cref="Gisoft.GeoAPI.Geometries.IMultiPoint"/>
        /// </summary>
        MultiPointM = 28,
        /// <summary>
        /// A MultiPatch consists of a number of surface patches. Each surface patch describes a
        /// surface. The surface patches of a MultiPatch are referred to as its parts, and the type of
        /// part controls how the order of vertices of an MultiPatch part is interpreted.
        /// Gisoft.SharpMap doesn't support this feature type.
        /// </summary>
        MultiPatch = 31
    } ;
}