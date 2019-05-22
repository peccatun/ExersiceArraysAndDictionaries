using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[size, size];
            int countC = 0;
            int startRow = -1;
            int startCol = -1;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] inputField = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = inputField[col];
                    if (inputField[col] == 'c')
                    {
                        countC++;
                    }
                    if (inputField[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            int currentRow = startRow;
            int currentCol = startCol;
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "left":
                        if (IsInField(currentRow,currentCol-1,size))
                        {
                            currentCol = currentCol - 1;
                        }
                        if (field[currentRow,currentCol] == 'c')
                        {
                            countC--;
                            field[currentRow, currentCol] = '*';
                        }
                        if (field[currentRow,currentCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        if (countC == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                        break;
                    case "right":
                        if (IsInField(currentRow,currentCol+1,size))
                        {
                            currentCol += 1;
                        }
                        if (field[currentRow,currentCol] == 'c')
                        {
                            countC--;
                            field[currentRow, currentCol] = '*';
                        }
                        if (field[currentRow,currentCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        if (countC == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                        break;
                    case "up":
                        if (IsInField(currentRow-1,currentCol,size))
                        {
                            currentRow -= 1;
                        }
                        if (field[currentRow,currentCol] == 'c')
                        {
                            countC--;
                            field[currentRow, currentCol] = '*';
                        }
                        if (field[currentRow,currentCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        if (countC == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                        break;
                    case "down":
                        if (IsInField(currentRow+1,currentCol,size))
                        {
                            currentRow += 1;
                        }
                        if (field[currentRow,currentCol] == 'c')
                        {
                            countC--;
                            field[currentRow, currentCol] = '*';
                        }
                        if (field[currentRow,currentCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        if (countC == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"{countC} coals left. ({currentRow}, {currentCol})");
        }

        static bool IsInField(int row,int col,int size)
        {
            bool isInField = true;
            if (row < 0)
            {
                isInField = false;
            }
            if (col < 0)
            {
                isInField = false;
            }
            if (row > size-1)
            {
                isInField = false;
            }
            if (col > size-1)
            {
                isInField = false;
            }
            return isInField;
        }
    }
}
