using AplikacjaKordynatora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void registerButton_Click(object sender, EventArgs e)
        {
            bool isOkay = true;
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
                password = textPassword.Text
            };
			User user = new User()
            {
                id = 0,
                name = textName.Text,
                surname = textSurname.Text,
                loginCredentials =credentials,
                role = 2,
                defaultAddress = address,
                phoneNumber = textPhone.Text
            };
            ValidationContext UserValidation = new ValidationContext(user,null,null);
            ValidationContext addressValidation = new ValidationContext(address, null, null);
            ValidationContext credentialsValidation = new ValidationContext(credentials, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if(!Validator.TryValidateObject(address,addressValidation,errors,true))
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
            if(!isOkay)
            {
				foreach (ValidationResult result in errors)
				{
					MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}


    }
}
