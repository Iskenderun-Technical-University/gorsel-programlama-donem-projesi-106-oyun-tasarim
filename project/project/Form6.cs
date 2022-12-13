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
    public partial class Form6 : Form
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
        int backLeft = 8; // this integer will set the background moving speed to 8


        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent6(object sender, EventArgs e)
        {

            txtscore.Text = "Score :" + score;
            player6.Top += jumpSpeed;

            if (goleft == true && player6.Left > 60)
            {
                player6.Left -= playSpeed;

            }
            if (goright == true && player6.Left + (player6.Width + 60) < this.ClientSize.Width)
            {
                player6.Left += playSpeed;
            }
            if (goleft == true && background6.Left < 0)
            {
                background6.Left += backgroundSpeed;
                MoveGameElements("forward");
            }
            if (goright == true && background6.Left > -1111)
            {
                background6.Left -= backgroundSpeed;
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
                if (x is PictureBox && (string)x.Tag == "platform6")
                {
                    if (player6.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        force = 8;
                        player6.Top = x.Top - player6.Height;
                        jumpSpeed = 0;
                    }
                    x.BringToFront();
                }

                if (x is PictureBox && (string)x.Tag == "coin6")
                {
                    if (player6.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score += 1;

                    }
                    if (player6.Bounds.IntersectsWith(key6.Bounds))
                    {
                        key6.Visible = false;
                        hasKey = true;
                    }
                    if (player6.Bounds.IntersectsWith(door6.Bounds) && hasKey == true)
                    {
                        door6.Image = Properties.Resources.door_open;
                        GameTimer6.Stop();
                        MessageBox.Show("well done your " + Environment.NewLine + "clik ok to play agaın");
                        RestartGame();
                    }
                    if (player6.Top + player6.Height > this.ClientSize.Height)
                    {
                        GameTimer6.Stop();
                        MessageBox.Show("you died!" + Environment.NewLine + "click ok to play again");
                        RestartGame();
                    }
                }
            }
        


        }

        private void KeyIsDown(object sender, KeyEventArgs e)
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

        private void KeyIsUp(object sender, KeyEventArgs e)
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

        private void CloseGame(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void RestartGame()
        {
            Form6 newwindoww = new Form6();
            newwindoww.Show();
            this.Hide();

        }
        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform6" || x is PictureBox && (string)x.Tag == "coin6" || x is PictureBox && (string)x.Tag == "key6" || x is PictureBox && (string)x.Tag == "door6")
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

        private void door6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 foorm8 = new Form8();
            foorm8.Show();
        }

        private void background6_Click(object sender, EventArgs e)
        {

        }
    }
}

           
         


