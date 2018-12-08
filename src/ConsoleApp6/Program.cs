using MySql.Data.MySqlClient;
using System;
using Dapper;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            //MySql.Data
            {
                var connectString = "server=127.0.0.1;por=3306;userid=root;pwd=123456;database=datamip;SslMode=none;";
                //MySqlConnection mySqlConnection = new MySqlConnection(connectString);


                //select
                var ds = MySqlHelper.ExecuteDataset(connectString, "select * from users");

                //select2
                var reader = MySqlHelper.ExecuteReader(connectString, "select * from users");
                var user = new Users();
                while (reader.Read())
                {
                    user.UserId = reader.GetInt32("UserID");
                    user.UserNick = reader.GetString("UserNick");
                    user.LoginIP = reader.GetString("LoginIP");
                    user.Email = reader.GetString("Email");
                }
                reader.Close();

                //update
                var result = MySqlHelper.ExecuteNonQuery(connectString, "update users set Email='786744873@qq.com' where UserID=1");
            }


            //Dapper
            {
                var connectString = "server=127.0.0.1;por=3306;userid=root;pwd=123456;database=datamip;SslMode=none;";
                MySqlConnection mySqlConnection = new MySqlConnection(connectString);

                //select
                var userList = mySqlConnection.Query<Users>("select * from users where UserID=@UserID",new { UserID=2 });

                //update
                var nums = mySqlConnection.Execute("update users set Email='786744873@qq.com' where UserID=1");
            }

        }

        class Users
        {
            public int UserId { get; set; }
            public string UserNick { get; set; }
            public string LoginIP { get; set; }
            public string Email { get; set; }
        }
    }
}
