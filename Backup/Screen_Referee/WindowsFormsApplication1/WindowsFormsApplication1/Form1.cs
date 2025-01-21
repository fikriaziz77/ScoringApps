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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        MqttClient mqttclient = new MqttClient("127.0.0.1"); //ipclient
        string clientId = "Referee"; //namapc
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public string excelPath, lastdata1, lastdata2;
        public List<ExcelData> records = new List<ExcelData>();
        public string courtselected;
        public static string[] str = new string[16];
        public static string blank = " ";
        public static string ready_stat = "Ready";
        public static string match_stat = "On Match";

        string[] datalap1 = new string[10];
        string[] datalap2 = new string[10];
        string[] datalap3 = new string[10];
        string[] datalap4 = new string[10];
        string[] datalap5 = new string[10];

        private const int ClockRadius = 80;
        private const int HourHandLength = 50;
        private const int MinuteHandLength = 70;
        private const int SecondHandLength = 70;

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
            curr_date.Text = DateTime.Now.ToString("dd/M/yyyy");
            curr_time.Text = DateTime.Now.ToString("hh:mm:ss tt");

            mysql.GetDataCourt();

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

 
        }

        

        public void publish(string topic, string payload)
        {

            mqttclient.Publish(topic, Encoding.UTF8.GetBytes(payload), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

        }

        private static string[] lap = { " ","lap1.txt", "lap2.txt", "lap3.txt", "lap4.txt", "lap5.txt" };
        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialization

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Define the relative path to your executable or resource
            string relativePath = "Debug\\Panel_Information.exe";

            string fullPath = Path.Combine(baseDirectory, relativePath);

            process = new Process();
            process.StartInfo.FileName = fullPath;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

            process.Start();
            scorestart = true;

            mysql.Initialize();

           

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





        }

        private void updatelap1(string a, string b, string c, string d, string e)
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
            
            read_from_excel();
            c1.SelectedIndex = Convert.ToInt16(c);
            r1.SelectedIndex = Convert.ToInt16(d);
            p1.SelectedIndex = Convert.ToInt16(e);

            if (b == "On Match") 
            {
                in1.Enabled = false;
            }

        }

        private void updatelap2(string a, string b, string c, string d, string e)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat2.Text = b;
                      
            c2.SelectedIndex = Convert.ToInt16(c);
            r2.SelectedIndex = Convert.ToInt16(d);
            p2.SelectedIndex = Convert.ToInt16(e);

            if (b == "On Match")
            {
                in2.Enabled = false;
            }

        }

        private void updatelap3(string a, string b, string c, string d, string e)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat2.Text = b;

            c3.SelectedIndex = Convert.ToInt16(c);
            r3.SelectedIndex = Convert.ToInt16(d);
            p3.SelectedIndex = Convert.ToInt16(e);

            if (b == "On Match")
            {
                in3.Enabled = false;
            }

        }

        private void updatelap4(string a, string b, string c, string d, string e)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat4.Text = b;

            c4.SelectedIndex = Convert.ToInt16(c);
            r4.SelectedIndex = Convert.ToInt16(d);
            p4.SelectedIndex = Convert.ToInt16(e);

            if (b == "On Match")
            {
                in4.Enabled = false;
            }

        }

        private void updatelap5(string a, string b, string c, string d, string e)
        {
            excelPath = a;
            textBox1.Text = Path.GetFileNameWithoutExtension(excelPath);
            stat2.Text = b;

            c5.SelectedIndex = Convert.ToInt16(c);
            r5.SelectedIndex = Convert.ToInt16(d);
            p5.SelectedIndex = Convert.ToInt16(e);

            if (b == "On Match")
            {
                in5.Enabled = false;
            }

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
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

            
            r1.SelectedIndex = -1;
            p1.SelectedIndex = -1;
            r1.Items.Clear();
            p1.Items.Clear();

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
                    p1.Items.Add(record.Name + "   VS   " + record.Name2);
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

           
            r2.SelectedIndex = -1;
            p2.SelectedIndex = -1;
            r2.Items.Clear();
            p2.Items.Clear();

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
                    p2.Items.Add(record.Name + "   VS   " + record.Name2);
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

         
            r3.SelectedIndex = -1;
            p3.SelectedIndex = -1;
            r3.Items.Clear();
            p3.Items.Clear();

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
                    p3.Items.Add(record.Name + "   VS   " + record.Name2);
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
                    p4.Items.Add(record.Name + "   VS   " + record.Name2);
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
                    p5.Items.Add(record.Name + "   VS   " + record.Name2);
                }
            }
        }

        private void c4_SelectedIndexChanged(object sender, EventArgs e)
        {
            n41.Text =  "";
            n42.Text =  "";
            cl41.Text = "";
            cl42.Text = "";

            
            r4.SelectedIndex = -1;
            p4.SelectedIndex = -1;
            r4.Items.Clear();
            p4.Items.Clear();

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

            
            r5.SelectedIndex = -1;
            p5.SelectedIndex = -1;
            r5.Items.Clear();
            p5.Items.Clear();

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

               
                c1.SelectedIndex = -1;
                r1.SelectedIndex = -1;
                p1.SelectedIndex = -1;
                r1.Items.Clear();
                p1.Items.Clear();
                r1.ResetText();
                p1.ResetText();

                courtt = 1;
                mysql.ClearTable(courtt);
                in1.Enabled = true;
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

               
                c2.SelectedIndex = -1;
                r2.SelectedIndex = -1;
                p2.SelectedIndex = -1;
                r2.Items.Clear();
                p2.Items.Clear();
                r2.ResetText();
                p2.ResetText();



                courtt = 2;
                mysql.ClearTable(courtt);
                in2.Enabled = true;
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

               
                c3.SelectedIndex = -1;
                r3.SelectedIndex = -1;
                p3.SelectedIndex = -1;
                r3.Items.Clear();
                p3.Items.Clear();
                r3.ResetText();
                p3.ResetText();

                courtt = 3;
                mysql.ClearTable(courtt);
                in3.Enabled = true;
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

               
                c4.SelectedIndex = -1;
                r4.SelectedIndex = -1;
                p4.SelectedIndex = -1;
                r4.Items.Clear();
                p4.Items.Clear();
                r4.ResetText();
                p4.ResetText();


                courtt = 4;
                mysql.ClearTable(courtt);
                in4.Enabled = true;
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

            
                c5.SelectedIndex = -1;
                r5.SelectedIndex = -1;
                p5.SelectedIndex = -1;
                r5.Items.Clear();
                p5.Items.Clear();
                r5.ResetText();
                p5.ResetText();


                courtt = 5;
                mysql.ClearTable(courtt);
                in5.Enabled = true;
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
                in1.Enabled = false;

            }
            else
            {
                MessageBox.Show($"Can`t Input Data to Court {courtt} !","Error Input Data",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            //string s = $"{c4.SelectedItem.ToString()};{r4.SelectedItem.ToString()};{n41.Text.ToString()};{cl41.Text.ToString()};{n42.Text.ToString()};{cl42.Text.ToString()}";
            //publish($"Lap-{courtt}/DataPl", s);


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
                in2.Enabled = false;

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
                in3.Enabled = false;

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
                in4.Enabled = false;

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
                in5.Enabled = false;

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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void curr_date_Click(object sender, EventArgs e)
        {

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
                        lastdata1 = record.Cath;
                    }
                }
                return false;
            }
        }
    }
}
