using AplikacjaKordynatora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaKurieraPIP
{
    public partial class Main : Form
    {
        List<Panel> panels = new List<Panel>();
        DateTime startHour;
        DateTime endHour;
        public Main(User user)
        {
            InitializeComponent();
            helloLabel.Text = "Witaj " + user.loginCredentials.login;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void startWorkButton_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DialogResult dialogResult = MessageBox.Show("Czy potwierdzasz rozpoczęcie pracy w dniu " + currentTime.ToString("dd/MM/yyyy") + " o godzinie " + currentTime.ToString("HH:mm") + "?", "Rozpocznij pracę", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                startHour = currentTime;
                startWorkButton.Enabled = false;
                startWorkButton.Visible = false;
                endWorkButton.Enabled = true;
                endWorkButton.Visible = true;
                workTimeLabel.Text = "Dzisiaj pracujesz od " + currentTime.ToString("HH:mm");
            }
        }
        private void endWorkButton_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DialogResult dialogResult = MessageBox.Show("Czy potwierdzasz zakończenie pracy w dniu " + currentTime.ToString("dd/MM/yyyy") + " o godzinie " + currentTime.ToString("HH:mm") + "?", "Rozpocznij pracę", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                endHour = currentTime;
                startWorkButton.Enabled = true;
                startWorkButton.Visible = true;
                endWorkButton.Enabled = false;
                endWorkButton.Visible = false;
                TimeSpan elapsedTime = startHour - endHour;
                Console.Write(elapsedTime);
                workTimeLabel.Text = "Dzisiaj przepracowałeś " +elapsedTime.Hours + " godzin i " + elapsedTime.Minutes + " minut";
            }
        }
    }
}
