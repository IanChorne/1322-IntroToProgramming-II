using System;
using System.Collections.Generic;

namespace _1322_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Encryption encrypt = new Encryption();

            Console.WriteLine("1: Encrypt a message\n2: Decrypt a message\n3: Quit\nEnter Choice");
            choice = Int32.Parse(Console.ReadLine());
            if (choice >= 1 || choice <= 3)
            {
                switch (choice)
                {
                    case 1:
                        string message;
                        Console.Write("Enter a message: ");
                        message = Console.ReadLine();
                        Console.WriteLine(encrypt.encrypt_message(message));
                        break;
                    case 2:
                        string eMessage;
                        Console.Write("Enter an encrypted message: ");
                        eMessage = Console.ReadLine();
                        Console.WriteLine(encrypt.decrypt_message(eMessage));
                        break;
                    case 3:
                        break;
                }

            }
            else if (choice >= 4 || choice <= 0)
            {
                Console.Write("Invalid command, please select an option: ");
            }
        }
    }

    class Encryption
    {
        List<char> symbols = new List<char>();
        List<char> alphabets = new List<char>();
        public Encryption()
        {
            symbols.Add('!');
            symbols.Add('@');
            symbols.Add('#');
            symbols.Add('$');
            symbols.Add('^');
            symbols.Add('&');
            symbols.Add('*');
            symbols.Add('(');
            symbols.Add(')');
            symbols.Add('_');
            symbols.Add('-');
            symbols.Add('+');
            symbols.Add('=');
            symbols.Add('?');
            symbols.Add(',');
            symbols.Add('{');
            symbols.Add('}');
            symbols.Add('[');
            symbols.Add(']');
            symbols.Add('/');
            symbols.Add('|');
            symbols.Add(';');
            symbols.Add(':');
            symbols.Add('.');
            symbols.Add('<');
            symbols.Add('>');
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                alphabets.Add(letter);
            }
        }

        public char return_alphabet(int a)
        {
            //How to take in 'a' and return the character stored at that location?
            /*for (int i = 0; i < alphabets.Count; i++) //is a normal for loop necessary?
            {
                i = a;
                //alphabets.Add(i);
                Console.WriteLine("");
            }*/

            /*foreach (char x in alphabets)
            {
                symbols[a] = alphabets[x];
                Console.WriteLine(x); //from lecture slides, unsure if correct
            }*/

            return alphabets[a];
        }

        public int return_alphabet_index(char a)
        {
            int i = 0;
            foreach (char x in alphabets)
            {
                if (x == a)
                {
                    break;
                }
                i++;
            }
            return i;
        }

        public char return_symbol(int a)
        {
            return symbols[a];
        }

        public int return_symbol_index(int a)
        {
            int i = 0;
            foreach (char x in symbols)
            {
                if (x == a)
                {
                    break;
                }
                i++;
            }
            return i;
        }

        public string encrypt_message(string a)
        {
            a = a.ToLower();//makes string lowercase
            string eMessage = "";
            char[] arr1 = a.ToCharArray();
            bool valid = true;
            for(int i = 0; i < arr1.Length; i++)
            {
                for(int j =0; j < symbols.Count; j++)
                {
                    if(arr1[i] != alphabets[j])
                    {
                        valid = false;
                        
                    }
                }
            }
            if (valid)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    eMessage += return_symbol(return_alphabet_index(arr1[i])); //like a composition of functions in math

                }

                return eMessage;
            }
            return "Error: Invalid Character";
        }

        public string decrypt_message(string a)
        {
            a = a.ToLower();//makes string lowercase
            string dMessage = "";
            bool valid = true;
            char[] arr1 = a.ToCharArray();

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < symbols.Count; j++)
                {
                    if (arr1[i] != symbols[j] && arr1[i] != alphabets[j])
                    {
                        valid = false;
                        
                    }
                }
            }
            if (valid)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    dMessage += return_alphabet(return_symbol_index(arr1[i]));
                }

                return dMessage;
            }
            return "Error: Invalid character"; //put here so it doesn't print out even if the message is valid
        }
    }
}
