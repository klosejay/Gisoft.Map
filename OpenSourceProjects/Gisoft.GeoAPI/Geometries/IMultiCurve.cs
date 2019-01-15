namespace Gisoft.GeoAPI.Geometries
{
    public interface IMultiCurve : IGeometryCollection
    {
        bool IsClosed { get; }
    }
}