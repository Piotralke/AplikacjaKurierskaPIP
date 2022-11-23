using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikacjaKordynatora.Models;

namespace AplikacjaKordynatora
{
    public partial class CoordinatorHome : Form
    {
        public CoordinatorHome(User user)
        {
            InitializeComponent();
            loggedlabel.Text = user.login;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void province1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void courierslist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CoordinatorHome_Load(object sender, EventArgs e)
        {

        }
    }
}
