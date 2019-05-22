using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioActiveVampireMutantBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] field = new char[sizes[0], sizes[1]];
            int startRow = -1;
            int startCol = -1;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string structure = Console.ReadLine();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = structure[col];
                    if (structure[col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            string commands = Console.ReadLine();
            //Chek Logic and fild adjusment
            int currentRow = startRow;
            int currentCol = startCol;
            bool hasDied = false;
            int deathRow = -1;
            int deathCol = -1;
            bool hasWon = false;
            for (int i = 0; i < commands.Length; i++)
            {
                //Player Moves
                switch (commands[i])
                {
                    //Move player left
                    case 'L':

                        if (currentCol - 1 < 0)
                        {
                            //TODO: Win
                            field[currentRow, currentCol] = '.';
                            hasWon = true;
                        }
                        else if (field[currentRow, currentCol - 1] == 'B')
                        {
                            //TODO: Lose
                            field[currentRow, currentCol] = '.';
                            field[currentRow, currentCol - 1] = 'B';
                            deathRow = currentRow;
                            deathCol = currentCol-1;
                            hasDied = true;
                        }
                        else
                        {
                            field[currentRow, currentCol] = '.';
                            field[currentRow, currentCol - 1] = 'P';
                            currentCol -= 1;
                        }
                        break;
                    //Move player right
                    case 'R':
                        if (currentCol + 1 > field.GetLength(1) - 1)
                        {
                            //TODO:Win
                            field[currentRow, currentCol] = '.';
                            hasWon = true;

                        }
                        else if (field[currentRow, currentCol + 1] == 'B')
                        {
                            //TODO:Lose
                            field[currentRow, currentCol] = '.';
                            field[currentRow, currentCol + 1] = 'B';
                            deathRow = currentRow;
                            deathCol = currentCol + 1;
                            hasDied = true;
                        }
                        else
                        {
                            field[currentRow, currentCol] = '.';
                            field[currentRow, currentCol + 1] = 'P';
                            currentCol += 1;
                        }
                        break;
                    //Move player up
                    case 'U':
                        if (currentRow - 1 < 0)
                        {
                            //TODO:Win
                            field[currentRow, currentCol] = '.';
                            hasWon = true;
                        }
                        else if (field[currentRow - 1, currentCol] == 'B')
                        {
                            //TODO:Lose
                            field[currentRow, currentCol] = '.';
                            field[currentRow - 1, currentCol] = 'B';
                            deathRow = currentRow - 1;
                            deathCol = currentCol;
                            hasDied = true;
                        }
                        else
                        {
                            field[currentRow, currentCol] = '.';
                            field[currentRow - 1, currentCol] = 'P';
                            currentRow -= 1;
                        }
                        break;
                    //Move player down
                    case 'D':
                        if (currentRow + 1 > field.GetLength(0) - 1)
                        {
                            //TODO:Win
                            field[currentRow, currentCol] = '.';
                            hasWon = true;
                        }
                        else if (field[currentRow + 1, currentCol] == 'B')
                        {
                            field[currentRow, currentCol] = '.';
                            field[currentRow + 1, currentCol] = 'B';
                            deathRow = currentRow + 1;
                            deathCol = currentCol;
                            hasDied = true;
                            //TODO:Lose
                        }
                        else
                        {
                            field[currentRow + 1, currentCol] = 'P';
                            field[currentRow, currentCol] = '.';
                            currentRow += 1;
                        }
                        break;
                    default:
                        break;
                }
                //Bunny spread
                List<int[]> bunnyCords = new List<int[]>();
                int index = 0;
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        if (field[row, col] == 'B')
                        {
                            bunnyCords.Add(new int[2]);
                            bunnyCords[index][0] = row;
                            bunnyCords[index][1] = col;
                            index++;
                        }
                    }
                }
                for (int j = 0; j < bunnyCords.Count; j++)
                {
                    int bunnyRow = bunnyCords[j][0];
                    int bunnyCol = bunnyCords[j][1];
                    //Bunny spread left
                    if (IsInField(bunnyRow, bunnyCol - 1, field.GetLength(0), field.GetLength(1)))
                    {
                        if (field[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            hasDied = true;
                            deathRow = bunnyRow;
                            deathCol = bunnyCol - 1;
                            field[bunnyRow, bunnyCol - 1] = 'B';
                        }
                        else
                        {
                            field[bunnyRow, bunnyCol - 1] = 'B';
                        }
                    }
                    //bunny spread right
                    if (IsInField(bunnyRow, bunnyCol + 1, field.GetLength(0), field.GetLength(1)))
                    {
                        if (field[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            hasDied = true;
                            deathRow = bunnyRow;
                            deathCol = bunnyCol + 1;
                            field[bunnyRow, bunnyCol + 1] = 'B';
                        }
                        else
                        {
                            field[bunnyRow, bunnyCol + 1] = 'B';
                        }
                    }
                    //Bunny spread up
                    if (IsInField(bunnyRow - 1, bunnyCol, field.GetLength(0), field.GetLength(1)))
                    {
                        if (field[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            hasDied = true;
                            deathRow = bunnyRow - 1;
                            deathCol = bunnyCol;
                            field[bunnyRow - 1, bunnyCol] = 'B';
                        }
                        else
                        {
                            field[bunnyRow - 1, bunnyCol] = 'B';
                        }
                    }
                    //Bunny spread down
                    if (IsInField(bunnyRow + 1, bunnyCol, field.GetLength(0), field.GetLength(1)))
                    {
                        if (field[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            hasDied = true;
                            deathRow = bunnyRow + 1;
                            deathCol = bunnyCol;
                            field[bunnyRow + 1, bunnyCol] = 'B';
                        }
                        else
                        {
                            field[bunnyRow + 1, bunnyCol] = 'B';
                        }
                    }
                }
                if (hasDied)
                {
                    break;
                }
                if (hasWon)
                {
                    break;
                }

            }
            if (hasWon)
            {
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        Console.Write(field[row, col]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"won: {currentRow} {currentCol}");
            }
            if (hasDied)
            {
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        Console.Write(field[row, col]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"dead: {deathRow} {deathCol}");
                return;
            }
        }
        static bool IsInField(int row, int col, int sizeRow, int sizeCol)
        {
            if (row < 0)
            {
                return false;
            }
            if (col < 0)
            {
                return false;
            }
            if (row > sizeRow - 1)
            {
                return false;
            }
            if (col > sizeCol - 1)
            {
                return false;
            }
            return true;
        }
    }
}
