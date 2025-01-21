using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStart
{
    class mysql
    { 
        private MySqlConnection connection;

        private string server;
        private string database;
        private string uid;
        private string password;

        public string event_name, event_loct;
        public byte[] image;

        public string[] cath = new string[100];
        public string[] round = new string[100];
        public string[] tim1p1 = new string[100];
        public string[] tim1p2 = new string[100];
        public string[] tim1ins = new string[100];
        public string[] tim2p1 = new string[100];
        public string[] tim2p2 = new string[100];
        public string[] tim2ins = new string[100];

        public string[] tim1scr = new string[100];
        public string[] tim2scr = new string[100];
        public string[] tim1set = new string[100];
        public string[] tim2set = new string[100];
        public string[] ball = new string[100];
        public string[] status = new string[100];


        //Initialize values
        public void Initialize()
        {
            server = "localhost";
            database = "score_board";
            uid = "root";
            password = "";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;

                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void UpdateData(int courtnumber, string cath, string round, string t1p1, string t1p2, string t1ins, string t2p1, string t2p2, string t2ins, string status)
        {
            string query = $"UPDATE court_list SET cath='{cath}', round='{round}', tim1p1='{t1p1}', tim1p2='{t1p2}', tim1ins='{t1ins}', tim2p1='{t2p1}', tim2p2='{t2p2}', tim2ins='{t2ins}', status='{status}' WHERE court = {courtnumber}";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public static string bytetoarray(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }



        public void InsertEventData(string eventname, string eventloc, byte[] imge)
        {
            string gambar = bytetoarray(imge);


            string query = "UPDATE data_event SET event_name='" + eventname + "', location='" + eventloc + "', image1=0x" + gambar + " WHERE number = 0 ";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void GetEventData()
        {
            string query = "SELECT * FROM data_event ";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();

                da.Fill(table);

                event_name = table.Rows[0][1].ToString();
                event_loct = table.Rows[0][2].ToString();
                image = (byte[])table.Rows[0][3];

                //close Data Reader
                da.Dispose();

                //close Connection
                this.CloseConnection();
            }
        }





        //Delete statement
        public void ClearTable(int courtnumber)
        {
            string query = "UPDATE court_list SET cath= '', round='', tim1p1='', tim1p2='', tim1ins='', tim2p1='', tim2p2='', tim2ins='', tim1scr='', tim2scr='', tim1set='', tim2set='',ball='',status='' WHERE court = " + courtnumber;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] GetDataCourt()
        {
            string query = "SELECT * FROM court_list ";

            //Create a list to store the result
            List<string>[] list = new List<string>[14];

            list[0] = new List<string>();   //cath
            list[1] = new List<string>();   //round
            list[2] = new List<string>();   //tim1 p1
            list[3] = new List<string>();   //tim1 p2
            list[4] = new List<string>();   //tim1 instansi
            list[5] = new List<string>();   //tim2 p1
            list[6] = new List<string>();   //tim2 p2
            list[7] = new List<string>();   //tim2 instansi
            list[8] = new List<string>();   //tim1 score
            list[9] = new List<string>();   //tim2 score
            list[10] = new List<string>();  //tim1 set game
            list[11] = new List<string>();  //tim2 set game
            list[12] = new List<string>();  //ball
            list[13] = new List<string>();  //status

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["cath"] + "");
                    list[1].Add(dataReader["round"] + "");
                    list[2].Add(dataReader["tim1p1"] + "");
                    list[3].Add(dataReader["tim1p2"] + "");
                    list[4].Add(dataReader["tim1ins"] + "");
                    list[5].Add(dataReader["tim2p1"] + "");
                    list[6].Add(dataReader["tim2p2"] + "");
                    list[7].Add(dataReader["tim2ins"] + "");
                    list[8].Add(dataReader["tim1scr"] + "");
                    list[9].Add(dataReader["tim2scr"] + "");
                    list[10].Add(dataReader["tim1set"] + "");
                    list[11].Add(dataReader["tim2set"] + "");
                    list[12].Add(dataReader["ball"] + "");
                    list[13].Add(dataReader["status"] + "");
                }

                int a = 1;
                foreach (var record in list[0])
                {
                    cath[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[1])
                {
                    round[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[2])
                {
                    tim1p1[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[3])
                {
                    tim1p2[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[4])
                {
                    tim1ins[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[5])
                {
                    tim2p1[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[6])
                {
                    tim2p2[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[7])
                {
                    tim2ins[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[8])
                {
                    tim1scr[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[9])
                {
                    tim2scr[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[10])
                {
                    tim1set[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[11])
                {
                    tim2set[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[12])
                {
                    ball[a] = record.ToString();
                    a++;
                }
                a = 1;
                foreach (var record in list[13])
                {
                    status[a] = record.ToString();
                    a++;
                }
                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }

        }

    }
}
