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
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikacjaKordynatora.Models;

namespace AplikacjaKordynatora
{
    public partial class CoordinatorHome : Form
    {

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
            packageslist.GridLines = true;
            workerslist.GridLines = true;
            schemeworkerslist.GridLines = true;
        }



        private void Workersbuttonoption_Click(object sender, EventArgs e)
        {

            if (workersoption.Text == "Loginie")
            {
                string workerlogin = workerssearchoption.Text;

            }
            if (workersoption.Text == "Imieniu")
            {
                string workername = workerssearchoption.Text;

            }
            if (workersoption.Text == "E-mailu")
            {
                string workermail = workerssearchoption.Text;

            }
            if (workersoption.Text == "Numerze Telefonu")
            {
                string workerphone = workerssearchoption.Text;
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
                list.Add(new List<string> { packages.id.ToString(), packages.number,packages.ReceiverId.ToString(),packages.receiverAddressId.ToString(),
                packages.SenderId.ToString(),packages.senderAddressId.ToString(),packages.weight.ToString(), packages.width.ToString(), packages.depth.ToString(),packages.heigth.ToString(),
                packages.description,packages.isStandardShape.ToString(), packages.CODcost.ToString()});

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

            packageslist.Items.Clear();
         
            
            
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
                    
                    list.Add(new List<string> { packages[i].id.ToString(), packages[i].number,packages[i].ReceiverId.ToString(),packages[i].receiverAddressId.ToString(),
                     packages[i].SenderId.ToString(),packages[i].senderAddressId.ToString(),packages[i].weight.ToString(), packages[i].width.ToString(), packages[i].depth.ToString(),packages[i].heigth.ToString(),
                     packages[i].description,packages[i].isStandardShape.ToString(), packages[i].CODcost.ToString()});

                 
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

        private void workersshowall_Click(object sender, EventArgs e)
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
                    list.Add(new List<string> { user[i].id.ToString(), user[i].name, user[i].surname, user[i].role.ToString(),
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

        private void workersrefreshbutton_Click(object sender, EventArgs e)
        {
            workerslist.Items.Clear();
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
                    list.Add(new List<string> {user[i].id.ToString(), user[i].name, user[i].surname, user[i].role.ToString(), user[i].defaultAddress.city.ToString(),
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
    }
    
}