using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ClientHomeForm : Form
    {
        List<Panel> panelList = new List<Panel>();
        public ClientHomeForm(string login)
        {
            InitializeComponent();
            label1.Text = login;
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
            //textBoxName.Text = data.Name;
            //textBoxSurname.Text = data.Name;
            //textBoxZip.Text = data.Name;
            //textBoxCity.Text = data.Name;
            //textBoxStreet.Text = data.Name;
            //textBoxNumber.Text = data.Name;
            //textBoxEmail.Text = data.Name;
            //textBoxPhoneNum.Text = data.Name;

            textBoxName.Text = "Dawid";
            textBoxSurname.Text = "Spychalski";
            textBoxZip.Text = "25-345";
            textBoxCity.Text = "Kielce";
            textBoxStreet.Text = "Mazurska";
            textBoxNumber.Text = "66/79";
            textBoxEmail.Text = "dawid.spychalski00@gamil.com";
            textBoxPhoneNum.Text = "731007454";
        }
    }
}
