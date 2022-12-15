
namespace Assignment2
{
    class Task
    {
        static void Main(string[] args)
        {
            /* test matrix
             5x5
             {1,2,3,4,5},
             { 6,7,8,9,10},
             { 11,12,13,14,15},
             { 16,17,18,19,20},
             { 21,22,23,24,25}
             Test matrix random 5x5


             */

            int n = 0;
            Console.WriteLine("Matrix traversal\n");

            Console.WriteLine("Matrix is square ,thast why we need one number,enter ODD number: ");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n % 2 == 0)
                {
                    Console.WriteLine("i say ODD not even");
                }
            }
            while (n % 2 == 0);
            int[,] matrix = new int[n, n];
            int[][] min = new int[1][];

            int[] matrixTraversalSequence = new int[n * n];

            Console.WriteLine("\nEnter numbers" +
                "\n'1' to generate random  matrix with your number " +
                "\n'2' to exit of the program" +
                "\n'3' yourself made matrix");
            string answer = Convert.ToString(Console.ReadLine());
            switch (answer)
            {

                case "1":
                    matrix = randommatrix(n);
                    break;
                case "2":
                    Console.WriteLine("see you later");
                    Environment.Exit(0);
                    break;
                case "3":
                    Console.WriteLine("test matrix");
                    matrix = testmatrix(n);
                    break;
                default:
                    Console.WriteLine("that is not '1' or '2' or '3'");
                    Environment.Exit(0);
                    break;
            }


            //start traversal
            min = MatrixTraversal(matrix, ref min, ref matrixTraversalSequence);

            //print all results
            PMatrix(matrix);
            PSequence(matrixTraversalSequence);
            print(min, matrix);

            /*Test out put(test matrix)
             * 
             * 1       2       3       4       5
               6       7       8       9       10
               11      12      13      14      15
               16      17      18      19      20
               21      22      23      24      25
               13  12  7  8  9  14  19  18  17  16  11  6  1  2  3  4  5  10  15  20  25  24  23  22  21
               1[0][0] - on the diagonal

            test output(random 5x5 matrix)
            6       7       5       7       6
            3       4       3       14      9
            13      7       14      9       5
            7       5       6       11      9
            8       8       5       3       10
            14  7  4  3  14  9  11  6  5  7  13  3  6  7  5  7  6  9  5  9  10  3  5  8  8
            3[1][2] - above the diagonal
            3[1][0] - under the diagonal
            3[4][3] - under the diagonal
            
             */
        }


        //generate test matrix
        static int[,] testmatrix(int n)
        {

            int i, j;
            int[,] matrix = new int[n, n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("element - [{0},{1}] : ", i, j);
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            return matrix;
        }
        //generate random matrix
        static int[,] randommatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int max;
            Random rand = new Random();


            Console.WriteLine("Enter max value of numbers : ");
            do
            {
                max = Convert.ToInt32(Console.ReadLine());
            } while (max < 1);


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(1, max);
                }
            }

            return matrix;
        }



        //main algorithm
        static int[][] MatrixTraversal(int[,] matrix, ref int[][] min, ref int[] matrixTraversalSequence)
        {
            int n = Convert.ToInt32(Math.Sqrt(matrix.Length));
            int x = (n - 1) / 2, y = (n - 1) / 2;
            min[0] = new int[] { y, x };
            Array.Fill<int>(matrixTraversalSequence, -1);

            for (int i = 0; i < (n - 1) / 2; i++)
            {
                x += 1;
                for (int j = 0; j < 2 + 2 * i; j++)
                {
                    x -= 1;
                    min = minimal(min, matrix, new int[] { y, x });
                    change(ref matrixTraversalSequence, matrix[y, x]);
                }
                for (int j = 0; j < 1 + 2 * i; j++)
                {
                    y -= 1;
                    min = minimal(min, matrix, new int[] { y, x });
                    change(ref matrixTraversalSequence, matrix[y, x]);
                }

                for (int j = 0; j < 2 + 2 * i; j++)
                {
                    x += 1;
                    min = minimal(min, matrix, new int[] { y, x });
                    change(ref matrixTraversalSequence, matrix[y, x]);
                }

                for (int j = 0; j < 1 + 2 * i; j++)
                {
                    y += 1;
                    min = minimal(min, matrix, new int[] { y, x });
                    change(ref matrixTraversalSequence, matrix[y, x]);
                }
                y += 1;
            }
            for (int i = 0; i < n; i++)
            {
                min = minimal(min, matrix, new int[] { y, x });
                change(ref matrixTraversalSequence, matrix[y, x]);
                x -= 1;
            }

            return min;
        }


        //comparing numbers
        static int[][] minimal(int[][] min, int[,] matrix, int[] pos)
        {
            int n1 = matrix[min[0][0], min[0][1]];
            int n2 = matrix[pos[0], pos[1]];

            if (n1 > n2)
            {
                return new int[1][] { pos };
            }
            else if (n1 == n2)
            {
                int[][] tmp = new int[min.Length + 1][];
                for (int i = 0; i < min.Length; i++)
                {
                    tmp[i] = min[i];
                }
                tmp[tmp.Length - 1] = pos;

                return tmp;
            }
            else
            {
                return min;
            }
        }


        //add number to first empty cell (-1)
        static void change(ref int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == -1)
                {
                    arr[i] = val;
                    break;
                }
            }
        }


        //print matrix in console
        static void PMatrix(int[,] matrix)
        {
            int n = Convert.ToInt32(Math.Sqrt(matrix.Length));


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }


        //print sequence of matrix traversal
        static void PSequence(int[] mts)
        {
            for (int i = 0; i < mts.Length; i++)
            {
                Console.Write(mts[i] + "  ");
            }
            Console.WriteLine("");
        }


        //print array of minimal numbers
        static void print(int[][] min, int[,] matrix)
        {
            for (int i = 0; i < min.Length; i++)
            {
                Console.Write(matrix[min[i][0], min[i][1]] + "[" + min[i][0] + "][" + min[i][1] + "] - ");
                if (min[i][0] > min[i][1])
                {
                    Console.Write("under the main diagonal\n");
                }
                else if (min[i][0] < min[i][1])
                {
                    Console.Write("above the main diagonal\n");
                }
                else
                {
                    Console.Write("on the main diagonal\n");
                }
            }
        }
    }
}