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
    public partial class Form08 : Form
    {
        public Form08()
        {
            InitializeComponent();
        }

        private void Form08_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.BloodType". При необходимости она может быть перемещена или удалена.
            this.bloodTypeTableAdapter.Fill(this.database1DataSet.BloodType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Pol". При необходимости она может быть перемещена или удалена.
            this.polTableAdapter.Fill(this.database1DataSet.Pol);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
