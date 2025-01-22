using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        MySql mysql = new MySql();
 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mysql.Initialize();
            timer1.Start();
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            mysql.GetEventData();
            byte[] img = (byte[])mysql.image;
            MemoryStream ms = new MemoryStream(img);
            sponsor_pic.Image = Image.FromStream(ms);

            event_name.Text = mysql.event_name;
            event_loct.Text = mysql.event_loct;

            mysql.GetDataCourt();
            update_lap1();
            update_lap2();
            update_lap3();
            update_lap4();
            update_lap5();
            update_lap6();
            update_lap7();

            date_time.Text = DateTime.Now.ToString("dddd dd/MMMM/yyyy");
            curr_date.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }


        public void update_lap1()
        {
            if (mysql.tim1p1[1] != "")
            {
                name11.Visible = true;
                name12.Visible = true;
                r_1.Visible = true;
                cat_1.Visible = true;

                r_1.Text = mysql.round[1];
                cat_1.Text = mysql.cath[1];
                if (mysql.tim1p2[1] != "")
                {
                    name11.Text = mysql.tim1p1[1] + "/" + mysql.tim1p2[1];
                    name12.Text = mysql.tim2p1[1] + "/" + mysql.tim2p2[1];
                }
                else
                {
                    name11.Text = mysql.tim1p1[1];
                    name12.Text = mysql.tim2p1[1];
                }

                if (mysql.tim1set[1] == "0" && mysql.tim2set[1] == "0")
                {
                    sc111.Visible = true;
                    sc112.Visible = true;
                    label8.Visible = true;
                    sc111.Text = mysql.tim1scr[1];
                    sc112.Text = mysql.tim2scr[1];

                }

                else if (mysql.tim1set[1] == "2" || mysql.tim2set[1] == "2")
                {
                    if (Convert.ToInt16(sc131.Text) > Convert.ToInt16(sc132.Text))
                    {
                        sc131.ForeColor = Color.Gold;
                    }
                    else sc132.ForeColor = Color.Gold;
                }

                else if (mysql.tim1set[1] == "1" ^ mysql.tim2set[1] == "1")
                {
                    if (Convert.ToInt16(sc111.Text) > Convert.ToInt16(sc112.Text))
                    {
                        sc111.ForeColor = Color.Gold;
                    }
                    else sc112.ForeColor = Color.Gold;


                    sc121.Visible = true;
                    sc122.Visible = true;
                    label15.Visible = true;
                    sc121.Text = mysql.tim1scr[1];
                    sc122.Text = mysql.tim2scr[1];
                }

                else if (mysql.tim1set[1] == "1" && mysql.tim2set[1] == "1")
                {
                    if (Convert.ToInt16(sc121.Text) > Convert.ToInt16(sc122.Text))
                    {
                        sc121.ForeColor = Color.Gold;
                    }
                    else sc122.ForeColor = Color.Gold;

                    sc131.Visible = true;
                    sc132.Visible = true;
                    label29.Visible = true;
                    sc131.Text = mysql.tim1scr[1];
                    sc132.Text = mysql.tim2scr[1];
                }

            }
            else
            {
                name11.Visible = false;
                name12.Visible = false;
                r_1.Visible = false;
                cat_1.Visible = false;
                sc111.Visible = false;
                sc112.Visible = false;
                sc121.Visible = false;
                sc122.Visible = false;
                sc131.Visible = false;
                sc132.Visible = false;
                label8.Visible = false;
                label15.Visible = false;
                label29.Visible = false;

                sc111.ForeColor = Color.White;
                sc112.ForeColor = Color.White;
                sc121.ForeColor = Color.White;
                sc122.ForeColor = Color.White;
                sc131.ForeColor = Color.White;
                sc132.ForeColor = Color.White;

            }

        }


        public void update_lap2()
        {
            if (mysql.tim1p1[2] != "")
            {
                name21.Visible = true;
                name22.Visible = true;
                r_2.Visible = true;
                cat_2.Visible = true;

                r_2.Text = mysql.round[2];
                cat_2.Text = mysql.cath[2];
                if (mysql.tim1p2[2] != "")
                {
                    name21.Text = mysql.tim1p1[2] + "/" + mysql.tim1p2[2];
                    name22.Text = mysql.tim2p1[2] + "/" + mysql.tim2p2[2];
                }
                else
                {
                    name21.Text = mysql.tim1p1[2];
                    name22.Text = mysql.tim2p1[2];
                }

                if (mysql.tim1set[2] == "0" && mysql.tim2set[2] == "0")
                {
                    sc211.Visible = true;
                    sc212.Visible = true;
                    label5.Visible = true;
                    sc211.Text = mysql.tim1scr[2];
                    sc212.Text = mysql.tim2scr[2];

                }

                else if (mysql.tim1set[2] == "2" || mysql.tim2set[2] == "2")
                {
                    if (Convert.ToInt16(sc231.Text) > Convert.ToInt16(sc232.Text))
                    {
                        sc231.ForeColor = Color.Gold;
                    }
                    else sc232.ForeColor = Color.Gold;
                }

                else if (mysql.tim1set[2] == "1" ^ mysql.tim2set[2] == "1")
                {
                    if (Convert.ToInt16(sc211.Text) > Convert.ToInt16(sc212.Text))
                    {
                        sc211.ForeColor = Color.Gold;
                    }
                    else sc212.ForeColor = Color.Gold;


                    sc221.Visible = true;
                    sc222.Visible = true;
                    label16.Visible = true;
                    sc221.Text = mysql.tim1scr[2];
                    sc222.Text = mysql.tim2scr[2];
                }

                else if (mysql.tim1set[2] == "1" && mysql.tim2set[2] == "1")
                {
                    if (Convert.ToInt16(sc221.Text) > Convert.ToInt16(sc222.Text))
                    {
                        sc221.ForeColor = Color.Gold;
                    }
                    else sc222.ForeColor = Color.Gold;

                    sc231.Visible = true;
                    sc232.Visible = true;
                    label30.Visible = true;
                    sc231.Text = mysql.tim1scr[2];
                    sc232.Text = mysql.tim2scr[2];
                }

            }
            else
            {
                name21.Visible = false;
                name22.Visible = false;
                r_2.Visible = false;
                cat_2.Visible = false;
                sc211.Visible = false;
                sc212.Visible = false;
                sc221.Visible = false;
                sc222.Visible = false;
                sc231.Visible = false;
                sc232.Visible = false;
                label5.Visible = false;
                label16.Visible = false;
                label30.Visible = false;

                sc211.ForeColor = Color.White;
                sc212.ForeColor = Color.White;
                sc221.ForeColor = Color.White;
                sc222.ForeColor = Color.White;
                sc231.ForeColor = Color.White;
                sc232.ForeColor = Color.White;

            }

        }


        public void update_lap3()
        {
            if (mysql.tim1p1[3] != "")
            {
                name31.Visible = true;
                name32.Visible = true;
                r_3.Visible = true;
                cat_3.Visible = true;

                r_3.Text = mysql.round[3];
                cat_3.Text = mysql.cath[3];
                if (mysql.tim1p2[3] != "")
                {
                    name31.Text = mysql.tim1p1[3] + "/" + mysql.tim1p2[3];
                    name32.Text = mysql.tim2p1[3] + "/" + mysql.tim2p2[3];
                }
                else
                {
                    name31.Text = mysql.tim1p1[3];
                    name32.Text = mysql.tim2p1[3];
                }

                if (mysql.tim1set[3] == "0" && mysql.tim2set[3] == "0")
                {
                    sc311.Visible = true;
                    sc312.Visible = true;
                    label6.Visible = true;
                    sc311.Text = mysql.tim1scr[3];
                    sc312.Text = mysql.tim2scr[3];

                }

                else if (mysql.tim1set[3] == "2" || mysql.tim2set[3] == "2")
                {
                    if (Convert.ToInt16(sc331.Text) > Convert.ToInt16(sc332.Text))
                    {
                        sc331.ForeColor = Color.Gold;
                    }
                    else sc332.ForeColor = Color.Gold;
                }

                else if (mysql.tim1set[3] == "1" ^ mysql.tim2set[3] == "1")
                {
                    if (Convert.ToInt16(sc311.Text) > Convert.ToInt16(sc312.Text))
                    {
                        sc311.ForeColor = Color.Gold;
                    }
                    else sc312.ForeColor = Color.Gold;


                    sc321.Visible = true;
                    sc322.Visible = true;
                    label17.Visible = true;
                    sc321.Text = mysql.tim1scr[3];
                    sc322.Text = mysql.tim2scr[3];
                }

                else if (mysql.tim1set[3] == "1" && mysql.tim2set[3] == "1")
                {
                    if (Convert.ToInt16(sc321.Text) > Convert.ToInt16(sc322.Text))
                    {
                        sc321.ForeColor = Color.Gold;
                    }
                    else sc322.ForeColor = Color.Gold;

                    sc331.Visible = true;
                    sc332.Visible = true;
                    label31.Visible = true;
                    sc331.Text = mysql.tim1scr[3];
                    sc332.Text = mysql.tim2scr[3];
                }

            }
            else
            {
                name31.Visible = false;
                name32.Visible = false;
                r_3.Visible = false;
                cat_3.Visible = false;
                sc311.Visible = false;
                sc312.Visible = false;
                sc321.Visible = false;
                sc322.Visible = false;
                sc331.Visible = false;
                sc332.Visible = false;
                label6.Visible = false;
                label17.Visible = false;
                label31.Visible = false;

                sc311.ForeColor = Color.White;
                sc312.ForeColor = Color.White;
                sc321.ForeColor = Color.White;
                sc322.ForeColor = Color.White;
                sc331.ForeColor = Color.White;
                sc332.ForeColor = Color.White;

            }

        }


        public void update_lap4()
        {
            if (mysql.tim1p1[4] != "")
            {
                name41.Visible = true;
                name42.Visible = true;
                r_4.Visible = true;
                cat_4.Visible = true;

                r_4.Text = mysql.round[4];
                cat_4.Text = mysql.cath[4];
                if (mysql.tim1p2[4] != "")
                {
                    name41.Text = mysql.tim1p1[4] + "/" + mysql.tim1p2[4];
                    name42.Text = mysql.tim2p1[4] + "/" + mysql.tim2p2[4];
                }
                else
                {
                    name41.Text = mysql.tim1p1[4];
                    name42.Text = mysql.tim2p1[4];
                }

                if (mysql.tim1set[4] == "0" && mysql.tim2set[4] == "0")
                {
                    sc411.Visible = true;
                    sc412.Visible = true;
                    label7.Visible = true;
                    sc411.Text = mysql.tim1scr[4];
                    sc412.Text = mysql.tim2scr[4];

                }

                else if (mysql.tim1set[4] == "2" || mysql.tim2set[4] == "2")
                {
                    if (Convert.ToInt16(sc431.Text) > Convert.ToInt16(sc432.Text))
                    {
                        sc431.ForeColor = Color.Gold;
                    }
                    else sc432.ForeColor = Color.Gold;
                }

                else if (mysql.tim1set[4] == "1" ^ mysql.tim2set[4] == "1")
                {
                    if (Convert.ToInt16(sc411.Text) > Convert.ToInt16(sc412.Text))
                    {
                        sc411.ForeColor = Color.Gold;
                    }
                    else sc412.ForeColor = Color.Gold;


                    sc421.Visible = true;
                    sc422.Visible = true;
                    label22.Visible = true;
                    sc421.Text = mysql.tim1scr[4];
                    sc422.Text = mysql.tim2scr[4];
                }

                else if (mysql.tim1set[4] == "1" && mysql.tim2set[4] == "1")
                {
                    if (Convert.ToInt16(sc421.Text) > Convert.ToInt16(sc422.Text))
                    {
                        sc421.ForeColor = Color.Gold;
                    }
                    else sc422.ForeColor = Color.Gold;

                    sc431.Visible = true;
                    sc432.Visible = true;
                    label23.Visible = true;
                    sc431.Text = mysql.tim1scr[4];
                    sc432.Text = mysql.tim2scr[4];
                }

            }
            else
            {
                name41.Visible = false;
                name42.Visible = false;
                r_4.Visible = false;
                cat_4.Visible = false;
                sc411.Visible = false;
                sc412.Visible = false;
                sc421.Visible = false;
                sc422.Visible = false;
                sc431.Visible = false;
                sc432.Visible = false;
                label7.Visible = false;
                label22.Visible = false;
                label23.Visible = false;

                sc411.ForeColor = Color.White;
                sc412.ForeColor = Color.White;
                sc421.ForeColor = Color.White;
                sc422.ForeColor = Color.White;
                sc431.ForeColor = Color.White;
                sc432.ForeColor = Color.White;

            }

        }



        public void update_lap5()
        {
            if (mysql.tim1p1[5] != "")
            {
                name51.Visible = true;
                name52.Visible = true;
                r_5.Visible = true;
                cat_5.Visible = true;

                r_5.Text = mysql.round[5];
                cat_5.Text = mysql.cath[5];
                if (mysql.tim1p2[5] != "")
                {
                    name51.Text = mysql.tim1p1[5] + "/" + mysql.tim1p2[5];
                    name52.Text = mysql.tim2p1[5] + "/" + mysql.tim2p2[5];
                }
                else
                {
                    name51.Text = mysql.tim1p1[5];
                    name52.Text = mysql.tim2p1[5];
                }

                if (mysql.tim1set[5] == "0" && mysql.tim2set[5] == "0")
                {
                    sc511.Visible = true;
                    sc512.Visible = true;
                    label9.Visible = true;
                    sc511.Text = mysql.tim1scr[5];
                    sc512.Text = mysql.tim2scr[5];

                }

                else if (mysql.tim1set[5] == "2" || mysql.tim2set[5] == "2")
                {
                    if (Convert.ToInt16(sc531.Text) > Convert.ToInt16(sc532.Text))
                    {
                        sc531.ForeColor = Color.Gold;
                    }
                    else sc532.ForeColor = Color.Gold;
                }

                else if (mysql.tim1set[5] == "1" ^ mysql.tim2set[5] == "1")
                {
                    if (Convert.ToInt16(sc511.Text) > Convert.ToInt16(sc512.Text))
                    {
                        sc511.ForeColor = Color.Gold;
                    }
                    else sc512.ForeColor = Color.Gold;


                    sc521.Visible = true;
                    sc522.Visible = true;
                    label10.Visible = true;
                    sc521.Text = mysql.tim1scr[5];
                    sc522.Text = mysql.tim2scr[5];
                }

                else if (mysql.tim1set[5] == "1" && mysql.tim2set[5] == "1")
                {
                    if (Convert.ToInt16(sc521.Text) > Convert.ToInt16(sc522.Text))
                    {
                        sc521.ForeColor = Color.Gold;
                    }
                    else sc522.ForeColor = Color.Gold;

                    sc531.Visible = true;
                    sc532.Visible = true;
                    label24.Visible = true;
                    sc531.Text = mysql.tim1scr[5];
                    sc532.Text = mysql.tim2scr[5];
                }

            }
            else
            {
                name51.Visible = false;
                name52.Visible = false;
                r_5.Visible = false;
                cat_5.Visible = false;
                sc511.Visible = false;
                sc512.Visible = false;
                sc521.Visible = false;
                sc522.Visible = false;
                sc531.Visible = false;
                sc532.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label24.Visible = false;

                sc511.ForeColor = Color.White;
                sc512.ForeColor = Color.White;
                sc521.ForeColor = Color.White;
                sc522.ForeColor = Color.White;
                sc531.ForeColor = Color.White;
                sc532.ForeColor = Color.White;

            }

        }

        public void update_lap6()
        {
            if (mysql.tim1p1[6] != "")
            {
                name61.Visible = true;
                name62.Visible = true;
                r_6.Visible = true;
                cat_6.Visible = true;

                r_6.Text = mysql.round[6];
                cat_6.Text = mysql.cath[6];
                if (mysql.tim1p2[6] != "")
                {
                    name61.Text = mysql.tim1p1[6] + "/" + mysql.tim1p2[6];
                    name62.Text = mysql.tim2p1[6] + "/" + mysql.tim2p2[6];
                }
                else
                {
                    name61.Text = mysql.tim1p1[6];
                    name62.Text = mysql.tim2p1[6];
                }

                if (mysql.tim1set[6] == "0" && mysql.tim2set[6] == "0")
                {
                    sc611.Visible = true;
                    sc612.Visible = true;
                    label35.Visible = true;
                    sc611.Text = mysql.tim1scr[6];
                    sc612.Text = mysql.tim2scr[6];

                }

                else if (mysql.tim1set[6] == "2" || mysql.tim2set[6] == "2")
                {
                    if (Convert.ToInt16(sc631.Text) > Convert.ToInt16(sc632.Text))
                    {
                        sc631.ForeColor = Color.Gold;
                    }
                    else sc632.ForeColor = Color.Gold;
                }

                else if (mysql.tim1set[6] == "1" ^ mysql.tim2set[6] == "1")
                {
                    if (Convert.ToInt16(sc611.Text) > Convert.ToInt16(sc612.Text))
                    {
                        sc611.ForeColor = Color.Gold;
                    }
                    else sc612.ForeColor = Color.Gold;


                    sc621.Visible = true;
                    sc622.Visible = true;
                    label32.Visible = true;
                    sc621.Text = mysql.tim1scr[6];
                    sc622.Text = mysql.tim2scr[6];
                }

                else if (mysql.tim1set[6] == "1" && mysql.tim2set[6] == "1")
                {
                    if (Convert.ToInt16(sc621.Text) > Convert.ToInt16(sc622.Text))
                    {
                        sc621.ForeColor = Color.Gold;
                    }
                    else sc622.ForeColor = Color.Gold;

                    sc631.Visible = true;
                    sc632.Visible = true;
                    label27.Visible = true;
                    sc631.Text = mysql.tim1scr[6];
                    sc632.Text = mysql.tim2scr[6];
                }

            }
            else
            {
                name61.Visible = false;
                name62.Visible = false;
                r_6.Visible = false;
                cat_6.Visible = false;
                sc611.Visible = false;
                sc612.Visible = false;
                sc621.Visible = false;
                sc622.Visible = false;
                sc631.Visible = false;
                sc632.Visible = false;
                label35.Visible = false;
                label32.Visible = false;
                label27.Visible = false;

                sc611.ForeColor = Color.White;
                sc612.ForeColor = Color.White;
                sc621.ForeColor = Color.White;
                sc622.ForeColor = Color.White;
                sc631.ForeColor = Color.White;
                sc632.ForeColor = Color.White;

            }

        }

        public void update_lap7()
        {
            if (mysql.tim1p1[7] != "")
            {
                name71.Visible = true;
                name72.Visible = true;
                r_7.Visible = true;
                cat_7.Visible = true;

                r_7.Text = mysql.round[7];
                cat_7.Text = mysql.cath[7];
                if (mysql.tim1p2[7] != "")
                {
                    name71.Text = mysql.tim1p1[7] + "/" + mysql.tim1p2[7];
                    name72.Text = mysql.tim2p1[7] + "/" + mysql.tim2p2[7];
                }
                else
                {
                    name71.Text = mysql.tim1p1[7];
                    name72.Text = mysql.tim2p1[7];
                }

                if (mysql.tim1set[7] == "0" && mysql.tim2set[7] == "0")
                {
                    sc711.Visible = true;
                    sc712.Visible = true;
                    label34.Visible = true;
                    sc711.Text = mysql.tim1scr[7];
                    sc712.Text = mysql.tim2scr[7];

                }

                else if (mysql.tim1set[7] == "2" || mysql.tim2set[7] == "2")
                {
                    if (Convert.ToInt16(sc731.Text) > Convert.ToInt16(sc732.Text))
                    {
                        sc731.ForeColor = Color.Gold;
                    }
                    else sc732.ForeColor = Color.Gold;
                }

                else if (mysql.tim1set[7] == "1" ^ mysql.tim2set[7] == "1")
                {
                    if (Convert.ToInt16(sc711.Text) > Convert.ToInt16(sc712.Text))
                    {
                        sc711.ForeColor = Color.Gold;
                    }
                    else sc712.ForeColor = Color.Gold;


                    sc721.Visible = true;
                    sc722.Visible = true;
                    label33.Visible = true;
                    sc721.Text = mysql.tim1scr[7];
                    sc722.Text = mysql.tim2scr[7];
                }

                else if (mysql.tim1set[7] == "1" && mysql.tim2set[7] == "1")
                {
                    if (Convert.ToInt16(sc721.Text) > Convert.ToInt16(sc722.Text))
                    {
                        sc721.ForeColor = Color.Gold;
                    }
                    else sc722.ForeColor = Color.Gold;

                    sc731.Visible = true;
                    sc732.Visible = true;
                    label28.Visible = true;
                    sc731.Text = mysql.tim1scr[7];
                    sc732.Text = mysql.tim2scr[7];
                }

            }
            else
            {
                name71.Visible = false;
                name72.Visible = false;
                r_7.Visible = false;
                cat_7.Visible = false;
                sc711.Visible = false;
                sc712.Visible = false;
                sc721.Visible = false;
                sc722.Visible = false;
                sc731.Visible = false;
                sc732.Visible = false;
                label34.Visible = false;
                label33.Visible = false;
                label28.Visible = false;

                sc711.ForeColor = Color.White;
                sc712.ForeColor = Color.White;
                sc721.ForeColor = Color.White;
                sc722.ForeColor = Color.White;
                sc731.ForeColor = Color.White;
                sc732.ForeColor = Color.White;

            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
    
        }

        int aaa = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            string text_title = "COURT INFORMATION SCREEN";
            if (aaa >= 2 && aaa <= text_title.Length+2)
            {
                string disp = text_title.Substring(0, aaa-2);
                label4.Text = disp;
                
            }

            if (aaa > text_title.Length+5)
            {
                aaa = 0;
            }

            aaa++;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

        
}
