using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] field = new char[sizes[0], sizes[1]];
            string input = Console.ReadLine();
            int possition = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[possition];
                    possition++;
                    if (possition >= input.Length)
                    {
                        possition = 0;
                    }
                }
            }
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
