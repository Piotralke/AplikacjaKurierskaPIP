using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikacjaKordynatora.Models;
using System.Text.Json;

namespace AplikacjaKurieraPIP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            loginBox.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = loginBox.Text;
			String requestCredentials = "http://localhost:5225/loginCredentials/GetLoginCredentialsByLogin/" + login;
			HttpWebRequest credentialsRequest = (HttpWebRequest)WebRequest.Create(@requestCredentials);
			try
			{
				HttpWebResponse credentialsResponse = (HttpWebResponse)credentialsRequest.GetResponse();
				string credentialsContent = new StreamReader(credentialsResponse.GetResponseStream()).ReadToEnd();
				loginCredentials credentials = JsonSerializer.Deserialize<loginCredentials>(credentialsContent);
				Console.WriteLine(credentialsContent);
				if (passBox.Text == credentials.password)
				{
					String requestUser = "http://localhost:5225/Users/GetUserByLogin/" + login;
					HttpWebRequest userRequest = (HttpWebRequest)WebRequest.Create(@requestUser);
					HttpWebResponse userResponse = (HttpWebResponse)userRequest.GetResponse();
					string userContent = new StreamReader(userResponse.GetResponseStream()).ReadToEnd();
					Console.WriteLine(userContent);
					User user = JsonSerializer.Deserialize<User>(userContent);

					if (user.role == 1)
                    {
						this.Hide();
						Main main = new Main(user);
						main.Show();
					}
						
                }
            }
            catch
            {
                MessageBox.Show("Niepoprawna nazwa uzytkownika lub haslo, sprobuj ponownie");
                loginBox.Clear();
                passBox.Clear();
                loginBox.Focus();
            }
        }
    }
}
