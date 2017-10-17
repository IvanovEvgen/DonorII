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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form3();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form4();
            f.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form3")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    this.Close();
                    return;
                }
            }
            Form3 f1 = new Form3();
            f1.Show();
            this.Close();
        }
    }
}
