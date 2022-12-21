namespace WindowsFormsApp1
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.registerButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textRepeatPassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textCity = new System.Windows.Forms.TextBox();
            this.textApartamentNumber = new System.Windows.Forms.TextBox();
            this.textBuildingNumber = new System.Windows.Forms.TextBox();
            this.textSurname = new System.Windows.Forms.TextBox();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textZipCode = new System.Windows.Forms.TextBox();
            this.textStreet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.DarkCyan;
            this.registerButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.White;
            this.registerButton.Location = new System.Drawing.Point(168, 451);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(119, 35);
            this.registerButton.TabIndex = 13;
            this.registerButton.Text = "Zarejestruj";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textEmail);
            this.panel1.Controls.Add(this.textRepeatPassword);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textCity);
            this.panel1.Controls.Add(this.textApartamentNumber);
            this.panel1.Controls.Add(this.textBuildingNumber);
            this.panel1.Controls.Add(this.textSurname);
            this.panel1.Controls.Add(this.textPhone);
            this.panel1.Controls.Add(this.textLogin);
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.textZipCode);
            this.panel1.Controls.Add(this.textStreet);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 448);
            this.panel1.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.DarkCyan;
            this.backButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(2, 2);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(66, 35);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Wróć";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(246, 202);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textEmail
            // 
            this.textEmail.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textEmail.Location = new System.Drawing.Point(145, 350);
            this.textEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(278, 33);
            this.textEmail.TabIndex = 11;
            // 
            // textRepeatPassword
            // 
            this.textRepeatPassword.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textRepeatPassword.Location = new System.Drawing.Point(145, 313);
            this.textRepeatPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textRepeatPassword.Name = "textRepeatPassword";
            this.textRepeatPassword.Size = new System.Drawing.Size(278, 33);
            this.textRepeatPassword.TabIndex = 10;
            this.textRepeatPassword.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(71, 241);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 28);
            this.label12.TabIndex = 0;
            this.label12.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 352);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-mail";
            // 
            // textCity
            // 
            this.textCity.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textCity.Location = new System.Drawing.Point(145, 165);
            this.textCity.Margin = new System.Windows.Forms.Padding(2);
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(278, 33);
            this.textCity.TabIndex = 6;
            // 
            // textApartamentNumber
            // 
            this.textApartamentNumber.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textApartamentNumber.Location = new System.Drawing.Point(331, 128);
            this.textApartamentNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textApartamentNumber.Name = "textApartamentNumber";
            this.textApartamentNumber.Size = new System.Drawing.Size(92, 33);
            this.textApartamentNumber.TabIndex = 5;
            // 
            // textBuildingNumber
            // 
            this.textBuildingNumber.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBuildingNumber.Location = new System.Drawing.Point(145, 128);
            this.textBuildingNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBuildingNumber.Name = "textBuildingNumber";
            this.textBuildingNumber.Size = new System.Drawing.Size(92, 33);
            this.textBuildingNumber.TabIndex = 4;
            // 
            // textSurname
            // 
            this.textSurname.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textSurname.Location = new System.Drawing.Point(145, 54);
            this.textSurname.Margin = new System.Windows.Forms.Padding(2);
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new System.Drawing.Size(278, 33);
            this.textSurname.TabIndex = 2;
            // 
            // textPhone
            // 
            this.textPhone.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textPhone.Location = new System.Drawing.Point(145, 387);
            this.textPhone.Margin = new System.Windows.Forms.Padding(2);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(278, 33);
            this.textPhone.TabIndex = 12;
            // 
            // textLogin
            // 
            this.textLogin.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textLogin.Location = new System.Drawing.Point(145, 239);
            this.textLogin.Margin = new System.Windows.Forms.Padding(2);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(278, 33);
            this.textLogin.TabIndex = 8;
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textPassword.Location = new System.Drawing.Point(145, 276);
            this.textPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(278, 33);
            this.textPassword.TabIndex = 9;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // textZipCode
            // 
            this.textZipCode.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textZipCode.Location = new System.Drawing.Point(145, 202);
            this.textZipCode.Margin = new System.Windows.Forms.Padding(2);
            this.textZipCode.Name = "textZipCode";
            this.textZipCode.Size = new System.Drawing.Size(92, 33);
            this.textZipCode.TabIndex = 7;
            // 
            // textStreet
            // 
            this.textStreet.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textStreet.Location = new System.Drawing.Point(145, 91);
            this.textStreet.Margin = new System.Windows.Forms.Padding(2);
            this.textStreet.Name = "textStreet";
            this.textStreet.Size = new System.Drawing.Size(278, 33);
            this.textStreet.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(241, 130);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 28);
            this.label10.TabIndex = 0;
            this.label10.Text = "Nr lokalu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 130);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nr budynku";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(62, 167);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "Miasto";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textName.Location = new System.Drawing.Point(145, 17);
            this.textName.Margin = new System.Windows.Forms.Padding(2);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(278, 33);
            this.textName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(4, 204);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 28);
            this.label11.TabIndex = 0;
            this.label11.Text = "Kod pocztowy";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(76, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ulica";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(43, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nazwisko";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(81, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Imie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-2, 315);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Powtórz Hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(71, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hasło";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(57, 388);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Telefon";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(450, 497);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textZipCode;
        private System.Windows.Forms.TextBox textStreet;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBuildingNumber;
        private System.Windows.Forms.TextBox textSurname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRepeatPassword;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox textApartamentNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textPhone;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Label label12;
    }
}