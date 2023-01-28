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
    public partial class Form1 : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\myTest\loginForm.accdb;
                                           Persist Security Info=False;";
        }

            

       
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.BackColor = System.Drawing.Color.Transparent;
            try
            {
                
                
                connection.Open();
                checkConnection.Text = "Connection Successful";
                connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

           /* if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                label1.Visible = false;
                label4.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                label4.Visible = false;
                label5.Visible = true;
                
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
                label5.Visible = false;
                label6.Visible = true;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
                label6.Visible = false;
                label7.Visible = true;
                
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox1.Visible = true;
                label7.Visible = false;
                label1.Visible = true;
            }
         */
             if (label1.Visible == true)
            {
                /*pictureBox1.Visible = false;
                pictureBox2.Visible = true;*/
                label1.Visible = false;
                label4.Visible = true;
            }
            else if (label4.Visible == true)
            {
                /*pictureBox2.Visible = false;
                pictureBox3.Visible = true;*/
                label4.Visible = false;
                label5.Visible = true;
                
            }
            else if (label5.Visible == true)
            {
                /*pictureBox3.Visible = false;
                pictureBox4.Visible = true;*/
                label5.Visible = false;
                label6.Visible = true;
            }
            else if (label6.Visible == true)
            {
                /*pictureBox4.Visible = false;
                pictureBox5.Visible = true;*/
                label6.Visible = false;
                label7.Visible = true;
                
            }
            else if (label7.Visible == true)
            {
                /*pictureBox5.Visible = false;
                pictureBox1.Visible = true;*/
                label7.Visible = false;
                label1.Visible = true;
            }
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
              {
                  connection.Open();
                  OleDbCommand command = new OleDbCommand();
                  command.Connection = connection;
                  command.CommandText = "Select * from login where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
                  OleDbDataReader reader = command.ExecuteReader();
                  int count = 0;
                  while (reader.Read())
                  {
                      count = count + 1;

                  }
                  if (count == 1)
                  {
                      MessageBox.Show("UserName and Password is correct");
                      this.Hide();
                      welcome w = new welcome();
                      w.Show();
                  }
                  else if (count > 1)
                  {
                      MessageBox.Show("Duplicate UserName and Password");
                  }
                  else
                  {
                      MessageBox.Show("UserName and Password is not correct");
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
            Application.Exit();
           /* this.Hide();
            CalculateMaterialPrice p = new CalculateMaterialPrice();
            p.Show();*/


           
        }

       
        

        


    }
}

