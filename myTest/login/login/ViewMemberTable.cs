using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Drawing2D ;


namespace login
{
    public partial class ViewMemberTable : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        public ViewMemberTable()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\myTest\loginForm.accdb;
                                           Persist Security Info=False;";
             Application.DoEvents();
             RoundedButton button2 = new RoundedButton();
             button2.Text = "Back";
             button2.ForeColor =System .Drawing .Color .Green;
             EventHandler myHandler = new EventHandler(button2_Click);
             button2.Click += myHandler;
             button2.Location = new System.Drawing.Point(300, 300);
             button2.Size = new System.Drawing.Size(110, 45);
             this.Controls.Add(button2 );         

         }

                     

        






        private void ViewMemberTable_Load(object sender, EventArgs e)
        {

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
                   // textBox2.Text = reader["Password"].ToString();

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
            EditMember w = new EditMember();
            w.Show();

        }
    }
}

class RoundedButton : Button
{
    GraphicsPath GetRoundPath(RectangleF Rect, int radius)
    {
        float r2 = radius / 2f;
        GraphicsPath GraphPath = new GraphicsPath();

        GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
        GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width- r2, Rect.Y);
        GraphPath.AddArc(Rect.X+Rect.Width-radius ,Rect .Y,radius,radius ,270,90 );
        GraphPath.AddLine(Rect.Width ,Rect.Y +r2,Rect.Width,Rect.Height -r2 );
        GraphPath.AddArc(Rect.X + Rect.Width -radius ,
                         Rect.Y+Rect.Height -radius ,radius ,radius ,0,90);
        GraphPath.AddLine(Rect.Width-r2 ,Rect.Height ,Rect.X+r2 ,Rect.Height );
        GraphPath.AddArc(Rect.X,Rect.Y +Rect.Height-radius,radius ,radius ,90,90);
        GraphPath.AddLine(Rect.X ,Rect.Height-r2 ,Rect.X,Rect.Y+r2 );

        GraphPath.CloseFigure();
        return GraphPath;
    }
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
        GraphicsPath GraphPath = GetRoundPath(Rect,100);

        this.Region = new Region(GraphPath);
        using (Pen pen = new Pen(Color.CadetBlue, 1.9f))
        {
            pen.Alignment = PenAlignment.Inset;
            pevent.Graphics.DrawPath(pen, GraphPath);
        }

    }

}  

            
        
