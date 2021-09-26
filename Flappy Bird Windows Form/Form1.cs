using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        //declared three variables for my pipe speed, gravity, and score.
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        //main function
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //created a game timer event
        private void gameTimerEvent(object sender, EventArgs e)
        {
            //moving the bird down with gravity variable
            flappyBird.Top += gravity;
            //moving both pipes towards the left using the pipe speed variable
            pipeButtom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            //updating the score text label with the "Score:" and score integer
            scoreText.Text = "Score: " + score;
            //checking if the pipe goes beyond -150 pixels from the left and reseting it to 800 and add 1 to the score
            if(pipeButtom.Left < -150)
            {
                pipeButtom.Left = 800;
                score++;
            }
            //checking if the pipe goes beyond -180 pixels from the left and reseting it to 950 and add 1 to the score
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            // if statment to see if the bird colides with the pipes or ground then throws endGame function 
            if (flappyBird.Bounds.IntersectsWith(pipeButtom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }
        }
        // gamekeyisup is checking for space key is being released we put gravity to 15
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }
        // gamekeyisdown checks for space key to be pressed and reverse the gravity from 15 to -15
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }
        // looks for gametimer and stops it
        private void endGame()
        {
            gameTimer.Stop();
            //added next to score when game ends 
            scoreText.Text += " Game over!!!";
        }
    }
}
