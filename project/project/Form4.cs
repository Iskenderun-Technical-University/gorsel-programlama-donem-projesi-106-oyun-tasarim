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
    public partial class Form4 : Form
    {

        bool goleft = false; // boolean which will control players going left
        bool goright = false; // boolean which will control players going right
        bool jumping = false; // boolean to check if player is jumping or not
        bool hasKey = false; // default value of whether the player has the key

        int jumpSpeed = 10; // integer to set jump speed
        int force = 8; // force of the jump in an integer
        int score = 0; // default score integer set to 0
        int backgroundSpeed = 8;
        int playSpeed = 10; //this integer will set players speed to 18
    
    public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void maintimerevent4(object sender, EventArgs e)
        {
            {
                txtScore4.Text = "Score :" + score;
                player4.Top += jumpSpeed;
                if (goleft == true && player4.Left > 60)
                {
                    player4.Left -= playSpeed;

                }
                if (goright == true && player4.Left + (player4.Width + 60) < this.ClientSize.Width)
                {
                    player4.Left += playSpeed;
                }

                if (goleft == true && background4.Left < 0)
                {
                    background4.Left += backgroundSpeed;
                    MoveGameElements("forward");
                }
                if (goright == true && background4.Left > -1230)
                {
                    background4.Left -= backgroundSpeed;
                    MoveGameElements("back");

                }

                if (jumping == true)
                {
                    jumpSpeed = -12;
                    force -= 1;
                }
                else
                {
                    jumpSpeed = 12;
                }
                if (jumping == true && force < 0)
                {
                    jumping = false;
                }
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "platform4")
                    {
                        if (player4.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                        {
                            force = 8;
                            player4.Top = x.Top - player4.Height;
                            jumpSpeed = 0;
                        }
                        x.BringToFront();
                    }

                    if (x is PictureBox && (string)x.Tag == "coin4")
                    {
                        if (player4.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score += 1;
                        }
                    }

                }
                if (player4.Bounds.IntersectsWith(key4.Bounds))
                {
                    key4.Visible = false;
                    hasKey = true;
                }
                if (player4.Bounds.IntersectsWith(door4.Bounds) && hasKey == true)
                {
                    door4.Image = Properties.Resources.door_open;
                    GameTimer4.Stop();
                    MessageBox.Show("well done your " + Environment.NewLine + "clik ok to play agaın");
                    RestartGame();
                }
                if (player4.Top + player4.Height > this.ClientSize.Height)
                {
                    GameTimer4.Stop();
                    MessageBox.Show("you died!" + Environment.NewLine + "click ok to play again");
                    RestartGame();
                }


            }
        
    }

        private void keyIsDown4(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }


            if (e.KeyCode == Keys.Right)
            {

                goright = true;
            }



            if (e.KeyCode == Keys.Space && jumping == false)
            {

                jumping = true;
            }
        }

        private void keyIsUp4(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (jumping == true)

            {
                jumping = false;
            }
        }

        private void closegame4(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void RestartGame()
        {
            Form4 newwindow = new Form4();
            newwindow.Show();
            this.Hide();
        }
        private void MoveGameElements(string direction)
        {
    foreach (Control x in this.Controls)
    {
        if (x is PictureBox && (string)x.Tag == "platform4" || x is PictureBox && (string)x.Tag == "coin4" || x is PictureBox && (string)x.Tag == "key4" || x is PictureBox && (string)x.Tag == "door4")
        {
            if (direction == "back")
            {
                x.Left -= backgroundSpeed;
            }
            if (direction == "forward")
            {
                x.Left += backgroundSpeed;
            }
        }
    }
}

        private void player4_Click(object sender, EventArgs e)
        {

        }

        private void door4_Click(object sender, EventArgs e)
        {
           
        }

        private void key4_Click(object sender, EventArgs e)
        {
           
        }

        private void door4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form5 foorm5 = new Form5();
            foorm5.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void background4_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void player4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
