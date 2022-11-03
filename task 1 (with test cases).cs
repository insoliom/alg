namespace task1

{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("x ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.Write("z ");
            double z = Convert.ToDouble(Console.ReadLine());

            if (z == 0)
            {
                Console.WriteLine("помилка");
                return;
            }
            double a = Math.Cos(x + ((x * y) / z));
            double b = (Math.Pow(x, 3) / Math.Cos(a));
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }
    }
}
/*case 1: x=1 y=1 z=1
 *case 2: x=0 y=0 z=0
 */


/*case 1: a=0,54 b=1,1659
 *case 2: error z can't be zero
 
 */