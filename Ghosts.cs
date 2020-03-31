using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrinitySeal;
using Newtonsoft.Json;
using PS3Lib;

namespace Aurora
{
    public partial class Ghosts : MetroFramework.Forms.MetroForm
    {
        public Ghosts()
        {
            InitializeComponent();
        }
        PS3API PS3 = new PS3API(SelectAPI.ControlConsole);

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Start();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            PS3.ConnectTarget();
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Connected to PROJECT AURORA by Lurkzy");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            PS3.AttachProcess();
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Connected to PROJECT AURORA by Lurkzy");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }

    }
}
