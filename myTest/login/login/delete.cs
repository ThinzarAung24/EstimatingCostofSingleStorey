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
    public partial class delete : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public delete()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Aspire  V5\Desktop\myTest\MaterialPrice.accdb;
                                           Persist Security Info=False;";
            InitializeComponent();
        }

        

        private void delete_Load(object sender, EventArgs e)
        {
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["MaterialName"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }



        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='" + comboBox1.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    textBox1.Text = reader["MaterialName"].ToString();

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "delete from Price where MaterialName='" + textBox1.Text + "'";
                command.CommandText = query;
               // MessageBox.Show(query);



                command.ExecuteNonQuery();

                MessageBox.Show("Data Deleted");

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
            EditAndCalculate ed = new EditAndCalculate();
            ed.Show();
        }

       
    }
}
