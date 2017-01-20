namespace Sapper
{
    using System;
    using System.Collections.Generic;

    public class StartGame
    {
        public static void Main(string[] args)
        {
            const int АllFields = 35;
            string command = string.Empty;
            char[,] board = Bombs.GenerateBoard();
            char[,] bombs = Bombs.SetBombs();
            int pointsCount = 0;
            bool exploded = false;
            var scores = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool startGame = true;
            bool winGame = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine("Lets play \"Mines\". Try to find all no-bomb fields." +
                    " Command 'top' shows RankList, 'restart' starts a new  game, 'exit' exits from the game");

                    Bombs.PrintBoard(board);
                    startGame = false;
                }

                Console.Write("Enter Row and Coloumn: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) &&
                        col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Bombs.PrintRankList(scores);
                        break;
                    case "restart":
                        board = Bombs.GenerateBoard();
                        bombs = Bombs.SetBombs();
                        Bombs.PrintBoard(board);
                        exploded = false;
                        startGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, Bye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                Bombs.ChangeFieldValue(board, bombs, row, col);
                                pointsCount++;
                            }

                            if (АllFields == pointsCount)
                            {
                                winGame = true;
                            }
                            else
                            {
                                Bombs.PrintBoard(board);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("Error! Unknown command\n");
                        break;
                }

                if (exploded)
                {
                    Bombs.PrintBoard(bombs);
                    Console.Write("\nHrrrrrr! Dies with {0} points. " + "Enter your nickname: ", pointsCount);
                    string nickname = Console.ReadLine();
                    var currScore = new Score(nickname, pointsCount);

                    if (scores.Count < 5)
                    {
                        scores.Add(currScore);
                    }
                    else
                    {
                        for (int i = 0; i < scores.Count; i++)
                        {
                            if (scores[i].Points < currScore.Points)
                            {
                                scores.Insert(i, currScore);
                                scores.RemoveAt(scores.Count - 1);
                                break;
                            }
                        }
                    }

                    scores.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    scores.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    Bombs.PrintRankList(scores);

                    board = Bombs.GenerateBoard();
                    bombs = Bombs.SetBombs();
                    pointsCount = 0;
                    exploded = false;
                    startGame = true;
                }

                if (winGame)
                {
                    Console.WriteLine("\nBRAVOOO! You had opened all 35 fields with 0 taken damage.");
                    Bombs.PrintBoard(bombs);
                    Console.WriteLine("Enter your nickname: ");
                    string nickname = Console.ReadLine();
                    var currScore = new Score(nickname, pointsCount);
                    scores.Add(currScore);
                    Bombs.PrintRankList(scores);
                    board = Bombs.GenerateBoard();
                    bombs = Bombs.SetBombs();
                    pointsCount = 0;
                    winGame = false;
                    startGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Game Over");
            Console.Read();
        }
    }
}
