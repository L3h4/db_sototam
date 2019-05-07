using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using configurator.Properties;
using Microsoft.Win32;
using System.Management;

namespace configurator
{
    
    public partial class Form2 : Form
    {
        private static string encriptionKey
        {
            get
            {
                return StringCipher.encriptionKey;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection myConnection;
        private void Button2_Click(object sender, EventArgs e)
        {
            // проверка подключения
            
            try
            {
                myConnection = new MySqlConnection($"Database={textBox2.Text};Data Source={textBox1.Text};User Id={textBox4.Text};Password={textBox5.Text}");
                myConnection.Open();
                myConnection.Close();
                label1.Text = "Ок: БД найдена";
                button1.Enabled = true;
            }
            catch
            {
                button1.Enabled = false;
                label1.Text = "Ошибка: БД не найдена";
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // сохранить
            try
            {
                MySqlCommand SQLCommandObj = new MySqlCommand(Resources.Log, myConnection);
                //label1.Text = Resources.Log;
                myConnection.Open();
                SQLCommandObj.ExecuteNonQuery();
                myConnection.Close();
                label1.Text = "Ок Готово";
            }
            catch (MySqlException)
            {
                label1.Text = "Ок Готово";
            }
            catch
            {
                label1.Text = "Ошибка что-то пошло не так";
            }
            finally { button1.Enabled = false; }
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\NBC");
            key.SetValue("mySQL_ip",StringCipher.Encrypt(textBox1.Text, encriptionKey));
            key.SetValue("mySQL_db", StringCipher.Encrypt(textBox2.Text, encriptionKey));
            key.SetValue("mySQL_login", StringCipher.Encrypt(textBox4.Text, encriptionKey));
            key.SetValue("mySQL_password", StringCipher.Encrypt(textBox5.Text, encriptionKey));
        }
    }
}
