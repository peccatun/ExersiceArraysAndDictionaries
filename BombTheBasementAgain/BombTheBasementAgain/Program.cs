using System;
using System.Linq;

namespace BombTheBasementAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] basement = new int[sizes[0], sizes[1]];

            int[] bomb = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bombRow = bomb[0];
            int bombCol = bomb[1];
            int blastPower = bomb[2];
            int printOne = blastPower * 2 + 1;

            //Marking the bombed cells.
            for (int i = 0; i <= blastPower; i++)
            {
                for (int j = -blastPower; j <= blastPower; j++)
                {
                    if (bombRow + i <= basement.GetLength(0) - 1 && bombCol + j <= basement.GetLength(1) - 1 && bombCol + j >= 0)
                    {
                        basement[bombRow + i, bombCol + j] = 1;
                    }
                    if (bombRow + j <= basement.GetLength(0) - 1 && bombCol + i <= basement.GetLength(1) - 1
                        && bombRow+j >= 0)
                    {
                        basement[bombRow + j, bombCol + i] = 1;
                    }
                    if (bombRow - i >= 0 && bombCol + j <= basement.GetLength(1) - 1
                        && bombCol + j >= 0 && bombRow + i <= basement.GetLength(0) - 1)
                    {
                        basement[bombRow - i, bombCol + j] = 1;
                    }
                    if (bombRow + j <= basement.GetLength(0) - 1 && bombCol - i >= 0 
                        && bombRow+ j >= 0 && bombCol + i <= basement.GetLength(1) - 1)
                    {
                        basement[bombRow + j, bombCol - i] = 1;
                    }
                }
                blastPower -= 1;
            }
            //TODO: Moving cells one down.
            for (int row = 0; row < basement.GetLength(1); row++)
            {
                for (int col = 0; col < basement.GetLength(0); col++)
                {
                    if (basement[col,row] == 1)
                    {
                        for (int k = 0; k < basement.GetLength(0); k++)
                        {
                            if (basement[k,row] == 0)
                            {
                                basement[k, row] = 1;
                                basement[col, row] = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < basement.GetLength(0); row++)
            {
                for (int col = 0; col < basement.GetLength(1); col++)
                {
                    Console.Write(basement[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
