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
    public partial class Form112 : Form
    {
        DataTable dt;
        public Form112()
        {
            InitializeComponent();
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

        private void Form112_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionBD.ConnBD();
            command.Connection.Open();
            string load = @"Select Users.FirstName,  Users.LastName, Users.Email, sum(Cost) AS SUMM FROM Users, GivingBlood WHERE (Users.Email = GivingBlood.IDUsers )
GROUP BY Users.Email, Users.FirstName, Users.LastName";
            command.CommandText = load;

            SqlDataAdapter da = new SqlDataAdapter(command);
            dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[0].HeaderText = "Имя";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].HeaderText = "e-Mail";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].HeaderText = "Сумма сданной крови";

            label5.Text = dataGridView1.RowCount.ToString();

            //Не Сюда пока
            //try
            //{
            //    SqlCommand command = new SqlCommand();
            //    command.Connection = ConnectionBD.ConnBD();
            //    command.Connection.Open();
            //    string load = @"SELECT FirstName, LastName, PolID, DateOfBirth, Health, BloodTypeID FROM Users WHERE Email = '" + IDuser + "'";
            //    command.CommandText = load;
            //    var rid = command.ExecuteReader();
            //    rid.Read();

            //    label13.Text = IDuser;
            //    textBox2.Text = rid["FirstName"].ToString();
            //    textBox3.Text = rid["LastName"].ToString();
            //    comboBox1.SelectedValue = rid["PolID"].ToString();
            //    dateTimePicker1.Value = Convert.ToDateTime(rid["DateOfBirth"]);
            //    comboBox2.SelectedItem = rid["Health"].ToString();
            //    comboBox3.SelectedValue = rid["BloodTypeID"].ToString();
            //    command.Connection.Close();
            //}
            //catch { MessageBox.Show("Ошибка!"); }
        }
    }
}
