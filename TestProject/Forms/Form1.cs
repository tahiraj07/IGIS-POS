using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public static string sendtext = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHide.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tbl_perdoruesit WHERE Emri='" + sendtext + "' AND Kodi='" + txtPassword.Text + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            con.Open();
            if (dt.Rows[0][0].ToString() == "1")
            {
                con = new SqlConnection(db.Connection());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Aksesi FROM tbl_perdoruesit WHERE Emri='" + sendtext + "' AND Kodi='" + txtPassword.Text + "'", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    UserType.Text = rdr.GetValue(0).ToString().Trim();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (UserType.Text == "Staf")
                {
                    string st = "Successfully logged in";

                    this.Hide();
                    new Form_Dashboard().Show();
                }


                if (UserType.Text == "Menaxher")
                {
                    string st = "Successfully logged in";

                    this.Hide();

                    //sendtext = comboBox1.Text;
                    new Form_Dashboard().Show();
                    txtPassword.Text = "";
                }
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */


            }
            else
                MessageBox.Show("Emri ose passwordi eshte GABIM");
            txtPassword.Text = "";
            con.Close();
        }
        private void clockTime_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            DataTable tbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_perdoruesit ", con);
            da.Fill(tbl);
            int i;
            DataRow last = tbl.Rows[tbl.Rows.Count - 1];
            int j = tbl.Rows.Count;
            for (i = 0; i < (tbl.Rows.Count); i++)
            {
                RadioButton bt2 = new RadioButton();
                bt2.Name = tbl.Rows[i].ItemArray[0].ToString();
                bt2.Text = tbl.Rows[i]["Emri"].ToString();

                bt2.Width = 126;
                bt2.Height = 66;

                bt2.ForeColor = Color.DarkBlue;
                bt2.BackColor = System.Drawing.Color.White;

                bt2.Appearance = Appearance.Button;
                bt2.FlatAppearance.CheckedBackColor = Color.DarkOrange;
                bt2.TabStop = true;
                bt2.UseVisualStyleBackColor = false;
                bt2.FlatStyle = FlatStyle.Flat;
                bt2.TextAlign = ContentAlignment.MiddleCenter;
                bt2.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                bt2.Cursor = Cursors.Hand;
                bt2.Click += new EventHandler(this.btn1_Click);
                //ThreadReceive = new System.Threading.Thread(table_list_click);
                flowLayoutPanel1.Controls.Add(bt2);
                con.Close();
            }
            }
        private void btn1_Click(object sender, EventArgs e)
        {
            sendtext = (sender as RadioButton).Text;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                button11_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "1";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "2";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "3";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "4";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "5";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "6";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "7";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "8";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "0" && txtPassword.Text != null)
            {
                txtPassword.Text = "9";
            }
            else
            {
                txtPassword.Text = txtPassword.Text + "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        } 

        private void timer2_Tick(object sender, EventArgs e)
        {
            CultureInfo al = new CultureInfo("al");
            label4.Text = DateTime.Now.ToString("hh:mm:ss");
            data.Text = DateTime.Now.ToLongDateString();
        }
    }
}
