using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = " ";
        bool operation_presented = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (operation_presented))
                result.Clear();
            operation_presented = false;
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse (result.Text);
            operation_presented = true;
            equation.Text = value + " " + operation;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            equation.Text = " ";
            switch (operation)
            {
                case "+" :
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default :
                    break;
                    
            
            }
            operation_presented = false;
            

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
        }
    }
}
  





