﻿using System;
using System.Collections.ObjectModel;
using NetTopologySuite.CoordinateSystems;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Text;
using System.IO;

namespace NetTopologySuite.IO.Tests.GeoJSON
{
    ///<summary>
    ///    This is a test class for GeoJsonWriterTest and is intended
    ///    to contain all GeoJsonWriterTest Unit Tests
    ///</summary>
    [TestFixture]
    public class GeoJsonWriterTest
    {       
        ///<summary>
        ///    A test for GeoJsonWriter Write method
        ///</summary>
        [Test]
        public void GeoJsonWriterWriteFeatureCollectionTest()
        {
            AttributesTable attributes = new AttributesTable();
            attributes.Add("test1", "value1");
            IFeature feature = new Feature(new Point(23, 56), attributes);
            FeatureCollection featureCollection = new FeatureCollection(new Collection<IFeature> { feature }) { CRS = new NamedCRS("name1") };
            var gjw = new GeoJsonWriter();
            gjw.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            string actual = gjw.Write(featureCollection);
            Assert.AreEqual("{\"type\":\"FeatureCollection\",\"features\":[{\"type\":\"Feature\",\"geometry\":{\"type\":\"Point\",\"coordinates\":[23.0,56.0]},\"properties\":{\"test1\":\"value1\"}}],\"crs\":{\"type\":\"name\",\"properties\":{\"name\":\"name1\"}}}", actual);
        }

        ///<summary>
        ///    A test for GeoJsonWriter Write method
        ///</summary>
        [Test]
        public void GeoJsonWriterWriteFeatureTest()
        {
            AttributesTable attributes = new AttributesTable();
            attributes.Add("test1", "value1");
            IFeature feature = new Feature(new Point(23, 56), attributes);
            string actual = new GeoJsonWriter().Write(feature);
            Assert.AreEqual("{\"type\":\"Feature\",\"geometry\":{\"type\":\"Point\",\"coordinates\":[23.0,56.0]},\"properties\":{\"test1\":\"value1\"}}", actual);
        }

        ///<summary>
        ///    A test for GeoJsonWriter Write method
        ///</summary>
        [Test]
        public void GeoJsonWriterWriteGeometryTest()
        {
            string actual = new GeoJsonWriter().Write(new Point(23, 56));
            Assert.AreEqual("{\"type\":\"Point\",\"coordinates\":[23.0,56.0]}", actual);
        }

        ///<summary>
        ///    A test for GeoJsonWriter Write method
        ///</summary>
        [Test]
        public void GeoJsonWriterWriteAttributesTest()
        {
            AttributesTable attributes = new AttributesTable();
            attributes.Add("test1", "value1");
            string actual = new GeoJsonWriter().Write(attributes);
            Assert.AreEqual("{\"test1\":\"value1\"}", actual);
        }

        ///<summary>
        ///    A test for GeoJsonWriter Write method
        ///</summary>
        [Test]
        public void GeoJsonWriterWriteAnyObjectTest()
        {
            AttributesTable attributes = new AttributesTable();
            DateTime Date = new DateTime(2012, 8, 8).Date;

            JsonSerializer g = new GeoJsonSerializer { NullValueHandling = NullValueHandling.Ignore };
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
                g.Serialize(sw, Date);
            string expectedDateString = sb.ToString();

            string expectedResult = "{\"featureCollection\":{\"type\":\"FeatureCollection\",\"features\":[{\"type\":\"Feature\",\"geometry\":{\"type\":\"Point\",\"coordinates\":[23.0,56.0]},\"properties\":{\"test1\":\"value1\"}}],\"crs\":{\"type\":\"name\",\"properties\":{\"name\":\"name1\"}}},\"Date\":" + expectedDateString + "}";
            attributes.Add("test1", "value1");
            IFeature feature = new Feature(new Point(23, 56), attributes);

            FeatureCollection featureCollection = new FeatureCollection(new Collection<IFeature> { feature }) { CRS = new NamedCRS("name1") };
            var gjw = new GeoJsonWriter();
            gjw.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            string actual = gjw.Write(new { featureCollection, Date = Date });
            Assert.AreEqual(expectedResult, actual);
        }
    }
}