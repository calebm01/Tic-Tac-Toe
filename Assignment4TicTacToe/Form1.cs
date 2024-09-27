using System.Drawing.Drawing2D;
using static Assignment4TicTacToe.TicTacToe;

namespace Assignment4TicTacToe
{
    public partial class Form1 : Form
    {
        TicTacToe TicTacToe;
        public Form1()
        {
            InitializeComponent();

            /// Calling Tic Tac Toe object
            TicTacToe = new TicTacToe();

            /// Initializing board
            board.board = new string[3, 3];
        }

        /// <summary>
        /// variable to tell the game who's turn it is
        /// </summary>
        int turn = 7;

        /// <summary>
        /// player 1 wins
        /// </summary>
        int wins1;

        /// <summary>
        /// player 2 wins
        /// </summary>
        int wins2;

        /// <summary>
        /// ties
        /// </summary>
        int ties;

        /// <summary>
        /// Declaring new tic tac toe object for use in form
        /// </summary>
        TicTacToe board = new TicTacToe();

        /// <summary>
        /// Sets the game to default values
        /// </summary>
        public void initializeGame()
        {
            

            // resetting values from TicTacToe class
            board.turncount = 0;
            InitializeBoard();
            board.eWinningMove = TicTacToe.WinningMove.NoWin;


            //player 1 always starts
            turn = 0;
            gameStatus(0);

            //initalize stats
            updateStats();



            //clearing and re-enabling buttons
            button1.BackColor = Color.Gray; button1.Text = " "; button1.Enabled = true;
            button2.BackColor = Color.Gray; button2.Text = " "; button2.Enabled = true;
            button3.BackColor = Color.Gray; button3.Text = " "; button3.Enabled = true;
            button4.BackColor = Color.Gray; button4.Text = " "; button4.Enabled = true;
            button5.BackColor = Color.Gray; button5.Text = " "; button5.Enabled = true;
            button6.BackColor = Color.Gray; button6.Text = " "; button6.Enabled = true;
            button7.BackColor = Color.Gray; button7.Text = " "; button7.Enabled = true;
            button8.BackColor = Color.Gray; button8.Text = " "; button8.Enabled = true;
            button9.BackColor = Color.Gray; button9.Text = " "; button9.Enabled = true;


        }

        /// <summary>
        /// method to load board to Tic Tac Toe class
        /// </summary>
        public void loadBoard()
        {
            if (button1.Text != " ")
            {
                board.board[0, 0] = button1.Text;
            }

            if (button2.Text != " ")
            {
                board.board[0, 1] = button2.Text;
            }

            if (button3.Text != " ")
            {
                board.board[0, 2] = button3.Text;
            }

            if (button4.Text != " ")
            {
                board.board[1, 0] = button4.Text;
            }

            if (button5.Text != " ")
            {
                board.board[1, 1] = button5.Text;
            }

            if (button6.Text != " ")
            {
                board.board[1, 2] = button6.Text;
            }

            if (button7.Text != " ")
            {
                board.board[2, 0] = button7.Text;
            }

            if (button8.Text != " ")
            {
                board.board[2, 1] = button8.Text;
            }

            if (button9.Text != " ")
            {
                board.board[2, 2] = button9.Text;
            }
        }

        /// <summary>
        /// updates stats in stats texbox
        /// </summary>
        public void updateStats()
        {
            richTextBox1.Text = "Player 1 Wins:  " + wins1 + "\n\n Player 2 Wins:  " + wins2 + "\n\n Ties:   " + ties;
        }

        /// <summary>
        /// intialize board with empty cells.
        /// </summary>
        public void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board.board[row, col] = " ";
                }
            }
        }


        /// <summary>
        /// Updates the game status textbox
        /// </summary>
        /// <param name="gameStatus"></param>
        public void gameStatus(int gameStatus)
        {
            if (gameStatus == 0)
            {
                textBox1.Text = "It is Player 1's turn!";
            }

            else if (gameStatus == 1)
            {
                textBox1.Text = "It is Player 2's turn!";
            }

            else if (gameStatus == 2)
            {
                textBox1.Text = "Player 1 Wins! Congratulations!!";
            }

            else if (gameStatus == 3)
            {
                textBox1.Text = "Player 2 Wins! Congratulations!!";
            }

            else if (gameStatus == 4)
            {
                textBox1.Text = "It's a Tie!";
            }
        }

        /// <summary>
        /// start game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            initializeGame();
        }

        /// <summary>
        /// Displaying X or O on buttons pressed dependent on who's turn it is, button will do nothing if turn isn't 
        /// 0 or 1 (game is not started, or game is finished)
        /// </summary>
        /// 

        private void playerClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn == 0)
            {

                button.Text = "X";
                button.Font = new Font("Arial", 25, FontStyle.Bold);
                button.ForeColor = Color.Red;
                button.Enabled = false;
                turn = 1;
                gameStatus(turn);
                loadBoard();
                board.turncount++;
                board.WinConditions();
                board.checkWin();
                if (board.checkWin() == true)
                {
                    //updating stats
                    wins1++;
                    updateStats();
                    gameStatus(2);
                    


                    //disallowing further moves
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;

                    //highlighting winning move
                    if (board.eWinningMove == TicTacToe.WinningMove.Row1)
                    {
                        button1.BackColor = Color.Yellow;
                        button2.BackColor = Color.Yellow;
                        button3.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == TicTacToe.WinningMove.Row2)
                    {
                        button4.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button6.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == TicTacToe.WinningMove.Row3)
                    {
                        button7.BackColor = Color.Yellow;
                        button8.BackColor = Color.Yellow;
                        button9.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == TicTacToe.WinningMove.Col1)
                    {
                        button1.BackColor = Color.Yellow;
                        button4.BackColor = Color.Yellow;
                        button7.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == TicTacToe.WinningMove.Col2)
                    {
                        button2.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button8.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == TicTacToe.WinningMove.Col3)
                    {
                        button3.BackColor = Color.Yellow;
                        button6.BackColor = Color.Yellow;
                        button9.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == TicTacToe.WinningMove.Diag1)
                    {
                        button1.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button9.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == TicTacToe.WinningMove.Diag2)
                    {
                        button7.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button3.BackColor = Color.Yellow;
                    }

                }
                board.isTie();
                if (board.isTie() == true)
                {
                    ties++;
                    gameStatus(4);
                    updateStats();
                }
            }

            else if (turn == 1)
            {
                button.Text = "O";
                button.Font = new Font("Arial", 25, FontStyle.Bold);
                button.ForeColor = Color.Blue;
                button.Enabled = false;
                turn = 0;
                gameStatus(turn);
                loadBoard();
                board.turncount++;
                board.WinConditions();
                board.checkWin();
                if (board.checkWin() == true)
                {
                    //updating stats
                    wins2++;
                    updateStats();
                    gameStatus(3);

                    //disallowing further moves
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;

                    //highlighting winning move
                    if (board.eWinningMove == WinningMove.Row1)
                    {
                        button1.BackColor = Color.Yellow;
                        button2.BackColor = Color.Yellow;
                        button3.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == WinningMove.Row2)
                    {
                        button4.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button6.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == WinningMove.Row3)
                    {
                        button7.BackColor = Color.Yellow;
                        button8.BackColor = Color.Yellow;
                        button9.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == WinningMove.Col1)
                    {
                        button1.BackColor = Color.Yellow;
                        button4.BackColor = Color.Yellow;
                        button7.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == WinningMove.Col2)
                    {
                        button2.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button8.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == WinningMove.Col3)
                    {
                        button3.BackColor = Color.Yellow;
                        button6.BackColor = Color.Yellow;
                        button9.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == WinningMove.Diag1)
                    {
                        button1.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button9.BackColor = Color.Yellow;
                    }

                    else if (board.eWinningMove == WinningMove.Diag2)
                    {
                        button7.BackColor = Color.Yellow;
                        button5.BackColor = Color.Yellow;
                        button3.BackColor = Color.Yellow;
                    }

                }
                board.isTie();
                if (board.isTie() == true)
                {
                    ties++;
                    gameStatus(4);
                    updateStats();
                }
            }


        }
    }
}