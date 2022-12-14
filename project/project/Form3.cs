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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 foorm4 = new Form4();
            Form3 foorm3 = new Form3();
            {
                if (checkBox1.Checked)

                    foorm4.Show();
                else
                    MessageBox.Show("your answer is incorrect,try again");
                foorm3.Show();
                


            }
            
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 foorm2 = new Form2();
            foorm2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 foorm1 = new Form1();
            foorm1.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
