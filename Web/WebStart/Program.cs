using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using MySql.Data.MySqlClient;
using WebStart;

mysql mysql = new mysql();

mysql.Initialize();
//websql.Initialize();

mysql.GetDataCourt();
//mysql.UpdateData(2, mysql.cath[1], mysql.round[1], mysql.tim1p1[1], mysql.tim1p2[1], mysql.tim1ins[1], mysql.tim2p1[1], mysql.tim2p2[1], mysql.tim2ins[1], mysql.status[1]);
//websql.UpdateData(1, mysql.cath[1], mysql.round[1], mysql.tim1p1[1], mysql.tim1p2[1], mysql.tim1ins[1], mysql.tim2p1[1], mysql.tim2p2[1], mysql.tim2ins[1], mysql.status[1], mysql.tim1scr[1], mysql.tim2scr[1], mysql.tim1set[1], mysql.tim2set[1], mysql.ball[1]);

//mysql.GetEventData();
//websql.UpdateEventData(mysql.event_name, mysql.event_loct, mysql.image);

Console.WriteLine("Hello, World!");

