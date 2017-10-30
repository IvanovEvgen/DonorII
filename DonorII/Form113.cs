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
    public partial class Form113 : Form
    {
        string ID;
        public Form113(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void Form113_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = ConnectionBD.ConnBD();
                command.Connection.Open();
                string load = @"SELECT FirstName, LastName, PolID, DateOfBirth, Health, BloodTypeID FROM Users WHERE Email = '" + ID + "'";
                command.CommandText = load;
                var rid = command.ExecuteReader();
                rid.Read();
                label13.Text = ID;
                label3.Text = rid["FirstName"].ToString();
                label5.Text = rid["LastName"].ToString();
                label6.Text = rid["PolID"].ToString();
                label11.Text = (rid["DateOfBirth"]).ToString();
                label14.Text = rid["Health"].ToString();
                label16.Text = rid["BloodTypeID"].ToString();
                command.Connection.Close();
            }
            catch { MessageBox.Show("Ошибка!"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form09 obj = new Form09(ID);
            obj.ShowDialog();
            Form113_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form115 obj = new Form115(label3.Text + " "+ label5.Text);
            obj.ShowDialog();
        }
    }
}
