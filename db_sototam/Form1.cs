using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_sototam
{
    public partial class Form1 : Form
    {
        private DBconnector DBcon;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            AppSettings.Configure();
            DBcon = new DBconnector();
            
            if (DBcon.checkConnection()) { }
            else
            {
                DialogResult r =  MessageBox.Show(null,"ОШИБКА: БД не найдена, запустить конфигуратор?", "ОШИБКА",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(r == DialogResult.Yes)
                {
                    PictureBox1_Click(this, new EventArgs());
                }
                else
                {
                    Application.Exit();
                }
            }
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            
            string id = textBox1.Text;
            string mode = comboBox1.Text;
            string name = textBox3.Text;
            string coment = textBox2.Text;


            if (id == null || id == "id компьютера")
            {
                MessageBox.Show("id неверно");
            }
            else if (mode == null || mode == "Выдать/принять")
            {
                MessageBox.Show("Выберите выдать/принять");
            }
            else if (name == null || name == "Ф.И.О.")
            {
                MessageBox.Show("введите имя");
            }
            else
            {
                
                if(DBcon.insertInfo(id, mode, name, coment)) { label1.Text = "ОК"; }
                else { label1.Text = "ОШИБКА"; Environment.Exit(1); }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = Environment.CurrentDirectory + "\\configurator.exe";
            try
            {
                Process.Start(proc);
            }
            catch { }
            Application.Exit();
        }
    }
}



