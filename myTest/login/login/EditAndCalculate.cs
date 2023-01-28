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
    public partial class EditAndCalculate : Form
    {
        private OleDbConnection connection = new OleDbConnection();
       
        public EditAndCalculate()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Aspire  V5\Desktop\myTest\MaterialPrice.accdb;
                                           Persist Security Info=False;";

            InitializeComponent();
        }

        private void EditAndCalculate_Load(object sender, EventArgs e)
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

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select MaterialName,MaterialPrice from Price";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
                String query = "select * from Price where MaterialName='"+comboBox1.Text +"'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    textBox1.Text = reader["MaterialName"].ToString();
                    textBox2.Text = reader["MaterialPrice"].ToString();
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

            this.Hide();
            Insert i = new Insert();
            i.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit edit = new Edit();
            edit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            delete d = new delete();
            d.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome w = new welcome();
            w.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

       
    }
 }

