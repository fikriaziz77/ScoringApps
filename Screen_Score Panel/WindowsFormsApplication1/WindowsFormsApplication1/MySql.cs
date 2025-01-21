using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
//using System.Windows.Documents;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace WindowsFormsApplication1
{



    class MySql
    {
        private MySqlConnection connection;
        public string server;
        private string database;
        private string uid;
        private string password;

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
        public void Initialize(string server2)
        {
            server = server2;
            database = "score_board";
            uid = "root";
            password = "";
     
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
  
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
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
                        MessageBox.Show("Cannot connect to server,  Contact administrator");
                        break;                  
                        
                        
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }






        //Close connection
        public bool CloseConnection()
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
        public void InsertData(int courtnumber)
        {
            string query = "UPDATE court_list SET round='R32', tim1p1='Fikri', tim1p2='', tim1ins='PB Polman', tim2p1='Aziz', tim2p2='', tim2ins='PB ITB', tim1scr='12', tim2scr='18', tim1set='', tim2set='',ball='0' WHERE court = " + courtnumber;

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

        public void UpdateScore(int courtnumber,string sc1,string sc2,string st1, string st2, string bal)
        {
            string query = "UPDATE court_list SET tim1scr='" + sc1 + "', tim2scr='" + sc2 + "', tim1set='" + st1 + "', tim2set='" + st2 + "',ball='" + bal + "' WHERE court = " + courtnumber;

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
        public void UpdateStatus(int courtnumber, string stat)
        {
            string query = "UPDATE court_list SET status='" + stat + "' WHERE court = " + courtnumber;

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


        //Delete statement
        public void ClearTable(int courtnumber)
        {
            string query = "UPDATE court_list SET cath='', round='', tim1p1='', tim1p2='', tim1ins='', tim2p1='', tim2p2='', tim2ins='', tim1scr='', tim2scr='', tim1set='', tim2set='',ball='',status='' WHERE court = " + courtnumber; 

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

            list[0] = new List<string>();   //court
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
                    list[0].Add(dataReader["court"] + "");
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