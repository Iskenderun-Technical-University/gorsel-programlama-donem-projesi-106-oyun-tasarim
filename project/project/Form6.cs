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
                             // sola giden oyuncuları kontrol edecek boolean

        bool goright = false; // boolean which will control players going right
                              // sağa giden oyuncuları kontrol edecek boolean

        bool jumping = false; // boolean to check if player is jumping or not
                              // oyuncunun zıplayıp zıplamadığını kontrol etmek için boolean
        bool hasKey = false; // default value of whether the player has the key
                             // oynatıcının anahtara sahip olup olmadığının varsayılan değeri

        int jumpSpeed = 10; // integer to set jump speed
                            // atlama hızını ayarlamak için tamsayı
        int force = 8; // force of the jump in an integer
                       // bir tamsayıdaki atlama kuvveti
        int score = 0; // default score integer set to 0
                       // varsayılan puan tam sayısı 0'a ayarlandı
        int backgroundSpeed = 8;
        int playSpeed = 10; //this integer will set players speed to 18
                            //bu tamsayı oyuncunun hızını 18 yapacak  

        int backLeft = 8; // this integer will set the background moving speed to 8
                          // bu tamsayı, arka plan hareket hızını 8 olarak ayarlayacaktır.

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
            // linking the jumpspeed integer with the player picture boxes to location
            // atlama hızı tamsayısını oyuncu resim kutuları ile konuma bağlama
            player6.Top += jumpSpeed;
            // refresh the player picture box consistently
            // oynatıcı resim kutusunu sürekli olarak yenile

            if (goleft == true && player6.Left > 60)
            {
                player6.Left -= playSpeed;
                // if jumping is true and force is less than 0
                // then change jumping to false

                // atlama doğruysa ve kuvvet 0'dan küçükse
                // sonra atlamayı false olarak değiştir

            }
            if (goright == true && player6.Left + (player6.Width + 60) < this.ClientSize.Width)
            {
                player6.Left += playSpeed;
                // if jumping is true and force is less than 0
                // then change jumping to false

                // atlama doğruysa ve kuvvet 0'dan küçükse
                // sonra atlamayı false olarak değiştir
            }
            if (goleft == true && background6.Left < 0)
            {
                background6.Left += backgroundSpeed;
                MoveGameElements("forward");
            }

            // if go right is true and the background picture left is greater 738

            // then we move the background picture towards the left
            if (goright == true && background6.Left > -1111)
            {
                background6.Left -= backgroundSpeed;
                MoveGameElements("back");

            }
           
            // then change jump speed to -12 
            // reduce force by 1

            // atlama doğruysa
            // sonra atlama hızını -12 olarak değiştir
            // kuvveti 1 azalt
            if (jumping == true)
            {
                jumpSpeed = -12;
                
                force -= 1;
            }
            // else change the jump speed to 12
            // yoksa atlama hızını 12 olarak değiştir
            else
            {
                jumpSpeed = 12;
                // if go left is true and players left is greater than 100 pixels
                // only then move player towards left of the

                // sola git doğruysa ve kalan oyuncu 100 pikselden büyükse
                // ancak bundan sonra oyuncuyu ekranın soluna doğru hareket ettirin
            }
            if (jumping == true && force < 0)
            {
                jumping = false;
                // below if the for loop thats checking for all of the controls in this form
                // bu formdaki tüm kontrolleri kontrol eden for döngüsü aşağıdaysa

            }
            foreach (Control x in this.Controls)
                // is X is a picture box and it has a tag of platform                     
                // X bir resim kutusudur ve platform etiketine sahiptir

            {
                if (x is PictureBox && (string)x.Tag == "platform6")
                {
                    // then we are checking if the player is colliding with the platform
                    // and jumping is set to false

                    // sonra oyuncunun platformla çarpışıp çarpışmadığını kontrol ediyoruz
                    // ve atlama false olarak ayarlanır
                    if (player6.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        // then we do the following
                        //sonra şunu yapıyoruz

                        force = 8;
                        // set the force to 8
                        // kuvveti 8 olarak ayarla
                        player6.Top = x.Top - player6.Height;
                        // also we place the player on top of the picture box
                        // ayrıca oynatıcıyı resim kutusunun üstüne yerleştiriyoruz
                        jumpSpeed = 0;
                        // set the jump speed to 0
                        // atlama hızını 0 olarak ayarla
                    }
                    x.BringToFront();
                }
                // if the picture box found has a tag of coin

                // Bulunan resim kutusunda madeni para etiketi varsa

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
                        // if the player collides with the door and has key boolean is true
                        // eğer oyuncu kapıyla çarpışırsa ve key boolea sahipse true olur
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
                        // stop the timer
                        MessageBox.Show("you died!" + Environment.NewLine + "click ok to play again");
                        // show the message box

                        RestartGame();
                    }
                }
            }
        


        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            //if the player pressed the left key AND the player is inside the panel
            // then we set the car left boolean to true

            //oyuncu sol tuşa bastıysa VE oyuncu panelin içindeyse
            // sonra car left boolean değerini true olarak ayarladık
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                // if player pressed the right key and the player left plus player width is less then the panel1 width 
                // oyuncu sağ tuşa bastıysa ve sol oyuncu artı oyuncu genişliği panel1 genişliğinden azsa
            }


            if (e.KeyCode == Keys.Right)
            {
                // then we set the player right to true
                // sonra oynatıcıyı doğru olarak ayarladık
                goright = true;
            }

            //if the player pressed the space key and jumping boolean is false
            //oyuncu boşluk tuşuna bastıysa ve atlama boole değeri yanlışsa

            if (e.KeyCode == Keys.Space && jumping == false)
            {

                jumping = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // if the LEFT key is up we set the car left to false
            // eğer SOL tuş yukarıdaysa, soldaki arabayı false olarak ayarladık

            if (e.KeyCode == Keys.Left)
            {

                goleft = false;
                // if the RIGHT key is up we set the car right to false
                // eğer SAĞ tuş yukarıdaysa, arabayı sağa yanlış olarak ayarladık
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            //when the keys are released we check if jumping is true
            // if so we need to set it back to false so the player can jump again

            //tuşlar bırakıldığında atlamanın doğru olup olmadığını kontrol ederiz
            // öyleyse, oyuncunun tekrar atlayabilmesi için onu tekrar false olarak ayarlamamız gerekir

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
            // aşağıdaki for döngüsü, seviyedeki platformları ve paraları görmek için kontrol ediyor

            // bulunduklarında onları sola doğru hareket ettirir
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

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }
    }
}

           
         


