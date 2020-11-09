using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoPapirOllo
{
    public partial class Form1 : Form
    {
        public int rounds = 3; //3 kor/game
        public int time = 6; //5sec/kor
        string[]AIchoice={"ko","papir","ollo","ko","papir","ollo"};
        public int randNumber;
        string command;
        Random rnd = new Random();
        string playerChoice;
        int playerWins = 0;
        int AIwins = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            playerChoice = "none";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void checkGame()
        {
            if(playerChoice=="ko" && command =="papir")
                {
                
                AIwins++;
                rounds--;
                MessageBox.Show("A gep nyert haha");
                nextRound();

                }
            else if(playerChoice=="papir" && command=="ko")
                {
                
                playerWins++;
                rounds--;
                MessageBox.Show("Te nyertel yey");
                nextRound();
                }
            else if(playerChoice=="papir" && command=="ollo")
            {
            
            AIwins++;
            rounds--;
            MessageBox.Show("A gep nyert hah");
            nextRound();
            }
            else if(playerChoice=="ollo" && command=="papir")
            {
            
            playerWins++;
            rounds--;
            MessageBox.Show("Te nyerte yeh");
            nextRound();
            }
            else if(playerChoice=="ollo" && command=="ko")
            {
            
            AIwins++;
            rounds--;
            MessageBox.Show("A bot nyert haha");
            nextRound();
            }
            else if(playerChoice=="ko" && command=="ollo")
            {
            
            playerWins++;
            rounds--;
            MessageBox.Show("Te nyertel yey");
            nextRound();
            }
            else if (playerChoice=="none")
            {
                MessageBox.Show(label1.Text + "Donts mar bazmeg");
                nextRound();
                //rounds--;
                
            }
            else
            {
                MessageBox.Show("Dontetlen");
                nextRound();
                //rounds--;
                
            }
            label9.Text = Convert.ToString(AIwins);
            label8.Text = Convert.ToString(playerWins);
        }
        private void decisionEngine()
        {
            if(playerWins>AIwins)
            {
                label5.Text=label1.Text + " nyerted a jatekot";
            }
            else if (playerWins < AIwins)
            {
                label5.Text = "A gep nyerte a jatekot";
            }
            else 
            {
                label5.Text = "Dontetlen";
            }
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(rounds);
            time--;
            label7.Text = Convert.ToString(time);
            if (time == 0)
            {
                //timer1.Enabled = false;
                timer1.Stop();
                time = 6;
                randNumber = rnd.Next(0, 5);
                command = AIchoice[randNumber];
                switch (command)
                {
                    case "ko":
                        pictureBox2.Image = Properties.Resources.rock;
                        break;
                    case "papir":
                        pictureBox2.Image = Properties.Resources.paper;
                        break;
                    case "ollo":
                        pictureBox2.Image = Properties.Resources.scissors;
                        break;
                    default:
                        break;
                }
                if (rounds >= 1)
                {
                    checkGame();
                    //label5.Text = Convert.ToString(rounds);

                }
                else
                {
                    decisionEngine();
                }
            }
            


            
        }
        private void nextRound()
        {
            playerChoice = "none";
            pictureBox1.Image = Properties.Resources.qq;
            timer1.Start();
            pictureBox2.Image=Properties.Resources.qq;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerChoice = "ko";
            pictureBox1.Image=Properties.Resources.rock;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            playerChoice = "papir";
            pictureBox1.Image=Properties.Resources.paper;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playerChoice = "ollo";
            pictureBox1.Image=Properties.Resources.scissors;
        }
    }
}
