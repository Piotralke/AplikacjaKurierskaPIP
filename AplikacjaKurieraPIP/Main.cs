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
using Status = AplikacjaKordynatora.Models.Status;
using System.Net.Http;

namespace AplikacjaKurieraPIP
{
    
    public partial class Main : Form
    {
		User loggedUser;
		List<Panel> panels = new List<Panel>();
        DateTime startHour;
        DateTime endHour;
		List<Package> packagesForDay = new List<Package>(); 
        public Main(User user)
        {
            InitializeComponent();
            helloLabel.Text = "Witaj " + user.loginCredentials.login;
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
			gMapControl1.Position = new PointLatLng(50.866065, 20.628568);
			gMapControl1.MinZoom = 1;
			gMapControl1.MaxZoom = 17;
			gMapControl1.Zoom = 10;
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

		private async void button7_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Czy na pewno potwierdzasz pobrane paczki? Nie będziesz mógł pobrać większej ilości paczek na dziś", "Potwierdź", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{

				String requestPackage = "http://localhost:5225/Packages/GetAllPackages/";
				HttpWebRequest webRequestPackage = (HttpWebRequest)WebRequest.Create(@requestPackage);
				HttpWebResponse webResponePackage = (HttpWebResponse)webRequestPackage.GetResponse();
				string packageContent = new StreamReader(webResponePackage.GetResponseStream()).ReadToEnd();
				List<Package> packages = JsonSerializer.Deserialize<List<Package>>(packageContent);

				foreach (ListViewItem item in takenPackagesList.Items)
				{
					packageToDeliver.Items.Add(item.Clone() as ListViewItem);
				}
				takenPackagesList.Items.Clear();
				foreach (ListViewItem item in ordersTakenList.Items)
				{
					packageToDeliver.Items.Add(item.Clone() as ListViewItem);
					
				}
				foreach (ListViewItem item in packageToDeliver.Items)
				{
					var x = packages.Find(p => p.id.ToString().Equals(item.SubItems[2].Text));
					if (x!=null)
					{
						packagesForDay.Add(x);
						Status status = new Status()
						{
							id = 0,
							idStatusName = 8,
							idPackage = x.id,
							date = DateTime.Now
						};
						String addStatus = "http://localhost:5225/statuses";
						String json2 = JsonSerializer.Serialize(status);
						using (var streamWriter = new HttpClient())
						{
							var response = await streamWriter.PostAsync(addStatus, new StringContent(json2, Encoding.UTF8, "application/json"));

						}
					}
				}

				ordersTakenList.Items.Clear();
				takePackagesButton.Enabled = false;
				handPackagesButton.Enabled = true;
				packagesToDeliver.BringToFront();
			}
			else if (dialogResult == DialogResult.No)
			{
				//do something else
			}
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

				List<Package> filteredPackages = new List<Package>();
				packages.ForEach(pack =>
				{
					pack.statuses.OrderByDescending(p => p.date);

					if (pack.statuses[0].idStatusName==4|| pack.statuses[0].idStatusName == 12)
					{
						filteredPackages.Add(pack);
					}
				});
				List<Package> yourPackages = new List<Package>();
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
					var polygon = new GMap.NET.WindowsForms.GMapPolygon(points, "overlay");
					filteredPackages.ForEach(p =>
					{
						string address = p.receiverAddress.street + " " + p.receiverAddress.houseNumber.Split('/')[0] + " " + p.receiverAddress.zipCode + " ," + p.receiverAddress.city;
						PointLatLng point;
						Console.WriteLine(address);
						gMapControl1.GetPositionByKeywords(address, out point);
						Console.WriteLine(point);
						if(polygon.IsInside(point))
						{
							yourPackages.Add(p);
						}

					});
					
				});


				List<List<string>> list = new List<List<string>>();
				for (int i = 0; i < yourPackages.Count; i++)
				{

					list.Add(new List<string> { yourPackages[i].number,
				   yourPackages[i].receiverAddress.street +" "+ yourPackages[i].receiverAddress.houseNumber +" " + yourPackages[i].receiverAddress.zipCode + " " + yourPackages[i].receiverAddress.city,yourPackages[i].id.ToString(),"O"});


				}
				dbPackagesList.Items.Clear();
				foreach (List<string> l in list)
				{
					ListViewItem item = new ListViewItem(l[0]);
					item.SubItems.Add(l[1]);
					item.SubItems.Add(l[2]);
					item.SubItems.Add(l[3]);
					dbPackagesList.Items.Add(item);
				}

				String requestOrders = "http://localhost:5225/orders";
				HttpWebRequest webRequestOrders = (HttpWebRequest)WebRequest.Create(@requestOrders);
				HttpWebResponse webResponeOrders = (HttpWebResponse)webRequestOrders.GetResponse();
				string ordersContent = new StreamReader(webResponeOrders.GetResponseStream()).ReadToEnd();
				List<Order> orders = JsonSerializer.Deserialize<List<Order>>(ordersContent);
				List<Package> yoursOrder= new List<Package>();
				orders.ForEach(o =>
				{
					if(o.courierId==loggedUser.id)
					{
						packages.ForEach(p =>
						{
							if (p.id ==o.packageId)
							{
								yoursOrder.Add(p);
							}
						});
					}	
				});
				List<List<string>> list2 = new List<List<string>>();
				for (int i = 0; i < yoursOrder.Count; i++)
				{

					list2.Add(new List<string> { yoursOrder[i].number,
				   yoursOrder[i].senderAddress.street +" "+ yoursOrder[i].senderAddress.houseNumber +" " + yoursOrder[i].senderAddress.zipCode + " " + yoursOrder[i].senderAddress.city,yoursOrder[i].id.ToString(),"N"});


				}
				dbOrdersList.Items.Clear();
				foreach (List<string> l in list2)
				{
					ListViewItem item = new ListViewItem(l[0]);
					item.SubItems.Add(l[1]);
					item.SubItems.Add(l[2]);
					item.SubItems.Add(l[3]);
					dbOrdersList.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("BLAD!" + ex);
			}
		}

		private void gMapControl1_Load(object sender, EventArgs e)
		{

		}

		private void dbPackagesList_DoubleClick(object sender, EventArgs e)
		{
			var item = dbPackagesList.SelectedItems[0];
			dbPackagesList.SelectedItems[0].Remove();
			takenPackagesList.Items.Add(item);
		}

		private void takenPackagesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void takenPackagesList_DoubleClick(object sender, EventArgs e)
		{
			var item = takenPackagesList.SelectedItems[0];
			takenPackagesList.SelectedItems[0].Remove();
			dbPackagesList.Items.Add(item);
		}

		private void dbOrdersList_DoubleClick(object sender, EventArgs e)
		{
			var item = dbOrdersList.SelectedItems[0];
			dbOrdersList.SelectedItems[0].Remove();
			ordersTakenList.Items.Add(item);
		}

		private void ordersTakenList_DoubleClick(object sender, EventArgs e)
		{
			var item = ordersTakenList.SelectedItems[0];
			ordersTakenList.SelectedItems[0].Remove();
			dbOrdersList.Items.Add(item);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			foreach (ListViewItem item in dbPackagesList.Items)
			{
				takenPackagesList.Items.Add(item.Clone() as ListViewItem);
			}
			dbPackagesList.Items.Clear();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in takenPackagesList.Items)
			{
				dbPackagesList.Items.Add(item.Clone() as ListViewItem);
			}
			takenPackagesList.Items.Clear();
		}

		private void button6_Click(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void handPackagesButton_Click(object sender, EventArgs e)
		{
			packagesToDeliver.BringToFront();
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			foreach (ListViewItem item in dbOrdersList.Items)
			{
				ordersTakenList.Items.Add(item.Clone() as ListViewItem);
			}
			dbOrdersList.Items.Clear();
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			foreach (ListViewItem item in ordersTakenList.Items)
			{
				dbOrdersList.Items.Add(item.Clone() as ListViewItem);
			}
			ordersTakenList.Items.Clear();
		}

		private void statisticsButton_Click(object sender, EventArgs e)
		{
			defaultPanel.BringToFront();
		}

		private void packageToDeliver_Click(object sender, EventArgs e)
		{
			var item = packageToDeliver.SelectedItems[0];
			packageNumber.Text = "Nr paczki: " + item.SubItems[0].Text;
			address.Text = "Adres: " + item.SubItems[1].Text;
			var pack = packagesForDay.Find(p => p.id.ToString().Equals(item.SubItems[2].Text));
			string search="";
			string pData = "";
			string serviceText = "";
			if (item.SubItems[3].Text=="N")
			{
				serviceText =service.Text = "Usługa: Zlecenie nadania";
				pData=personData.Text = "Dane nadawcy:\n" + pack.sender.name + " " + pack.sender.surname;
				search = pack.senderAddress.street + " " + pack.senderAddress.houseNumber.Split('/')[0] + " " + pack.senderAddress.zipCode + " ," + pack.senderAddress.city;
				
			}
			else if(item.SubItems[3].Text == "O")
			{
				serviceText =service.Text = "Usługa: Wydanie przesyłki";
				pData=personData.Text = "Dane odbiorcy:\n" + pack.receiver.name + " " + pack.receiver.surname;
				search = pack.receiverAddress.street + " " + pack.receiverAddress.houseNumber.Split('/')[0] + " " + pack.receiverAddress.zipCode + " ," + pack.receiverAddress.city;
			}
			PointLatLng point;
			gMapControl1.GetPositionByKeywords(search, out point);
			var markers = new GMapOverlay("markers");
			var marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
			marker.ToolTipText = packageNumber.Text;
			marker.ToolTipText += "\n" + serviceText + "\n" + pData;
			marker.ToolTipText += "\n" + address.Text;
			gMapControl1.Overlays.Clear();
			gMapControl1.Position= point;
			
			markers.Markers.Add(marker);
			gMapControl1.Overlays.Add(markers);
			gMapControl1.Zoom = 16;
		}

		private void button11_Click(object sender, EventArgs e)
		{
			packagesToDeliver.BringToFront();
		}

		private void button8_Click(object sender, EventArgs e)
		{

		}
		private Package deliveryPack;
		private void packageToDeliver_DoubleClick(object sender, EventArgs e)
		{
			var item = packageToDeliver.SelectedItems[0];
			deliveryPack = packagesForDay.Find(p => p.id.ToString().Equals(item.SubItems[2].Text));
			numberLabel.Text = "Nr paczki: " + item.SubItems[0].Text;
			addressLabel.Text = "Adres: " + item.SubItems[1].Text;
			if (item.SubItems[3].Text == "N")
			{
				dataLabel.Text = personData.Text = "Dane nadawcy:\n" + deliveryPack.sender.name + " " + deliveryPack.sender.surname;

			}
			else if (item.SubItems[3].Text == "O")
			{
				dataLabel.Text = "Dane odbiorcy::\n" + deliveryPack.receiver.name + " " + deliveryPack.receiver.surname;
			}
			if(deliveryPack.cODcost>0)
			{
				CODLabel.Text= "Kwota pobrania: " + deliveryPack.cODcost.ToString();
			}
			else
			{
				CODLabel.Text = "";
			}
			descriptionLabel.Text = "Opis:\n" + deliveryPack.description;
			packageDetail.BringToFront();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox2.SelectedIndex ==0) 
			{
				panel3.Enabled = true;
				panel3.Visible = true;
				panel4.Enabled = false;
				panel4.Visible = false;
				panel3.BringToFront();
			}
			else
			{
				panel4.Enabled = true;
				panel4.Visible = true;
				panel3.Enabled = false;
				panel3.Visible = false;
				panel4.BringToFront();
			}
		}

		private async void button13_Click(object sender, EventArgs e)
		{
			if(comboBox3.SelectedIndex ==0)//odmowa
			{
				Status status = new Status()
				{
					id = 0,
					idStatusName = 10,
					idPackage = deliveryPack.id,
					date = DateTime.Now
				};
				String addStatus = "http://localhost:5225/statuses";
				String json2 = JsonSerializer.Serialize(status);
				using (var streamWriter = new HttpClient())
				{
					var response = await streamWriter.PostAsync(addStatus, new StringContent(json2, Encoding.UTF8, "application/json"));

				}
			}
			else
			{
				Status status = new Status()
				{
					id = 0,
					idStatusName = 11,
					idPackage = deliveryPack.id,
					date = DateTime.Now
				};
				String addStatus = "http://localhost:5225/statuses";
				String json2 = JsonSerializer.Serialize(status);
				using (var streamWriter = new HttpClient())
				{
					var response = await streamWriter.PostAsync(addStatus, new StringContent(json2, Encoding.UTF8, "application/json"));

				}
			}
			var item = packageToDeliver.SelectedItems[0].Index;
			packageToDeliver.Items.RemoveAt(item);
			packagesToDeliver.BringToFront();
		}

		private async void button12_Click(object sender, EventArgs e)
		{
			Status status = new Status()
			{
				id = 0,
				idStatusName = 9,
				idPackage = deliveryPack.id,
				date = DateTime.Now
			};
			String addStatus = "http://localhost:5225/statuses";
			String json2 = JsonSerializer.Serialize(status);
			using (var streamWriter = new HttpClient())
			{
				var response = await streamWriter.PostAsync(addStatus, new StringContent(json2, Encoding.UTF8, "application/json"));

			}

			var item = packageToDeliver.SelectedItems[0].Index;
			packageToDeliver.Items.RemoveAt(item);
			packagesToDeliver.BringToFront();
		}
	}
}
