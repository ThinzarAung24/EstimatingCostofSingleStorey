using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace login
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
            
          
        }

        
        private void welcome_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton4.BackColor = System.Drawing.Color.Transparent;
            radioButton6.BackColor = System.Drawing.Color.Transparent;

            

           

            


        }

       
         
      /*  private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            label2.Left += 5;
            if (label2.Left >= this.Width)
                label2.Left = label2.Width * -1;
        }

        */
      

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.Hide();
                ViewBuildingFlow v = new ViewBuildingFlow();
                v.Show();
            }
            else if (radioButton3.Checked == true)
            {
                this.Hide();
                CalculateMaterialPrice c = new CalculateMaterialPrice();
                c.Show();
            }
            else if (radioButton4.Checked == true)
            {
                this.Hide();
                AboutUs a = new AboutUs();
                a.Show();
            }
            else if (radioButton5.Checked == true)
            {
                this.Hide();
                EditAndCalculate ed = new EditAndCalculate();
                ed.Show();

            }
            else if (radioButton6.Checked == true)
            {
                this.Hide();
                EditMember em = new EditMember();
                em.Show();

            }

            else {
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color .Pink ;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Cyan;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
       
       

        

       
    }
}
