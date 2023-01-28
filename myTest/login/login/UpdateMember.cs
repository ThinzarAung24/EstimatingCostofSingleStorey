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
    public partial class UpdateMember : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        public UpdateMember()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\myTest\loginForm.accdb;
                                           Persist Security Info=False;";
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "Select * from login where  Password='" + txtExistingPassword.Text + "'";
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

                            String query1 = "update login set [UserName]='" + textBox2.Text.ToString() + "' where [UserName]='" + textBox1.Text.ToString() + "'";
                            command1.CommandText = query1;
                            // MessageBox.Show(query);



                            command1.ExecuteNonQuery();

                            MessageBox.Show("Data Edit Successful");

                            //connection.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex);
                        }


                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("Duplicate Password");
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
            if (radioButton2.Checked == true)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "Select * from login where  Password='" + txtExistingPassword.Text + "'";
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

                            String query1 = "update login set [Password]='" + textBox3.Text.ToString() + "' where [UserName]='" + textBox1.Text.ToString() + "'";
                            command1.CommandText = query1;
                            // MessageBox.Show(query);



                            command1.ExecuteNonQuery();

                            MessageBox.Show("Data Edit Successful");

                            //connection.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex);
                        }


                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("Duplicate Password");
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
        }
        private void UpdateMember_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;

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

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = false;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMember w = new EditMember();
            w.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Visible = false ;
            label5.Visible = true ;
            textBox2.Visible = false ;
            textBox3.Visible = true;
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
