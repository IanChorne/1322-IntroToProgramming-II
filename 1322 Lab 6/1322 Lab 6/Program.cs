using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1322_Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number you want to find the Fibonaccie Series for: ");
            int fib = Int32.Parse(Console.ReadLine());
            FibIteration fi = new FibIteration();
            FibFormula fb = new FibFormula();
           
            Console.WriteLine("Fib of " + fib + " by iteration is: " + fi.calculate_fib(fib));
            Console.WriteLine("Fib of " + fib + " by formula is: " + fb.calculate_fib(fib));
        }
    }

    interface FindFib
    {
        public abstract int calculate_fib(int x);
    }

    class FibIteration : FindFib
    {
        public int calculate_fib(int x)
        {
            int num1 = 0;
            int num2 = 1; 
            int result = 0;
            if (x == 0) return 0;
            if (x == 1) return 1; 

            for (int i = 2; i<= x; i++)
            {
                result = num1 + num2;
                num1 = num2;
                num2 = result;
            }
            return result;
        }
    }

    class FibFormula : FindFib
    {
        public int calculate_fib(int x)
        {
            double rootFive = Math.Sqrt(5);
            double goldenRatio = (1 + rootFive) / 2;
            double phi = (1 - rootFive) / 2;


            return Convert.ToInt32((Math.Pow(goldenRatio, x) - Math.Pow(phi, x)) / rootFive);
        }
    }
}