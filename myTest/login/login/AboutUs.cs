using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace login
{
    public partial class AboutUs : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index=0;
        public AboutUs()
        {
            InitializeComponent();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {

            listPanel.Add(panel14);
            listPanel.Add(panel13);
            listPanel.Add(panel12);
            listPanel.Add(panel11);
            listPanel.Add(panel10);
            listPanel.Add(panel9);
            listPanel.Add(panel8);
            
            listPanel[index].BringToFront();
            panel14.BackColor  = System.Drawing.Color.Transparent;
            panel13.BackColor = System.Drawing.Color.Transparent;
            panel12.BackColor = System.Drawing.Color.Transparent;
            panel11.BackColor = System.Drawing.Color.Transparent;
            panel9.BackColor = System.Drawing.Color.Transparent;
            panel8.BackColor = System.Drawing.Color.Transparent;
            panel10.BackColor = System.Drawing.Color.Transparent;
           

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
                listPanel[index].BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listPanel[index+1].BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listPanel[index+2].BringToFront();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listPanel[index+3].BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listPanel[index+4].BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listPanel[index+5].BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listPanel[index+6].BringToFront();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome d = new welcome();
            d.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            listPanel[index].BringToFront();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listPanel[index + 1].BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listPanel[index + 2].BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listPanel[index + 3].BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listPanel[index + 4].BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listPanel[index + 5].BringToFront();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listPanel[index + 6].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            welcome d = new welcome();
            d.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
       

        
       

       
       
    }
}
