using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaKurieraPIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // gMapControl1.DragButton = MouseButtons.Left;
            // gMapControl1.MapProvider = GMapProviders.GoogleMap;
            // gMapControl1.ShowCenter = false;
            // gMapControl1.SetPositionByKeywords("Chennai, India");
            //// gMapControl1.Position = new GMap.NET.PointLatLng(50,50);
            // gMapControl1.MinZoom = 5;
            // gMapControl1.MaxZoom = 100;
            // gMapControl1.Zoom = 10;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load_1(object sender, EventArgs e)
        {
           // GMapProviders.GoogleMap.ApiKey = @"AIzaSyAUjFFozCwlfp8OmeKONT_lhjlk-hy3dP8";
            gMapControl1.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.SetPositionByKeywords("Kielce");
            
            gMapControl1.ShowCenter = false;
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 100;
            gMapControl1.Zoom = 10;

            GMapOverlay markers = new GMapOverlay("markers");
            PointLatLng point = new GMap.NET.PointLatLng();
            gMapControl1.GetPositionByKeywords("Kielce, Wiosenna 10", out point);
            GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new PointLatLng(point.Lat,point.Lng),
                 GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
            marker.ToolTipText = "Dupa";
            
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

            PointLatLng point2 = new GMap.NET.PointLatLng();
            gMapControl1.GetPositionByKeywords("Kielce, Mazurska 66", out point2);

            MapRoute route = OpenStreetMapProvider.Instance.GetRoute(point, point2, false, false, 0);

            GMapRoute r = new GMapRoute(route.Points, "My route");

            GMapOverlay routesOverlay = new GMapOverlay("routes");
            routesOverlay.Routes.Add(r);
            gMapControl1.Overlays.Add(routesOverlay);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            gMapControl1.SetPositionByKeywords(text);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:5001/WeatherForecast");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(content);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
