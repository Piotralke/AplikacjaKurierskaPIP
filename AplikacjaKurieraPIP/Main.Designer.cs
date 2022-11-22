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
            this.defaultPanel = new System.Windows.Forms.Panel();
            this.endWorkButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.handPackagesButton = new System.Windows.Forms.Button();
            this.takePackagesButton = new System.Windows.Forms.Button();
            this.startWorkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultPanel
            // 
            this.defaultPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.defaultPanel.Location = new System.Drawing.Point(287, 59);
            this.defaultPanel.Margin = new System.Windows.Forms.Padding(50);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.Padding = new System.Windows.Forms.Padding(50);
            this.defaultPanel.Size = new System.Drawing.Size(958, 659);
            this.defaultPanel.TabIndex = 0;
            // 
            // endWorkButton
            // 
            this.endWorkButton.AutoSize = true;
            this.endWorkButton.Enabled = false;
            this.endWorkButton.FlatAppearance.BorderSize = 0;
            this.endWorkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endWorkButton.ForeColor = System.Drawing.Color.Transparent;
            this.endWorkButton.Image = global::AplikacjaKurieraPIP.Properties.Resources.EndWork;
            this.endWorkButton.Location = new System.Drawing.Point(39, 268);
            this.endWorkButton.Margin = new System.Windows.Forms.Padding(0);
            this.endWorkButton.Name = "endWorkButton";
            this.endWorkButton.Size = new System.Drawing.Size(206, 106);
            this.endWorkButton.TabIndex = 1;
            this.endWorkButton.UseVisualStyleBackColor = false;
            this.endWorkButton.Visible = false;
            this.endWorkButton.Click += new System.EventHandler(this.button3_Click);
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
            this.startWorkButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // Main
            // 
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1280, 777);
            this.Controls.Add(this.endWorkButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.takePackagesButton);
            this.Controls.Add(this.startWorkButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.handPackagesButton);
            this.Controls.Add(this.defaultPanel);
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
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
    }
}