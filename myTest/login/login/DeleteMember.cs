using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace login
{
    public partial class DeleteMember : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public DeleteMember()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\myTest\loginForm.accdb;
                                           Persist Security Info=False;";
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "Select * from login where  Password='" + textBox2.Text + "'";
                OleDbDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;

                }

                if (count == 1)
                {
                    // connection.Close();
                    //MessageBox.Show(" Password is correct");

                    try
                    {


                        //  connection.Open();


                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;

                        String query1 = "delete from login where UserName='" + textBox1.Text + "'";
                        command1.CommandText = query1;
                        // MessageBox.Show(query);



                        command1.ExecuteNonQuery();

                        MessageBox.Show("Data Deleted");

                        //connection.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }


                }
                else if (count > 1)
                {
                    MessageBox.Show("Password is not correct");
                }
                else
                {
                    MessageBox.Show("Password is not correct");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            
        }

        private void DeleteMember_Load(object sender, EventArgs e)
        {
           label2.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label2.Text = "ပတ္တန္း";

           
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from login";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["UserName"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMember em = new EditMember();
            em.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from login where UserName='" + comboBox1.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    textBox1.Text = reader["UserName"].ToString();

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
