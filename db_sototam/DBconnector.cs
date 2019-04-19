using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace db_sototam
{
    class DBconnector
    {
        private MySqlConnection myConnection;
        public DBconnector()
        {
            myConnection = new MySqlConnection(AppSettings.mySQL_connect);
        }
        public bool checkConnection()
        {
            try
            {
                myConnection.Open();
                myConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertInfo(string id, string mode, string name, string coment)
        {
            try
            {
                //string curDate = DateTime.Now.ToUniversalTime().ToString().Replace(".", "-");
                string Command = $"INSERT INTO `Log` (`id`, `Comp_id`, `FIO`, `What`, `Date`, `Comment`) VALUES (NULL, '{id}', '{name}', '{mode}', NULL, '{coment}')";
                MySqlCommand SQLCommandObj = new MySqlCommand(Command, myConnection);
                myConnection.Open();
                SQLCommandObj.ExecuteNonQuery();
                myConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
