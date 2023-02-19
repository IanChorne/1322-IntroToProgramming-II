using System;
using System.Threading;

namespace _1322_Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Baby b1 = new Baby("Noah");
            Baby b2 = new Baby("Olivia");
            Baby b3 = new Baby("Liam");
            Baby b4 = new Baby("Emma");
            Baby b5 = new Baby("Amelia");

            Thread t1 = new Thread(b1.Run);
            Thread t2 = new Thread(b2.Run);
            Thread t3 = new Thread(b3.Run);
            Thread t4 = new Thread(b4.Run);
            Thread t5 = new Thread(b5.Run);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
        }
    }

    class Baby
    {
        int time;
        string name;

        public Baby(string n)
        {
            name = n;
            //random object created correctly? Yep it is lol
            Random rand = new Random();
            time = rand.Next(5000);
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("My name is " + name + " I am going to sleep for " + time + "ms");
                Thread.Sleep(time);
                Console.WriteLine("My name is " + name + ", I am awake, feed me!!!");

            }
            catch (ThreadInterruptedException)
            {
                throw new ThreadInterruptedException("Error: Thread Interrupted");
            }
        }
    }
}
