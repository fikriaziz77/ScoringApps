using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        
        

        public int court;
        public string ip;
        public bool formatoke;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            this.Close();
            formatoke = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
          

            switch(selectcourt.SelectedIndex)
            {
                case 0: court = 1; break;
                case 1: court = 2; break;
                case 2: court = 3; break;
                case 3: court = 4; break;
                case 4: court = 5; break;
                case 5: court = 6; break;
                case 6: court = 7; break;
            }

            ip = inputip.Text.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            selectcourt.SelectedIndex = 0;
        }

        private void inputip_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
