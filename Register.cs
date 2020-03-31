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
    public partial class Register : MetroFramework.Forms.MetroForm
    {
        public Register()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SealCheck.HashChecks();
            if (SealCheck.isValidDLL)
            {
                bool response = TrinitySeal.Seal.Register(metroTextBox1.Text, metroTextBox2.Text, metroTextBox3.Text, metroTextBox4.Text);
                if (response == true)
                {

                }
                else
                {

                }
            }
            
        }
    }
}
