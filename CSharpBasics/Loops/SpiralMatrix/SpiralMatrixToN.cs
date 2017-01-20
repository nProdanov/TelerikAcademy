using System;
class FillMatrix4
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int[,] multiArr = new int[n, n];
        string down = "down";
        string right = "right";
        string up = "up";
        string left = "left";
        string direction = right;
        int count = 1;
        int row = 0;
        int col = 0;

        while (count <= n * n)
        {
            multiArr[row, col] = count;
            count++;
            switch (direction)
            {
                //DOWN
                case "down":
                    if (row + 1 == n || multiArr[row + 1, col] != 0)
                    {
                        direction = left;
                        col--;
                    }
                    else
                    {
                        row++;
                    }
                    break;

                //RIGHT
                case "right":
                    if (col + 1 == n || multiArr[row, col + 1] != 0)
                    {
                        direction = down;
                        row++;
                    }
                    else
                    {
                        col++;
                    }
                    break;

                //UP
                case "up":
                    if (row - 1 < 0 || multiArr[row - 1, col] != 0)
                    {
                        direction = right;
                        col++;
                    }
                    else
                    {
                        row--;
                    }
                    break;

                //LEFT
                case "left":
                    if (col - 1 < 0 || multiArr[row, col - 1] != 0)
                    {
                        direction = up;
                        row--;
                    }
                    else
                    {
                        col--;
                    }
                    break;
            }

        }
        for (int i = 0; i < multiArr.GetLength(0); i++)
        {
            for (int j = 0; j < multiArr.GetLength(1); j++)
            {
                Console.Write("{0} ", multiArr[i, j]);
            }
            Console.WriteLine();
        }

    }
}

