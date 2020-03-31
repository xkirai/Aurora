using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;

namespace Aurora
{
    public partial class ModernWarfare2 : MetroFramework.Forms.MetroForm
    {
        public ModernWarfare2()
        {
            InitializeComponent();
        }
        private static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        private void metroButton1_Click(object sender, EventArgs e)
        {
            PS3.ConnectTarget();
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Connected!");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            PS3.AttachProcess();
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Attached!");
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            MW2RPC.ExecuteCommand("jump_ladderPushVel 1024");
            MW2RPC.SV_GameSendServerCommand(-1, "c \"Ladder ^1Mod^7 [^2ON^7]\"");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            MW2RPC.EnableRPC();
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "RPC Enabled!");
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            MW2RPC.Cbuf_AddText(0, "popup_gamesetup");
        }

        private void metroButton43_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MW2RPC.ExecuteCommand("party_maxplayers " + numericUpDown1.Value);
            MW2RPC.ExecuteCommand("party_gamesize " + numericUpDown1.Value);
            MW2RPC.ExecuteCommand("party_maxPrivatePartyPlayers " + numericUpDown1.Value);
            MW2RPC.ExecuteCommand("sv_maxclients " + numericUpDown1.Value);
            timer1.Start();
        }

        private void metroButton37_Click(object sender, EventArgs e)
        {
            if (metroButton37.ForeColor == Color.Black)
            {
                timer1.Start();
                metroButton37.ForeColor = Color.Green;
            }
            else if (metroButton37.ForeColor == Color.Green)
            {
                timer1.Stop();
                metroButton37.ForeColor = Color.Black;
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MW2RPC.ExecuteCommand("party_minplayers " + numericUpDown2.Value);
            timer2.Start();
        }

        private void metroButton38_Click(object sender, EventArgs e)
        {
            if (metroButton38.ForeColor == Color.Black)
            {
                timer2.Start();
                metroButton38.ForeColor = Color.Green;
            }
            else if (metroButton38.ForeColor == Color.Green)
            {
                timer2.Stop();
                metroButton38.ForeColor = Color.Black;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            MW2RPC.ExecuteCommand("party_maxTeamDiff " + numericUpDown3.Value);
            timer3.Start();
        }

        private void metroButton39_Click(object sender, EventArgs e)
        {
            if (metroButton39.ForeColor == Color.Black)
            {
                timer3.Start();
                metroButton39.ForeColor = Color.Green;
            }
            else if (metroButton39.ForeColor == Color.Green)
            {
                timer3.Stop();
                metroButton39.ForeColor = Color.Black;
            }
        }
    }
}
