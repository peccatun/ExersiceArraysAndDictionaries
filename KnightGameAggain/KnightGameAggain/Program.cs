using System;

namespace KnightGameAggain
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] field = new int[size, size];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }
            int[] cordsKnight = new int[3];
            int count = 0;
            int[] removedKnight = new int[3];
            for (int i = 0; i < size * size; i++)
            {
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        int currentKnight = 0;
                        if (field[row, col] == 'K')
                        {
                            // 2 horizontaly 1 verticaly right
                            if (col + 2 <= field.GetLength(1) - 1
                                && row + 1 <= field.GetLength(0) - 1)
                            {
                                if (field[row + 1, col + 2] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            //2 horizontaly 1 verticaly left
                            if (col - 2 >= 0 && row + 1 <= field.GetLength(0) - 1)
                            {
                                if (field[row + 1, col - 2] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            //one horizontaly two verticaly right
                            if (col + 1 <= field.GetLength(1) - 1
                                && row + 2 <= field.GetLength(0) - 1)
                            {
                                if (field[row + 2, col + 1] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            //one horizontaly two verticaly left
                            if (col - 1 >= 0 && row + 2 <= field.GetLength(0) - 1)
                            {
                                if (field[row + 2, col - 1] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                        }
                        if (currentKnight >= cordsKnight[2])
                        {
                            cordsKnight[0] = row;
                            cordsKnight[1] = col;
                            cordsKnight[2] = currentKnight;
                        }
                    }
                }
                if (i == size * size - 2)
                {
                    if (cordsKnight[2] == -1)
                    {
                        break;
                    }
                    else
                    {
                        removedKnight = cordsKnight;
                        field[cordsKnight[0], cordsKnight[1]] = '0';
                        cordsKnight[0] = -1;
                        cordsKnight[1] = -1;
                        cordsKnight[2] = 0;
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
