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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Enter your email address";
            textBox1.ForeColor = Color.Gray;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);

            textBox2.Text = "Enter your password";
            textBox2.ForeColor = Color.Gray;
            textBox2.Font = new Font(textBox2.Font, FontStyle.Italic);
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
             {
                 SqlCommand command = new SqlCommand();
                 command.Connection = ConnectionBD.ConnBD();
                 command.Connection.Open();
                 string load = @"SELECT Password, RoleID FROM Users WHERE Email='" + textBox1.Text + "'";
                 command.CommandText = load;
                 var rid = command.ExecuteReader();
                 rid.Read();
                 string pas = rid["Password"].ToString();
                 string role = rid["RoleID"].ToString();
                 command.Connection.Close();

                 if (textBox2.Text == pas)
                 {
                     if (role == "1")
                     {
                         Form111 obj = new Form111(textBox1.Text);
                         obj.Show();
                     }
                     else
                     {
                         Form07 obj = new Form07(textBox1.Text);
                         obj.Show();
                     }
                 }
             }
             catch { MessageBox.Show("Ошибка!"); }
             
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form07")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    this.Close();
                    return;
                }
            }
            Form07 f1 = new Form07();
            f1.Show();
            this.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) { button4_Click(sender, e); }
        }
    }
}
