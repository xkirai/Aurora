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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
           
            InitializeComponent();

            SealCheck.HashChecks();
            if (SealCheck.isValidDLL)
            {
                TrinitySeal.Seal.Secret = "uKy1DheorMpbExzZ7W9xKgG7YHnsjnMyHPnGLhHWEp0Kj";
                TrinitySeal.Seal.Initialize("1.0");
            }

            if (Properties.Settings.Default.username != string.Empty)
            {
                metroTextBox1.Text = Properties.Settings.Default.username;
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                Properties.Settings.Default.username = metroTextBox1.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            SealCheck.HashChecks();
            if (SealCheck.isValidDLL)
            {
                bool response = TrinitySeal.Seal.Login(metroTextBox1.Text, metroTextBox2.Text);
                if (response == true)
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                this.metroTextBox2.PasswordChar = '\0';
            }
            else
            {
                this.metroTextBox2.PasswordChar = '●';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
