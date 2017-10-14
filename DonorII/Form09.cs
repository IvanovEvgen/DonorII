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

namespace DonorII
{
    public partial class Form09 : Form
    {
        public Form09()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Year >= DateTime.Now.Year - 18)
            {
                MessageBox.Show("Вам нет 18 лет, вы не можете быть зарегистрированы!");
            }
            else
            {
                //try
                //{
                //    SqlCommand command = new SqlCommand();
                //    command.Connection = ConnectionBD.ConnBD();
                //    command.Connection.Open();
                //    string load = @"INSERT INTO Users(Email, Password, FirstName, LastName, RoleID, PolID, DateOfBirth, Health, BloodTypeID) VALUES(N'" + textBox1.Text + "', N'" + textBox2.Text + "', N'" + textBox4.Text + "', N'" + textBox5.Text + "', '2', N'" + comboBox1.SelectedValue + "', '" + Convert.ToDateTime(dateTimePicker1.Value) + "', N'" + comboBox2.SelectedItem + "', N'" + comboBox3.SelectedValue + "')";
                //    command.CommandText = load;
                //    command.ExecuteNonQuery();
                //    command.Connection.Close();
                //    var f = new Form5(textBox1.Text);
                //    f.ShowDialog();
                //    this.Close();
                //}
                //catch
                //{
                //    MessageBox.Show("Заполните все поля!");
                //}
            }


            //Если не хотят менять пароль, использовать старый!!! 
            if (Regex.IsMatch(textBox4.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}") == false)
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

            }
            var f = new Form07();
            f.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Form07();
            f.ShowDialog();
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
    }
}
