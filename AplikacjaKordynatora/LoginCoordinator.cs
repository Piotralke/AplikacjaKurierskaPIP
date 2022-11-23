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
            String requestString = "http://localhost:5225/api/GetUserByLogin/" + login;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@requestString);
         
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(content);
                User user = JsonSerializer.Deserialize<User>(content);
                if (passbox.Text == user.password && user.role == 2)
                {
                    this.Hide();

                    CoordinatorHome coordinatorhome = new CoordinatorHome(user);
                    coordinatorhome.Show();
                    
                }
            }
            catch
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
            }

        }

 
    }
}
