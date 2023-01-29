using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikacjaKordynatora.Models;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Region = AplikacjaKordynatora.Models.Region;

namespace AplikacjaKordynatora
{
    struct Coordinates
    {
        public float lat;
        public float lng;
    }
    public partial class CoordinatorHome : Form
    {
        List<String> courierids = new List<String>();
        List<String> regionids = new List<String>();
        List<Coordinates> coordinates = new List<Coordinates>();
        public CoordinatorHome(loginCredentials credentials)
        {
            InitializeComponent();
            loggedlabel.Text = credentials.login;
            datetimenow.Text = DateTime.Now.ToShortDateString();
            registerseat.Text = "Kurier";
            datework.Text = calendar.TodayDate.ToShortDateString();

        }

        private void CoordinatorHome_Load(object sender, EventArgs e)
        {
            load_Regions();
            buttonUpdate.Enabled = false;
            packageslist.GridLines = true;
            workerslist.GridLines = true;
            schemeworkerslist.GridLines = true;
            buttonUpdate.Enabled = false;
            deleteRegionButton.Enabled = false;
            regioncode.Enabled = false;
            addregion.Enabled = false;
            gmap.MapProvider = GMapProviders.OpenStreetMap;
            gmap.Position = new PointLatLng(50.866065, 20.628568);
            gmap.MinZoom = 1;
            gmap.MaxZoom = 17;
            gmap.Zoom = 10;
            LoadCouriers();
            loadWorkers();
        }

        private void LoadCouriers()
        {
            try
            {

                String requestWorkers = "http://localhost:5225/Users/GetAllCouriers/";
                HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                comboBoxWorkers.Items.Clear();
                for (int i = 0; i < user.Length; i++)
                {
                    comboBoxWorkers.Items.Add(user[i].name + " "+ user[i].surname + " " + user[i].loginCredentials.login);
                    courierids.Add(user[i].id.ToString());

                }
                 


            }
            catch (Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }
        }

        

     

        private async void registerbutton_Click(object sender, EventArgs e)
        {
            var chars = "ABC123!@#abc";
            var stringChars = new char[12];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var randompassword = new String(stringChars);

            String login = registerloginbox.Text;
            String email = registeremailbox.Text;
            String requestCredentials = "http://localhost:5225/loginCredentials";
            HttpWebRequest credentialsRequest = (HttpWebRequest)WebRequest.Create(@requestCredentials);
            HttpWebResponse credentialsResponse = (HttpWebResponse)credentialsRequest.GetResponse();
            string credentialsContent = new StreamReader(credentialsResponse.GetResponseStream()).ReadToEnd();
            List<loginCredentials> credential = JsonSerializer.Deserialize<List<loginCredentials>>(credentialsContent);
            loginCredentials checkLogin = credential.Find(x => x.login == login);
            loginCredentials checkEmail = credential.Find(x => x.email == email);
            bool isOkay = true;
            if (checkLogin != null)
            {
                MessageBox.Show("Login jest już zajęty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkEmail != null)
            {
                MessageBox.Show("Istnieje konto o podanym adresie e-mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                loginCredentials credentials = new loginCredentials()
                {
                    id = 0,
                    email = registeremailbox.Text,
                    login = registerloginbox.Text,
                    password = randompassword
                };
                User user = new User()
                {
                    id = 0,
                    name = registernamebox.Text,
                    surname = registersurnamebox.Text,
                    loginCredentials = credentials,
                    role = registerseat.Text == "Kurier" ? 1 : 0,
                    defaultAddress = null,
                    phoneNumber = registerphone.Text
                };
                ValidationContext UserValidation = new ValidationContext(user, null, null);
                ValidationContext credentialsValidation = new ValidationContext(credentials, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(credentials, credentialsValidation, errors, true))
                {
                    isOkay = false;
                }
                if (!Validator.TryValidateObject(user, UserValidation, errors, true))
                {
                    isOkay = false;
                }
                if (!isOkay)
                {
                    foreach (ValidationResult result in errors)
                    {
                        MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {

                    String request = "http://localhost:5225/Users";
                    String json = JsonSerializer.Serialize(user);
                    using (var streamWriter = new HttpClient())
                    {
                        var response = await streamWriter.PostAsync(request, new StringContent(json, Encoding.UTF8, "application/json"));

                    }
                    string message = "Dodano pracownika";
                    string title = "Sukces!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK,MessageBoxIcon.Information);
                    registerloginbox.Clear();
                    registernamebox.Clear();
                    registeremailbox.Clear();
                    registersurnamebox.Clear();
                    registerphone.Clear();

                }
            }
        }

        private void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            calendar.MaxSelectionCount = 1;
            datework.Text = calendar.SelectionRange.Start.ToShortDateString();
        }

        private void packagesnumbersearch_Click(object sender, EventArgs e)
        {
            try
            {
                String packagenumber = packagesidtext.Text;
                if(packagesidtext.Text == "")
                {
                    string message = "Jezeli chcesz wyszukac, podaj numer paczki!";
                   
                    MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                String requestPackage = "http://localhost:5225/Packages/GetPackageByNumber/" + packagenumber;
                HttpWebRequest webRequestPackage = (HttpWebRequest)WebRequest.Create(@requestPackage);
                HttpWebResponse webResponePackage = (HttpWebResponse)webRequestPackage.GetResponse();
                string packageContent = new StreamReader(webResponePackage.GetResponseStream()).ReadToEnd();
                Package packages = JsonSerializer.Deserialize<Package>(packageContent);
                List<List<string>> list = new List<List<string>>();
                Console.WriteLine(packages.description);
                list.Add(new List<string> { packages.id.ToString(), packages.number,packages.receiverId.ToString(),packages.receiverAddressId.ToString(),
                packages.senderId.ToString(),packages.senderAddressId.ToString(),packages.weight.ToString(), packages.width.ToString(), packages.depth.ToString(),packages.heigth.ToString(),
                packages.description,packages.isStandardShape.ToString(), packages.cODcost.ToString()});

                packageslist.Items.Clear();
                foreach (List<string> l in list)
                {
                    ListViewItem item = new ListViewItem(l[0]);
                    item.SubItems.Add(l[1]);
                    item.SubItems.Add(l[2]);
                    item.SubItems.Add(l[3]);
                    item.SubItems.Add(l[4]);
                    item.SubItems.Add(l[5]);
                    item.SubItems.Add(l[6]);
                    item.SubItems.Add(l[7]);
                    item.SubItems.Add(l[8]);
                    item.SubItems.Add(l[9]);
                    item.SubItems.Add(l[10]);
                    item.SubItems.Add(l[11]);
                    item.SubItems.Add(l[12]);
                    packageslist.Items.Add(item);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }


        }

        private void packagesrefresh_Click(object sender, EventArgs e)
        {

            loadWorkers();
         
            
        }

        private void packagesshowall_Click(object sender, EventArgs e)
        {
            try
            {
                
                String requestPackage = "http://localhost:5225/Packages/GetAllPackages/";
                HttpWebRequest webRequestPackage = (HttpWebRequest)WebRequest.Create(@requestPackage);
                HttpWebResponse webResponePackage = (HttpWebResponse)webRequestPackage.GetResponse();
                string packageContent = new StreamReader(webResponePackage.GetResponseStream()).ReadToEnd();
                Package[] packages = JsonSerializer.Deserialize<Package[]>(packageContent);
                List<List<string>> list = new List<List<string>>();
                for (int i=0;i<packages.Length;i++)
                {
                    
                    list.Add(new List<string> { packages[i].id.ToString(), packages[i].number,packages[i].receiverId.ToString(),packages[i].receiverAddressId.ToString(),
                     packages[i].senderId.ToString(),packages[i].senderAddressId.ToString(),packages[i].weight.ToString(), packages[i].width.ToString(), packages[i].depth.ToString(),packages[i].heigth.ToString(),
                     packages[i].description,packages[i].isStandardShape.ToString(), packages[i].cODcost.ToString()});

                 
                }
                packageslist.Items.Clear();
                foreach (List<string> l in list)
                {
                    ListViewItem item = new ListViewItem(l[0]);
                    item.SubItems.Add(l[1]);
                    item.SubItems.Add(l[2]);
                    item.SubItems.Add(l[3]);
                    item.SubItems.Add(l[4]);
                    item.SubItems.Add(l[5]);
                    item.SubItems.Add(l[6]);
                    item.SubItems.Add(l[7]);
                    item.SubItems.Add(l[8]);
                    item.SubItems.Add(l[9]);
                    item.SubItems.Add(l[10]);
                    item.SubItems.Add(l[11]);
                    item.SubItems.Add(l[12]);
                    packageslist.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }
        }

        private void loadWorkers()
        {
            try
            {
                String requestWorkers = "http://localhost:5225/Users/GetAllWorkers/";
                HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                List<List<string>> list = new List<List<string>>();
                for (int i = 0; i < user.Length; i++)
                {
                    list.Add(new List<string> { user[i].id.ToString(), user[i].name, user[i].surname, user[i].role.ToString() == "0" ? "Koordynator" : "Kurier",
                        user[i].loginCredentials.login.ToString(),user[i].loginCredentials.password.ToString(),user[i].phoneNumber,user[i].loginCredentials.email.ToString()});


                }
                workerslist.Items.Clear();
                foreach (List<string> l in list)
                {
                    ListViewItem item = new ListViewItem(l[0]);
                    item.SubItems.Add(l[1]);
                    item.SubItems.Add(l[2]);
                    item.SubItems.Add(l[3]);
                    item.SubItems.Add(l[4]);
                    item.SubItems.Add(l[5]);
                    item.SubItems.Add(l[6]);
                    item.SubItems.Add(l[7]);
                    workerslist.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }
        }
        private void workersshowall_Click(object sender, EventArgs e)
        {
            loadWorkers();
            workerssearchid.Clear();
            workerssearchsurname.Clear();
        }

        private void workersrefreshbutton_Click(object sender, EventArgs e)
        {
            loadWorkers();
        }

        private void schemerefreshbutton_Click(object sender, EventArgs e)
        {
            try
            {

                String requestCouriers = "http://localhost:5225/Users/GetAllCouriers/";
                HttpWebRequest webRequestCouriers = (HttpWebRequest)WebRequest.Create(@requestCouriers);
                HttpWebResponse webResponeCouriers = (HttpWebResponse)webRequestCouriers.GetResponse();
                string couriersContent = new StreamReader(webResponeCouriers.GetResponseStream()).ReadToEnd();
                User[] user = JsonSerializer.Deserialize<User[]>(couriersContent);
                List<List<string>> list = new List<List<string>>();
                for (int i = 0; i < user.Length; i++)
                {
                    list.Add(new List<string> {user[i].id.ToString(), user[i].name, user[i].surname, user[i].role.ToString() == "0" ? "Koordynator" : "Kurier", user[i].defaultAddress.city.ToString(),
                        user[i].loginCredentials.login.ToString(),user[i].phoneNumber,user[i].defaultAddress.zipCode,"tutaj region"});


                }
                schemeworkerslist.Items.Clear();
                foreach (List<string> l in list)
                {
                    ListViewItem item = new ListViewItem(l[0]);
                    item.SubItems.Add(l[1]);
                    item.SubItems.Add(l[2]);
                    item.SubItems.Add(l[3]);
                    item.SubItems.Add(l[4]);
                    item.SubItems.Add(l[5]);
                    item.SubItems.Add(l[6]);
                    item.SubItems.Add(l[7]);
                    item.SubItems.Add(l[8]);
                    schemeworkerslist.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }


        }

        private void schemeworkerslist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (mousechoice.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    var point = gmap.FromLocalToLatLng(e.X, e.Y);
                    float lat = (float)point.Lat;
                    float lng = (float)point.Lng;

                    gmap.Position = point;

                    var markers = new GMapOverlay("markers");
                    var marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
                    markers.Markers.Add(marker);
                    Coordinates coords = new Coordinates() { lat = lat, lng = lng};
                    coordinates.Add(coords);
                   
                    gmap.Overlays.Add(markers);

                }
            }
         
        }

        private void mousechoice_CheckedChanged(object sender, EventArgs e)
        {
            coordinates.Clear();
            gmap.Overlays.Clear();
            gmap.Refresh();
            if (mousechoice.Checked)
            {
                regioncode.Enabled = true;
                addregion.Enabled = true;
            }
            else
            {
                regioncode.Enabled = false;
                addregion.Enabled = false;
            }
        }

        private async void addregion_Click(object sender, EventArgs e)
        {
            String sregioncode = regioncode.Text;
            String requestRegions = "http://localhost:5225/regions";
            HttpWebRequest regionsRequest = (HttpWebRequest)WebRequest.Create(@requestRegions);
            HttpWebResponse regionsResponse = (HttpWebResponse)regionsRequest.GetResponse();
            string regionsContent = new StreamReader(regionsResponse.GetResponseStream()).ReadToEnd();
            List<Region> listregion = JsonSerializer.Deserialize<List<Region>>(regionsContent);
            Region checkRegion = listregion.Find(x => x.code == sregioncode);
            bool isOkay = true;
            if(checkRegion != null)
            {
                MessageBox.Show("Istnieje już region o podanym kodzie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isOkay = false;
            }
            if(coordinates.Count < 3)
            {
                MessageBox.Show("Aby utworzyć region utwórz conajmniej 3 punkty na mapie!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isOkay = false;
            }
            if(isOkay)
            {
                Region region = new Region()
                {
                    id = 0,
                    code = sregioncode,
                    courier = null,
                    regionPins = null

                };

                int regionId;
                String requestRegions2 = "http://localhost:5225/regions";
                String jsonRegions = JsonSerializer.Serialize(region);
                using (var streamWriter = new HttpClient())
                {
                    var response = await streamWriter.PostAsync(requestRegions2, new StringContent(jsonRegions, Encoding.UTF8, "application/json"));
                    var jString = response.Content.ReadAsStringAsync();
                    Region resultRegion = JsonSerializer.Deserialize<Region>(jString.Result);
                    regionId = resultRegion.id;
                }
                


                List<RegionPins> listRegionPins = new List<RegionPins>();
                foreach (Coordinates c in coordinates)
                {
                    RegionPins regionPins = new RegionPins()
                    {
                        id = 0,
                        x = c.lat,
                        y = c.lng,
                        regionId = regionId

                    };
                    listRegionPins.Add(regionPins);
                }
                String request = "http://localhost:5225/regionPins/PostList";
                String json = JsonSerializer.Serialize(listRegionPins);
                using (var streamWriter = new HttpClient())
                {
                    var response = await streamWriter.PostAsync(request, new StringContent(json, Encoding.UTF8, "application/json"));

                }
                MessageBox.Show("Pomyślnie dodano Region");
                coordinates.Clear();
                gmap.Overlays.Clear();
                gmap.Refresh();
                load_Regions();

            }
        }

        private void regionsrefreshbutton_Click(object sender, EventArgs e)
        {
            gmap.Overlays.Clear();
            buttonUpdate.Enabled = false;
            gmap.Zoom -= 1;
            gmap.Zoom += 1;
            load_Regions();
           
        }

        private void load_Regions()
        {
            try
            {
                regionids.Clear();
                String requestRegionsList = "http://localhost:5225/regions/";
                HttpWebRequest webRequestRegionsList = (HttpWebRequest)WebRequest.Create(@requestRegionsList);
                HttpWebResponse webResponseRegionsList = (HttpWebResponse)webRequestRegionsList.GetResponse();
                string workersContent = new StreamReader(webResponseRegionsList.GetResponseStream()).ReadToEnd();
                Region[] region = JsonSerializer.Deserialize<Region[]>(workersContent);
                Console.Write(workersContent);
                List<List<string>> list = new List<List<string>>();
               
                for (int i = 0; i < region.Length; i++)
                {
                    list.Add(new List<string> { region[i].code.ToString(), region[i].courier == null ?" ":region[i].courier.loginCredentials.login });
                    regionids.Add(region[i].id.ToString());
                }
                regionlist.Items.Clear();
                foreach (List<string> l in list)
                {
                    ListViewItem item = new ListViewItem(l[0]);
                    item.SubItems.Add(l[1]);
                    regionlist.Items.Add(item);
                }
                mousechoice.Checked = false;
                regioncode.Text = null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }
        }

        private void regionlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(regionlist.SelectedIndices.Count <=0)
            {
                return;
            }
            int intselectedinex = regionlist.SelectedIndices[0];
            if(intselectedinex >= 0)
            {
                buttonUpdate.Enabled = true;
                gmap.Overlays.Clear();
                String code = regionlist.Items[intselectedinex].Text;
                String requestRegionsList = "http://localhost:5225/regions/GetRegionByCode/" + code;
                HttpWebRequest webRequestRegionsList = (HttpWebRequest)WebRequest.Create(@requestRegionsList);
                HttpWebResponse webResponseRegionsList = (HttpWebResponse)webRequestRegionsList.GetResponse();
                string workersContent = new StreamReader(webResponseRegionsList.GetResponseStream()).ReadToEnd();
                Region region = JsonSerializer.Deserialize<Region>(workersContent);



                String requestRegionsPinsList = "http://localhost:5225/regionPins/GetRegionPinByRegionId/" + region.id;
                HttpWebRequest webRequestRegionsPinsList = (HttpWebRequest)WebRequest.Create(@requestRegionsPinsList);
                HttpWebResponse webResponseRegionsPinsList = (HttpWebResponse)webRequestRegionsPinsList.GetResponse();
                string regionPinsContent = new StreamReader(webResponseRegionsPinsList.GetResponseStream()).ReadToEnd();
                List<RegionPins> regionPins  = JsonSerializer.Deserialize<List<RegionPins>>(regionPinsContent);

                List<PointLatLng> points = new List<PointLatLng>();
                foreach(RegionPins pin in regionPins)
                {
                    PointLatLng pll = new PointLatLng()
                    {
                        Lat = pin.x,
                        Lng = pin.y,
                    };
                    points.Add(pll);
                }
                double maxlatx = points.Max(x => x.Lat);
                double minlatx = points.Min(x => x.Lat);
                double maxlngx = points.Max(x => x.Lng);
                double minlngx = points.Min(x => x.Lng);

                PointLatLng maxpll = new PointLatLng()
                {
                    Lat = (maxlatx+minlatx)/2,
                    Lng = (maxlngx + minlngx)/2
                };

                var polygon = new GMapPolygon(points, code)
                {
                    Stroke = new Pen(Color.Red, 3),
                   Fill = new SolidBrush(Color.Transparent)
                    
                };
                var polygons = new GMapOverlay("polygons");
                polygons.Polygons.Add(polygon);
                gmap.Overlays.Add(polygons);
                gmap.Refresh();
                gmap.Zoom -= 1;
                gmap.Zoom += 1;
                gmap.Position = maxpll;
                
            }
            else
            {
                
            }
        }

        private void regionlist_Click(object sender, EventArgs e)
        {
            
                buttonUpdate.Enabled = true;
                deleteRegionButton.Enabled = true;
            
        }


        

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(comboBoxWorkers.SelectedItem == null)
            {
                MessageBox.Show("Pusty Wybór!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var selectedCourierId = comboBoxWorkers.SelectedIndex;
                var selectedRegionId = regionlist.SelectedIndices[0];
                var CourierId = Int16.Parse(courierids[selectedCourierId]);
                var RegionId = Int16.Parse(regionids[selectedRegionId]);


      
                String requestRegionsUpdate = "http://localhost:5225/regions/UpdateRegionByCourier/" + RegionId.ToString();
                using (var client = new HttpClient())
                {
                    var content = new StringContent(CourierId.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(requestRegionsUpdate, content);


                }
               

            }
        }

        private async void deleteRegionButton_Click(object sender, EventArgs e)
        {
            var selectedRegionId = regionlist.SelectedIndices[0];
            var RegionId = regionids[selectedRegionId];
            String requestRegionsDelete = "http://localhost:5225/regions/DeleteRegionById/" + RegionId;
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(requestRegionsDelete);
            }
            MessageBox.Show("Pomyślnie usunięto Region");
            coordinates.Clear();
            gmap.Overlays.Clear();
            gmap.Refresh();
            deleteRegionButton.Enabled = false;
            load_Regions();
        }

        private void workersbuttonid_Click(object sender, EventArgs e)
        {
            String workerid = workerssearchid.Text;
            if (workerssearchid.Text == "")
            {
                string message = "Jezeli chcesz wyszukac, podaj id pracownika!";

                MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {

      


                String requestWorkers = "http://localhost:5225/Users/GetAllWorkers/";
                HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                User[] filteredUserById = user.Where(u => u.id == Int16.Parse(workerid)).ToArray();
                List<List<string>> list = new List<List<string>>();
                for (int i = 0; i < filteredUserById.Length; i++)
                {
                    list.Add(new List<string> { filteredUserById[i].id.ToString(), filteredUserById[i].name, filteredUserById[i].surname, filteredUserById[i].role.ToString() == "0" ? "Koordynator" : "Kurier",
                        filteredUserById[i].loginCredentials.login.ToString(),filteredUserById[i].loginCredentials.password.ToString(),filteredUserById[i].phoneNumber,filteredUserById[i].loginCredentials.email.ToString()});


                }
                workerslist.Items.Clear();
                foreach (List<string> l in list)
                {
                    ListViewItem item = new ListViewItem(l[0]);
                    item.SubItems.Add(l[1]);
                    item.SubItems.Add(l[2]);
                    item.SubItems.Add(l[3]);
                    item.SubItems.Add(l[4]);
                    item.SubItems.Add(l[5]);
                    item.SubItems.Add(l[6]);
                    item.SubItems.Add(l[7]);
                    workerslist.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }

        }

        private void workersbuttonsurname_Click(object sender, EventArgs e)
        {
            String workersurname = workerssearchsurname.Text;
            if (workerssearchsurname.Text == "")
            {
                string message = "Jezeli chcesz wyszukac, podaj nazwisko pracownika!";

                MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                String requestWorkers = "http://localhost:5225/Users/GetAllWorkers/";
                HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                User[] filteredUserBySurname = user.Where(u => u.surname == workersurname).ToArray();
                List<List<string>> list = new List<List<string>>();
                for (int i = 0; i < filteredUserBySurname.Length; i++)
                {
                    list.Add(new List<string> { filteredUserBySurname[i].id.ToString(), filteredUserBySurname[i].name, filteredUserBySurname[i].surname, filteredUserBySurname[i].role.ToString() == "0" ? "Koordynator" : "Kurier",
                        filteredUserBySurname[i].loginCredentials.login.ToString(),filteredUserBySurname[i].loginCredentials.password.ToString(),filteredUserBySurname[i].phoneNumber,filteredUserBySurname[i].loginCredentials.email.ToString()});


                }
                workerslist.Items.Clear();
                foreach (List<string> l in list)
                {
                    ListViewItem item = new ListViewItem(l[0]);
                    item.SubItems.Add(l[1]);
                    item.SubItems.Add(l[2]);
                    item.SubItems.Add(l[3]);
                    item.SubItems.Add(l[4]);
                    item.SubItems.Add(l[5]);
                    item.SubItems.Add(l[6]);
                    item.SubItems.Add(l[7]);
                    workerslist.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("BLAD!" + ex);
            }
        }
        private void Workersbuttonoption_Click(object sender, EventArgs e)
        {
            if(workersoption.SelectedIndex == 0)
            {
                String workerlogin = workerssearchoption.Text;
                if (workerssearchoption.Text == "")
                {
                    string message = "Pole nie moze byc puste!";

                    MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        String requestWorkers = "http://localhost:5225/Users/GetAllWorkers/";
                        HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                        HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                        string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                        User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                        User[] filteredUserByLogin = user.Where(u => u.loginCredentials.login == workerlogin).ToArray();
                        List<List<string>> list = new List<List<string>>();
                        for (int i = 0; i < filteredUserByLogin.Length; i++)
                        {
                            list.Add(new List<string> { filteredUserByLogin[i].id.ToString(), filteredUserByLogin[i].name, filteredUserByLogin[i].surname, filteredUserByLogin[i].role.ToString() == "0" ? "Koordynator" : "Kurier",
                        filteredUserByLogin[i].loginCredentials.login.ToString(),filteredUserByLogin[i].loginCredentials.password.ToString(),filteredUserByLogin[i].phoneNumber,filteredUserByLogin[i].loginCredentials.email.ToString()});


                        }
                        workerslist.Items.Clear();
                        foreach (List<string> l in list)
                        {
                            ListViewItem item = new ListViewItem(l[0]);
                            item.SubItems.Add(l[1]);
                            item.SubItems.Add(l[2]);
                            item.SubItems.Add(l[3]);
                            item.SubItems.Add(l[4]);
                            item.SubItems.Add(l[5]);
                            item.SubItems.Add(l[6]);
                            item.SubItems.Add(l[7]);
                            workerslist.Items.Add(item);
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("BLAD!" + ex);
                    }
                }

            }
            else if(workersoption.SelectedIndex == 1)
            {
                String workername = workerssearchoption.Text;
                if (workerssearchoption.Text == "")
                {
                    string message = "Pole nie moze byc puste!";

                    MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        String requestWorkers = "http://localhost:5225/Users/GetAllWorkers/";
                        HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                        HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                        string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                        User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                        User[] filteredUserByName = user.Where(u => u.name == workername).ToArray();
                        List<List<string>> list = new List<List<string>>();
                        for (int i = 0; i < filteredUserByName.Length; i++)
                        {
                            list.Add(new List<string> { filteredUserByName[i].id.ToString(), filteredUserByName[i].name, filteredUserByName[i].surname, filteredUserByName[i].role.ToString() == "0" ? "Koordynator" : "Kurier",
                        filteredUserByName[i].loginCredentials.login.ToString(),filteredUserByName[i].loginCredentials.password.ToString(),filteredUserByName[i].phoneNumber,filteredUserByName[i].loginCredentials.email.ToString()});


                        }
                        workerslist.Items.Clear();
                        foreach (List<string> l in list)
                        {
                            ListViewItem item = new ListViewItem(l[0]);
                            item.SubItems.Add(l[1]);
                            item.SubItems.Add(l[2]);
                            item.SubItems.Add(l[3]);
                            item.SubItems.Add(l[4]);
                            item.SubItems.Add(l[5]);
                            item.SubItems.Add(l[6]);
                            item.SubItems.Add(l[7]);
                            workerslist.Items.Add(item);
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("BLAD!" + ex);
                    }
                }
            }
            else if (workersoption.SelectedIndex == 2)
            {
                String workermail = workerssearchoption.Text;
                if (workerssearchoption.Text == "")
                {
                    string message = "Pole nie moze byc puste!";

                    MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        String requestWorkers = "http://localhost:5225/Users/GetAllWorkers/";
                        HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                        HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                        string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                        User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                        User[] filteredUserByEmail = user.Where(u => u.loginCredentials.email == workermail).ToArray();
                        List<List<string>> list = new List<List<string>>();
                        for (int i = 0; i < filteredUserByEmail.Length; i++)
                        {
                            list.Add(new List<string> { filteredUserByEmail[i].id.ToString(), filteredUserByEmail[i].name, filteredUserByEmail[i].surname, filteredUserByEmail[i].role.ToString() == "0" ? "Koordynator" : "Kurier",
                        filteredUserByEmail[i].loginCredentials.login.ToString(),filteredUserByEmail[i].loginCredentials.password.ToString(),filteredUserByEmail[i].phoneNumber,filteredUserByEmail[i].loginCredentials.email.ToString()});


                        }
                        workerslist.Items.Clear();
                        foreach (List<string> l in list)
                        {
                            ListViewItem item = new ListViewItem(l[0]);
                            item.SubItems.Add(l[1]);
                            item.SubItems.Add(l[2]);
                            item.SubItems.Add(l[3]);
                            item.SubItems.Add(l[4]);
                            item.SubItems.Add(l[5]);
                            item.SubItems.Add(l[6]);
                            item.SubItems.Add(l[7]);
                            workerslist.Items.Add(item);
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("BLAD!" + ex);
                    }
                }

            }
            else if (workersoption.SelectedIndex == 3)
            {
                String workerphone = workerssearchoption.Text;
                if (workerssearchoption.Text == "")
                {
                    string message = "Pole nie moze byc puste!";

                    MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        String requestWorkers = "http://localhost:5225/Users/GetAllWorkers/";
                        HttpWebRequest webRequestWorkers = (HttpWebRequest)WebRequest.Create(@requestWorkers);
                        HttpWebResponse webResponeWorkers = (HttpWebResponse)webRequestWorkers.GetResponse();
                        string workersContent = new StreamReader(webResponeWorkers.GetResponseStream()).ReadToEnd();
                        User[] user = JsonSerializer.Deserialize<User[]>(workersContent);
                        User[] filteredUserByPhone = user.Where(u => u.phoneNumber == workerphone).ToArray();
                        List<List<string>> list = new List<List<string>>();
                        for (int i = 0; i < filteredUserByPhone.Length; i++)
                        {
                            list.Add(new List<string> { filteredUserByPhone[i].id.ToString(), filteredUserByPhone[i].name, filteredUserByPhone[i].surname, filteredUserByPhone[i].role.ToString() == "0" ? "Koordynator" : "Kurier",
                        filteredUserByPhone[i].loginCredentials.login.ToString(),filteredUserByPhone[i].loginCredentials.password.ToString(),filteredUserByPhone[i].phoneNumber,filteredUserByPhone[i].loginCredentials.email.ToString()});


                        }
                        workerslist.Items.Clear();
                        foreach (List<string> l in list)
                        {
                            ListViewItem item = new ListViewItem(l[0]);
                            item.SubItems.Add(l[1]);
                            item.SubItems.Add(l[2]);
                            item.SubItems.Add(l[3]);
                            item.SubItems.Add(l[4]);
                            item.SubItems.Add(l[5]);
                            item.SubItems.Add(l[6]);
                            item.SubItems.Add(l[7]);
                            workerslist.Items.Add(item);
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("BLAD!" + ex);
                    }
                }
            }
            else
            {
                string message = "Jezeli chcesz wyszukac, wybierz jakas opcje!!";

                MessageBox.Show(message, "BLAD!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        

      
    }
    
}