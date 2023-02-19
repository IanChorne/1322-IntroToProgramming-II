using System;

namespace _1322_Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {

            int choice;
            do
            {
                Console.WriteLine("1 - Multiply two numbers\n2 - Divide two numbers\n3 - Mod two numbers");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter first number: ");
                        int num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter second number: ");
                        int num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Answer: " + recursive_multiply(num1, num2));
                        break;
                    case 2:
                        Console.WriteLine("Enter first number: ");
                        int i = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter second number: ");
                        int j = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Answer: " + recursive_div(i, j));
                        
                        break;
                    case 3:
                        Console.WriteLine("Enter first number: ");
                        int x = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter second number: ");
                        int y = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Answer: " + recursive_mod(x, y));
                        break;
                    case 4:
                        break;
                }
                if(choice > 4 || choice < 1)
                {
                    Console.WriteLine("Invalid selection, please try again: ");
                }
            } while (choice != 4);
            
        }

        public static int recursive_multiply(int i, int j)
        {
            
            if(j != 0)
            {
                return (i + recursive_multiply(i, j - 1));
            }
            else
            {
                return 0;
            }
        }

        public static int recursive_div(int i, int j)
        {
            if(i - j <= 0)
            {
                return 1;
            }
            else
            {
                return recursive_div(i - j, j) + 1;
            }
        }

        public static int recursive_mod(int i, int j)
        {
            if(i < j)
            {
                return i;
            }
            if(i == 0 || j == 0)
            {
                return -1;
            }
            else
            {
                return recursive_mod(i - j, j);
            }
        }
    }
}

