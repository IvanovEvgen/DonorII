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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form2")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    return;
                }
            }
            Form2 f1 = new Form2();
            f1.Show();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form3")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    return;
                }
            }
            Form3 f1 = new Form3();
            f1.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form118")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    return;
                }
            }
            Form118 f1 = new Form118();
            f1.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form3")
                {
                    //  MessageBox.Show("Уже открыта");
                    f.Activate();
                    return;
                }
            }
            Form3 f1 = new Form3();
            f1.Show(); 
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
