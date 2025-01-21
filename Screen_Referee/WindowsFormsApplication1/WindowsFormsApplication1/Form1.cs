using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Org.BouncyCastle.Crypto.Engines;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Security.Cryptography;
using Google.Protobuf.WellKnownTypes;
using System.Threading;
using System.Diagnostics;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        IFirebaseConfig db_config = new FirebaseConfig
        {
            AuthSecret = "TNsmUVZLN9gZNVJNno1zkgCYRlyNhgDcU7imHt2n",
            BasePath = "https://score-bandabaru-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseClient db_client;

        OpenFileDialog openFileDialog = new OpenFileDialog();

        public string excelPath, lastdata1, lastdata2;
        public List<ExcelData> records = new List<ExcelData>();
        public string courtselected;
        public static string[] str = new string[16];
        public static string blank = " ";
        public static string ready_stat = "StandBye";
        public static string match_stat = "On Match";

        string[] datalap1 = new string[10];
        string[] datalap2 = new string[10];
        string[] datalap3 = new string[10];
        string[] datalap4 = new string[10];
        string[] datalap5 = new string[10];
        string[] datalap6 = new string[10];
        string[] datalap7 = new string[10];


        public bool scorestart;

        MySql mysql = new MySql();

        static Process process;


        public class ExcelData
        {
            public string Cath { get; set; }
            public string Name { get; set; }
            public string Name2 { get; set; }
            public string Round { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void date_timer_Tick(object sender, EventArgs e)
        {


            //string datetime = DateTime.Now.ToString("dd-MMM-yyyyhh:mm:ss tt");
            curr_date.Text = DateTime.Now.ToString("ddd dd/M/yyyy");
            curr_time.Text = DateTime.Now.ToString("hh:mm:ss tt");

            mysql.GetDataCourt();
            //sqlweb.UpdateData(1, mysql.cath[1], mysql.round[1], mysql.tim1p1[1], mysql.tim1p2[1], mysql.tim1ins[1], mysql.tim2p1[1], mysql.tim2p2[1], mysql.tim2ins[1], mysql.status[1], mysql.tim1scr[1], mysql.tim2scr[1], mysql.tim1set[1], mysql.tim2set[1], mysql.ball[1]);

            //mysql.GetEventData();
            //sqlweb.UpdateEventData(mysql.event_name, mysql.event_loct, mysql.image);

            if (mysql.status[1] == "1") stat1.Text = match_stat;
            else if (mysql.status[1] == "0") stat1.Text = ready_stat;

            if (mysql.status[2] == "1") stat2.Text = match_stat;
            else if (mysql.status[2] == "0") stat2.Text = ready_stat;

            if (mysql.status[3] == "1") stat3.Text = match_stat;
            else if (mysql.status[3] == "0") stat3.Text = ready_stat;

            if (mysql.status[4] == "1") stat4.Text = match_stat;
            else if (mysql.status[4] == "0") stat4.Text = ready_stat;

            if (mysql.status[5] == "1") stat5.Text = match_stat;
            else if (mysql.status[5] == "0") stat5.Text = ready_stat;

            if (mysql.status[6] == "1") stat6.Text = match_stat;
            else if (mysql.status[6] == "0") stat6.Text = ready_stat;

            if (mysql.status[7] == "1") stat7.Text = match_stat;
            else if (mysql.status[7] == "0") stat7.Text = ready_stat;


            if (stat1.Text == ready_stat) l1.BackColor = Color.Green;
            else l1.BackColor = Color.Red;

            if (stat2.Text == ready_stat) l2.BackColor = Color.Green;
            else l2.BackColor = Color.Red;

            if (stat3.Text == ready_stat) l3.BackColor = Color.Green;
            else l3.BackColor = Color.Red;

            if (stat4.Text == ready_stat) l4.BackColor = Color.Green;
            else l4.BackColor = Color.Red;

            if (stat5.Text == ready_stat) l5.BackColor = Color.Green;
            else l5.BackColor = Color.Red;

            if (stat6.Text == ready_stat) l6.BackColor = Color.Green;
            else l6.BackColor = Color.Red;

            if (stat7.Text == ready_stat) l7.BackColor = Color.Green;
            else l7.BackColor = Color.Red;


        }

       

        private static string[] lap = { " ","lap1.txt", "lap2.txt", "lap3.txt", "lap4.txt", "lap5.txt", "lap6.txt", "lap7.txt" };
        private void Form1_Load(object sender, EventArgs e)
        {

            mysql.Initialize();
            //Initialization
            db_client = new FireSharp.FirebaseClient(db_config);

            if(db_client!=null)
            {
                MessageBox.Show("oyeah!!");
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Define the relative path to your executable or resource
            string relativePath = "Debug\\Panel_Information.exe";

            string fullPath = Path.Combine(baseDirectory, relativePath);

            process = new Process();
            process.StartInfo.FileName = fullPath;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

            process.Start();
            scorestart = true;

            mysql.GetEventData();
            byte[] img = (byte[])mysql.image;
            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);   
            event_name.Text = mysql.event_name;
            event_loct.Text = mysql.event_loct;
            
            stat1.Text = ready_stat;
            stat2.Text = ready_stat;
            stat3.Text = ready_stat;
            stat4.Text = ready_stat;
            stat5.Text = ready_stat;
            stat6.Text = ready_stat;
            stat7.Text = ready_stat;

            string lap1 = File.ReadAllText(lap[1]);
            datalap1 = lap1.Split(',');
            updatelap1(datalap1[0], datalap1[1], datalap1[2], datalap1[3], datalap1[4]);

            string lap2 = File.ReadAllText(lap[2]);
            datalap2 = lap2.Split(',');
            updatelap2(datalap2[0], datalap2[1], datalap2[2], datalap2[3], datalap2[4]);

            string lap3 = File.ReadAllText(lap[3]);
            datalap3 = lap3.Split(',');
            updatelap3(datalap3[0], datalap3[1], datalap3[2], datalap3[3], datalap3[4]);

            string lap4 = File.ReadAllText(lap[4]);
            datalap4 = lap4.Split(',');
            updatelap4(datalap4[0], datalap4[1], datalap4[2], datalap4[3], datalap4[4]);

            string lap5 = File.ReadAllText(lap[5]);
            datalap5 = lap5.Split(',');
            updatelap5(datalap5[0], datalap5[1], datalap5[2], datalap5[3], datalap5[4]);

            string lap6 = File.ReadAllText(lap[6]);
            datalap6 = lap6.Split(',');
            updatelap6(datalap6[0], datalap6[1], datalap6[2], datalap6[3], datalap6[4]);

            string lap7 = File.ReadAllText(lap[7]);
            datalap7 = lap7.Split(',');
            updatelap7(datalap7[0], datalap7[1], datalap7[2], datalap7[3], datalap7[4]);

        }

        private void updatelap1(string a, string b, string cc, string dd, string ee)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat1.Text = b;
            records.Clear();
            c1.Items.Clear();
            c2.Items.Clear();
            c3.Items.Clear();
            c4.Items.Clear();
            c5.Items.Clear();
            c6.Items.Clear();
            c7.Items.Clear();

            read_from_excel();
            if (stat1.Text == match_stat)
            {
                c1.SelectedIndex = Convert.ToInt16(cc);
                r1.SelectedIndex = Convert.ToInt16(dd);
                p1.SelectedIndex = Convert.ToInt16(ee);
                dis_input(1);
            }
        }

        private void updatelap2(string a, string b, string cc, string dd, string ee)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat2.Text = b;

            if (stat2.Text == match_stat)
            {
                c2.SelectedIndex = Convert.ToInt16(cc);
                r2.SelectedIndex = Convert.ToInt16(dd);
                p2.SelectedIndex = Convert.ToInt16(ee);
                dis_input(2);
            }

        }

        private void updatelap3(string a, string b, string cc, string dd, string ee)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat3.Text = b;

            if (stat3.Text == match_stat)
            {
                c3.SelectedIndex = Convert.ToInt16(cc);
                r3.SelectedIndex = Convert.ToInt16(dd);
                p3.SelectedIndex = Convert.ToInt16(ee);
                dis_input(3);
            }
        }

        private void updatelap4(string a, string b, string cc, string dd, string ee)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat4.Text = b;

            if (stat4.Text == match_stat)
            {
                c4.SelectedIndex = Convert.ToInt16(cc);
                r4.SelectedIndex = Convert.ToInt16(dd);
                p4.SelectedIndex = Convert.ToInt16(ee);
                dis_input(4);
            }

        }

        private void updatelap5(string a, string b, string cc, string dd, string ee)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat5.Text = b;

            if (stat5.Text == match_stat)
            {
                c5.SelectedIndex = Convert.ToInt16(cc);
                r5.SelectedIndex = Convert.ToInt16(dd);
                p5.SelectedIndex = Convert.ToInt16(ee);
                dis_input(5);
            }

        }

        private void updatelap6(string a, string b, string cc, string dd, string ee)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat6.Text = b;

            if (stat6.Text == match_stat)
            {
                c6.SelectedIndex = Convert.ToInt16(cc);
                r6.SelectedIndex = Convert.ToInt16(dd);
                p6.SelectedIndex = Convert.ToInt16(ee);
                dis_input(6);
            }

        }

        private void updatelap7(string a, string b, string cc, string dd, string ee)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat7.Text = b;

            if (stat7.Text == match_stat)
            {
                c7.SelectedIndex = Convert.ToInt16(cc);
                r7.SelectedIndex = Convert.ToInt16(dd);
                p7.SelectedIndex = Convert.ToInt16(ee);
                dis_input(7);
            }

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string lap1 = $"{excelPath},{stat1.Text},{c1.SelectedIndex},{r1.SelectedIndex},{p1.SelectedIndex}";
            string lap2 = $"{excelPath},{stat2.Text},{c2.SelectedIndex},{r2.SelectedIndex},{p2.SelectedIndex}";
            string lap3 = $"{excelPath},{stat3.Text},{c3.SelectedIndex},{r3.SelectedIndex},{p3.SelectedIndex}";
            string lap4 = $"{excelPath},{stat4.Text},{c4.SelectedIndex},{r4.SelectedIndex},{p4.SelectedIndex}";
            string lap5 = $"{excelPath},{stat5.Text},{c5.SelectedIndex},{r5.SelectedIndex},{p5.SelectedIndex}";
            string lap6 = $"{excelPath},{stat6.Text},{c6.SelectedIndex},{r6.SelectedIndex},{p6.SelectedIndex}";
            string lap7 = $"{excelPath},{stat7.Text},{c7.SelectedIndex},{r7.SelectedIndex},{p7.SelectedIndex}";

            File.WriteAllText("lap1.txt", lap1);
            File.WriteAllText("lap2.txt", lap2);
            File.WriteAllText("lap3.txt", lap3);
            File.WriteAllText("lap4.txt", lap4);
            File.WriteAllText("lap5.txt", lap5);
            File.WriteAllText("lap6.txt", lap6);
            File.WriteAllText("lap7.txt", lap7);

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


        private void c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            n11.Text = "";
            n12.Text = "";
            cl11.Text = "";
            cl12.Text = "";

            p1.Items.Clear();
            r1.Items.Clear();
            r1.ResetText();
            p1.ResetText();

            lastdata2 = "";
            foreach (var record in records)
            {
                if (record.Cath == c1.SelectedItem)
                {
                    if (record.Round != lastdata2)
                    {
                        r1.Items.Add(record.Round);
                        lastdata2 = record.Round;
                    }
                }


            }

          
           
        }

        private void r1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Items.Clear();
            foreach (var record in records)
            {
                if (record.Cath == c1.SelectedItem && record.Round == r1.SelectedItem)
                {
                    p1.Items.Add(record.Name + "  VS  " + record.Name2);
                }
            }
        }

        private void p1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_name_player(1); //court 1
        }

        public bool update_name_player(int court)
        {

            switch(court)
            {
                case 1: courtselected = p1.SelectedItem.ToString();break;
                case 2: courtselected = p2.SelectedItem.ToString(); break;
                case 3: courtselected = p3.SelectedItem.ToString(); break;
                case 4: courtselected = p4.SelectedItem.ToString(); break;
                case 5: courtselected = p5.SelectedItem.ToString(); break;
                case 6: courtselected = p6.SelectedItem.ToString(); break;
                case 7: courtselected = p7.SelectedItem.ToString(); break;

            }

            str[court] = courtselected;
                
            string[] p = str[court].Split(new string[] { "VS" }, StringSplitOptions.RemoveEmptyEntries);
            string[] playerdata = p[0].Trim().Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            string[] playerdata2 = p[1].Trim().Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);

            bool seeded = str.Contains("[");
            bool seeded1 = p[0].Contains("[");
            bool seeded2 = p[1].Contains("[");
            bool clubbracket = str.Contains("))");
            bool clubbracket1 = p[0].Contains("))");
            bool clubbracket2 = p[1].Contains("))");

            //Player 1 Split
            switch (court)
            {
                case 1: n11.Text =  playerdata[0].Trim(); break;
                case 2: n21.Text =  playerdata[0].Trim(); break;
                case 3: n31.Text =  playerdata[0].Trim(); break;
                case 4: n41.Text =  playerdata[0].Trim(); break;
                case 5: n51.Text =  playerdata[0].Trim(); break;
                case 6: n61.Text =  playerdata[0].Trim(); break;
                case 7: n71.Text =  playerdata[0].Trim(); break;
            }
            
            if (clubbracket1 == false)
            {       
                switch (court)
                {
                    case 1: cl11.Text =  playerdata[1].Trim(); break;
                    case 2: cl21.Text =  playerdata[1].Trim(); break;
                    case 3: cl31.Text =  playerdata[1].Trim(); break;
                    case 4: cl41.Text =  playerdata[1].Trim(); break;
                    case 5: cl51.Text =  playerdata[1].Trim(); break;
                    case 6: cl61.Text =  playerdata[1].Trim(); break;
                    case 7: cl71.Text =  playerdata[1].Trim(); break;
                }
                
                    if (seeded1)
                    {
                        switch (court)
                        {
                        case 1: n11.Text =  playerdata[0].Trim() + playerdata[2].Trim(); break;
                        case 2: n21.Text =  playerdata[0].Trim() + playerdata[2].Trim(); break;
                        case 3: n31.Text =  playerdata[0].Trim() + playerdata[2].Trim(); break;
                        case 4: n41.Text =  playerdata[0].Trim() + playerdata[2].Trim(); break;
                        case 5: n51.Text =  playerdata[0].Trim() + playerdata[2].Trim(); break;
                        case 6: n61.Text =  playerdata[0].Trim() + playerdata[2].Trim(); break;
                        case 7: n71.Text =  playerdata[0].Trim() + playerdata[2].Trim(); break;
                    }

                        
                    }
            }
            else
            {   
                switch (court)
                {
                    case 1: cl11.Text =  playerdata[1].Trim() + "(" + playerdata[2].Trim() + ")"; break;
                    case 2: cl21.Text =  playerdata[1].Trim() + "(" + playerdata[2].Trim() + ")"; break;
                    case 3: cl31.Text =  playerdata[1].Trim() + "(" + playerdata[2].Trim() + ")"; break;
                    case 4: cl41.Text =  playerdata[1].Trim() + "(" + playerdata[2].Trim() + ")"; break;
                    case 5: cl51.Text =  playerdata[1].Trim() + "(" + playerdata[2].Trim() + ")"; break;
                    case 6: cl61.Text =  playerdata[1].Trim() + "(" + playerdata[2].Trim() + ")"; break;
                    case 7: cl71.Text =  playerdata[1].Trim() + "(" + playerdata[2].Trim() + ")"; break;

                }

                if (seeded1)
                {
                    switch (court)
                    {
                        case 1: n11.Text =  playerdata[0].Trim() + playerdata[3].Trim(); break;
                        case 2: n21.Text =  playerdata[0].Trim() + playerdata[3].Trim(); break;
                        case 3: n31.Text =  playerdata[0].Trim() + playerdata[3].Trim(); break;
                        case 4: n41.Text =  playerdata[0].Trim() + playerdata[3].Trim(); break;
                        case 5: n51.Text =  playerdata[0].Trim() + playerdata[3].Trim(); break;
                        case 6: n61.Text =  playerdata[0].Trim() + playerdata[3].Trim(); break;
                        case 7: n71.Text =  playerdata[0].Trim() + playerdata[3].Trim(); break;
                    }
                        
                }
            }

            //Player 2 Split

            switch (court)
            {
                case 1: cl12.Text =  playerdata2[0].Trim(); break;
                case 2: cl22.Text =  playerdata2[0].Trim(); break;
                case 3: cl32.Text =  playerdata2[0].Trim(); break;
                case 4: cl42.Text =  playerdata2[0].Trim(); break;
                case 5: cl52.Text =  playerdata2[0].Trim(); break;
                case 6: cl62.Text =  playerdata2[0].Trim(); break;
                case 7: cl72.Text =  playerdata2[0].Trim(); break;
            }

            if (clubbracket2 == false)
            {
                switch (court)
                {
                    case 1: n12.Text =  playerdata2[1].Trim(); break;
                    case 2: n22.Text =  playerdata2[1].Trim(); break;
                    case 3: n32.Text =  playerdata2[1].Trim(); break;
                    case 4: n42.Text =  playerdata2[1].Trim(); break;
                    case 5: n52.Text =  playerdata2[1].Trim(); break;
                    case 6: n62.Text =  playerdata2[1].Trim(); break;
                    case 7: n72.Text =  playerdata2[1].Trim(); break;
                }
            }
            else
            {
                switch (court)
                {
                    case 1: n12.Text = playerdata2[2].Trim(); cl12.Text =  playerdata2[0].Trim() + "(" + playerdata2[1].Trim() + ")"; break;
                    case 2: n22.Text = playerdata2[2].Trim(); cl22.Text =  playerdata2[0].Trim() + "(" + playerdata2[1].Trim() + ")"; break;
                    case 3: n32.Text = playerdata2[2].Trim(); cl32.Text =  playerdata2[0].Trim() + "(" + playerdata2[1].Trim() + ")"; break;
                    case 4: n42.Text = playerdata2[2].Trim(); cl42.Text =  playerdata2[0].Trim() + "(" + playerdata2[1].Trim() + ")"; break;
                    case 5: n52.Text = playerdata2[2].Trim(); cl52.Text =  playerdata2[0].Trim() + "(" + playerdata2[1].Trim() + ")"; break;
                    case 6: n62.Text = playerdata2[2].Trim(); cl62.Text =  playerdata2[0].Trim() + "(" + playerdata2[1].Trim() + ")"; break;
                    case 7: n72.Text = playerdata2[2].Trim(); cl72.Text =  playerdata2[0].Trim() + "(" + playerdata2[1].Trim() + ")"; break;
                }
            }
            return false;

        }

        private void c2_SelectedIndexChanged(object sender, EventArgs e)
        {
            n21.Text = "";
            n22.Text = "";
            cl21.Text = "";
            cl22.Text = "";


            p3.Items.Clear();
            r3.Items.Clear();
            r3.ResetText();
            p3.ResetText();

            lastdata2 = "";
            foreach (var record in records)
            {
                if (record.Cath == c2.SelectedItem)
                {
                    if (record.Round != lastdata2)
                    {
                        r2.Items.Add(record.Round);
                        lastdata2 = record.Round;
                    }
                }


            }
        }

        private void r2_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Items.Clear();
            foreach (var record in records)
            {
                if (record.Cath == c2.SelectedItem && record.Round == r2.SelectedItem)
                {
                    p2.Items.Add(record.Name + "  VS  " + record.Name2);
                }
            }
        }

        private void p2_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_name_player(2);
        }

        private void c3_SelectedIndexChanged(object sender, EventArgs e)
        {
            n31.Text =  "";
            n32.Text =  "";
            cl31.Text = "";
            cl32.Text = "";


            p3.Items.Clear();
            r3.Items.Clear();
            r3.ResetText();
            p3.ResetText();

            lastdata2 = "";
            foreach (var record in records)
            {
                if (record.Cath == c3.SelectedItem)
                {
                    if (record.Round != lastdata2)
                    {
                        r3.Items.Add(record.Round);
                        lastdata2 = record.Round;
                    }
                }
            }
        }

        private void r3_SelectedIndexChanged(object sender, EventArgs e)
        {
            p3.Items.Clear();
            foreach (var record in records)
            {
                if (record.Cath == c3.SelectedItem && record.Round == r3.SelectedItem)
                {
                    p3.Items.Add(record.Name + "  VS  " + record.Name2);
                }
            }
        }

        private void p3_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_name_player(3);
        }

        private void p4_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_name_player(4);
        }

        private void p5_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_name_player(5);
        }

        private void r4_SelectedIndexChanged(object sender, EventArgs e)
        {
            p4.Items.Clear();
            foreach (var record in records)
            {
                if (record.Cath == c4.SelectedItem && record.Round == r4.SelectedItem)
                {
                    p4.Items.Add(record.Name + "  VS  " + record.Name2);
                }
            }
        }

        private void r5_SelectedIndexChanged(object sender, EventArgs e)
        {
            p5.Items.Clear();
            foreach (var record in records)
            {
                if (record.Cath == c5.SelectedItem && record.Round == r5.SelectedItem)
                {
                    p5.Items.Add(record.Name + "  VS  " + record.Name2);
                }
            }
        }

        private void c4_SelectedIndexChanged(object sender, EventArgs e)
        {
            n41.Text =  "";
            n42.Text =  "";
            cl41.Text = "";
            cl42.Text = "";

            p4.Items.Clear();
            r4.Items.Clear();
            r4.ResetText();
            p4.ResetText();

            lastdata2 = "";
            foreach (var record in records)
            {
                if (record.Cath == c4.SelectedItem)
                {
                    if (record.Round != lastdata2)
                    {
                        r4.Items.Add(record.Round);
                        lastdata2 = record.Round;
                    }
                }
            }
        }

        private void c5_SelectedIndexChanged(object sender, EventArgs e)
        {
            n51.Text =  "";
            n52.Text =  "";
            cl51.Text = "";
            cl52.Text = "";

            p5.Items.Clear();
            r5.Items.Clear();
            r5.ResetText();
            p5.ResetText();

            lastdata2 = "";
            foreach (var record in records)
            {
                if (record.Cath == c5.SelectedItem)
                {
                    if (record.Round != lastdata2)
                    {
                        r5.Items.Add(record.Round);
                        lastdata2 = record.Round;
                    }
                }
            }
        }

        private void clr1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear data ?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
           
            if (result == DialogResult.Yes)
            {
                n11.Text = "";
                n12.Text = "";
                cl11.Text = "";
                cl12.Text = "";
           
              
                r1.Items.Clear();
                p1.Items.Clear();
                c1.ResetText();
                r1.ResetText();
                p1.ResetText();

                courtt = 1;
                mysql.ClearTable(courtt);
                en_input(1);
            }
        }

        private void clr2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                n21.Text = "";
                n22.Text = "";
                cl21.Text = "";
                cl22.Text = "";

               
                r2.Items.Clear();
                p2.Items.Clear();
                c2.ResetText();
                r2.ResetText();
                p2.ResetText();

                courtt = 2;
                mysql.ClearTable(courtt);
                en_input(2);
            }
        }

        private void clr3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                n31.Text = "";
                n32.Text = "";
                cl31.Text = "";
                cl32.Text = "";

               
                r3.Items.Clear();
                p3.Items.Clear();
                c3.ResetText();
                r3.ResetText();
                p3.ResetText();

                courtt = 3;
                mysql.ClearTable(courtt);
                en_input(3);
            }
        }

        private void clr4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                n41.Text = "";
                n42.Text = "";
                cl41.Text = "";
                cl42.Text = "";

               
                r4.Items.Clear();
                p4.Items.Clear();
                c4.ResetText();
                r4.ResetText();
                p4.ResetText();

                courtt = 4;
                mysql.ClearTable(courtt);
                en_input(4);
            }
        }

        private void clr5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                n51.Text = "";
                n52.Text = "";
                cl51.Text = "";
                cl52.Text = "";

                
                r5.Items.Clear();
                p5.Items.Clear();
                c5.ResetText();
                r5.ResetText();
                p5.ResetText();

                courtt = 5;
                mysql.ClearTable(courtt);
                en_input(5);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                //MemoryStream ms = new MemoryStream();
                //pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] img = File.ReadAllBytes(opf.FileName);

                mysql.InsertEventData(event_name.Text, event_loct.Text, img);
            }
        }
        int courtt;
        private void in1_Click(object sender, EventArgs e)
        {

            courtt = 1;
            if (n11.Text != "")
            {
                string[] splited1 = new string[2];
                string[] splited2 = new string[2];

                Array.Clear(splited1, 0, splited1.Length);
                Array.Clear(splited2, 0, splited2.Length);

                if (n11.Text.Contains("+") == true)
                {
                    splited1 = n11.Text.Split('+');
                    splited2 = n12.Text.Split('+');
                }
                else
                {
                    splited1[0] = n11.Text;
                    splited2[0] = n12.Text;
                }

                mysql.UpdateData(courtt, c1.SelectedItem.ToString(), r1.SelectedItem.ToString(), splited1[0], splited1[1], cl11.Text, splited2[0], splited2[1], cl12.Text, "1");
            
                dis_input(1);

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !","Error Input Data",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            //string s = $"{c4.SelectedItem.ToString()};{r4.SelectedItem.ToString()};{n41.Text.ToString()};{cl41.Text.ToString()};{n42.Text.ToString()};{cl42.Text.ToString()}";
            //publish($"Lap-{courtt}/DataPl", s);


        }

        private void dis_input(int a)
        {
            switch (a)
            {
                case 1:
                    in1.Enabled = false;
                    c1.Enabled = false;
                    r1.Enabled = false;
                    p1.Enabled = false;
                    break;
                case 2:
                    in2.Enabled = false;
                    c2.Enabled = false;
                    r2.Enabled = false;
                    p2.Enabled = false;
                    break;
                case 3:
                    in3.Enabled = false;
                    c3.Enabled = false;
                    r3.Enabled = false;
                    p3.Enabled = false;
                    break;
                case 4:
                    in4.Enabled = false;
                    c4.Enabled = false;
                    r4.Enabled = false;
                    p4.Enabled = false;
                    break;
                case 5:
                    in5.Enabled = false;
                    c5.Enabled = false;
                    r5.Enabled = false;
                    p5.Enabled = false;
                    break;
                case 6:
                    in6.Enabled = false;
                    c6.Enabled = false;
                    r6.Enabled = false;
                    p6.Enabled = false;
                    break;
                case 7:
                    in7.Enabled = false;
                    c7.Enabled = false;
                    r7.Enabled = false;
                    p7.Enabled = false;
                    break;
            }
            
        }

        private void en_input(int a)
        {
            switch (a)
            {
                case 1:
                    in1.Enabled = true;
                    c1.Enabled = true;
                    r1.Enabled = true;
                    p1.Enabled = true;
                    break;
                case 2:
                    in2.Enabled = true;
                    c2.Enabled = true;
                    r2.Enabled = true;
                    p2.Enabled = true;
                    break;
                case 3:
                    in3.Enabled = true;
                    c3.Enabled = true;
                    r3.Enabled = true;
                    p3.Enabled = true;
                    break;
                case 4:
                    in4.Enabled = true;
                    c4.Enabled = true;
                    r4.Enabled = true;
                    p4.Enabled = true;
                    break;
                case 5:
                    in5.Enabled = true;
                    c5.Enabled = true;
                    r5.Enabled = true;
                    p5.Enabled = true;
                    break;
                case 6:
                    in6.Enabled = true;
                    c6.Enabled = true;
                    r6.Enabled = true;
                    p6.Enabled = true;
                    break;
                case 7:
                    in7.Enabled = true;
                    c7.Enabled = true;
                    r7.Enabled = true;
                    p7.Enabled = true;
                    break;
            }

        }

        private void in2_Click(object sender, EventArgs e)
        {
            courtt = 2;
            if (n21.Text != "")
            {
                string[] splited1 = new string[2];
                string[] splited2 = new string[2];

                Array.Clear(splited1, 0, splited1.Length);
                Array.Clear(splited2, 0, splited2.Length);

                if (n21.Text.Contains("+") == true)
                {
                    splited1 = n21.Text.Split('+');
                    splited2 = n22.Text.Split('+');
                }
                else
                {
                    splited1[0] = n21.Text;
                    splited2[0] = n22.Text;
                }

                mysql.UpdateData(courtt, c2.SelectedItem.ToString(), r2.SelectedItem.ToString(), splited1[0], splited1[1], cl21.Text, splited2[0], splited2[1], cl22.Text, "1");
                dis_input(2);

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !", "Error Input Data",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void in3_Click(object sender, EventArgs e)
        {
            courtt = 3;
            if (n31.Text != "")
            {
                string[] splited1 = new string[2];
                string[] splited2 = new string[2];

                Array.Clear(splited1, 0, splited1.Length);
                Array.Clear(splited2, 0, splited2.Length);

                if (n31.Text.Contains("+") == true)
                {
                    splited1 = n31.Text.Split('+');
                    splited2 = n32.Text.Split('+');
                }
                else
                {
                    splited1[0] = n31.Text;
                    splited2[0] = n32.Text;
                }

                mysql.UpdateData(courtt, c3.SelectedItem.ToString(), r3.SelectedItem.ToString(), splited1[0], splited1[1], cl31.Text, splited2[0], splited2[1], cl32.Text, "1");
                dis_input(3);

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !", "Error Input Data",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void in4_Click(object sender, EventArgs e)
        {
            courtt = 4;
            if (n41.Text != "")
            {
                string[] splited1 = new string[2];
                string[] splited2 = new string[2];

                Array.Clear(splited1, 0, splited1.Length);
                Array.Clear(splited2, 0, splited2.Length);

                if (n41.Text.Contains("+") == true)
                {
                    splited1 = n41.Text.Split('+');
                    splited2 = n42.Text.Split('+');
                }
                else
                {
                    splited1[0] = n41.Text;
                    splited2[0] = n42.Text;
                }

                mysql.UpdateData(courtt, c4.SelectedItem.ToString(), r4.SelectedItem.ToString(), splited1[0], splited1[1], cl41.Text, splited2[0], splited2[1], cl42.Text, "1");
                dis_input(4);

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !", "Error Input Data",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void in5_Click(object sender, EventArgs e)
        {
            courtt = 5;
            if (n51.Text != "")
            {
                string[] splited1 = new string[2];
                string[] splited2 = new string[2];

                Array.Clear(splited1, 0, splited1.Length);
                Array.Clear(splited2, 0, splited2.Length);

                if (n51.Text.Contains("+") == true)
                {
                    splited1 = n51.Text.Split('+');
                    splited2 = n52.Text.Split('+');
                }
                else
                {
                    splited1[0] = n51.Text;
                    splited2[0] = n52.Text;
                }

                mysql.UpdateData(courtt, c5.SelectedItem.ToString(), r5.SelectedItem.ToString(), splited1[0], splited1[1], cl51.Text, splited2[0], splited2[1], cl52.Text, "1");
                dis_input(5);

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !", "Error Input Data",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string lap1 = $"{excelPath},{stat1.Text},{c1.SelectedIndex},{r1.SelectedIndex},{p1.SelectedIndex}";
            string lap2 = $"{excelPath},{stat2.Text},{c2.SelectedIndex},{r2.SelectedIndex},{p2.SelectedIndex}";
            string lap3 = $"{excelPath},{stat3.Text},{c3.SelectedIndex},{r3.SelectedIndex},{p3.SelectedIndex}";
            string lap4 = $"{excelPath},{stat4.Text},{c4.SelectedIndex},{r4.SelectedIndex},{p4.SelectedIndex}";
            string lap5 = $"{excelPath},{stat5.Text},{c5.SelectedIndex},{r5.SelectedIndex},{p5.SelectedIndex}";

            File.WriteAllText("lap1.txt", lap1);
            File.WriteAllText("lap2.txt", lap2);
            File.WriteAllText("lap3.txt", lap3);
            File.WriteAllText("lap4.txt", lap4);
            File.WriteAllText("lap5.txt", lap5);
        }


        private void c6_SelectedIndexChanged(object sender, EventArgs e)
        {
            n61.Text = "";
            n62.Text = "";
            cl61.Text = "";
            cl62.Text = "";

            p6.Items.Clear();
            r6.Items.Clear();
            r6.ResetText();
            p6.ResetText();

            lastdata2 = "";
            foreach (var record in records)
            {
                if (record.Cath == c6.SelectedItem)
                {
                    if (record.Round != lastdata2)
                    {
                        r6.Items.Add(record.Round);
                        lastdata2 = record.Round;
                    }
                }


            }
        }

        private void c7_SelectedIndexChanged(object sender, EventArgs e)
        {
            n71.Text = "";
            n72.Text = "";
            cl71.Text = "";
            cl72.Text = "";

            p7.Items.Clear();
            r7.Items.Clear();
            r7.ResetText();
            p7.ResetText();

            lastdata2 = "";
            foreach (var record in records)
            {
                if (record.Cath == c7.SelectedItem)
                {
                    if (record.Round != lastdata2)
                    {
                        r7.Items.Add(record.Round);
                        lastdata2 = record.Round;
                    }
                }


            }
        }

        private void r6_SelectedIndexChanged(object sender, EventArgs e)
        {
            p6.Items.Clear();
            foreach (var record in records)
            {
                if (record.Cath == c6.SelectedItem && record.Round == r6.SelectedItem)
                {
                    p6.Items.Add(record.Name + "  VS  " + record.Name2);
                }
            }
        }

        private void r7_SelectedIndexChanged(object sender, EventArgs e)
        {
            p7.Items.Clear();
            foreach (var record in records)
            {
                if (record.Cath == c7.SelectedItem && record.Round == r7.SelectedItem)
                {
                    p7.Items.Add(record.Name + "  VS  " + record.Name2);
                }
            }
        }

        private void p6_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_name_player(6);
        }

        private void p7_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_name_player(7);
        }

        private void clr6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                n61.Text = "";
                n62.Text = "";
                cl61.Text = "";
                cl62.Text = "";

              
                r6.Items.Clear();
                p6.Items.Clear();
                c6.ResetText();
                r6.ResetText();
                p6.ResetText();

                courtt = 6;
                mysql.ClearTable(courtt);
                en_input(6);
            }
        }

        private void clr7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                n71.Text = "";
                n72.Text = "";
                cl71.Text = "";
                cl72.Text = "";

                r7.Items.Clear();
                p7.Items.Clear();
                c7.ResetText();
                r7.ResetText();
                p7.ResetText();

                courtt = 7;
                mysql.ClearTable(courtt);
                en_input(7);
            }
        }

        private void in6_Click(object sender, EventArgs e)
        {
            courtt = 6;
            if (n61.Text != "")
            {
                string[] splited1 = new string[2];
                string[] splited2 = new string[2];

                Array.Clear(splited1, 0, splited1.Length);
                Array.Clear(splited2, 0, splited2.Length);

                if (n61.Text.Contains("+") == true)
                {
                    splited1 = n61.Text.Split('+');
                    splited2 = n62.Text.Split('+');
                }
                else
                {
                    splited1[0] = n61.Text;
                    splited2[0] = n62.Text;
                }

                mysql.UpdateData(courtt, c6.SelectedItem.ToString(), r6.SelectedItem.ToString(), splited1[0], splited1[1], cl61.Text, splited2[0], splited2[1], cl62.Text, "1");
                dis_input(6);

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !", "Error Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void in7_Click(object sender, EventArgs e)
        {
            courtt = 7;
            if (n71.Text != "")
            {
                string[] splited1 = new string[2];
                string[] splited2 = new string[2];

                Array.Clear(splited1, 0, splited1.Length);
                Array.Clear(splited2, 0, splited2.Length);

                if (n71.Text.Contains("+") == true)
                {
                    splited1 = n71.Text.Split('+');
                    splited2 = n72.Text.Split('+');
                }
                else
                {
                    splited1[0] = n71.Text;
                    splited2[0] = n72.Text;
                }

                mysql.UpdateData(courtt, c7.SelectedItem.ToString(), r7.SelectedItem.ToString(), splited1[0], splited1[1], cl71.Text, splited2[0], splited2[1], cl72.Text, "1");
                dis_input(7);

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !", "Error Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm|All Files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                records.Clear();
                c1.Items.Clear();
                c2.Items.Clear();
                c3.Items.Clear();
                c4.Items.Clear();
                c5.Items.Clear();
                c6.Items.Clear();
                c7.Items.Clear();

                excelPath = openFileDialog.FileName;
                textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
                read_from_excel();
            }
        }

        public bool read_from_excel()
        {
            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; 


                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                //var records = new List<ExcelData>();

                for (int row = 3; row <= rowCount; row++) // Assuming the data starts from the second row
                {
                    var cath = worksheet.Cells[row, 3].Value?.ToString();
                    var round = worksheet.Cells[row, 6].Value?.ToString();
                    var name = worksheet.Cells[row, 7].Value?.ToString();
                    var name2 = worksheet.Cells[row, 8].Value?.ToString();
                    //var name = int.Parse(worksheet.Cells[row, 3].Value?.ToString() ?? "0");

                    records.Add(new ExcelData { Cath = cath, Name = name, Round = round, Name2 = name2 });
                }

                foreach (var record in records)
                {

                    if (record.Cath != lastdata1)
                    {
                        c1.Items.Add(record.Cath);
                        c2.Items.Add(record.Cath);
                        c3.Items.Add(record.Cath);
                        c4.Items.Add(record.Cath);
                        c5.Items.Add(record.Cath);
                        c6.Items.Add(record.Cath);
                        c7.Items.Add(record.Cath);
                        lastdata1 = record.Cath;
                    }
                }
                return false;
            }
        }
    }
}
