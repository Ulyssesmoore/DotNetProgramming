using System;

namespace TicTacToeEngine
{
    public class Engine
    {
        private static int[,] wincombos =
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
         };

        public static bool checkWin(String[] board)
        {
            Boolean b = false;
            for (int i = 0; i < wincombos.GetLength(0); i++)
            {
                if ((board[wincombos[i, 0]] == board[wincombos[i, 1]] && board[wincombos[i, 0]] == board[wincombos[i, 2]]) && !String.IsNullOrEmpty(board[wincombos[i, 0]]))
                {
                    b = true;
                    break;
                }
            }
            return b;
        }


    }
}
