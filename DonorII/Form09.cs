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
    public partial class Form09 : Form
    {
        string IDuser;
        public Form09(string IDuser)
        {
            InitializeComponent();
            this.IDuser = IDuser;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Сохранение новых данных пользователя
           
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void Form09_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.BloodType". При необходимости она может быть перемещена или удалена.
            this.bloodTypeTableAdapter.Fill(this.database1DataSet.BloodType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Pol". При необходимости она может быть перемещена или удалена.
            this.polTableAdapter.Fill(this.database1DataSet.Pol);
            //Загрузка данных пользователя
 //           try
 //           {
                SqlCommand command = new SqlCommand();
                command.Connection = ConnectionBD.ConnBD();
                command.Connection.Open();
                string load = @"SELECT FirstName, LastName, PolID, DateOfBirth, Health, BloodTypeID FROM Users WHERE Email = '" + IDuser + "')";
                command.CommandText = load;
                var rid = command.ExecuteReader();
                rid.Read();
                label13.Text = IDuser;
                textBox2.Text = rid["FirstName"].ToString();
                textBox3.Text = rid["LastName"].ToString();
                comboBox1.SelectedValue = rid["PolID"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(rid["DateOfBirth"]);
                comboBox2.SelectedValue = rid["Health"].ToString();
                comboBox3.SelectedValue = rid["BloodTypeID"].ToString();
                command.Connection.Close();
//            }
//            catch { MessageBox.Show("Ошибка!"); }
        }
    }
}
