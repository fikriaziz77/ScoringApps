using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStart
{
    internal class websql
    {
        private MySqlConnection connection;

        private string server;
        private string database;
        private string uid;
        private string password;


        //Initialize values
        public void Initialize()
        {
            server = "sql102.ezyro.com";
            uid = "ezyro_38141599";
            password = "Wo170601";
            database = "ezyro_38141599_bandabaru";

            string connectionString = "SERVER=" + server + ";" +
                                      "DATABASE=" + database + ";" +
                                      "UID=" + uid + ";" +
                                      "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
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

        public void UpdateEventData(string eventname, string eventloc, byte[] imge)
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
        public static string bytetoarray(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        public void UpdateData(int courtnumber, string cath, string round, string t1p1, string t1p2, string t1ins, string t2p1, string t2p2, string t2ins, string status, string t1sc, string t2sc, string t1st, string t2st, string ball)
        {
            string query = $"UPDATE court_list SET cath='{cath}', round='{round}', tim1p1='{t1p1}', tim1p2='{t1p2}', tim1ins='{t1ins}', tim2p1='{t2p1}', tim2p2='{t2p2}', tim2ins='{t2ins}', status='{status}', tim1scr={t1sc} , tim2scr={t2sc} , tim1set={t1st} , tim2set={t2st} , ball={ball}  WHERE court = {courtnumber}";

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


    }
}

