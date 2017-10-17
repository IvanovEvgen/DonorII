using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DonorII
{
    public partial class Form5 : Form
    {
        string IDUsers;
        public Form5(string IDUsers)
        {
            InitializeComponent();
            this.IDUsers = IDUsers;
        }
        public Form5()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Проверка дат
            //try
            //{
                SqlCommand command = new SqlCommand();
                command.Connection = ConnectionBD.ConnBD();
                command.Connection.Open();
                string[] data = dateTimePicker1.Value.ToString().Split(' ');
                string load = @"INSERT INTO GivingBlood(IDUsers, StartDataTime, Cost) VALUES('" + IDUsers + "', '" + data[0] + "', '" +Convert.ToDouble(textBox1.Text) + "')";
                command.CommandText = load;
                command.ExecuteNonQuery();
                command.Connection.Close();

                var f = new Form6();
                f.ShowDialog();
                this.Close();
            //}
            //catch { MessageBox.Show("Ошибка!"); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form1")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    this.Close();
                    return;
                }
            }
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
