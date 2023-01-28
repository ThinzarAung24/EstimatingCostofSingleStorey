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
    public partial class Insert : Form
        
    {

        private OleDbConnection connection = new OleDbConnection();
        public Insert()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Aspire  V5\Desktop\myTest\MaterialPrice.accdb;
                                           Persist Security Info=False;";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "Insert into Price (MaterialName,MaterialPrice) values('" + textBox1.Text + "','" + textBox2.Text + "')";
                command.CommandText = query;

                

                command.ExecuteNonQuery();

                MessageBox.Show("Data Saved");

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
