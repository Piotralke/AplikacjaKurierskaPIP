using AplikacjaKordynatora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using Region =AplikacjaKordynatora.Models.Region;
using GMap.NET.WindowsPresentation;

namespace AplikacjaKurieraPIP
{
    
    public partial class Main : Form
    {
		User loggedUser;
		List<Panel> panels = new List<Panel>();
        DateTime startHour;
        DateTime endHour;
        
        public Main(User user)
        {
            InitializeComponent();
            helloLabel.Text = "Witaj " + user.loginCredentials.login;
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
			loggedUser = user;
			takePackagesButton.Enabled = false;
            handPackagesButton.Enabled = false;
			defaultPanel.BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void startWorkButton_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DialogResult dialogResult = MessageBox.Show("Czy potwierdzasz rozpoczęcie pracy w dniu " + currentTime.ToString("dd/MM/yyyy") + " o godzinie " + currentTime.ToString("HH:mm") + "?", "Rozpocznij pracę", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                startHour = currentTime;
                startWorkButton.Enabled = false;
                startWorkButton.Visible = false;
                endWorkButton.Enabled = true;
                endWorkButton.Visible = true;
				takePackagesButton.Enabled = true;
				workTimeLabel.Text = "Dzisiaj pracujesz od " + currentTime.ToString("HH:mm");
            }
        }
        private void endWorkButton_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DialogResult dialogResult = MessageBox.Show("Czy potwierdzasz zakończenie pracy w dniu " + currentTime.ToString("dd/MM/yyyy") + " o godzinie " + currentTime.ToString("HH:mm") + "?", "Rozpocznij pracę", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                endHour = currentTime;
                startWorkButton.Enabled = true;
                startWorkButton.Visible = true;
                endWorkButton.Enabled = false;
                endWorkButton.Visible = false;
				takePackagesButton.Enabled = false;
                TimeSpan elapsedTime = startHour - endHour;
                Console.Write(elapsedTime);
                workTimeLabel.Text = "Dzisiaj przepracowałeś " +elapsedTime.Hours + " godzin i " + elapsedTime.Minutes + " minut";
            }
        }

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void button7_Click(object sender, EventArgs e)
		{

		}

		private void takePackagesButton_Click(object sender, EventArgs e)
		{

            fetchData();
            takePackages.BringToFront();

		}
        private void fetchData()
        {
			try
			{

				String requestRegions = "http://localhost:5225/regions";
				HttpWebRequest webRequestRegion = (HttpWebRequest)WebRequest.Create(@requestRegions);
				HttpWebResponse webResponeRegion = (HttpWebResponse)webRequestRegion.GetResponse();
				string regionContent = new StreamReader(webResponeRegion.GetResponseStream()).ReadToEnd();
				List<Region> regions = JsonSerializer.Deserialize<List<Region>>(regionContent);
                List<Region> filteredRegions = new List<Region>();
                regions.ForEach(r =>
                {
                    if(r.courierId==loggedUser.id)
                    {
						filteredRegions.Add(r);
                    }
                });
				String requestPackage = "http://localhost:5225/Packages/GetAllPackages/";
				HttpWebRequest webRequestPackage = (HttpWebRequest)WebRequest.Create(@requestPackage);
				HttpWebResponse webResponePackage = (HttpWebResponse)webRequestPackage.GetResponse();
				string packageContent = new StreamReader(webResponePackage.GetResponseStream()).ReadToEnd();
				List<Package> packages = JsonSerializer.Deserialize<List<Package>>(packageContent);

				filteredRegions.ForEach(r =>
				{
					String requestRegionsPinsList = "http://localhost:5225/regionPins/GetRegionPinByRegionId/" + r.id;
					HttpWebRequest webRequestRegionsPinsList = (HttpWebRequest)WebRequest.Create(@requestRegionsPinsList);
					HttpWebResponse webResponseRegionsPinsList = (HttpWebResponse)webRequestRegionsPinsList.GetResponse();
					string regionPinsContent = new StreamReader(webResponseRegionsPinsList.GetResponseStream()).ReadToEnd();
					List<RegionPins> regionPins = JsonSerializer.Deserialize<List<RegionPins>>(regionPinsContent);

					List<PointLatLng> points = new List<PointLatLng>();
					foreach (RegionPins pin in regionPins)
					{
						PointLatLng pll = new PointLatLng()
						{
							Lat = pin.x,
							Lng = pin.y,
						};
						points.Add(pll);
					}

				});
				

				packages.ForEach(p =>
                {
                    string address = p.receiverAddress.street + " " + p.receiverAddress.houseNumber + " " + p.receiverAddress.zipCode + " " + p.receiverAddress.city;
                    PointLatLng point;
                    gMapControl1.GetPositionByKeywords(address, out point);

				});

				List<List<string>> list = new List<List<string>>();
				//for (int i = 0; i < packages.Count; i++)
				//{

				//	list.Add(new List<string> { packages[i].number,
				//   packages[i].sender.name +" "+ packages[i].sender.surname,
				//   packages[i].receiver.name +" "+ packages[i].receiver.surname,
				//   packages[i].receiverAddress.street +" "+packages[i].receiverAddress.houseNumber,
				//   packages[i].receiverAddress.zipCode,
				//   packages[i].receiverAddress.city});


				//}
				//listView.Items.Clear();
				//foreach (List<string> l in list)
				//{
				//	ListViewItem item = new ListViewItem(l[0]);
				//	item.SubItems.Add(l[1]);
				//	item.SubItems.Add(l[2]);
				//	item.SubItems.Add(l[3]);
				//	item.SubItems.Add(l[4]);
				//	item.SubItems.Add(l[5]);
				//	listView.Items.Add(item);
				//}


			}
			catch (Exception ex)
			{
				Console.WriteLine("BLAD!" + ex);
			}
		}

		private void gMapControl1_Load(object sender, EventArgs e)
		{

		}
	}
}
