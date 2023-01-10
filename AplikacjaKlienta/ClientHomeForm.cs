using AplikacjaKordynatora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ClientHomeForm : Form
    {
        public string generateNumber()
        {
            return "placeholder";
        }
        List<Panel> panelList = new List<Panel>();
        User loggedUser;
        public ClientHomeForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            label1.Text = user.loginCredentials.login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelList[0].BringToFront();
            button1.BackColor = Color.Teal;
            button2.BackColor = Color.DarkCyan;
        }
        private void ClientHomeForm_Load(object sender, EventArgs e)
        {
            panelList.Add(panelTrack);
            panelList.Add(panelSend);
            panelList[0].BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelList[1].BringToFront();
            button1.BackColor = Color.DarkCyan;
            button2.BackColor = Color.Teal;
        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            textBoxName.Text = loggedUser.name;
            textBoxSurname.Text = loggedUser.surname;
            textBoxZip.Text = loggedUser.defaultAddress.zipCode;
            textBoxCity.Text = loggedUser.defaultAddress.city;
            textBoxStreet.Text = loggedUser.defaultAddress.street;
            textBoxNumber.Text = loggedUser.defaultAddress.houseNumber;
            textBoxEmail.Text = loggedUser.loginCredentials.email;
            textBoxPhoneNum.Text = loggedUser.phoneNumber;
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {

            String phoneNumber = textReceiverPhone.Text;
            String requestUser = "http://localhost:5225/Users";
            HttpWebRequest userRequest = (HttpWebRequest)WebRequest.Create(@requestUser);
            HttpWebResponse userResponse = (HttpWebResponse)userRequest.GetResponse();
            string userContent = new StreamReader(userResponse.GetResponseStream()).ReadToEnd();
            List<User> user = JsonSerializer.Deserialize<List<User>>(userContent);
            User checkAccount = user.Find(x => x.phoneNumber == phoneNumber);

            String streetReceiver = textReceiverStreet.Text;
            String cityReceiver = textReceiverCity.Text;
            String homeNumberReceiver = textReceiverHomeNumber.Text;
            String zipReceiver = textReceiverZip.Text;

            String streetSender = textBoxStreet.Text;
            String citySender = textBoxCity.Text;
            String homeNumberSender = textBoxNumber.Text;
            String zipSender = textBoxZip.Text;

            String request = "http://localhost:5225/Address/";
            HttpWebRequest addressRequest = (HttpWebRequest)WebRequest.Create(@request);
            HttpWebResponse addressResponse = (HttpWebResponse)addressRequest.GetResponse();
            string addressContent = new StreamReader(addressResponse.GetResponseStream()).ReadToEnd();
            List<Address> addressList = JsonSerializer.Deserialize<List<Address>>(addressContent);
            Address senderAddress = addressList.Find(x => x.street == streetSender && x.city == citySender && x.houseNumber == homeNumberSender && x.zipCode == zipSender);
            Address receiverAddress = addressList.Find(x => x.street == streetReceiver && x.city == cityReceiver && x.houseNumber == homeNumberReceiver && x.zipCode == zipReceiver);

            int receiverId;
            int receiverAddressId = 0;
            int senderAddressId = 0;
            User user1;
            Address address1 = null;
            Address address2 = null;
            if (senderAddress == null)
            {
                senderAddressId = 0;
                Address address = new Address()
                {
                    street = textBoxStreet.Text,
                    city = textBoxCity.Text,
                    houseNumber = textBoxNumber.Text,
                    zipCode = textBoxZip.Text,
                };
                address1 = address;
            }
            else
            {
                address1 = null;
                senderAddressId = senderAddress.id;
            }
            if (receiverAddress == null)
            {
                receiverAddressId = 0;
                Address address = new Address()
                {
                    street = textReceiverStreet.Text,
                    city = textReceiverCity.Text,
                    houseNumber = textReceiverHomeNumber.Text,
                    zipCode = textReceiverZip.Text,
                };
                address2 = address;
            }
            else
            {
                address2 = null;
                receiverAddressId = receiverAddress.id;
            }
            if (checkAccount == null)
            {
                receiverId = 0;

                User newUser = new User()
                {
                    id = 0,
                    name = textReceiverName.Text,
                    surname = textReceiverSurname.Text,
                    role = 2,
                    phoneNumber = textReceiverPhone.Text
                };
                user1 = newUser;

            }
            else
            {
                receiverId = checkAccount.id;
                user1 = null;
            }

            float weight = float.Parse(textBoxWeight.Text, CultureInfo.InvariantCulture.NumberFormat);
            float width = float.Parse(textBoxWidth.Text, CultureInfo.InvariantCulture.NumberFormat);
            float depth = float.Parse(textBoxDepth.Text, CultureInfo.InvariantCulture.NumberFormat);
            float heigth = float.Parse(textBoxHeigth.Text, CultureInfo.InvariantCulture.NumberFormat);


            Package package = new Package()
            {
                id = 0,
                number = generateNumber(),
                ReceiverId = receiverId,
                Receiver = user1,
                receiverAddressId = receiverAddressId,
                receiverAddress=address2,
                SenderId = loggedUser.id,
                senderAddressId = senderAddressId,
                senderAddress=address1,
                weight = weight,
                width = width,
                depth = depth,
                heigth = heigth,
                description = textBoxDescription.Text,
                isStandardShape = radioButton1.Checked ? true : false,
                CODcost = 0.0f,

            };
            //String AddPackage = "http://localhost:5225/packages";
            //String packageJson = JsonSerializer.Serialize(package);
            //using (var streamWriter = new HttpClient())
            //{
            //    var response = await streamWriter.PostAsync(AddPackage, new StringContent(packageJson, Encoding.UTF8, "application/json"));

            //}

            Order order = new Order()
            {
                id = 0,
                package = package,
                price = 0.0f,
                courier=null,

            };
            //statusNames statusNames = new statusNames()
            //{
            //    id = 0,
            //    name = "Utworzono zlecenie nadania"
            //};

            int packageId;
            String addOrder = "http://localhost:5225/orders";
            String json = JsonSerializer.Serialize(order);
            using (var streamWriter = new HttpClient())
            {
                var response = await streamWriter.PostAsync(addOrder, new StringContent(json, Encoding.UTF8, "application/json"));
                var jString = response.Content.ReadAsStringAsync();
                Order resultOrder = JsonSerializer.Deserialize<Order>(jString.Result);
                Console.WriteLine(resultOrder.packageId);
                packageId=resultOrder.packageId;
            }

            Status status = new Status()
            {
                Id = 0,
                idStatusName = 4,
                idPackage = packageId,
                date = DateTime.Now
            };


            String addStatus = "http://localhost:5225/statuses";
            String json2 = JsonSerializer.Serialize(status);
            using (var streamWriter = new HttpClient())
            {
                var response = await streamWriter.PostAsync(addStatus, new StringContent(json2, Encoding.UTF8, "application/json"));

            }

            MessageBox.Show("Dodano paczki");

        }
    }
}
