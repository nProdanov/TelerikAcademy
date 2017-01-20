namespace Sapper
{
    using System;
    using System.Collections.Generic;

    public static class Bombs
    {
        public static void PrintRankList(List<Score> score)
        {
            Console.WriteLine("\nScores:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} fields",
                        i + 1,
                        score[i].Name,
                        score[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty RankList!\n");
            }
        }

        public static void ChangeFieldValue(
            char[,] board,
            char[,] bombs,
            int row,
            int col)
        {
            char bombsCount = CountNearBombs(bombs, row, col);
            bombs[row, col] = bombsCount;
            board[row, col] = bombsCount;
        }

        public static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        public static char[,] GenerateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        public static char[,] SetBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            var bombs = new List<int>();

            while (bombs.Count < 15)
            {
                Random random = new Random();
                int currBomb = random.Next(50);

                if (!bombs.Contains(currBomb))
                {
                    bombs.Add(currBomb);
                }
            }

            foreach (int bomb in bombs)
            {
                int col = bomb / cols;
                int row = bomb % cols;
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        public static char CountNearBombs(char[,] board, int row, int col)
        {
            int countBombs = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    countBombs++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, col] == '*')
                {
                    countBombs++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    countBombs++;
                }
            }

            if (col + 1 < cols)
            {
                if (board[row, col + 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    countBombs++;
                }
            }

            return char.Parse(countBombs.ToString());
        }
    }
}
