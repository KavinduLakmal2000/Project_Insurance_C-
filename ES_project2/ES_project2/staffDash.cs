﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES_project2
{
    public partial class staffDash : Form
    {
        public staffDash()
        {
            InitializeComponent();
            pUser.Visible = false;
            U_regi_panel.Visible = false;

            P_staff.Visible = true;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Project_Insurance_C-\Car_Insurance_DB.mdf;Integrated Security=True;Connect Timeout=30");


        private void regi_tab_Click(object sender, EventArgs e)
        {
            line1.Left = regi_tab.Left;
            line1.Width = regi_tab.Width;
            pUser.Visible = false;
            U_regi_panel.Visible = false;

            P_staff.Visible = true;
        }

        private void tab2_Click(object sender, EventArgs e)
        {
            line1.Left = tab2.Left;
            line1.Width = regi_tab.Width;
            U_regi_panel.Visible = false;
            P_staff.Visible = false;

            pUser.Visible = true;
        }

        private void tab3_Click(object sender, EventArgs e)
        {
            line1.Left = tab3.Left;
            line1.Width = regi_tab.Width;
            pUser.Visible = false;
            P_staff.Visible = false;

            U_regi_panel.Visible = true;
        }


        private void tab4_Click(object sender, EventArgs e)
        {
            line1.Left = tab4.Left;
            line1.Width = regi_tab.Width;
        }

        private void tab5_Click(object sender, EventArgs e)
        {
            line1.Left = tab5.Left;
            line1.Width = regi_tab.Width;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void data_display_Paint(object sender, PaintEventArgs e)
        {

        }
        //........................................................................................staff panel.......................................
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            String id = staffid.Text;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from staff where id = '"+id+"' ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            staff_data.DataSource = dt;
            conn.Close();
        }

        private void chk_old_pass_Click(object sender, EventArgs e)
        {
            String id = staffid.Text;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT '" + id + "', password FROM staff", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            staff_data.DataSource = dt;
            conn.Close();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            String id = staffid.Text;
            String P1 = pass1.Text;
            String P2 = pass2.Text;

            if (P1 == P2)
            {
                String insert = "UPDATE staff SET password='" + P1 + "' WHERE id='" + id + "'";
                SqlCommand cmd = new SqlCommand(insert, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Password is Set!");
                    conn.Close();
                }

                catch (SqlException)
                {
                    MessageBox.Show("Password reset is failed! try again!");
                }
            }
            else
            {
                MessageBox.Show("Passwords does not match!");
            }
        }
        //..................................................................... client panel...............................................
     

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            String id = Uid.Text;
            // chk staff
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM client WHERE uid = '" + id + "'", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            userData.DataSource = dt;
            conn.Close();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            String id = Uid.Text;
            // chk staff
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM v_data WHERE vid = '" + id + "'", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Vdata.DataSource = dt;
            conn.Close();
        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            String id = Uid.Text;

            String insert = "DELETE FROM client WHERE uid = '" + id + "'";
            SqlCommand cmd = new SqlCommand(insert, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("client Has been removed!");
                conn.Close();
            }

            catch (SqlException)
            {
                MessageBox.Show("Client remove failed! try again!");
            }
        }

        //......................................................................client register...........................................

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            String uid = U_id.Text;
            String fname = f_name.Text;
            String lname = l_name.Text;
            String mail = email.Text;
            String adres = add.Text;
            String pass1 = f_pass.Text;
            String pass2 = con_pass.Text;
            String birth_d = b_day.Value.ToString();

            if (pass1 == pass2)
            {


                String insert = "INSERT INTO client VALUES ('" + uid + "' ,'" + fname + "', '" + lname + "', '" + pass1 + "' , '" + birth_d + "' , '" + mail + "', '" + adres + "' )";
                SqlCommand cmd = new SqlCommand(insert, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client has been Registered!");
                    conn.Close();
                }

                catch (SqlException es)
                {
                    MessageBox.Show("Data can not be upload & try again!"+ es);
                }

            }

            else
            {
                MessageBox.Show("Check both passwords & try again!");
            }

        }
    }
}
