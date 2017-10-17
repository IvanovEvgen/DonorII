using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonorII
{
    public partial class Form07 : Form
    {
        string IDUsers;
        public Form07(string IDUsers)
        {
            InitializeComponent();
            this.IDUsers = IDUsers;
        }
        public Form07()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Form09(IDUsers);
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new Form5(IDUsers);
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new Form110(IDUsers);
            f.ShowDialog();
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

        private void Form07_Load(object sender, EventArgs e)
        {

        }
    }
}
