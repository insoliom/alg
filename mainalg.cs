using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of rows (N): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns (M): ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Enter the value of K: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter the value of L: ");
        int l = int.Parse(Console.ReadLine());
        Console.Write("range of ramdom numbers in matrix  ");
        int chislo = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = rnd.Next(chislo);
            }
        }
        Console.WriteLine("Original Matrix:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] / k  < l)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine();
        }

        Console.ResetColor();

      
       for (int i = 0; i < n; i++)
        {
            bool swapped = true;
            int gap = m;
            while (gap > 1 || swapped)
            {
                gap = (int)(gap / 1.3);
                if (gap == 0 || gap == 1)
                {
                    gap = 1;
                }
                int j = 0;
                swapped = false;
                while (j + gap < m)
                {
                    if (matrix[i, j] / k < l && matrix[i, j + gap] / k < l)
                    {
                        if (matrix[i, j] > matrix[i, j + gap])
                        {
                            Swap(matrix, i, j, j + gap);
                            swapped = true;
                        }
                        
                    }
                    j++;
                }
            }
        }
        Console.WriteLine("Sorted Matrix:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] / k   < l)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine();
        }

        Console.ResetColor();
    }

    static void Swap(int[,] matrix, int row, int i, int j)
    {
        int temp = matrix[row, i];
        matrix[row, i] = matrix[row, j];
        matrix[row, j] = temp;
    }

}
