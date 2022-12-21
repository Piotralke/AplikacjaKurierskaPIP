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
            String requestString = "http://localhost:5225/api/GetUserByLogin/" + login;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@requestString);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(content);
                User user = JsonSerializer.Deserialize<User>(content);
                if (user.loginCredentials.password == textPassword.Text && user.role == 2)
                {
                    this.Close();
                    
                    ClientHomeForm clientHomeForm = new ClientHomeForm(user.loginCredentials.login);
                    clientHomeForm.Show();
                    homeForm.Hide();
                }
            }
            catch
            {
                if (textUserName.Text == "" || textPassword.Text == "")
                {
                    MessageBox.Show("Nalezy podac wszystkie dane");
                    textUserName.Clear();
                    textPassword.Clear();
                    textUserName.Focus();
                }
                else
                {
                    MessageBox.Show("Niepoprawna nazwa uzytkownika lub haslo, sprobuj ponownie");
                    textUserName.Clear();
                    textPassword.Clear();
                    textUserName.Focus();
                } 
            }
        }
    }
}
