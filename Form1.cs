using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticktactoe
{
    public partial class Form1 : Form
    {

        bool turn = true; // when true X turn, false O turn
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn)
                button.Text = "X";
            else
                button.Text = "O";

            turn = !turn;

            button.Enabled = false;
            turn_count++;


            checkWinner();


        }

        
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            {

            }
            
        }

        private void checkWinner()
        {
            bool winner = false;
            //horizontal
            if((A1.Text == A2.Text)&&(A2.Text == A3.Text) && (A1.Text != ""))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B1.Text != ""))
                winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C1.Text != ""))
                winner = true;


            //vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (B1.Text != ""))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (B2.Text != ""))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (B3.Text != ""))
                winner = true;

            //cross-sectional
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (A1.Text != ""))
                winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (B2.Text != ""))
                winner = true;



            if (winner)
            {
                

                String win = "";
                if (turn)
                {
                    win = "O";
                }
                else
                {
                    win = "X";
                }
                MessageBox.Show("The winner is " + win);
                disableButtons();

                restart();
            }
            else
            {
                if(turn_count == 9)
                {
                    MessageBox.Show("It is a draw :(!");
                    restart();
                }
            }


        }

        private void restart()
        {
            foreach(Control b in Controls.OfType<Button>())
            {
                b.Enabled = true;
                b.Text = "";

            }
            turn_count = 0;
            turn = true;

        }


        private void playAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls.OfType<Button>())
                {
                    
                    c.Enabled = true;
                    c.Text = "";
                }
            }
            catch
            {

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
