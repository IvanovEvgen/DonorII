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
using System.Text.RegularExpressions;

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
            // Cвета this.bloodTypeTableAdapter.Fill(this.database1DataSet.BloodType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Pol". При необходимости она может быть перемещена или удалена.
            //Света this.polTableAdapter.Fill(this.database1DataSet.Pol);
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

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form2")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    this.Close();
                    return;
                }
            }
            Form2 f1 = new Form2();
            f1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, @"\A[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\z") == false)
            {
                MessageBox.Show("Не правильно введен адрес почты. Повторите попытку.");
                return;
            }
           else if (Regex.IsMatch(textBox2.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}") == false)
            {
                MessageBox.Show("Пароль должен содержать: /nМинимум 6 символов, /nМинимум 1 прописная буква, /nМинимум 1 цифра, /nПо крайней мере один из следующих символов: ! @ # $ % ^");
                return;
            }
            else if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else if (dateTimePicker1.Value.Year >= DateTime.Now.Year-18)
            {
                MessageBox.Show("Вам нет 18 лет, вы не можете быть зарегистрированы!");
            }
            else
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = ConnectionBD.ConnBD();
                    command.Connection.Open();
                    string load = @"INSERT INTO Users(Email, Password, FirstName, LastName, RoleID, PolID, DateOfBirth, Health, BloodTypeID) VALUES(N'" + textBox1.Text + "', N'" + textBox2.Text + "', N'" + textBox4.Text + "', N'" + textBox5.Text + "', '2', N'" + comboBox1.SelectedValue + "', '" + Convert.ToDateTime(dateTimePicker1.Value) + "', N'" + comboBox2.SelectedItem + "', N'" + comboBox3.SelectedValue + "')";
                    command.CommandText = load;
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    var f = new Form5(textBox1.Text);
                    f.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
