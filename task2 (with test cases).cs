using System;
namespace Program
{
    class World
    {
        static bool isPrime(int numberForCheck)
        {
            bool prime = true;
            for (int i = 2; i <= numberForCheck / 2; i++)
            {
                if (numberForCheck % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;

        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter value for n: ");
            n = Convert.ToInt32(Console.ReadLine());
            List<int> nums = new();
            if (n <= 0 )
            {
                Console.WriteLine("error");
                return;
            }

            for (int i = 2; i < n; i++)
            {
                if (isPrime(i))
                {
                    double checkUpTo = Math.Log2(i + 1);
                    for (int m = 0; m <= checkUpTo; m++)
                    {
                        if (Math.Pow(2, m) == (i + 1))
                        {
                            if (isPrime(m))
                            {
                                nums.Add(i);
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < nums.Count(); i++)
            {
                Console.Write(nums[i] + " ");
            }
        }


    }
}
/*case 1: n = 0
 *case 2: n = -100
 *case 3: n = 100
 */
/*case 1: error n can't be zero
 *case 2: error n can't be negative
 *case 3: nums = 3 7 31
 */