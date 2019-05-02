using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Management;

namespace db_sototam
{
    public static class AppSettings
    {
        // ну типа сюда нужно всавить свою инфу
        public static string mySQL_ip;// = "localhost";
        public static string mySQL_db;// = "comp_log";
        //public static string mySQL_table;// = "log";
        public static string mySQL_login;// = "root";
        public static string mySQL_password;// = "";
        private static string encriptionKey
            {
            get
            {
                string cpuInfo = string.Empty;
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (cpuInfo == "")
                    {
                        //Get only the first CPU's ID
                        cpuInfo = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }
                return Environment.MachineName + "::" + cpuInfo;
            }
            }

        // это трогать не нужно
        public static string mySQL_connect;



        public static void Configure()
        {
            using(RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\NBC"))
            {
                mySQL_ip = StringCipher.Decrypt(key?.GetValue("mySQL_ip")?.ToString(), encriptionKey);
                mySQL_db = StringCipher.Decrypt(key?.GetValue("mySQL_db")?.ToString(), encriptionKey);
                //mySQL_table = StringCipher.Decrypt(key?.GetValue("mySQL_table")?.ToString(), encriptionKey);
                mySQL_login = StringCipher.Decrypt(key?.GetValue("mySQL_login")?.ToString(), encriptionKey);
                mySQL_password = StringCipher.Decrypt(key?.GetValue("mySQL_password")?.ToString(), encriptionKey);
                mySQL_connect = $"Database={mySQL_db};Data Source={mySQL_ip};User Id={mySQL_login};Password={mySQL_password}";
            }
            
        }

    }
}
