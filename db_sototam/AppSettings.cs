using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_sototam
{
    public static class AppSettings
    {
        // ну типа сяда нужно всавить свою инфу
        public const string mySQL_ip = "localhost";
        public const string mySQL_db = "comp_log";
        public const string mySQL_table = "log";
        public const string mySQL_login = "root";
        public const string mySQL_password = "";

        // это трогать не нужно
        public static string mySQL_connect = $"Database={mySQL_db};Data Source={mySQL_ip};User Id={mySQL_login};Password={mySQL_password}";
    }
}
