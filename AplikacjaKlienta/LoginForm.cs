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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Close();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (textUserName.Text == "spychu" && textPassword.Text == "123")
            {
                this.Hide();
                ClientHomeForm clientHomeForm = new ClientHomeForm();
                clientHomeForm.Show();
            }
            else
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
