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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.BloodType". При необходимости она может быть перемещена или удалена.
            this.bloodTypeTableAdapter.Fill(this.database1DataSet.BloodType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Pol". При необходимости она может быть перемещена или удалена.
            this.polTableAdapter.Fill(this.database1DataSet.Pol);
            textBox1.Text = "Email";
            textBox1.ForeColor = Color.Gray;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);

            textBox2.Text = "Пароль";
            textBox2.ForeColor = Color.Gray;
            textBox2.Font = new Font(textBox2.Font, FontStyle.Italic);

            textBox3.Text = "Повторите пароль";
            textBox3.ForeColor = Color.Gray;
            textBox3.Font = new Font(textBox1.Font, FontStyle.Italic);

            textBox4.Text = "Имя";
            textBox4.ForeColor = Color.Gray;
            textBox4.Font = new Font(textBox2.Font, FontStyle.Italic);

            textBox5.Text = "Фамилия";
            textBox5.ForeColor = Color.Gray;
            textBox5.Font = new Font(textBox2.Font, FontStyle.Italic);


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
            textBox1.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.ForeColor = Color.Black;
            textBox2.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox3.ForeColor = Color.Black;
            textBox3.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox4.ForeColor = Color.Black;
            textBox4.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = null;
            textBox5.ForeColor = Color.Black;
            textBox5.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form5();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//Регистрация
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionBD.ConnBD();
            command.Connection.Open();
            string load = @"INSERT INTO User(Email, Password, FirstName, LastName, RoleID, PolID, DateOfBirth, Health, BloodTypeID) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '"+2+"', '"+ comboBox1.SelectedValue +"', '"+dateTimePicker1.Value+"', '"+comboBox2.SelectedText+"', '"+comboBox3.SelectedValue+"')";
            command.CommandText = load;
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
