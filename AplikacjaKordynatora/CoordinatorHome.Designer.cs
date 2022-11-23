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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.packagesidtext = new System.Windows.Forms.TextBox();
            this.packagesidsearch = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Email = new System.Windows.Forms.TabPage();
            this.Register = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.seat = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.registersubmit = new System.Windows.Forms.Button();
            this.province = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.driverlicense = new System.Windows.Forms.CheckedListBox();
            this.banknumber = new System.Windows.Forms.TextBox();
            this.pesel = new System.Windows.Forms.TextBox();
            this.localnumber = new System.Windows.Forms.TextBox();
            this.housenumber = new System.Windows.Forms.TextBox();
            this.postcode = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.TextBox();
            this.birth = new System.Windows.Forms.DateTimePicker();
            this.secondname = new System.Windows.Forms.TextBox();
            this.city = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.Scheme = new System.Windows.Forms.TabPage();
            this.submithours = new System.Windows.Forms.Button();
            this.workhours = new System.Windows.Forms.ComboBox();
            this.couriers = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.datework = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.Workers = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.workersprovince = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.workersdelbutton = new System.Windows.Forms.Button();
            this.workerseditbutton = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.packageschoicetext = new System.Windows.Forms.TextBox();
            this.packageschoicesearch = new System.Windows.Forms.Button();
            this.packageschoice = new System.Windows.Forms.ComboBox();
            this.AdminPanel.SuspendLayout();
            this.Packages.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Register.SuspendLayout();
            this.Scheme.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Workers.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminPanel
            // 
            this.AdminPanel.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
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
            this.AdminPanel.Controls.Add(this.Workers);
            this.AdminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminPanel.HotTrack = true;
            this.AdminPanel.ImageList = this.imageList1;
            this.AdminPanel.ItemSize = new System.Drawing.Size(118, 28);
            this.AdminPanel.Location = new System.Drawing.Point(0, 0);
            this.AdminPanel.Multiline = true;
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AdminPanel.SelectedIndex = 0;
            this.AdminPanel.Size = new System.Drawing.Size(1178, 561);
            this.AdminPanel.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.AdminPanel.TabIndex = 3;
            // 
            // HomePage
            // 
            this.HomePage.BackColor = System.Drawing.Color.LightSlateGray;
            this.HomePage.ImageIndex = 0;
            this.HomePage.Location = new System.Drawing.Point(4, 32);
            this.HomePage.Name = "HomePage";
            this.HomePage.Padding = new System.Windows.Forms.Padding(1);
            this.HomePage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HomePage.Size = new System.Drawing.Size(1170, 525);
            this.HomePage.TabIndex = 1;
            this.HomePage.Text = "Strona Główna";
            // 
            // Jobs
            // 
            this.Jobs.BackColor = System.Drawing.Color.LightSlateGray;
            this.Jobs.ImageIndex = 9;
            this.Jobs.Location = new System.Drawing.Point(4, 32);
            this.Jobs.Name = "Jobs";
            this.Jobs.Padding = new System.Windows.Forms.Padding(3);
            this.Jobs.Size = new System.Drawing.Size(1170, 525);
            this.Jobs.TabIndex = 0;
            this.Jobs.Text = "Zlecenia";
            // 
            // Statistics
            // 
            this.Statistics.BackColor = System.Drawing.Color.LightSlateGray;
            this.Statistics.ImageIndex = 1;
            this.Statistics.Location = new System.Drawing.Point(4, 32);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(1170, 525);
            this.Statistics.TabIndex = 2;
            this.Statistics.Text = "Statystyki";
            // 
            // Reports
            // 
            this.Reports.BackColor = System.Drawing.Color.LightSlateGray;
            this.Reports.ImageIndex = 2;
            this.Reports.Location = new System.Drawing.Point(4, 32);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(1170, 525);
            this.Reports.TabIndex = 3;
            this.Reports.Text = "Raporty";
            // 
            // Notify
            // 
            this.Notify.BackColor = System.Drawing.Color.LightSlateGray;
            this.Notify.ImageIndex = 8;
            this.Notify.Location = new System.Drawing.Point(4, 32);
            this.Notify.Name = "Notify";
            this.Notify.Size = new System.Drawing.Size(1170, 525);
            this.Notify.TabIndex = 4;
            this.Notify.Text = "Zgłoszenia";
            // 
            // Payoff
            // 
            this.Payoff.BackColor = System.Drawing.Color.LightSlateGray;
            this.Payoff.ImageIndex = 4;
            this.Payoff.Location = new System.Drawing.Point(4, 32);
            this.Payoff.Name = "Payoff";
            this.Payoff.Size = new System.Drawing.Size(1170, 525);
            this.Payoff.TabIndex = 5;
            this.Payoff.Text = "Rozliczenia";
            // 
            // Packages
            // 
            this.Packages.BackColor = System.Drawing.Color.LightSlateGray;
            this.Packages.Controls.Add(this.panel2);
            this.Packages.Controls.Add(this.listView2);
            this.Packages.Controls.Add(this.listView1);
            this.Packages.ImageIndex = 3;
            this.Packages.Location = new System.Drawing.Point(4, 32);
            this.Packages.Name = "Packages";
            this.Packages.Size = new System.Drawing.Size(1170, 525);
            this.Packages.TabIndex = 6;
            this.Packages.Text = "Paczki";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.packageschoice);
            this.panel2.Controls.Add(this.packageschoicesearch);
            this.panel2.Controls.Add(this.packageschoicetext);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.packagesidtext);
            this.panel2.Controls.Add(this.packagesidsearch);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 525);
            this.panel2.TabIndex = 8;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Cursor = System.Windows.Forms.Cursors.Default;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label22.Location = new System.Drawing.Point(28, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "Wyszukaj Paczke";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(28, 38);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 13);
            this.label25.TabIndex = 7;
            this.label25.Text = "Po Numerze Paczki";
            // 
            // packagesidtext
            // 
            this.packagesidtext.Location = new System.Drawing.Point(3, 54);
            this.packagesidtext.Name = "packagesidtext";
            this.packagesidtext.Size = new System.Drawing.Size(160, 20);
            this.packagesidtext.TabIndex = 4;
            // 
            // packagesidsearch
            // 
            this.packagesidsearch.Location = new System.Drawing.Point(46, 80);
            this.packagesidsearch.Name = "packagesidsearch";
            this.packagesidsearch.Size = new System.Drawing.Size(69, 22);
            this.packagesidsearch.TabIndex = 2;
            this.packagesidsearch.Text = "Szukaj";
            this.packagesidsearch.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(111, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1063, 529);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightSlateGray;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-4, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1174, 525);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.LightSlateGray;
            this.Email.ImageIndex = 6;
            this.Email.Location = new System.Drawing.Point(4, 32);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(1170, 525);
            this.Email.TabIndex = 7;
            this.Email.Text = "Poczta";
            // 
            // Register
            // 
            this.Register.BackColor = System.Drawing.Color.LightSlateGray;
            this.Register.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Register.Controls.Add(this.label14);
            this.Register.Controls.Add(this.seat);
            this.Register.Controls.Add(this.label13);
            this.Register.Controls.Add(this.label12);
            this.Register.Controls.Add(this.label11);
            this.Register.Controls.Add(this.label10);
            this.Register.Controls.Add(this.label9);
            this.Register.Controls.Add(this.label8);
            this.Register.Controls.Add(this.label7);
            this.Register.Controls.Add(this.registersubmit);
            this.Register.Controls.Add(this.province);
            this.Register.Controls.Add(this.label6);
            this.Register.Controls.Add(this.label5);
            this.Register.Controls.Add(this.label4);
            this.Register.Controls.Add(this.label3);
            this.Register.Controls.Add(this.label2);
            this.Register.Controls.Add(this.label1);
            this.Register.Controls.Add(this.driverlicense);
            this.Register.Controls.Add(this.banknumber);
            this.Register.Controls.Add(this.pesel);
            this.Register.Controls.Add(this.localnumber);
            this.Register.Controls.Add(this.housenumber);
            this.Register.Controls.Add(this.postcode);
            this.Register.Controls.Add(this.street);
            this.Register.Controls.Add(this.birth);
            this.Register.Controls.Add(this.secondname);
            this.Register.Controls.Add(this.city);
            this.Register.Controls.Add(this.surname);
            this.Register.Controls.Add(this.name);
            this.Register.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Register.ImageIndex = 5;
            this.Register.Location = new System.Drawing.Point(4, 32);
            this.Register.Name = "Register";
            this.Register.Padding = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.Register.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Register.Size = new System.Drawing.Size(1170, 525);
            this.Register.TabIndex = 8;
            this.Register.Text = "Rejestracja Praconików";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(784, 366);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 14);
            this.label14.TabIndex = 31;
            this.label14.Text = "Stanowisko";
            // 
            // seat
            // 
            this.seat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.seat.FormattingEnabled = true;
            this.seat.Items.AddRange(new object[] {
            "Kurier",
            "Koordynator"});
            this.seat.Location = new System.Drawing.Point(784, 379);
            this.seat.Name = "seat";
            this.seat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.seat.Size = new System.Drawing.Size(230, 23);
            this.seat.TabIndex = 30;
            this.seat.Text = "Kurier";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(452, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 14);
            this.label13.TabIndex = 29;
            this.label13.Text = "Prawo Jazdy";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(784, 289);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "Numer Mieszkania";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(452, 289);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 14);
            this.label11.TabIndex = 27;
            this.label11.Text = "Numer Domu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(121, 366);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 14);
            this.label10.TabIndex = 26;
            this.label10.Text = "Numer Konta Bankowego";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(121, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "Ulica";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(784, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "Miasto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(452, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "Kod pocztowy";
            // 
            // registersubmit
            // 
            this.registersubmit.Location = new System.Drawing.Point(1034, 494);
            this.registersubmit.Name = "registersubmit";
            this.registersubmit.Size = new System.Drawing.Size(128, 23);
            this.registersubmit.TabIndex = 22;
            this.registersubmit.Text = "Dodaj Pracownika";
            this.registersubmit.UseVisualStyleBackColor = true;
            // 
            // province
            // 
            this.province.FormattingEnabled = true;
            this.province.Items.AddRange(new object[] {
            "Dolnośląskie",
            "Kujawsko-Pomorskie",
            "Lubelskie",
            "Łódzkie",
            "Małopolskie",
            "Mazowieckie",
            "Opolskie",
            "Podkarpackie",
            "Podlaskie",
            "Pomorskie",
            "Śląskie",
            "Świętokrzyskie",
            "Warmińsko-Mazurskie",
            "Wielkopolskie",
            "Zachodniopomorskie"});
            this.province.Location = new System.Drawing.Point(121, 228);
            this.province.Name = "province";
            this.province.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.province.Size = new System.Drawing.Size(230, 21);
            this.province.TabIndex = 21;
            this.province.Text = "Dolnośląskie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(121, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "Województwo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(784, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nazwisko";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(452, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Data urodzenia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(452, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Drugie imię";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Imię";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(121, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "PESEL";
            // 
            // driverlicense
            // 
            this.driverlicense.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverlicense.FormattingEnabled = true;
            this.driverlicense.Items.AddRange(new object[] {
            "AM",
            "A1",
            "A2",
            "A",
            "B1",
            "B",
            "C1",
            "C",
            "D1",
            "BE",
            "C1E",
            "CE",
            "D1E",
            "DE",
            "T"});
            this.driverlicense.Location = new System.Drawing.Point(452, 381);
            this.driverlicense.Name = "driverlicense";
            this.driverlicense.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.driverlicense.Size = new System.Drawing.Size(230, 132);
            this.driverlicense.TabIndex = 14;
            // 
            // banknumber
            // 
            this.banknumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.banknumber.Location = new System.Drawing.Point(121, 381);
            this.banknumber.Name = "banknumber";
            this.banknumber.Size = new System.Drawing.Size(230, 21);
            this.banknumber.TabIndex = 12;
            // 
            // pesel
            // 
            this.pesel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pesel.Location = new System.Drawing.Point(121, 159);
            this.pesel.MaxLength = 11;
            this.pesel.Name = "pesel";
            this.pesel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pesel.Size = new System.Drawing.Size(230, 21);
            this.pesel.TabIndex = 11;
            // 
            // localnumber
            // 
            this.localnumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.localnumber.Location = new System.Drawing.Point(784, 306);
            this.localnumber.Name = "localnumber";
            this.localnumber.Size = new System.Drawing.Size(230, 21);
            this.localnumber.TabIndex = 9;
            // 
            // housenumber
            // 
            this.housenumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.housenumber.Location = new System.Drawing.Point(452, 306);
            this.housenumber.Name = "housenumber";
            this.housenumber.Size = new System.Drawing.Size(230, 21);
            this.housenumber.TabIndex = 8;
            // 
            // postcode
            // 
            this.postcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.postcode.Location = new System.Drawing.Point(452, 227);
            this.postcode.Name = "postcode";
            this.postcode.Size = new System.Drawing.Size(230, 21);
            this.postcode.TabIndex = 7;
            // 
            // street
            // 
            this.street.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.street.Location = new System.Drawing.Point(121, 306);
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(230, 21);
            this.street.TabIndex = 6;
            // 
            // birth
            // 
            this.birth.CalendarFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.birth.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.birth.Location = new System.Drawing.Point(452, 157);
            this.birth.MaxDate = new System.DateTime(2022, 11, 22, 0, 0, 0, 0);
            this.birth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.birth.Name = "birth";
            this.birth.Size = new System.Drawing.Size(230, 21);
            this.birth.TabIndex = 5;
            this.birth.Value = new System.DateTime(2022, 11, 22, 0, 0, 0, 0);
            // 
            // secondname
            // 
            this.secondname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.secondname.Location = new System.Drawing.Point(452, 89);
            this.secondname.Name = "secondname";
            this.secondname.Size = new System.Drawing.Size(230, 21);
            this.secondname.TabIndex = 4;
            // 
            // city
            // 
            this.city.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.city.Location = new System.Drawing.Point(784, 229);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(230, 21);
            this.city.TabIndex = 3;
            // 
            // surname
            // 
            this.surname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.surname.Location = new System.Drawing.Point(784, 89);
            this.surname.Name = "surname";
            this.surname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.surname.Size = new System.Drawing.Size(230, 21);
            this.surname.TabIndex = 1;
            // 
            // name
            // 
            this.name.AcceptsReturn = true;
            this.name.AccessibleDescription = "";
            this.name.AccessibleName = "";
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.name.AutoCompleteCustomSource.AddRange(new string[] {
            "fsdfsd"});
            this.name.BackColor = System.Drawing.SystemColors.Window;
            this.name.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.name.Location = new System.Drawing.Point(121, 89);
            this.name.Name = "name";
            this.name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.name.Size = new System.Drawing.Size(230, 21);
            this.name.TabIndex = 0;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // Scheme
            // 
            this.Scheme.BackColor = System.Drawing.Color.LightSlateGray;
            this.Scheme.Controls.Add(this.submithours);
            this.Scheme.Controls.Add(this.workhours);
            this.Scheme.Controls.Add(this.couriers);
            this.Scheme.Controls.Add(this.label19);
            this.Scheme.Controls.Add(this.label18);
            this.Scheme.Controls.Add(this.panel1);
            this.Scheme.Controls.Add(this.datework);
            this.Scheme.Controls.Add(this.label15);
            this.Scheme.Controls.Add(this.calendar);
            this.Scheme.ImageIndex = 7;
            this.Scheme.Location = new System.Drawing.Point(4, 32);
            this.Scheme.Name = "Scheme";
            this.Scheme.Size = new System.Drawing.Size(1170, 525);
            this.Scheme.TabIndex = 9;
            this.Scheme.Text = "Harmongram Pracy";
            // 
            // submithours
            // 
            this.submithours.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.submithours.Location = new System.Drawing.Point(602, 310);
            this.submithours.Name = "submithours";
            this.submithours.Size = new System.Drawing.Size(86, 27);
            this.submithours.TabIndex = 9;
            this.submithours.Text = "Zatwierdź";
            this.submithours.UseVisualStyleBackColor = true;
            // 
            // workhours
            // 
            this.workhours.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workhours.FormattingEnabled = true;
            this.workhours.Items.AddRange(new object[] {
            "6:00-14:00",
            "7:00-15:00",
            "8:00-16:00",
            "9:00-17:00",
            "10:00-18:00",
            "11:00-19:00",
            "12:00-20:00"});
            this.workhours.Location = new System.Drawing.Point(498, 250);
            this.workhours.Name = "workhours";
            this.workhours.Size = new System.Drawing.Size(288, 24);
            this.workhours.TabIndex = 8;
            this.workhours.Text = "6:00-14:00";
            // 
            // couriers
            // 
            this.couriers.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.couriers.FormattingEnabled = true;
            this.couriers.Items.AddRange(new object[] {
            "Maciek",
            "Bartek",
            "Damian",
            "Stefan"});
            this.couriers.Location = new System.Drawing.Point(498, 194);
            this.couriers.Name = "couriers";
            this.couriers.Size = new System.Drawing.Size(288, 24);
            this.couriers.TabIndex = 7;
            this.couriers.Text = "Stefan";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label19.Location = new System.Drawing.Point(495, 230);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 17);
            this.label19.TabIndex = 6;
            this.label19.Text = "Godziny Pracy";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(495, 174);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 17);
            this.label18.TabIndex = 5;
            this.label18.Text = "Kurier";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 52);
            this.panel1.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label17.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(396, 0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(2);
            this.label17.Size = new System.Drawing.Size(414, 42);
            this.label17.TabIndex = 3;
            this.label17.Text = "Przypisz godziny kurierowi";
            // 
            // datework
            // 
            this.datework.AutoSize = true;
            this.datework.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datework.Location = new System.Drawing.Point(675, 129);
            this.datework.Name = "datework";
            this.datework.Size = new System.Drawing.Size(30, 18);
            this.datework.TabIndex = 2;
            this.datework.Text = "NA";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(561, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 18);
            this.label15.TabIndex = 1;
            this.label15.Text = "Wybrales dzień:";
            // 
            // calendar
            // 
            this.calendar.CalendarDimensions = new System.Drawing.Size(1, 3);
            this.calendar.Location = new System.Drawing.Point(36, 56);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            // 
            // Workers
            // 
            this.Workers.BackColor = System.Drawing.Color.LightSlateGray;
            this.Workers.Controls.Add(this.button4);
            this.Workers.Controls.Add(this.button3);
            this.Workers.Controls.Add(this.button2);
            this.Workers.Controls.Add(this.workersprovince);
            this.Workers.Controls.Add(this.textBox2);
            this.Workers.Controls.Add(this.label23);
            this.Workers.Controls.Add(this.label21);
            this.Workers.Controls.Add(this.label20);
            this.Workers.Controls.Add(this.label16);
            this.Workers.Controls.Add(this.textBox1);
            this.Workers.Controls.Add(this.workersdelbutton);
            this.Workers.Controls.Add(this.workerseditbutton);
            this.Workers.Controls.Add(this.listView3);
            this.Workers.ImageIndex = 10;
            this.Workers.Location = new System.Drawing.Point(4, 32);
            this.Workers.Name = "Workers";
            this.Workers.Size = new System.Drawing.Size(1170, 525);
            this.Workers.TabIndex = 10;
            this.Workers.Text = "Pracownicy";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 193);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 20);
            this.button4.TabIndex = 11;
            this.button4.Text = "Szukaj";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 20);
            this.button3.TabIndex = 10;
            this.button3.Text = "Szukaj";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 20);
            this.button2.TabIndex = 9;
            this.button2.Text = "Szukaj";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // workersprovince
            // 
            this.workersprovince.FormattingEnabled = true;
            this.workersprovince.Items.AddRange(new object[] {
            "Dolnośląskie",
            "Kujawsko-Pomorskie",
            "Lubelskie",
            "Łódzkie",
            "Małopolskie",
            "Mazowieckie",
            "Opolskie",
            "Podkarpackie",
            "Podlaskie",
            "Pomorskie",
            "Śląskie",
            "Świętokrzyskie",
            "Warmińsko-Mazurskie",
            "Wielkopolskie",
            "Zachodniopomorskie"});
            this.workersprovince.Location = new System.Drawing.Point(13, 175);
            this.workersprovince.Name = "workersprovince";
            this.workersprovince.Size = new System.Drawing.Size(100, 21);
            this.workersprovince.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 117);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 159);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 13);
            this.label23.TabIndex = 6;
            this.label23.Text = "Po Województwie";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(33, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Po Nazwisku";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(33, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "Po Imieniu";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(6, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "Wyszukaj pracownika";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // workersdelbutton
            // 
            this.workersdelbutton.Location = new System.Drawing.Point(8, 300);
            this.workersdelbutton.Name = "workersdelbutton";
            this.workersdelbutton.Size = new System.Drawing.Size(110, 38);
            this.workersdelbutton.TabIndex = 2;
            this.workersdelbutton.Text = "Usuń";
            this.workersdelbutton.UseVisualStyleBackColor = true;
            // 
            // workerseditbutton
            // 
            this.workerseditbutton.Location = new System.Drawing.Point(8, 237);
            this.workerseditbutton.Name = "workerseditbutton";
            this.workerseditbutton.Size = new System.Drawing.Size(110, 38);
            this.workerseditbutton.TabIndex = 1;
            this.workerseditbutton.Text = "Edytuj";
            this.workerseditbutton.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(124, 0);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(1046, 529);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home.png");
            this.imageList1.Images.SetKeyName(1, "statistics.png");
            this.imageList1.Images.SetKeyName(2, "report.png");
            this.imageList1.Images.SetKeyName(3, "package.png");
            this.imageList1.Images.SetKeyName(4, "payoff.png");
            this.imageList1.Images.SetKeyName(5, "registers.png");
            this.imageList1.Images.SetKeyName(6, "email.png");
            this.imageList1.Images.SetKeyName(7, "scheme.png");
            this.imageList1.Images.SetKeyName(8, "error.png");
            this.imageList1.Images.SetKeyName(9, "jobs.png");
            this.imageList1.Images.SetKeyName(10, "workers.png");
            // 
            // packageschoicetext
            // 
            this.packageschoicetext.Location = new System.Drawing.Point(3, 143);
            this.packageschoicetext.Name = "packageschoicetext";
            this.packageschoicetext.Size = new System.Drawing.Size(160, 20);
            this.packageschoicetext.TabIndex = 9;
            // 
            // packageschoicesearch
            // 
            this.packageschoicesearch.Location = new System.Drawing.Point(46, 169);
            this.packageschoicesearch.Name = "packageschoicesearch";
            this.packageschoicesearch.Size = new System.Drawing.Size(69, 22);
            this.packageschoicesearch.TabIndex = 10;
            this.packageschoicesearch.Text = "Szukaj";
            this.packageschoicesearch.UseVisualStyleBackColor = true;
            // 
            // packageschoice
            // 
            this.packageschoice.FormattingEnabled = true;
            this.packageschoice.Items.AddRange(new object[] {
            "Po imieniu nadawcy",
            "Po nazwisku nadawcy",
            "Po imieniu odbiorcy",
            "Po nazwisku odbiorcy",
            "Po numerze telefonu nadawcy",
            "Po numerze telefonu odbiorcy"});
            this.packageschoice.Location = new System.Drawing.Point(3, 116);
            this.packageschoice.Name = "packageschoice";
            this.packageschoice.Size = new System.Drawing.Size(160, 21);
            this.packageschoice.TabIndex = 11;
            // 
            // CoordinatorHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1178, 561);
            this.Controls.Add(this.AdminPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CoordinatorHome";
            this.Text = "Koordynator";
            this.AdminPanel.ResumeLayout(false);
            this.Packages.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Register.ResumeLayout(false);
            this.Register.PerformLayout();
            this.Scheme.ResumeLayout(false);
            this.Scheme.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Workers.ResumeLayout(false);
            this.Workers.PerformLayout();
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
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.TextBox banknumber;
        private System.Windows.Forms.TextBox pesel;
        private System.Windows.Forms.TextBox localnumber;
        private System.Windows.Forms.TextBox housenumber;
        private System.Windows.Forms.TextBox postcode;
        private System.Windows.Forms.TextBox street;
        private System.Windows.Forms.DateTimePicker birth;
        private System.Windows.Forms.TextBox secondname;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.CheckedListBox driverlicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox province;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox seat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button registersubmit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage Workers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label datework;
        private System.Windows.Forms.ComboBox couriers;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox workhours;
        private System.Windows.Forms.Button submithours;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button packagesidsearch;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button workersdelbutton;
        private System.Windows.Forms.Button workerseditbutton;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox packagesidtext;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox workersprovince;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox packageschoice;
        private System.Windows.Forms.Button packageschoicesearch;
        private System.Windows.Forms.TextBox packageschoicetext;
    }
}

