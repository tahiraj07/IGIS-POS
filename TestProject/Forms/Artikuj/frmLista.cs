using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject.Forms.Artikuj
{
    public partial class frmLista : Form
    {
        public frmLista()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmShtoArtikuj().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmImportoArtikuj().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmGrupe().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmBarkodi().Show();
        }
    }
}
