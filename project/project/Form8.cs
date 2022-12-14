using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 foorm1 = new Form1();
            foorm1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked != false)
            {
                this.Close();

                Form6 foorm6 = new Form6();
                foorm6.Show();
            }
            else if (checkBox2.Checked == true || checkBox3.Checked == true)
            {
                MessageBox.Show("erorr");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 foorm9 = new Form9();
            foorm9.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
