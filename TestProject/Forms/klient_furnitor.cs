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

namespace TestProject.Forms
{
    public partial class klient_furnitor : Form
    {
        public klient_furnitor()
        {
            InitializeComponent();
        }
        public void pastro()
        {
            emri_f.Text = "";
            adresa_f.Text = "";
            nr_f.Text = "";
            id_f.Text = "";
            textBox7.Text = "";
            kompania.Text = "";
            btn_ruaj.Text = "Ruaj";
        }
        public void pastro_klient()
        {
            txtSupName.Text = "";
            txtSupAddress.Text = "";
            txtSupPhone.Text = "";
            txtSupID.Text = "";
            TextBox6.Text = "";
            btnSave.Text = "Ruaj";
        }
        public void rifreskoDG()
        {
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter dapt = new SqlDataAdapter("select * from tbl_furnitor", con);
            dapt.Fill(tbl);
            dataGridView1.Rows.Clear();
            int i;
            for (i = 0; i < tbl.Rows.Count; i++)

            {

                dataGridView1.Rows.Add(tbl.Rows[i].ItemArray[0].ToString(), tbl.Rows[i].ItemArray[1].ToString(), tbl.Rows[i].ItemArray[2].ToString(), tbl.Rows[i].ItemArray[3].ToString(), tbl.Rows[i].ItemArray[4].ToString());
            }
            dataGridView1.ClearSelection();

            con.Close();

        }
        public void rifreskoDG_klient()
        {
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter dapt = new SqlDataAdapter("select * from tbl_klient", con);
            dapt.Fill(tbl);
            dgw.Rows.Clear();
            int i;
            for (i = 0; i < tbl.Rows.Count; i++)

            {

                dgw.Rows.Add(tbl.Rows[i].ItemArray[0].ToString(), tbl.Rows[i].ItemArray[1].ToString(), tbl.Rows[i].ItemArray[2].ToString(), tbl.Rows[i].ItemArray[3].ToString());
            }
            dgw.ClearSelection();

            con.Close();

        }
        private void shtofurnitor()
        {
            if (btn_ruaj.Text == "Ruaj")
            {
                SqlConnection con = new SqlConnection();
                databaza_con db = new databaza_con();// making connection 
                con = new SqlConnection(db.Connection()); 
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_furnitor(emri,adresa, nr_cel,kompania) VALUES('" + emri_f.Text + "','" + adresa_f.Text + "','" + nr_f.Text + "','" + kompania.Text + "')", con);

                cmd.ExecuteNonQuery();
                dataGridView1.Refresh();
                MessageBox.Show("Regjistrimi u krye");
                pastro();
                rifreskoDG();
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection();
                databaza_con db = new databaza_con();// making connection 
                con = new SqlConnection(db.Connection());
                con.Open();
                SqlCommand cm = new SqlCommand("update  tbl_furnitor SET emri=@k,adresa=@art,nr_cel=@b,kompania=@kp where id=@id", con);
                cm.Parameters.AddWithValue("@id", id_f.Text);
                cm.Parameters.AddWithValue("@k", emri_f.Text);
                cm.Parameters.AddWithValue("@art", adresa_f.Text);
                cm.Parameters.AddWithValue("@b", nr_f.Text);
                cm.Parameters.AddWithValue("@kp", kompania.Text);
                cm.ExecuteNonQuery();
                dataGridView1.Refresh();
                MessageBox.Show("Perditesimi u krye");
                pastro();
                rifreskoDG();
                con.Close();
            }

        }
        private void shtoklient()
        {
            if (btnSave.Text == "Ruaj")
            {
                SqlConnection con = new SqlConnection();
                databaza_con db = new databaza_con();// making connection 
                con = new SqlConnection(db.Connection());
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_klient(emri,adresa, nrcel) VALUES('" + txtSupName.Text + "','" + txtSupAddress.Text + "','" + txtSupPhone.Text + "')", con);

                cmd.ExecuteNonQuery();
                dgw.Refresh();
                MessageBox.Show("Regjistrimi u krye");
                pastro();
                rifreskoDG_klient();
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection();
                databaza_con db = new databaza_con();// making connection 
                con = new SqlConnection(db.Connection());
                con.Open();
                SqlCommand cm = new SqlCommand("update  tbl_klient SET emri=@k,adresa=@art,nrcel=@b where id=@id", con);
                cm.Parameters.AddWithValue("@id", txtSupID.Text);
                cm.Parameters.AddWithValue("@k", txtSupName.Text);
                cm.Parameters.AddWithValue("@art", txtSupAddress.Text);
                cm.Parameters.AddWithValue("@b", txtSupPhone.Text);
                cm.ExecuteNonQuery();
                dgw.Refresh();
                MessageBox.Show("Perditesimi u krye");
                pastro();
                rifreskoDG_klient();
                con.Close();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            con.Open();

            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                DataGridViewRow dr = dgw.Rows[i];
                if (dr.Selected == true)
                {
                    dgw.Rows.RemoveAt(i);
                    try
                    {
                        SqlCommand da = new SqlCommand("delete from tbl_klient where id=@id", con);
                        da.Parameters.AddWithValue("@id", txtSupID.Text);

                        da.ExecuteNonQuery();
                        dgw.Refresh();
                        //cmd.ExecuteNonQuery();
                        pastro();
                        rifreskoDG_klient();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }


            }
        }

        private void klient_furnitor_Load(object sender, EventArgs e)
        {
            textBox7.Focus();
            rifreskoDG();
            TextBox6.Focus();
            rifreskoDG_klient();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            con.Open();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow dr = dataGridView1.Rows[i];
                if (dr.Selected == true)
                {
                    dataGridView1.Rows.RemoveAt(i);
                    try
                    {
                        SqlCommand da = new SqlCommand("delete from tbl_furnitor where id=@id", con);
                        da.Parameters.AddWithValue("@id", id_f.Text);

                        da.ExecuteNonQuery();
                        dataGridView1.Refresh();
                        //cmd.ExecuteNonQuery();
                        pastro();
                        rifreskoDG();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pastro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shtofurnitor();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr;
                    dr = dataGridView1.SelectedRows[0];
                    id_f.Text = dr.Cells[0].Value.ToString();
                    emri_f.Text = dr.Cells[1].Value.ToString();
                    adresa_f.Text = dr.Cells[2].Value.ToString();
                    nr_f.Text = dr.Cells[3].Value.ToString();
                    kompania.Text = dr.Cells[4].Value.ToString();
                    btn_ruaj.Text = "Perditeso";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter dapt = new SqlDataAdapter("select * from tbl_furnitor where emri like '%" + textBox7.Text + "%'", con);
            dapt.Fill(tbl);
            dataGridView1.Rows.Clear();
            int i;
            for (i = 0; i < tbl.Rows.Count; i++)

            {

                dataGridView1.Rows.Add(tbl.Rows[i].ItemArray[0].ToString(), tbl.Rows[i].ItemArray[1].ToString(), tbl.Rows[i].ItemArray[2].ToString(), tbl.Rows[i].ItemArray[3].ToString(), tbl.Rows[i].ItemArray[4].ToString());
            }
            dataGridView1.ClearSelection();

            con.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pastro_klient();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            shtoklient();
        }

        private void dgw_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {
                    DataGridViewRow dr;
                    dr = dgw.SelectedRows[0];
                    txtSupID.Text = dr.Cells[0].Value.ToString();
                    txtSupName.Text = dr.Cells[1].Value.ToString();
                    txtSupAddress.Text = dr.Cells[2].Value.ToString();
                    txtSupPhone.Text = dr.Cells[3].Value.ToString();
                    btnSave.Text = "Perditeso";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            databaza_con db = new databaza_con();// making connection 
            con = new SqlConnection(db.Connection());
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter dapt = new SqlDataAdapter("select * from tbl_klient where emri like '%" + TextBox6.Text + "%'", con);
            dapt.Fill(tbl);
            dgw.Rows.Clear();
            int i;
            for (i = 0; i < tbl.Rows.Count; i++)

            {

                dgw.Rows.Add(tbl.Rows[i].ItemArray[0].ToString(), tbl.Rows[i].ItemArray[1].ToString(), tbl.Rows[i].ItemArray[2].ToString(), tbl.Rows[i].ItemArray[3].ToString());
            }
            dgw.ClearSelection();

            con.Close();
        }
    }
}
