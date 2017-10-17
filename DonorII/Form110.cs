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
        System.Data.DataTable dt;
        string IDuser;
        public Form110(string IDuser)
        {
            InitializeComponent();
            this.IDuser = IDuser;
            load_table();
            pol();
        }
        public Form110()
        {
            InitializeComponent();
           
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
        public void load_table()
        { 
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionBD.ConnBD();
            command.Connection.Open();
            string load = @"Select GivingBlood.StartDataTime, GivingBlood.Cost, BloodType.BloodType, Users.Health 
                            From GivingBlood JOIN Users ON GivingBlood.IDUsers = Users.Email JOIN BloodType ON (BloodType.BloodType = Users.BloodTypeID) Where GivingBlood.IDUsers = '" + IDuser + "' and BloodType.BloodType = Users.BloodTypeID";
            command.CommandText = load;

            SqlDataAdapter da = new SqlDataAdapter(command);
            dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[0].HeaderText = "Дата";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].HeaderText = "Количество крови в мл";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].HeaderText = "Группа крови";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].HeaderText = "Здоровье";
            
        }

        public void pol()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionBD.ConnBD();
            command.Connection.Open();
            string load = @"Select Users.PolID, Users.DateOfBirth From Users  Where Users.Email = '" + IDuser + "'";
            command.CommandText = load;
            
            var rid = command.ExecuteReader();
            rid.Read();
            label6.Text = rid["PolID"].ToString();
            DateTime bd = Convert.ToDateTime(rid["DateOfBirth"]);
            
            command.Connection.Close();
            var t = DateTime.Now.Year - bd.Year;
            if (t >= 18 || t <= 21)
            {
                label7.Text = "18-21";
            }
            else if (t >= 22 || t <= 28)
            {
                label7.Text = "22-28";
            }
            else if (t >= 29 || t <= 36)
            {
                label7.Text = "29-36";
            }
            else if (t >= 37)
            {
                label7.Text = "37-..";
            }
          
         
        }
    }
}
