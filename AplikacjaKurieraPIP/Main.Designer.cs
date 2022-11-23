namespace AplikacjaKurieraPIP
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.defaultPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.helloLabel = new System.Windows.Forms.Label();
            this.endWorkButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.handPackagesButton = new System.Windows.Forms.Button();
            this.takePackagesButton = new System.Windows.Forms.Button();
            this.startWorkButton = new System.Windows.Forms.Button();
            this.takePackages = new System.Windows.Forms.Panel();
            this.packagesToDeliver = new System.Windows.Forms.Panel();
            this.statisticsPanel = new System.Windows.Forms.Panel();
            this.workTimeLabel = new System.Windows.Forms.Label();
            this.defaultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultPanel
            // 
            this.defaultPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.defaultPanel.Controls.Add(this.label3);
            this.defaultPanel.Controls.Add(this.label2);
            this.defaultPanel.Controls.Add(this.helloLabel);
            this.defaultPanel.Location = new System.Drawing.Point(287, 59);
            this.defaultPanel.Margin = new System.Windows.Forms.Padding(50);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.Padding = new System.Windows.Forms.Padding(50);
            this.defaultPanel.Size = new System.Drawing.Size(958, 659);
            this.defaultPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.label3.Location = new System.Drawing.Point(657, 571);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Szerokiej drogi:)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(196)))), ((int)(((byte)(106)))));
            this.label2.Location = new System.Drawing.Point(7, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(964, 256);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.helloLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.helloLabel.Location = new System.Drawing.Point(56, 55);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(181, 55);
            this.helloLabel.TabIndex = 0;
            this.helloLabel.Text = "Witaj ...";
            this.helloLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // endWorkButton
            // 
            this.endWorkButton.AutoSize = true;
            this.endWorkButton.Enabled = false;
            this.endWorkButton.FlatAppearance.BorderSize = 0;
            this.endWorkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endWorkButton.ForeColor = System.Drawing.Color.Transparent;
            this.endWorkButton.Image = global::AplikacjaKurieraPIP.Properties.Resources.EndWork;
            this.endWorkButton.Location = new System.Drawing.Point(43, 268);
            this.endWorkButton.Margin = new System.Windows.Forms.Padding(0);
            this.endWorkButton.Name = "endWorkButton";
            this.endWorkButton.Size = new System.Drawing.Size(206, 106);
            this.endWorkButton.TabIndex = 1;
            this.endWorkButton.UseVisualStyleBackColor = false;
            this.endWorkButton.Visible = false;
            this.endWorkButton.Click += new System.EventHandler(this.endWorkButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AplikacjaKurieraPIP.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(39, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // statisticsButton
            // 
            this.statisticsButton.AutoSize = true;
            this.statisticsButton.FlatAppearance.BorderSize = 0;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.ForeColor = System.Drawing.Color.Transparent;
            this.statisticsButton.Image = global::AplikacjaKurieraPIP.Properties.Resources.statistics;
            this.statisticsButton.Location = new System.Drawing.Point(41, 630);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(208, 106);
            this.statisticsButton.TabIndex = 3;
            this.statisticsButton.UseVisualStyleBackColor = true;
            // 
            // handPackagesButton
            // 
            this.handPackagesButton.AutoSize = true;
            this.handPackagesButton.FlatAppearance.BorderSize = 0;
            this.handPackagesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.handPackagesButton.ForeColor = System.Drawing.Color.Transparent;
            this.handPackagesButton.Image = global::AplikacjaKurieraPIP.Properties.Resources.handOverPackage;
            this.handPackagesButton.Location = new System.Drawing.Point(41, 508);
            this.handPackagesButton.Name = "handPackagesButton";
            this.handPackagesButton.Size = new System.Drawing.Size(208, 106);
            this.handPackagesButton.TabIndex = 3;
            this.handPackagesButton.UseVisualStyleBackColor = true;
            // 
            // takePackagesButton
            // 
            this.takePackagesButton.AutoSize = true;
            this.takePackagesButton.FlatAppearance.BorderSize = 0;
            this.takePackagesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.takePackagesButton.ForeColor = System.Drawing.Color.Transparent;
            this.takePackagesButton.Image = global::AplikacjaKurieraPIP.Properties.Resources.TakePackages;
            this.takePackagesButton.Location = new System.Drawing.Point(39, 385);
            this.takePackagesButton.Name = "takePackagesButton";
            this.takePackagesButton.Size = new System.Drawing.Size(208, 106);
            this.takePackagesButton.TabIndex = 2;
            this.takePackagesButton.UseVisualStyleBackColor = true;
            // 
            // startWorkButton
            // 
            this.startWorkButton.AutoSize = true;
            this.startWorkButton.FlatAppearance.BorderSize = 0;
            this.startWorkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startWorkButton.ForeColor = System.Drawing.Color.Transparent;
            this.startWorkButton.Image = global::AplikacjaKurieraPIP.Properties.Resources.StartWork;
            this.startWorkButton.Location = new System.Drawing.Point(41, 268);
            this.startWorkButton.Margin = new System.Windows.Forms.Padding(0);
            this.startWorkButton.Name = "startWorkButton";
            this.startWorkButton.Size = new System.Drawing.Size(206, 106);
            this.startWorkButton.TabIndex = 1;
            this.startWorkButton.UseVisualStyleBackColor = false;
            this.startWorkButton.Click += new System.EventHandler(this.startWorkButton_Click);
            // 
            // takePackages
            // 
            this.takePackages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.takePackages.Location = new System.Drawing.Point(1216, 728);
            this.takePackages.Margin = new System.Windows.Forms.Padding(50);
            this.takePackages.Name = "takePackages";
            this.takePackages.Padding = new System.Windows.Forms.Padding(50);
            this.takePackages.Size = new System.Drawing.Size(958, 659);
            this.takePackages.TabIndex = 3;
            // 
            // packagesToDeliver
            // 
            this.packagesToDeliver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.packagesToDeliver.Location = new System.Drawing.Point(1270, 688);
            this.packagesToDeliver.Margin = new System.Windows.Forms.Padding(50);
            this.packagesToDeliver.Name = "packagesToDeliver";
            this.packagesToDeliver.Padding = new System.Windows.Forms.Padding(50);
            this.packagesToDeliver.Size = new System.Drawing.Size(958, 659);
            this.packagesToDeliver.TabIndex = 4;
            // 
            // statisticsPanel
            // 
            this.statisticsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.statisticsPanel.Location = new System.Drawing.Point(1247, 709);
            this.statisticsPanel.Margin = new System.Windows.Forms.Padding(50);
            this.statisticsPanel.Name = "statisticsPanel";
            this.statisticsPanel.Padding = new System.Windows.Forms.Padding(50);
            this.statisticsPanel.Size = new System.Drawing.Size(958, 659);
            this.statisticsPanel.TabIndex = 5;
            // 
            // workTimeLabel
            // 
            this.workTimeLabel.AutoSize = true;
            this.workTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.workTimeLabel.Location = new System.Drawing.Point(293, 9);
            this.workTimeLabel.Name = "workTimeLabel";
            this.workTimeLabel.Size = new System.Drawing.Size(0, 39);
            this.workTimeLabel.TabIndex = 3;
            // 
            // Main
            // 
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1280, 777);
            this.Controls.Add(this.workTimeLabel);
            this.Controls.Add(this.statisticsPanel);
            this.Controls.Add(this.takePackages);
            this.Controls.Add(this.packagesToDeliver);
            this.Controls.Add(this.endWorkButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.takePackagesButton);
            this.Controls.Add(this.startWorkButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.handPackagesButton);
            this.Controls.Add(this.defaultPanel);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.defaultPanel.ResumeLayout(false);
            this.defaultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PAGE1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel defaultPanel;
        private System.Windows.Forms.Button startWorkButton;
        private System.Windows.Forms.Button takePackagesButton;
        private System.Windows.Forms.Button handPackagesButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button endWorkButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label helloLabel;
        private System.Windows.Forms.Panel takePackages;
        private System.Windows.Forms.Panel packagesToDeliver;
        private System.Windows.Forms.Panel statisticsPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label workTimeLabel;
    }
}