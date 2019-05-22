using System;
using System.Linq;

namespace Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] field = new int[size, size];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                int[] values = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = values[col];
                }
            }
            string[] bombCells = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombCells.Length; i++)
            {
                int[] values = bombCells[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int bombRow = values[0];
                int bombCol = values[1];
                if (bombRow >= 0 && bombCol >= 0
                    && bombRow <= field.GetLength(0) - 1
                    && bombCol <= field.GetLength(1) - 1)
                {
                    if (field[bombRow,bombCol] > 0)
                    {
                        int bombPower = field[bombRow, bombCol];
                        field[bombRow, bombCol] -= bombPower;
                        //left side
                        if (IsInField(bombRow,bombCol-1,size))
                        {
                            if (field[bombRow,bombCol-1] > 0)
                            {
                                field[bombRow, bombCol - 1] -= bombPower;
                            }
                        }
                        //left up diagonal
                        if (IsInField(bombRow-1,bombCol-1,size))
                        {
                            if (field[bombRow-1,bombCol-1] > 0)
                            {
                                field[bombRow - 1, bombCol - 1] -= bombPower;
                            }
                        }
                        //left down diagonal
                        if (IsInField(bombRow+1,bombCol-1,size))
                        {
                            if (field[bombRow+1,bombCol-1] > 0)
                            {
                                field[bombRow + 1, bombCol - 1] -= bombPower;
                            }
                        }
                        //up
                        if (IsInField(bombRow-1,bombCol,size))
                        {
                            if (field[bombRow-1,bombCol] > 0)
                            {
                                field[bombRow - 1, bombCol] -= bombPower;
                            }
                        }
                        //down
                        if (IsInField(bombRow+1,bombCol,size))
                        {
                            if (field[bombRow+1,bombCol] > 0)
                            {
                                field[bombRow + 1, bombCol] -= bombPower;
                            }
                        }
                        //righ side
                        if (IsInField(bombRow,bombCol+1,size))
                        {
                            if (field[bombRow,bombCol+1] > 0)
                            {
                                field[bombRow, bombCol + 1] -= bombPower;
                            }
                        }
                        //down right diagonal
                        if (IsInField(bombRow+1,bombCol+1,size))
                        {
                            if (field[bombRow+1,bombCol+1] > 0)
                            {
                                field[bombRow + 1, bombCol + 1] -= bombPower;
                            }
                        }
                        //up right diagonal
                        if (IsInField(bombRow-1,bombCol+1,size))
                        {
                            if (field[bombRow-1,bombCol+1] > 0)
                            {
                                field[bombRow - 1, bombCol + 1] -= bombPower;
                            }
                        }
                    }
                }
            }
            int positiveNums = 0;
            int sum = 0;
            foreach (var cell in field)
            {
                if (cell > 0)
                {
                    positiveNums++;
                    sum += cell;
                }
            }
            Console.WriteLine("Alive cells: "+positiveNums);
            Console.WriteLine("Sum: "+sum);
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col]+" ");
                }
                Console.WriteLine();
            }
        }

        static bool IsInField(int row, int col, int size)
        {
            bool isInRange = true;
            if (row < 0)
            {
                isInRange = false;
            }
            if (row > size - 1)
            {
                isInRange = false;
            }
            if (col < 0)
            {
                isInRange = false;
            }
            if (col > size - 1)
            {
                isInRange = false;
            }
            return isInRange;
        }
    }
}
