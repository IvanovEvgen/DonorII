using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonorII
{
    public partial class Form110 : Form
    {
        string IDuser;
        public Form110(string IDuser)
        {
            InitializeComponent();
            this.IDuser = IDuser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
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

        private void Form110_Load(object sender, EventArgs e)
        {

        }
        public void load_table_worker()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionBD.ConnBD();
            command.Connection.Open();
            string load = @"SELECT FirstName, LastName, PolID, DateOfBirth, Health, BloodTypeID FROM Users WHERE Email = '" + IDuser + "')";
            command.CommandText = load;
            command.ExecuteReader();
       //     command.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(command);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[0].Width = 55;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].HeaderText = "Адрес регистрации";
            dataGridView1.Columns[5].Width = 55;
            dataGridView1.Columns[5].HeaderText = "ID";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[6].HeaderText = "Должность";
            dataGridView1.Columns[7].Width = 55;
            dataGridView1.Columns[7].HeaderText = "ID";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[8].HeaderText = "Отдел";
            //label13.Text = IDuser;
            //textBox2.Text = rid["FirstName"].ToString();
            //textBox3.Text = rid["LastName"].ToString();
            //comboBox1.SelectedValue = rid["PolID"].ToString();
            //dateTimePicker1.Value = Convert.ToDateTime(rid["DateOfBirth"]);
            //comboBox2.SelectedValue = rid["Health"].ToString();
            //comboBox3.SelectedValue = rid["BloodTypeID"].ToString();
            command.Connection.Close();


        }
    }
}
