using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Forms.Artikuj;
using TestProject.Forms.Blerje;

namespace TestProject.Forms
{
    public partial class Form_Dashboard : Form
    {
        public Form_Dashboard()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new klient_furnitor().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmLista().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmListaBlerje().Show();
        }
    }
}
