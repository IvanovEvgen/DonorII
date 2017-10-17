using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (dateTimePicker1.Value.Year >= DateTime.Now.Year - 18)
            {
                MessageBox.Show("Вам нет 18 лет, вы не можете быть зарегистрированы!");
            }
            else if (textBox4.Text == "")
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = ConnectionBD.ConnBD();
                    command.Connection.Open();
                    string load = @"UPDATE Users SET FirstName = N'"+textBox2.Text+"', LastName= N'"+textBox3.Text+"', PolID = N'"+ comboBox1.SelectedValue +"', DateOfBirth = '"+Convert.ToDateTime(dateTimePicker1.Value)+"', Health = N'"+comboBox2.SelectedItem+"', BloodTypeID = '" + comboBox3.SelectedValue + "' WHERE (Email = '"+IDuser+"')";
                    command.CommandText = load;
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            //Если не хотят менять пароль, использовать старый!!! 
            else if (Regex.IsMatch(textBox4.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}") == false)
            {
                MessageBox.Show("Пароль должен содержать: /nМинимум 6 символов, /nМинимум 1 прописная буква, /nМинимум 1 цифра, /nПо крайней мере один из следующих символов: ! @ # $ % ^");
                return;
            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else
            {
                SqlCommand command = new SqlCommand();
                command.Connection = ConnectionBD.ConnBD();
                command.Connection.Open();
                string load = @"UPDATE Users SET Password='"+textBox4.Text+"', FirstName = N'" + textBox2.Text + "', LastName= N'" + textBox3.Text + "', PolID = N'" + comboBox1.SelectedValue + "', DateOfBirth = '" + Convert.ToDateTime(dateTimePicker1.Value) + "', Health = N'" + comboBox2.SelectedItem + "', BloodTypeID = '" + comboBox3.SelectedValue + "' WHERE (Email = '" + IDuser + "')";
                command.CommandText = load;
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            this.Close();
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
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = ConnectionBD.ConnBD();
                command.Connection.Open();
                string load = @"SELECT FirstName, LastName, PolID, DateOfBirth, Health, BloodTypeID FROM Users WHERE Email = '" + IDuser + "'";
                command.CommandText = load;
                var rid = command.ExecuteReader();
                rid.Read();
                label13.Text = IDuser;
                textBox2.Text = rid["FirstName"].ToString();
                textBox3.Text = rid["LastName"].ToString();
                comboBox1.SelectedValue = rid["PolID"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(rid["DateOfBirth"]);
                comboBox2.SelectedItem = rid["Health"].ToString();
                comboBox3.SelectedValue = rid["BloodTypeID"].ToString();
                command.Connection.Close();
            }
            catch { MessageBox.Show("Ошибка!"); }
        }
    }
}
