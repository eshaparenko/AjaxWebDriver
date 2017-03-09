using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Factorial(10));
        }

        static int Factorial(int number)
        {
            if (number <= 1)
                return 1;
            else
                return number * Factorial(number - 1);
        }
    }

}
