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
    public partial class InsertMember : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public InsertMember()
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
                    MessageBox.Show(" Duplicate Password");

                   

                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate Password");
                }
                else
                {
                    try
                    {


                        //  connection.Open();


                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;

                        String query1 = "Insert into login ([UserName],[Password]) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')";
                        command1.CommandText = query1;
                        // MessageBox.Show(query);



                        command1.ExecuteNonQuery();

                        MessageBox.Show("Data Saved");

                        //connection.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }

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
            EditMember ed = new EditMember();
            ed.Show();
        }
    }
}
