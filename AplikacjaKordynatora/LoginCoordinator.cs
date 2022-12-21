using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikacjaKordynatora.Models;

namespace AplikacjaKordynatora
{
    public partial class LoginCoordinator : Form
    {
        public LoginCoordinator()
        {
            InitializeComponent();
            
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            String login = loginbox.Text;
            String requestCredentials = "http://localhost:5225/loginCredentials/GetLoginCredentialsByLogin/" + login;
            HttpWebRequest credentialsRequest = (HttpWebRequest)WebRequest.Create(@requestCredentials);
            try
            {
                HttpWebResponse credentialsResponse = (HttpWebResponse)credentialsRequest.GetResponse();
                string credentialsContent = new StreamReader(credentialsResponse.GetResponseStream()).ReadToEnd();
                loginCredentials credentials = JsonSerializer.Deserialize<loginCredentials>(credentialsContent);
                if (passbox.Text == credentials.password)
                {
                    String requestUser = "http://localhost:5225/Users/GetUserByLogin/" + login;
                    HttpWebRequest userRequest = (HttpWebRequest)WebRequest.Create(@requestUser);
                    HttpWebResponse userResponse = (HttpWebResponse)userRequest.GetResponse();
                    string userContent = new StreamReader(userResponse.GetResponseStream()).ReadToEnd();
                    User user = JsonSerializer.Deserialize<User>(userContent);

                    if (user.role==0)
                    {
                        this.Hide();

                        CoordinatorHome coordinatorhome = new CoordinatorHome(credentials);
                        coordinatorhome.Show();
                    }
                }
            }
            catch(Exception ex) 
            {
                if (loginbox.Text == "" || passbox.Text == "")
                {
                    MessageBox.Show("Nalezy podac wszystkie dane");
                    loginbox.Clear();
                    passbox.Clear();
                    loginbox.Focus();
                }
                else
                {
                    MessageBox.Show("Niepoprawna nazwa uzytkownika lub haslo, sprobuj ponownie");
                    loginbox.Clear();
                    passbox.Clear();
                    loginbox.Focus();
                }
                Console.WriteLine(ex.ToString());
            }

        }

 
    }
}
