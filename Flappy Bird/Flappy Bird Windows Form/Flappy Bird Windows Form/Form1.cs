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
    using System.Media;

    public partial class Form1 : Form
    {


        int highScore = 0;
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {

                gravity = -10;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Space)
            {

                gravity = 10;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();

            if (score > highScore)
            {
                highScore = score;
                MessageBox.Show("Yeni Rekor! Tebrikler! 🎉", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            gameTimer.Stop();
            scoreText.Text += " ";

            DialogResult cevap = MessageBox.Show("Tekrar oynamak ister misin?", "Oyun Bitti", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {

                RestartGame();
            }
            else
            {

                Application.Exit();
            }
        }
        private void RestartGame()
        {
            score = 0;
            pipeSpeed = 8;
            gravity = 10;

            pipeBottom.Left = 800;
            pipeTop.Left = 950;

            flappyBird.Top = 150;

            scoreText.Text = $"Skor: {score}   En Yüksek Skor: {highScore}";

            gameTimer.Start();
        }

    

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            scoreText.Text = $"Skor: {score}   En Yüksek Skor: {highScore}";


            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 10;
            }

            if (score > 10)
            {
                pipeSpeed = 15;
            }
            if (score > 20)
            {
                pipeSpeed = 20;
            }
            if (score > 30)
            {
                pipeSpeed = 30;
            }
            if(score >= 50)
            {
                
            }
        }


        private void flappyBird_Click(object sender, EventArgs e)
        {

        }
   

        private void Form1_Load(object sender, EventArgs e)
        {
            
            scoreText.Text = "Skor: 0";
        }

     
    }
}
