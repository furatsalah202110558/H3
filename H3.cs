using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuessTheNumber
{
    public partial class MainForm : Form
    {
        private int randomNumber;
        private int attempts;

        public MainForm()
        {
            InitializeComponent();
            GenerateRandomNumber();
        }

        private void GenerateRandomNumber()
        {
            Random random = new Random();
            randomNumber = random.Next(1, 1001); 
        }

        private void CheckGuess()
        {
            int guess = int.Parse(guessTextBox.Text);

            if (guess == randomNumber)
            {
                MessageBox.Show("Correct!");
                BackColor = Color.Green;
                guessTextBox.Enabled = false;
            }
            else
            {
                string message;
                if (guess < randomNumber)
                {
                    message = "Too Low";
                }
                else
                {
                    message = "Too High";
                }

                MessageBox.Show(message);

                if (Math.Abs(guess - randomNumber) < Math.Abs(attempts - randomNumber))
                {
                    BackColor = Color.Red;
                }
                else
                {
                    BackColor = Color.Blue;
                }
            }

            guessTextBox.Clear();
            guessTextBox.Focus();
            attempts++;
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            GenerateRandomNumber();
            BackColor = DefaultBackColor;
            guessTextBox.Enabled = true;
            guessTextBox.Clear();
            guessTextBox.Focus();
            attempts = 0;
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            CheckGuess();
        }
    }
}