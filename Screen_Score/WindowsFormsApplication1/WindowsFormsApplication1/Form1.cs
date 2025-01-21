using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public int courtnumber = 1; //isi nomor lapangannya
        public int ball = 0;
        MySql mysql = new MySql();
        public string[] tim1scr = new string[100];

        int sc1, sc2, st1, st2, stat;
        public string[] config = new string[2];

        private void name11_Click(object sender, EventArgs e)
        {

        }

        private void name12_Click(object sender, EventArgs e)
        {

        }

        private void instansi1_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = "C:\\PanelConfig\\config.txt"; // Replace with the path to your .txt file
            string content = File.ReadAllText(filePath, Encoding.UTF8);
            
            config = content.Split(',');

            mysql.Initialize(config[0]);
            courtnumber = Convert.ToInt16(config[1]);

            pictureBox1.Visible = false;
            event_loct.Visible = false;
            event_name.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            mysql.GetEventData();
            byte[] img = (byte[])mysql.image;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

            event_name.Text = mysql.event_name;
            event_loct.Text = mysql.event_loct;


            mysql.GetDataCourt(); 
            updatepanel(courtnumber);
            if (Convert.ToUInt16(mysql.status[courtnumber]) == 2)
            {
                mysql.ClearTable(courtnumber);
                sc1 = 0;
                sc2 = 0;
                st1 = 0;
                st2 = 0;
                ball = 0;
            }

            if (mysql.tim1p1[courtnumber] == "")
            {
                score1.Visible = false;
                score2.Visible = false;
                set1.Visible = false;
                set2.Visible = false;

                pictureBox1.Visible = true;
                event_loct.Visible = true;
                event_name.Visible = true;
            }
            else
            {
                score1.Visible = true;
                score2.Visible = true;
                set1.Visible = true;
                set2.Visible = true;

                pictureBox1.Visible = false;
                event_loct.Visible = false;
                event_name.Visible = false;
            }


        }

        public bool updatepanel(int court)
        {
            round.Text = mysql.round[court];
            name11.Text = mysql.tim1p1[court];
            name12.Text = mysql.tim1p2[court];
            name21.Text = mysql.tim2p1[court];
            name22.Text = mysql.tim2p2[court];
            instansi1.Text = mysql.tim1ins[court];
            instansi2.Text = mysql.tim2ins[court];
            set1.Text = mysql.tim1set[court];
            set2.Text = mysql.tim2set[court];
            score1.Text = mysql.tim1scr[court];
            score2.Text = mysql.tim2scr[court];
            ball = Convert.ToInt16(mysql.ball[court]);


            if (ball == 0)
            {
                score1.BackColor = Color.Lime;
                score1.ForeColor = Color.Black;

                score2.BackColor = Color.Black;
                score2.ForeColor = Color.Gold;
            }
            else
            {
                score2.BackColor = Color.Gold;
                score2.ForeColor = Color.Black;

                score1.BackColor = Color.Black;
                score1.ForeColor = Color.Lime;   
            }


            return false;
        }

      
    }
}
