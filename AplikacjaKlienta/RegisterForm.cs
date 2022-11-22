using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (textName.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show("Nalezy podac wszystkie dane");
            }
        }
    }
}
