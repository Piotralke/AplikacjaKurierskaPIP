using AplikacjaKordynatora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        private HomeForm homeForm;
        public RegisterForm(HomeForm homeForm)
        {
            InitializeComponent();
            this.homeForm = homeForm;  
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm(homeForm);
            loginForm.Show();
        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            String login = textLogin.Text;
            String email = textEmail.Text;
            String requestCredentials = "http://localhost:5225/loginCredentials";
            HttpWebRequest credentialsRequest = (HttpWebRequest)WebRequest.Create(@requestCredentials);
            HttpWebResponse credentialsResponse = (HttpWebResponse)credentialsRequest.GetResponse();
            string credentialsContent = new StreamReader(credentialsResponse.GetResponseStream()).ReadToEnd();
            List<loginCredentials> credential = JsonSerializer.Deserialize<List<loginCredentials>>(credentialsContent);
            bool isOkay = true;
            loginCredentials checkLogin = credential.Find(x => x.login == login);
            loginCredentials checkEmail = credential.Find(x => x.email == email);
            if (textPassword.Text != textRepeatPassword.Text)
            {
                isOkay = false;
                MessageBox.Show("Hasła nie są identyczne", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(checkLogin != null)
            {
                MessageBox.Show("Login jest już zajęty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(checkEmail != null)
            {
                MessageBox.Show("Istnieje konto o podanym adresie e-mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Address address = new Address()
                {
                    id = 0,
                    street = textStreet.Text,
                    city = textCity.Text,
                    houseNumber = textApartamentNumber.Text == "" ? textBuildingNumber.Text : textBuildingNumber.Text + "/" + textApartamentNumber.Text,
                    zipCode = textZipCode.Text,
                };
                loginCredentials credentials = new loginCredentials()
                {
                    id = 0,
                    email = textEmail.Text,
                    login = textLogin.Text,
                    password = textPassword.Text,
                };
                User user = new User()
                {
                    id = 0,
                    name = textName.Text,
                    surname = textSurname.Text,
                    loginCredentials = credentials,
                    role = 2,
                    defaultAddress = address,
                    phoneNumber = textPhone.Text
                };
                ValidationContext UserValidation = new ValidationContext(user, null, null);
                ValidationContext addressValidation = new ValidationContext(address, null, null);
                ValidationContext credentialsValidation = new ValidationContext(credentials, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(address, addressValidation, errors, true))
                {
                    isOkay = false;
                }
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
                    String request = "http://localhost:5225/Users";
                    String json = JsonSerializer.Serialize(user);
                    using (var streamWriter = new HttpClient())
                    {
                        var response = await streamWriter.PostAsync(request, new StringContent(json, Encoding.UTF8, "application/json"));

                    }
                    MessageBox.Show("Rejestracja przebiegła pomyślnie");
                    this.Close();  
                }
            }
		}
    }
}
