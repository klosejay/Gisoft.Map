using Gisoft.GeoAPI.Geometries;

namespace Gisoft.NetTopologySuite.IO.Handlers
{
	public class MBRInfo
	{
		public MBRInfo(Envelope shapeMBR, long offsetFromStartOfFile, int shapeIndex)
		{
			ShapeFileDetails = new ShapeLocationInFileInfo(offsetFromStartOfFile, shapeIndex);
			ShapeMBR = shapeMBR;
		}

		public ShapeLocationInFileInfo ShapeFileDetails { get; private set; }
		public Envelope ShapeMBR { get; private set; }
	}
}
