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

        private void MoveGameElements(object sender, EventArgs e)
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

        }
        private void RestarGame()
        {

        }
        private void MoveGameElements(string direction)
        {

        }
    }
}
