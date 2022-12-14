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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 foorm6 = new Form6();
            Form5 foorm5 = new Form5();
            {
                if (checkBox2.Checked)

                    foorm6.Show();
                else
                    MessageBox.Show("your answer is incorrect,try again");
                foorm5.Show();

               
           
           
        }

       
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 foorm1 = new Form1();
            foorm1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form4 foorm4 = new Form4();
            foorm4.Show();
        }
    }
}
