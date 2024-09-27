using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4TicTacToe
{
    public class TicTacToe
    {
        /// <summary>
        /// storing board values
        /// </summary>
        public string[,] board;

        /// <summary>
        /// winning moved, put in a placeholder value
        /// </summary>
        public WinningMove eWinningMove;

        /// <summary>
        /// variable to keep track of turns taken in a given game
        /// </summary>
        public int turncount;

        /// <summary>
        /// establish all possible winning  move values
        /// </summary>
        public enum WinningMove
        {
            NoWin = 0,
            Row1 = 1,
            Row2 = 2, 
            Row3 = 3,
            Col1 = 4,
            Col2 = 5,
            Col3 = 6,
            Diag1 = 7,
            Diag2 = 8,
        }

        /// <summary>
        /// method to establish what each winning move is in the form, based on what is loaded into the board from loadboard method
        /// </summary>
        public void WinConditions()
        {
            if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && (board[0, 0] == "X" || board[0, 0] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Row1;
            }

            if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && (board[1, 0] == "X" || board[1, 0] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Row2;
            }

            if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && (board[2, 0] == "X" || board[2, 0] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Row3;
            }

            if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && (board[0, 0] == "X" || board[0, 0] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Col1;
            }

            if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && (board[0, 1] == "X" || board[0, 1] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Col2;
            }

            if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && (board[0, 2] == "X" || board[0, 2] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Col3;
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && (board[0, 0] == "X" || board[0, 0] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Diag1;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && (board[0, 2] == "X" || board[0, 2] == "O"))
            {
                eWinningMove = TicTacToe.WinningMove.Diag2;
            }

        }

        /// <summary>
        ///  populate winning move values
        /// </summary   

        /// <summary>
        /// Checking for win to pass back to the windows form
        /// </summary>
        public bool checkWin()
        {
            isHor();

            isVert();

            isDiag();

            if (isHor())
            {
                return true;
            }

            
            else if (isVert())
            {
                return true;
            }

            else if (isDiag()) 
            { 
                return true;
            }

            return false;
            
        }

        /// <summary>
        /// checking if win condition was met through a matching row
        /// </summary>
        /// <returns></returns>
        private bool isHor()
        {
            if (eWinningMove == WinningMove.Row1 || eWinningMove == WinningMove.Row2 || eWinningMove == WinningMove.Row3)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// checking if win condition was met through matching column
        /// </summary>
        /// <returns></returns>
        private bool isVert()
        {
            if (eWinningMove == WinningMove.Col1 || eWinningMove == WinningMove.Col2 || eWinningMove == WinningMove.Col3)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// checking if win condition was met through matching diagonal spaces
        /// </summary>
        /// <returns></returns>
        private bool isDiag()
        { 
            if (eWinningMove == WinningMove.Diag1 || eWinningMove == WinningMove.Diag2)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// checking if all spaces on the board have been filled without satisfying a win condition
        /// </summary>
        /// <returns></returns>
        public bool isTie()
        {
            if (turncount == 9 && eWinningMove == WinningMove.NoWin)
            {
                return true;
            }

            return false;

        }
    }
}
