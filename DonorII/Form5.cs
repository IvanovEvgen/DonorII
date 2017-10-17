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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Проверка дат
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = ConnectionBD.ConnBD();
                command.Connection.Open();
                string load = @"INSERT INTO GivingBlood(IDUsers, StartDataTime, Cost) VALUES('" + IDUsers + "', '" + Convert.ToDateTime(dateTimePicker1.Value) + "', '" + Convert.ToDecimal(textBox1.Text) + "')";
                command.CommandText = load;
                command.ExecuteNonQuery();
                command.Connection.Close();

                var f = new Form6();
                f.ShowDialog();
                this.Close();
            }
            catch { MessageBox.Show("Ошибка!"); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
