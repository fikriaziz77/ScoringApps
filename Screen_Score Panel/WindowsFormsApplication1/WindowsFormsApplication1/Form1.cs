using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using MySqlX.XDevAPI;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {       

        public int courtnumber; //isi nomor lapangannya
        public int ball = 0;
        Form2 inputdatalap = new Form2();
        MySql mysql = new MySql();
        public string[] tim1scr = new string[100];
        int sc1, sc2, st1, st2, stat;
        bool stopcount;

        // Create a new process
        static Process process;


        public Form1()
        {
            InitializeComponent();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Define the relative path to your executable or resource
            string relativePath = "Debug\\WindowsFormsApplication1.exe";

            string fullPath = Path.Combine(baseDirectory, relativePath);

            process = new Process();
            process.StartInfo.FileName = fullPath;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;


            this.Hide();
            
            inputdatalap.ShowDialog();

            this.Show();
  
        }

    
        
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            mysql.GetDataCourt();

            updatepanel(courtnumber);

            if (mysql.tim1p1[courtnumber] == "")
            {
                score1.Visible = false;
                score2.Visible = false;
                set1.Visible = false;
                set2.Visible = false;
                plus1.Visible = false;
                plus2.Visible = false;
                min1.Visible = false;
                min2.Visible = false;
                next.Visible = false;
                label1.Visible = true;
                pictureBox1.Visible = true;
            }
            else
            {
                score1.Visible = true;
                score2.Visible = true;
                set1.Visible = true;
                set2.Visible = true;
                plus1.Visible = true;
                plus2.Visible = true;
                min1.Visible = true;
                min2.Visible = true;
                next.Visible = true;
                label1.Visible = false;
                pictureBox1.Visible = false;
            }


        }

       
        int selisih;
        private void next_Click(object sender, EventArgs e)
        {
            if (next.Text != "DONE")
            {
                selisih = sc1 - sc2;

                
                if ((sc1 >= 21 && selisih >= 2) || sc1 >= 30)
                {
                    st1 += 1;
                }
                else if ((sc2 >= 21 && selisih <= -2) || sc2 >= 30)
                {
                    st2 += 1;
                }

                if (stopcount == true)
                {
                    if (st1 >= 2)
                    {
                        next.Text = "DONE";
                        sc1 = 0; sc2 = 0;
                    }
                    else
                    {
                        if (st2 >= 2)
                        {
                            next.Text = "DONE";
                            sc1 = 0; sc2 = 0;
                        }
                        else
                        {
                            sc1 = 0; sc2 = 0;
                            stopcount = false;
                        }
                    }
                }
                mysql.UpdateScore(courtnumber, sc1.ToString(), sc2.ToString(), st1.ToString(), st2.ToString(), ball.ToString());
              
            }
            else
            {
                next.Text = "NEXT";
                sc1 = 0;sc2 = 0;st1= 0; st2 = 0;ball= 0;stat= 0;
                stopcount = false;
                mysql.ClearTable(courtnumber);

                mysql.UpdateScore(courtnumber, sc1.ToString(), sc2.ToString(), st1.ToString(), st2.ToString(), ball.ToString());
                mysql.UpdateStatus(courtnumber,stat.ToString());



            }
        }

       

        private void plus1_Click(object sender, EventArgs e)
        {
            if (stopcount == false)
            {
                if (ball == 1) ball = 0;

                selisih = sc1 - sc2;

                if ((sc1 >= 21 && Math.Abs(selisih) >= 2) || sc1 >= 30)
                {
                    stopcount = true;
                }
                else
                {
                    sc1 += 1;
                    selisih = sc1 - sc2;
                    if ((sc1 >= 21 && Math.Abs(selisih) >= 2) || sc1 >= 30)
                    {
                        stopcount = true;
                    }
                }

            }
            mysql.UpdateScore(courtnumber, sc1.ToString(), sc2.ToString(), st1.ToString(), st2.ToString(), ball.ToString());

        }

        int show1;
        bool scorestart;  
        private void show(object sender, EventArgs e)
        {
           if (show1 == 1)
           {
                if (inputdatalap.formatoke == true)
                {
                    if (inputdatalap.ip != "")
                    {
                        mysql.Initialize(inputdatalap.ip);

                        bool conect = mysql.OpenConnection();
                        if (conect)
                        {
                            courtnumber = inputdatalap.court;

                            mysql.CloseConnection();


                            string path = "C:\\PanelConfig\\config.txt";
                            string s;
                            s = $"{inputdatalap.ip},{inputdatalap.court.ToString()}";
                            File.Delete(path);
                            File.WriteAllText(path, s);

                            process.Start();
                            scorestart = true;
                            

                            mysql.GetDataCourt();
                            sc1 = Convert.ToInt16(mysql.tim1scr[courtnumber]);
                            sc2 = Convert.ToInt16(mysql.tim2scr[courtnumber]);
                            st1 = Convert.ToInt16(mysql.tim1set[courtnumber]);
                            st2 = Convert.ToInt16(mysql.tim2set[courtnumber]);
                            stat = Convert.ToInt16(mysql.status[courtnumber]);
                            ball = Convert.ToInt16(mysql.ball[courtnumber]);

                            timer1.Start();

                        }
                        else
                        {
                            show1 = 0;
                            this.Hide();

                            inputdatalap.ShowDialog();

                            this.Show();
                            mysql.CloseConnection();
                        }

                    }
                    else
                    {
                        this.Close();
                    }
                }
                else { this.Close(); }
           }

                show1++;


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (process != null && scorestart == true)
            {
                // Close the process
                Thread.Sleep(200);
                process.Kill();
                scorestart = false;
            }
            else
            {
                process.Start();
                Thread.Sleep(200);
                process.Kill();
                scorestart = false;
            }
        
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void pictureBox1_VisibleChanged(object sender, EventArgs e)
        {
            mysql.GetDataCourt();
            sc1 = Convert.ToInt16(mysql.tim1scr[courtnumber]);
            sc2 = Convert.ToInt16(mysql.tim2scr[courtnumber]);
            st1 = Convert.ToInt16(mysql.tim1set[courtnumber]);
            st2 = Convert.ToInt16(mysql.tim2set[courtnumber]);
            stat = Convert.ToInt16(mysql.status[courtnumber]);
            ball = Convert.ToInt16(mysql.ball[courtnumber]);
        }

        private void name12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void plus2_Click(object sender, EventArgs e)
        {
            if (stopcount == false)
            {
                if (ball == 0) ball = 1;

                selisih = sc1 - sc2;

                if ((sc2 >= 21 && Math.Abs(selisih) >= 2) || sc2 >= 30)
                {
                    stopcount = true;
                }
                else
                {
                    sc2 += 1;
                    selisih = sc1 - sc2;
                    if ((sc2 >= 21 && Math.Abs(selisih) >= 2) || sc2 >= 30)
                    {
                        stopcount = true;
                    }
                }

            }
            mysql.UpdateScore(courtnumber, sc1.ToString(), sc2.ToString(), st1.ToString(), st2.ToString(), ball.ToString());

        }

        private void min1_Click(object sender, EventArgs e)
        {

            if (st1 < 2 && st2 < 2)
            {
                if (sc1 > 0)
                {
                    sc1 -= 1;
                    stopcount = false;
                }
            }
            
            mysql.UpdateScore(courtnumber, sc1.ToString(), sc2.ToString(), st1.ToString(), st2.ToString(), ball.ToString());


        }

        private void min2_Click(object sender, EventArgs e)
        {
         
            if (st1 < 2 && st2 < 2)
            {
                if (sc2 > 0)
                {
                    sc2 -= 1;
                    stopcount = false;
                }
            }
            
            mysql.UpdateScore(courtnumber, sc1.ToString(), sc2.ToString(), st1.ToString(), st2.ToString(), ball.ToString());


        }

        public void updatepanel(int court)
        {
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


        }

        

    }
}
