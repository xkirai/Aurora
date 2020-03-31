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

namespace Aurora
{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        public Dashboard()
        {
            InitializeComponent();
            SealCheck.HashChecks();
            if (SealCheck.isValidDLL)
            {

                if (!TrinitySeal.ProgramVariables.Freemode)
                {
                    TrinitySeal.Security.ChallengeCheck();
                }
            }
        }
        AdvancedWarfare AW = new AdvancedWarfare();
        Ghosts ghosts = new Ghosts();
        ModernWarfare2 MW2 = new ModernWarfare2();
        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            AW.Show();
            this.Hide();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            ghosts.Show();
            this.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            MW2.Show();
            this.Hide();
        }
    }
}
