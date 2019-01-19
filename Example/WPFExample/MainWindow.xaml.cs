using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gisoft;
using Gisoft.GeoAPI.Geometries;

namespace WPFExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComponent();

            var gss = Gisoft.GeoAPI.GeometryServiceProvider.Instance;
            var css = new Gisoft.SharpMap.CoordinateSystems.CoordinateSystemServices(
                new Gisoft.ProjNet.CoordinateSystems.CoordinateSystemFactory(),
                new Gisoft.ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory(),
                Gisoft.SharpMap.Converters.WellKnownText.SpatialReference.GetAllReferenceSystems());

            Gisoft.GeoAPI.GeometryServiceProvider.Instance = gss;
            Gisoft.SharpMap.Session.Instance
                .SetGeometryServices(gss)
                .SetCoordinateSystemServices(css)
                .SetCoordinateSystemRepository(css);
        }

        private void AddShapeLayer_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = @"Shapefiles (*.shp)|*.shp|All files(*.*)|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //var fileName = ofd.FileName.Convert2UTF8();
                var ds = new Gisoft.SharpMap.Data.Providers.Ogr(ofd.FileName.Convert2UTF8());
                //ds.IncludeOid = false;
                //var ds = new Gisoft.SharpMap.Data.Providers.Ogr(ofd.FileName);
                var lay = new Gisoft.SharpMap.Layers.VectorLayer(System.IO.Path.GetFileNameWithoutExtension(ofd.FileName), ds);
                if (ds.CoordinateSystem != null)
                {
                    Gisoft.GeoAPI.CoordinateSystems.Transformations.ICoordinateTransformationFactory fact =
                        new Gisoft.ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();

                    lay.CoordinateTransformation = fact.CreateFromCoordinateSystems(ds.CoordinateSystem,
                        Gisoft.ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator);
                    lay.ReverseCoordinateTransformation = fact.CreateFromCoordinateSystems(Gisoft.ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator,
                        ds.CoordinateSystem);
                }
                var features = ds.GetFeature(0);
                WpfMap.MapLayers.Add(lay);

                if (WpfMap.MapLayers.Count == 1)
                {
                    Envelope env = lay.Envelope;
                    WpfMap.ZoomToEnvelope(env);
                }
            }
            e.Handled = true;
        }
        private void AddImageLayer_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = @"ImageFiles (*.tif)|*.tif";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var lay = new Gisoft.SharpMap.Layers.GdalRasterLayer(ofd.SafeFileName, ofd.FileName.Convert2UTF8());
                //WpfMap.MapLayers.Add(Gisoft.SharpMap.Layers.AsyncLayerProxyLayer.Create(lay));
                WpfMap.BackgroundLayer = lay;
                if (WpfMap.MapLayers.Count <= 1)
                {
                    Envelope env = lay.Envelope;
                    WpfMap.ZoomToEnvelope(env);
                }

            }
            e.Handled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void BgOsm_Click(object sender, RoutedEventArgs e)
        {
            //WpfMap.BackgroundLayer = new Gisoft.SharpMap.Layers.TileAsyncLayer(BruTile.Predefined.KnownTileSources.Create(), "OSM");

            //foreach (var menuItem in Menu.Items.OfType<MenuItem>())
            //{
            //    menuItem.IsChecked = false;
            //}
            //BgOsm.IsChecked = true;

            //WpfMap.ZoomToExtents();
            //e.Handled = true;
        }

        private void BgMapQuest_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
