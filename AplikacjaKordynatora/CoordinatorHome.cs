using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            registerseat.Text = "Kurier";
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
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var randompassword = new String(stringChars);
            bool isOkay = true;
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
                role = registerseat.Text=="Kurier"?1:0,
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
              



            }
        }
    }
}
