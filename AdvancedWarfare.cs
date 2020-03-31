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
    public partial class AdvancedWarfare : MetroFramework.Forms.MetroForm
    {
        public AdvancedWarfare()
        {
            InitializeComponent();
        }

        PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        private void timer1_Tick(object sender, EventArgs e)//sv_maxagents
        {
            AdvancedWarfareRPC.ExecuteCommand("party_MaxPlayers " + numericUpDown1.Value);
            AdvancedWarfareRPC.ExecuteCommand("party_gamesize " + numericUpDown1.Value);
            AdvancedWarfareRPC.ExecuteCommand("party_maxPrivatePartyPlayers " + numericUpDown1.Value);
            AdvancedWarfareRPC.ExecuteCommand("party_lobbyPlayerCount " + numericUpDown1.Value);
            AdvancedWarfareRPC.ExecuteCommand("sv_maxclients " + numericUpDown1.Value);
            //extra test shit  party_mapname
            AdvancedWarfareRPC.ExecuteCommand("party_gametype sd");
            AdvancedWarfareRPC.ExecuteCommand("ui_gametype sd");
            AdvancedWarfareRPC.ExecuteCommand("g_gametype sd");
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
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Attached to Advanced Warfare");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AdvancedWarfareRPC.Init();
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "RPC Enabled");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            PS3.DisconnectTarget();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e) //
        {
            AdvancedWarfareRPC.ExecuteCommand("party_minplayers " + numericUpDown2.Value);
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            AdvancedWarfareRPC.ExecuteCommand("party_maxTeamDiff " + numericUpDown3.Value);
            timer3.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            AdvancedWarfareRPC.ExecuteCommand("ds_serverConnectTimeout 1000");
            AdvancedWarfareRPC.ExecuteCommand("pt_searchConnectAttempts 1");
            AdvancedWarfareRPC.ExecuteCommand("pt_connectAttempts 1");
            AdvancedWarfareRPC.ExecuteCommand("pt_connectTimeout 1");
            AdvancedWarfareRPC.ExecuteCommand("party_minLobbyTime 1");
            timer4.Start();
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked)
            {
                timer4.Start();
            }
            else
            {
                timer4.Stop();
            }
            
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x5BC86C, new byte[] { 0x38, 0x60, 0x00, 0x00 });
            PS3.SetMemory(0x5BEDC4, new byte[] { 0x4E, 0x80, 0x00, 0x20 });
            PS3.SetMemory(0x5BCDBC, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x668960, new byte[] { 0x60, 0x00, 0x00, 0x00, 0x3B, 0xE0 });
            PS3.SetMemory(0x668FA0, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7EC434, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 000, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x678F68, new byte[] { 0x3B, 0xC0, 0x00, 0x00 });
            PS3.SetMemory(0x5BCD24, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x79542C, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.WRONGWAY, "ANTIBAN ENABLED");
        }
    }
}
