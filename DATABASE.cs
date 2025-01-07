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

namespace donot_base
{
    public partial class Form1 : Form
    {

        private bool serching = false;
        
        //Sql conncet
        private void namayesh() 
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=YOURPCInitial Catalog=\"donot service\";Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from donot_tbl";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, cn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            namayesh();
        }

        
        private void btnsave_Click(object sender, EventArgs e)
        {
            //Save table
            
            if (textBox7.Text == "")
            {
                MessageBox.Show("pls write something in name to save :))");
                textBox7.Focus();
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("pls write something in price to save :))");
                textBox6.Focus();
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("pls write something in code to save :))");
                textBox5.Focus();
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("pls write something in addres to save :3");
                textBox4.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("pls write something in phone number to save :3");
                textBox3.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("pls write something in describe to save :3");
                textBox2.Focus();
                return;
            }


            // code for in-app fill datagrid and set records
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=YOURPCInitial Catalog=\"donot service\";Integrated Security=True";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into donot_tbl(Pname,Pprice,Pcode,Padress,phone_number,Pdiscribe) values('" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
                cmd.ExecuteNonQuery();
                textBox7.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox7.Focus();
                namayesh();
            }
            catch (Exception d)
            {

                MessageBox.Show(d.Message);
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            // When you press tab you can skip the textbox
            
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Security for app to fix bug
            if (((e.KeyChar>='0')&&(e.KeyChar<='9') == false))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Security for app to fix bug

            if (((e.KeyChar >= '0') && (e.KeyChar <= '9') == false))
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9') == false))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("pls enter something you want in name to delete ;P");
                textBox7.Focus();
                return;
            }






            if (MessageBox.Show("are you sure you want to delete this value?", "becureful :o", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=YOURPCInitial Catalog=\"donot service\";Integrated Security=True";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from donot_tbl where Pname = '" + textBox7.Text + "'";
                cmd.ExecuteNonQuery();
                namayesh();


                MessageBox.Show("delete successfully cmplct =)");
                textBox7.Text = "";
                textBox7.Focus();
            }
            else
            {
                textBox7.Text = "";
                textBox7.Focus();
                MessageBox.Show("canceled =]");
            }



        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            
            //Update the table
            
            if (textBox7.Text == "")
            {
                MessageBox.Show("pls write something in name to update:))");
                textBox7.Focus();
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("pls write something in price to update:))");
                textBox6.Focus();
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("pls write something in code to update:))");
                textBox5.Focus();
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("pls write something in addres to update:3");
                textBox4.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("pls write something in phone number to update:3");
                textBox3.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("pls write something in describe to update:3");
                textBox2.Focus();
                return;
            }



            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=YOURPCInitial Catalog=\"donot service\";Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update donot_tbl set Pprice='" + textBox6.Text + "',Pcode='" + textBox5.Text + "',Padress='" + textBox4.Text + "',phone_number='" + textBox3.Text + "',Pdiscribe='" + textBox2.Text + "' where Pname='" + textBox7.Text +"'";
            cmd.ExecuteNonQuery();
            namayesh();

            MessageBox.Show("datas update successfully =]");

            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox7.Focus();
        }

        private void btnserch_Click(object sender, EventArgs e)
        {
            //Serching in table
            
            if (textBox7.Text == "")
            {
                MessageBox.Show("pls enter something you want in name to serch ;P");
                textBox7.Focus();
                return;
            }


            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=YOURPCInitial Catalog=\"donot service\";Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from donot_tbl where Pname='" + textBox7.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, cn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dt.Rows.Count>0)
            {
                textBox6.Text = dt.Rows[0][1].ToString();
                textBox5.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                textBox3.Text = dt.Rows[0][4].ToString();
                textBox2.Text = dt.Rows[0][5].ToString();
            }
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            namayesh();
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox7.Focus();
            MessageBox.Show("datas refreshed successfully :]");



        }
        
    }
}
