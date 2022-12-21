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

namespace WindowsFormsApp1
{
    public partial class ClientHomeForm : Form
    {
        public string generateNumber()
        {
            return "twojastara";
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

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            String phoneNumber = textReceiverPhone.Text;
            String requestCredentials = "http://localhost:5225/";
            HttpWebRequest userRequest = (HttpWebRequest)WebRequest.Create(@requestCredentials);
            HttpWebResponse userResponse = (HttpWebResponse)userRequest.GetResponse();
            string userContent = new StreamReader(userResponse.GetResponseStream()).ReadToEnd();
            List<loginCredentials> user = JsonSerializer.Deserialize<List<loginCredentials>>(userContent);
            loginCredentials checkAccount = user.Find(x => x.phoneNumber == phoneNumber);
            Package package = new Package()
            {
                id = 0,
                number = generateNumber(),
                ReceiverId = 0,
                Receiver
            }
        }
    }
}
