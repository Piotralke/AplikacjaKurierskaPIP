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
            string dateTime = DateTime.Now.ToString("dd-MM-yyyy");
            Random random = new Random();
            string randomCode = "";
            int randomNumber = random.Next(0, 10);
            for (int i = 0; i < 10; i++)
            {
                randomNumber = random.Next(0, 10);
                randomCode += randomNumber.ToString();
            }
            randomCode += dateTime;
            return randomCode;
        }
        List<Panel> panelList = new List<Panel>();
        List<Panel> panelList2 = new List<Panel>();
        User loggedUser;
        public ClientHomeForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            label1.Text = user.loginCredentials.login;
            labelCostOfService.Text = "10.99";
            textBoxCOD.Text = "0.00";
        }

        private void ClientHomeForm_Load(object sender, EventArgs e)
        {
            panelList.Add(panelTrack);
            panelList.Add(panelSend);
            panelList.Add(panelProblem);
            panelList[0].BringToFront();

            panelList2.Add(panelEmpty);
            panelList2.Add(panelDamageDescription);
            panelList2.Add(panelLost);
            panelList2.Add(panelOther);
            panelList[0].BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panelList[0].BringToFront();
            button1.BackColor = Color.Teal;
            button2.BackColor = Color.DarkCyan;
            button3.BackColor = Color.DarkCyan;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelList[1].BringToFront();
            button1.BackColor = Color.DarkCyan;
            button2.BackColor = Color.Teal;
            button3.BackColor = Color.DarkCyan;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelList[2].BringToFront();
            button1.BackColor = Color.DarkCyan;
            button2.BackColor = Color.DarkCyan;
            button3.BackColor = Color.Teal;
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
            float CODcost = float.Parse(textBoxCOD.Text, CultureInfo.InvariantCulture.NumberFormat);

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
                isStandardShape = radioButtonStandard.Checked ? true : false,
                CODcost = CODcost

            };
            //String AddPackage = "http://localhost:5225/packages";
            //String packageJson = JsonSerializer.Serialize(package);
            //using (var streamWriter = new HttpClient())
            //{
            //    var response = await streamWriter.PostAsync(AddPackage, new StringContent(packageJson, Encoding.UTF8, "application/json"));

            //}
            float price = float.Parse(labelCostOfService.Text, CultureInfo.InvariantCulture.NumberFormat);
            Order order = new Order()
            {
                id = 0,
                package = package,
                price = price,
                courier =null,

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

        private void checkBoxCOD_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxCOD.Checked == true)
            {
                textBoxCOD.Enabled = true;
            }
            else
            {
                textBoxCOD.Enabled = false;
            }
        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {
            calculatePrice(labelCostOfService, textBoxWeight, radioButtonStandard, radioButtonCustom);
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrice(labelCostOfService, textBoxWeight, radioButtonStandard, radioButtonCustom);
        }

        private void calculatePrice(Label labelCostOfService ,TextBox weight, RadioButton radioButtonStnadard, RadioButton radioButtonCustom)
        {
            double costOfServiceValue = 10.99;
            double weightValue;
            
            if(double.TryParse(weight.Text, out weightValue) && weightValue < 0.5)
            {
                double.TryParse(labelCostOfService.Text, out costOfServiceValue);
                costOfServiceValue = 12.99;
            }
            else if ((double.TryParse(weight.Text, out weightValue) && weightValue >= 0.5) && (double.TryParse(weight.Text, out weightValue) && weightValue < 3.0))
            {
                double.TryParse(labelCostOfService.Text, out costOfServiceValue);
                costOfServiceValue = 13.99;
            }
            else if ((double.TryParse(weight.Text, out weightValue) && weightValue >= 3.0) && (double.TryParse(weight.Text, out weightValue) && weightValue < 10.0))
            {
                double.TryParse(labelCostOfService.Text, out costOfServiceValue);
                costOfServiceValue = 17.99;
            }
            else if ((double.TryParse(weight.Text, out weightValue) && weightValue >= 10.0))
            {
                double.TryParse(labelCostOfService.Text, out costOfServiceValue);
                costOfServiceValue = 26.99;
            }
            if(radioButtonCustom.Checked == true)
            {
                costOfServiceValue += 20.0;
            }
            labelCostOfService.Text = costOfServiceValue.ToString();
        }

        private void comboBoxTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTopic.SelectedIndex == 0)
            {
                panelList2[1].BringToFront();
            }
            else if (comboBoxTopic.SelectedIndex == 1)
            {
                panelList2[2].BringToFront();
            }
            else if (comboBoxTopic.SelectedIndex == 2)
            {
                panelList2[3].BringToFront();
            }
        }
    }
}
