using System;

namespace _1322_Assignment_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            do
            { 
                Console.WriteLine("1 – Convert Decimal Number to Binary Number\n2 – Convert Decimal Number to Hexadecimal Number\n3 – Convert Decimal IP Address to Binary IP Address\n4 – Convert Decimal MAC Address to Hexadecimal MAC Address\n5 – Exit");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter a decimal number to convert to Binary: ");
                        int bnum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Decimal Number: " + bnum);
                        Console.WriteLine("Binary Number: " + decimal2Binary(bnum));
                    break;
                    case 2:
                        Console.WriteLine("Enter a decimal number to convert to Hexadecimal: ");
                        int hnum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Decimal Number: " + hnum);
                        Console.WriteLine("Hexadecimal Number: " + decimal2Hexadecimal(hnum));
                    break;
                    case 3:
                        Console.WriteLine("Enter decimal IP address: ");
                        string s = Console.ReadLine();
                        string[] ip = s.Split('.');
                        Console.WriteLine("Decimal IP Adress: " + s);
                        Console.WriteLine("Binary IP Address: " + convertipAddress(ip, 0));
                    break;
                    case 4:
                        Console.WriteLine("Enter decimal MAC address: ");
                        string a = Console.ReadLine();
                        string[] mac = a.Split(':');
                        Console.WriteLine("Decimal MAC Address: " + a);
                        Console.WriteLine("Hexadecimal MAC Address: " + convertMacAddress(mac, 0));
                    break;
                    case 5:
                    break;
                }
                if(choice > 5 || choice < 1)
                {
                    Console.WriteLine("Invalid selection, please try again: ");
                }
            } while (choice != 5);

        }

        public static string decimal2Binary(int i)
        {
            /*(didn't work) string output = " ";
            int remainder;
            string binary = " ";*/
            //base, when this is reached the recursion stops
            if (i == 0)
            {
                return "";
            }
            else
            {
                return decimal2Binary(i / 2) + (i % 2); 
                //You have to return the value in order to keep adding to the return value (like Inception)
                //In this case, the code is looking for the value of i/2, but then it just keeps looking until the break value is reached
                //it's like a different way of writing a loop

                //(didn't work) decimal2Binary(i / 2);  //uses recursion to start calculation
                /*remainder = (i % 2);    //gets remiander of user's num, then loops through num until it hits 0
                binary = Convert.ToString(remainder);
                output += binary;*/
            }
        }

        public static string decimal2Hexadecimal(int i)
        {
            string Hcode = "0123456789ABCDEF";
            if (i <= 0)
            {
                return "";
            }
            else
            {
                return decimal2Hexadecimal((i / 16)) + Hcode[i % 16];
            }
        }

        public static string convertipAddress(string[] s, int i)
        {
            if (i >= s.Length - 1)//you reach first or last index of array
            {
                return decimal2Binary(Int32.Parse(s[i]));
            }
            else
            {
                return decimal2Binary(Int32.Parse(s[i])) + "." + convertipAddress(s, i + 1);
            }

           
        }

        public static string convertMacAddress(string[] s, int i)
        {
            if (i >= s.Length - 1)
            {
                return decimal2Hexadecimal(Int32.Parse(s[i]));
            }
            else
            {
                return decimal2Hexadecimal(Int32.Parse(s[i])) + ":" + convertMacAddress(s, i + 1);
            }

        }

    }

}