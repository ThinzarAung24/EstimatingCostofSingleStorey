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
    public partial class EditMember : Form
    {
        public EditMember()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertMember im = new InsertMember();
            im.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateMember um = new UpdateMember();
            um.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteMember dm = new DeleteMember();
            dm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewMemberTable vmt = new ViewMemberTable();
            vmt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome we = new welcome();
            we.Show();
        }

        private void EditMember_Load(object sender, EventArgs e)
        {

        }
    }
}
