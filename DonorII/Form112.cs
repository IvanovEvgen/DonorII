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
            dataGridView1.Columns[0].HeaderText = "Имя";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "e-Mail";
            DataGridViewButtonColumn obj = new DataGridViewButtonColumn() { HeaderText = "Управление", UseColumnTextForButtonValue = true, Text = "Edit" };
            dataGridView1.Columns.Add(obj);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[3, i].Tag = dataGridView1[2, i].Value.ToString();
            }
            label5.Text = dataGridView1.RowCount.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedItem)
            {
                case "Имя": dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Descending); break;
                case "Фамилия":dataGridView1.Sort(dataGridView1.Columns[1], System.ComponentModel.ListSortDirection.Descending); break;
                case "E-mail": dataGridView1.Sort(dataGridView1.Columns[2], System.ComponentModel.ListSortDirection.Descending); break;
                case "Количество": dataGridView1.Sort(dataGridView1.Columns[3], System.ComponentModel.ListSortDirection.Descending); break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionBD.ConnBD();
            command.Connection.Open();
            string load = @"Select Users.FirstName,  Users.LastName, Users.Email, sum(Cost) AS SUMM FROM Users, GivingBlood WHERE (Users.Email = GivingBlood.IDUsers)
            GROUP BY Users.Email, Users.FirstName, Users.LastName";
            command.CommandText = load;

            SqlDataAdapter da = new SqlDataAdapter(command);
            dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[0].HeaderText = "Имя";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "e-Mail";
            dataGridView1.Columns[3].HeaderText = "Сумма сданной крови";

            label5.Text = dataGridView1.RowCount.ToString();

            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[3, i].Value.ToString() != comboBox3.SelectedItem.ToString()) { dataGridView1.Rows.Remove(dataGridView1.Rows[i]); i--; }
                else if (comboBox3.SelectedIndex == 10)
                {
                    if (Convert.ToDouble(dataGridView1[3, i].Value) < 550){ dataGridView1.Rows.Remove(dataGridView1.Rows[i]); i--; }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form112_Load(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell) != null)
            {
                Form113 obj = new Form113(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                obj.ShowDialog();
            }
        }
    }
}
