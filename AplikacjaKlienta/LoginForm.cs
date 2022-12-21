using AplikacjaKordynatora;
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
    public partial class LoginForm : Form
    {
        private HomeForm homeForm;
        public LoginForm(HomeForm homeForm)
        {
            InitializeComponent();
            this.homeForm = homeForm;
        }
        public LoginForm()
        {
            InitializeComponent();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Close();
            RegisterForm registerForm = new RegisterForm(homeForm);
            registerForm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            String login = textUserName.Text;
            String requestCredentials = "http://localhost:5225/loginCredentials/GetLoginCredentialsByLogin/" + login;
            HttpWebRequest credentialsRequest = (HttpWebRequest)WebRequest.Create(@requestCredentials);
            try
            {
                HttpWebResponse credentialsResponse = (HttpWebResponse)credentialsRequest.GetResponse();
                string credentialsContent = new StreamReader(credentialsResponse.GetResponseStream()).ReadToEnd();
                loginCredentials credentials = JsonSerializer.Deserialize<loginCredentials>(credentialsContent);
                Console.WriteLine(credentialsContent);
                if (credentials.password == textPassword.Text)
                {
                    String requestUser = "http://localhost:5225/Users/GetUserByLogin/" + login;
                    HttpWebRequest userRequest = (HttpWebRequest)WebRequest.Create(@requestUser);
                    HttpWebResponse userResponse = (HttpWebResponse)userRequest.GetResponse();
                    string userContent = new StreamReader(userResponse.GetResponseStream()).ReadToEnd();
                    Console.WriteLine(userContent);
                    User user = JsonSerializer.Deserialize<User>(userContent);
                    if(user.role == 2)
                    {
                        this.Close();

                        ClientHomeForm clientHomeForm = new ClientHomeForm(user);
                        clientHomeForm.Show();
                        homeForm.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Niepoprawna nazwa uzytkownika lub haslo, sprobuj ponownie");
                    textUserName.Clear();
                    textPassword.Clear();
                    textUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                if (textUserName.Text == "" || textPassword.Text == "")
                {
                    MessageBox.Show("Nalezy podac wszystkie dane");
                    textUserName.Clear();
                    textPassword.Clear();
                    textUserName.Focus();
                }
                
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
