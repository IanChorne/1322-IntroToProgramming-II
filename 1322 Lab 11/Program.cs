using System;
using System.IO;
using System.Collections.Generic;

namespace _1322_Lab_11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the name of the first file: ");
                string file1 = Console.ReadLine();
                Console.WriteLine("Enter the name of the second file: ");
                string file2 = Console.ReadLine();

                StreamReader sr = new StreamReader(file1);  
                StreamReader sr2 = new StreamReader(file2);
                //string dataline = "";
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();

                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
                while (!sr2.EndOfStream)
                {
                    list2.Add(sr2.ReadLine());
                }
                
                if(list.Count != list2.Count)
                {
                    throw new DifferentNumberOfLinesException("Error: Files have different number of lines");
                }

                for(int i = 0; i < list.Count; i++)
                {
                    if(list[i] != list2[i])
                    {
                        Console.WriteLine("Line " + (i + 1) + "\n<" + list[i] + "\n> " + list2[i]);  
                    }
                }

                sr.Close();
                sr2.Close();
                
            }
            catch(DifferentNumberOfLinesException e)
            {
                Console.WriteLine(e);
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Error: " + ioex);
            }

        }

        
    }
    class DifferentNumberOfLinesException : Exception
    {
        public DifferentNumberOfLinesException(string message) : base(message) { }

    }
}
