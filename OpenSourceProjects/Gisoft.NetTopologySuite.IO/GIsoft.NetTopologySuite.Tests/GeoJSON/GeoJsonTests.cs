﻿using System;
using System.IO;
using System.Text;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NetTopologySuite.IO.Tests.GeoJSON
{
    [TestFixture]
    public class Test
    {
        private readonly IPoint _point = new Point(10, 10);
        private readonly ILineString _lineString = new LineString(new[] { new Coordinate(10, 10), new Coordinate(20, 20) });

        private readonly IPolygon _polygon1 =
            new Polygon(
                new LinearRing(new[]
                                   {
                                       new Coordinate(10, 10), new Coordinate(20, 20), new Coordinate(20, 10),
                                       new Coordinate(10, 10)
                                   }));

        private readonly IPolygon _polygon2 = new Polygon(
            new LinearRing(new[]
                               {
                                   new Coordinate(10, 10), new Coordinate(20, 20), new Coordinate(20, 10),
                                   new Coordinate(10, 10)
                               }),
            new[]
                {
                    new LinearRing(new[]
                                       {
                                           new Coordinate(11, 11), new Coordinate(19, 11), new Coordinate(19, 19),
                                           new Coordinate(11, 11)
                                       })
                });
        private readonly IMultiPoint _multiPoint = new MultiPoint(new[] { new Point(10, 10), new Point(11, 11), new Point(12, 12), });


        private readonly IMultiPolygon _multiPolygon =
            new MultiPolygon(
                new[] {
                    new Polygon(
                        new LinearRing(new[] { new Coordinate (10, 10), new Coordinate (20, 20),
                                               new Coordinate (20, 10), new Coordinate (10, 10) }),
                        new[]
                        {
                            new LinearRing(new[] { new Coordinate (11, 11), new Coordinate (19, 11),
                                                   new Coordinate (19, 19), new Coordinate (11, 11)})
                        }),
                    new Polygon(
                        new LinearRing(new[] { new Coordinate (10, 10), new Coordinate (20, 20),
                                               new Coordinate (20, 10), new Coordinate (10, 10) }))

                });



        private readonly IMultiLineString _multiLineString =
            new MultiLineString(new[]
                                    {
                                        new LineString(new[] {new Coordinate(10, 10), new Coordinate(20, 20)}),
                                        new LineString(new[] {new Coordinate(10, 11), new Coordinate(20, 21)})
                                    });

        [Test]
        public void TestMultiPoly()
        {
            PerformGeometryTest(_multiPolygon);
        }

        [Test]
        public void TestAllGeometries()
        {
            PerformGeometryTest(_point);
            PerformGeometryTest(_lineString);
            PerformGeometryTest(_polygon1);
            PerformGeometryTest(_polygon2);
            PerformGeometryTest(_multiPoint);
            PerformGeometryTest(_multiLineString);
            PerformGeometryTest(_multiPolygon);
            PerformGeometryTest(new GeometryCollection(new[] { (IGeometry)_point, _lineString, _polygon2 }));
        }

        public void PerformGeometryTest(IGeometry geom)
        {
            JsonSerializer s = new GeoJsonSerializer();
            StringBuilder sb = new StringBuilder();
            s.Serialize(new JsonTextWriter(new StringWriter(sb)), geom);
            string result = sb.ToString();
            Console.WriteLine(result);

            Deserialize(result, geom);
        }

        private static void Deserialize(string result, IGeometry geom)
        {
            JsonSerializer s = new GeoJsonSerializer();
            JsonTextReader r = new JsonTextReader(new StringReader(result));

            IGeometry des;

            if (geom is IPoint)
                des = s.Deserialize<Point>(r);
            else if (geom is ILineString)
                des = s.Deserialize<LineString>(r);
            else if (geom is IPolygon)
                des = s.Deserialize<Polygon>(r);
            else if (geom is IMultiPoint)
                des = s.Deserialize<MultiPoint>(r);
            else if (geom is IMultiLineString)
                des = s.Deserialize<MultiLineString>(r);
            else if (geom is IMultiPolygon)
                des = s.Deserialize<MultiPolygon>(r);
            else if (geom is IGeometryCollection)
                des = s.Deserialize<GeometryCollection>(r);
            else
                throw new Exception();

            Console.WriteLine(des.AsText());
            Assert.IsTrue(des.EqualsExact(geom));
        }

        [Test]
        public void TestCoordinateSerialize()
        {
            Coordinate coordinate = new Coordinate(1, 1);
            JsonSerializer g = new GeoJsonSerializer();
            StringBuilder sb = new StringBuilder();
            g.Serialize(new JsonTextWriter(new StringWriter(sb)), coordinate);

            Console.WriteLine(sb.ToString());
        }

        [Test]
        public void TestCoordinatesSerialize()
        {
            Coordinate[] coordinates = new Coordinate[4];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = new Coordinate(i, i, i);
            }
            StringBuilder sb = new StringBuilder();
            JsonSerializer g = new GeoJsonSerializer();
            g.Serialize(new JsonTextWriter(new StringWriter(sb)), coordinates);

            Console.WriteLine(sb.ToString());
        }

        [Test]
        public void TestCoordinateDeserialize()
        {
            string json = "{coordinates:[1.0, 1.0]}";
            JsonSerializer s = new GeoJsonSerializer();
            Coordinate c = s.Deserialize<Coordinate>(new JsonTextReader(new StringReader(json)));
            Console.WriteLine(c.ToString());

        }
    }
}