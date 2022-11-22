namespace AplikacjaKordynatora
{
    partial class CoordinatorHome
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoordinatorHome));
            this.AdminPanel = new System.Windows.Forms.TabControl();
            this.HomePage = new System.Windows.Forms.TabPage();
            this.Jobs = new System.Windows.Forms.TabPage();
            this.Statistics = new System.Windows.Forms.TabPage();
            this.Reports = new System.Windows.Forms.TabPage();
            this.Notify = new System.Windows.Forms.TabPage();
            this.Payoff = new System.Windows.Forms.TabPage();
            this.Packages = new System.Windows.Forms.TabPage();
            this.Email = new System.Windows.Forms.TabPage();
            this.Register = new System.Windows.Forms.TabPage();
            this.Scheme = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.AdminPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminPanel
            // 
            this.AdminPanel.Controls.Add(this.HomePage);
            this.AdminPanel.Controls.Add(this.Jobs);
            this.AdminPanel.Controls.Add(this.Statistics);
            this.AdminPanel.Controls.Add(this.Reports);
            this.AdminPanel.Controls.Add(this.Notify);
            this.AdminPanel.Controls.Add(this.Payoff);
            this.AdminPanel.Controls.Add(this.Packages);
            this.AdminPanel.Controls.Add(this.Email);
            this.AdminPanel.Controls.Add(this.Register);
            this.AdminPanel.Controls.Add(this.Scheme);
            this.AdminPanel.ImageList = this.imageList1;
            this.AdminPanel.Location = new System.Drawing.Point(-4, -2);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Padding = new System.Drawing.Point(10, 8);
            this.AdminPanel.SelectedIndex = 0;
            this.AdminPanel.Size = new System.Drawing.Size(1151, 688);
            this.AdminPanel.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.AdminPanel.TabIndex = 3;
            // 
            // HomePage
            // 
            this.HomePage.BackColor = System.Drawing.Color.Silver;
            this.HomePage.ImageIndex = 0;
            this.HomePage.Location = new System.Drawing.Point(4, 33);
            this.HomePage.Name = "HomePage";
            this.HomePage.Padding = new System.Windows.Forms.Padding(1);
            this.HomePage.Size = new System.Drawing.Size(1143, 651);
            this.HomePage.TabIndex = 1;
            this.HomePage.Text = "Strona Główna";
            // 
            // Jobs
            // 
            this.Jobs.BackColor = System.Drawing.Color.Transparent;
            this.Jobs.Location = new System.Drawing.Point(4, 33);
            this.Jobs.Name = "Jobs";
            this.Jobs.Padding = new System.Windows.Forms.Padding(3);
            this.Jobs.Size = new System.Drawing.Size(1143, 651);
            this.Jobs.TabIndex = 0;
            this.Jobs.Text = "Zlecenia";
            // 
            // Statistics
            // 
            this.Statistics.BackColor = System.Drawing.Color.Transparent;
            this.Statistics.ImageIndex = 1;
            this.Statistics.Location = new System.Drawing.Point(4, 33);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(1143, 651);
            this.Statistics.TabIndex = 2;
            this.Statistics.Text = "Statystyki";
            // 
            // Reports
            // 
            this.Reports.BackColor = System.Drawing.Color.Transparent;
            this.Reports.ImageIndex = 2;
            this.Reports.Location = new System.Drawing.Point(4, 33);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(1143, 651);
            this.Reports.TabIndex = 3;
            this.Reports.Text = "Raporty";
            // 
            // Notify
            // 
            this.Notify.BackColor = System.Drawing.Color.Transparent;
            this.Notify.Location = new System.Drawing.Point(4, 33);
            this.Notify.Name = "Notify";
            this.Notify.Size = new System.Drawing.Size(1143, 651);
            this.Notify.TabIndex = 4;
            this.Notify.Text = "Zgłoszenia";
            // 
            // Payoff
            // 
            this.Payoff.BackColor = System.Drawing.Color.Transparent;
            this.Payoff.Location = new System.Drawing.Point(4, 33);
            this.Payoff.Name = "Payoff";
            this.Payoff.Size = new System.Drawing.Size(1143, 651);
            this.Payoff.TabIndex = 5;
            this.Payoff.Text = "Rozliczenia";
            // 
            // Packages
            // 
            this.Packages.BackColor = System.Drawing.Color.Transparent;
            this.Packages.ImageIndex = 3;
            this.Packages.Location = new System.Drawing.Point(4, 33);
            this.Packages.Name = "Packages";
            this.Packages.Size = new System.Drawing.Size(1143, 651);
            this.Packages.TabIndex = 6;
            this.Packages.Text = "Paczki";
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.Transparent;
            this.Email.Location = new System.Drawing.Point(4, 33);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(1143, 651);
            this.Email.TabIndex = 7;
            this.Email.Text = "Poczta";
            // 
            // Register
            // 
            this.Register.BackColor = System.Drawing.Color.Transparent;
            this.Register.Location = new System.Drawing.Point(4, 33);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(1143, 651);
            this.Register.TabIndex = 8;
            this.Register.Text = "Rejestracja Praconików";
            // 
            // Scheme
            // 
            this.Scheme.BackColor = System.Drawing.Color.Transparent;
            this.Scheme.Location = new System.Drawing.Point(4, 33);
            this.Scheme.Name = "Scheme";
            this.Scheme.Size = new System.Drawing.Size(1143, 651);
            this.Scheme.TabIndex = 9;
            this.Scheme.Text = "Harmongram Pracy";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home.png");
            this.imageList1.Images.SetKeyName(1, "statistics.png");
            this.imageList1.Images.SetKeyName(2, "reports.png");
            this.imageList1.Images.SetKeyName(3, "package.png");
            // 
            // CoordinatorHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1141, 681);
            this.Controls.Add(this.AdminPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CoordinatorHome";
            this.Text = "Koordynator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AdminPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl AdminPanel;
        private System.Windows.Forms.TabPage Jobs;
        private System.Windows.Forms.TabPage HomePage;
        private System.Windows.Forms.TabPage Statistics;
        private System.Windows.Forms.TabPage Reports;
        private System.Windows.Forms.TabPage Notify;
        private System.Windows.Forms.TabPage Payoff;
        private System.Windows.Forms.TabPage Packages;
        private System.Windows.Forms.TabPage Email;
        private System.Windows.Forms.TabPage Register;
        private System.Windows.Forms.TabPage Scheme;
        private System.Windows.Forms.ImageList imageList1;
    }
}

