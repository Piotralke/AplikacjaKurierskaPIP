using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
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
        }
        public CoordinatorHome()
        {
            InitializeComponent();
            
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

        private void workerseditbutton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("GBS");
        }

        private void workersrefreshbutton_Click(object sender, EventArgs e)
        {

          
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        

        private void registerbutton_Click(object sender, EventArgs e)
        {
            string email = registeremailbox.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (registernamebox.Text=="" || registersurnamebox.Text == "" || registerloginbox.Text == "" || registeremailbox.Text == "" || registerseat.Text == "")
            {
                MessageBox.Show("Nalezy podac wszystkie dane");
                registernamebox.Clear();
                registersurnamebox.Clear();
                registerloginbox.Clear();
                registeremailbox.Clear();
                
            }
            else
            {
                if(registerseat.Text == "Kurier")
                {
                    registernamebox.Clear();
                    registersurnamebox.Clear();
                    registerloginbox.Clear();
                    registeremailbox.Clear();
                   

                    string message = "Dodano nowego kuriera!";
                    string caption = "Sukces!";
                    MessageBox.Show(message,caption);
                }
                else if(registerseat.Text == "Koordynator")
                {
                    registernamebox.Clear();
                    registersurnamebox.Clear();
                    registerloginbox.Clear();
                    registeremailbox.Clear();

                    string message = "Dodano nowego koordynatora!";
                    string caption = "Sukces!";
                    MessageBox.Show(message, caption);
                    
                }
            }
        }
    }
}
