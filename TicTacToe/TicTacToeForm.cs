using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeEngine;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {

        private Button[] gameButtons;
        private String[] buttonTexts;
        private Boolean turn;

        public TicTacToeForm()
        {
            InitializeComponent();
            gameButtons = new Button[9];
            buttonTexts = new String[9];
            turn = new Random().Next(100) % 2 == 0;
        }

        private void takeTurn(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Enabled = false;
            if (turn)
            {
                clickedButton.Text = "X";
            }
            else
            {
                clickedButton.Text = "O";
            }
            checkWin();
            turn = !turn;
        }

        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            int buttonAmount = 0;
            for(int row=0;row<3;row++)
            {
                for(int column=0;column<3;column++)
                {
                    gameButtons[buttonAmount] = new Button();
                    gameButtons[buttonAmount].Location = new Point(row * 100, column * 100);
                    gameButtons[buttonAmount].Size = new Size(100, 100);
                    gameButtons[buttonAmount].Click += new EventHandler(takeTurn);
                    this.Controls.Add(gameButtons[buttonAmount]);
                    this.Size = new Size(350, 350);
                    buttonAmount++;
                }
            }
        }

        public void checkWin()
        {
            for (int i=0;i<gameButtons.Length;i++)
            {
                buttonTexts[i] = gameButtons[i].Text;
                int result = buttonTexts.Count(j => !String.IsNullOrEmpty(j));
                if (Engine.checkWin(buttonTexts))
                {
                    String wintext = "Speler ";
                    if (turn)
                    {
                        wintext += "X";
                    }
                    else
                    {
                        wintext += "O";
                    }
                    wintext += " heeft gewonnen!";
                    MessageBox.Show(wintext, "Gewonnen!");
                    clearButtons();
                }
                else if (result == 9)
                {
                    MessageBox.Show("Er is gelijkspel gespeeld", "Gelijkspel");
                    clearButtons();
                    break;
                }
            }
           
        }
        private void clearButtons()
        {
            for (int i = 0; i < gameButtons.Length; i++)
            {
                gameButtons[i].Enabled = true;
                gameButtons[i].Text = "";
                buttonTexts = new String[9];
            }
        }
    }
}
