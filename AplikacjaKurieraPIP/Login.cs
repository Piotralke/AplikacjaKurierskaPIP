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
            String requestString = "http://localhost:5225/api/GetUserByLogin/" + login;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@requestString);
            try 
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(content);
                User user = JsonSerializer.Deserialize<User>(content);
                if (user.password == passBox.Text && user.role == 1)
                {
                    this.Hide();
                    Main main = new Main(user);
                    main.Show();
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
