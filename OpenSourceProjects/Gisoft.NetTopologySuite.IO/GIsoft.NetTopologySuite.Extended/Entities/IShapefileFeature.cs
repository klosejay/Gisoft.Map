using Gisoft.NetTopologySuite.Features;

namespace Gisoft.NetTopologySuite.IO.ShapeFile.Extended.Entities
{
    public interface IShapefileFeature : IFeature
    {
        long FeatureId { get; }
    }
}
