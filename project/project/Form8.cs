﻿using System;
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
            Form6 foorm6 = new Form6();
            foorm6.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form9 foorm9 = new Form9();
            foorm9.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
