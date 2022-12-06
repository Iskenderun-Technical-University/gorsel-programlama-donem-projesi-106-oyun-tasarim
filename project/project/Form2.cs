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
    public partial class Form2 : Form
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



        public Form2()
        {


            InitializeComponent();
        }

        private void background_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void background_Click_1(object sender, EventArgs e)
        {

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
        private void RestarGame()
        {
            Form2 newwindow = new Form2();
            newwindow.Show();
            this.Hide();
        }
        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "coin" || x is PictureBox && (string)x.Tag == "key" || x is PictureBox && (string)x.Tag == "door")
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

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtscore.Text = "Score :" + score;
            player.Top += jumpSpeed;
            if (goleft == true && player.Left > 60)
            {
                player.Left -= playSpeed;

            }
            if (goright == true && player.Left + (player.Width + 60) < this.ClientSize.Width)
            {
                player.Left += playSpeed;
            }

            if (goleft == true && background.Left < 0)
            {
            
            background.Left += backgroundSpeed;
            MoveGameElements("forward");
        }
                if (goright == true && background.Left > -738)
                {
                    background.Left -= backgroundSpeed;
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
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                        jumpSpeed = 0;
                    }
                    x.BringToFront();
                }

                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score += 1;
                    }
                

}
if (player.Bounds.IntersectsWith(key.Bounds))
{
    key.Visible = false;
    hasKey = true;
}
if (player.Bounds.IntersectsWith(door.Bounds) && hasKey == true)
{
    door.Image = Properties.Resources.door_open;
    GameTimer.Stop();
    MessageBox.Show("well done your " + Environment.NewLine + "clik ok to play agaın");
    RestarGame();
}
if (player.Top + player.Height > this.ClientSize.Height)
{
    GameTimer.Stop();
    MessageBox.Show("you died!" + Environment.NewLine + "click ok to play again");
    RestarGame();
}
            }

        }

        private void door_Click(object sender, EventArgs e)
        {
           Form3 foorm3 = new Form3();
            foorm3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }
    }
}
