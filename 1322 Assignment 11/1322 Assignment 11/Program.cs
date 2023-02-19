using System;
using System.Threading;

namespace _1322_Assignment_11
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard card1 = new CreditCard();
            CreditCard card2 = new CreditCard();
            CardHolder acc1 = new CardHolder(card1);
            CardHolder acc2 = new CardHolder(card2);

            Thread John = new Thread(acc1.Run);
            Thread Mary = new Thread(acc2.Run);

            John.Name = "John";
            Mary.Name = "Mary";

            John.Start();
            Mary.Start();
        }
    }

    class CreditCard
    {
        private double accBal = 5000.00;
        public void withdraw(double a)
        {
            accBal -= a;
        }
        public double getBalance()
        {
            return accBal;
        }
        //public abstract void run();
    }

    class CardHolder
    {
        private static object padlock = new object();
        private CreditCard card;

        public CardHolder(CreditCard c)
        {
            card = c;
        }

        public void Run()  //run method?
        {
            double withdrawAMT = 500.00;

            for (int i = 0; i < 6; i++)  //6 is a placeholder
            {
                makeWithdrawl(withdrawAMT);
                if (card.getBalance() == 0)
                {
                    Console.WriteLine("Error: Account has no remaining balance");   //you broke
                }
            }
        }

        private void makeWithdrawl(double a)
        {
            Thread thread = Thread.CurrentThread;
            lock(padlock)
            {
                card.getBalance();
                if (card.getBalance() < a)
                {
                    Console.WriteLine("Not enough in: thread " + thread.Name + " to withdraw: $" + a + ", Balance: $" + card.getBalance());  //needs to include thread name
                }
                if (card.getBalance() >= a)
                {
                    Console.WriteLine("thread " + thread.Name + ", before withdrawing $" + a + ", Balance: $" + card.getBalance());  //needs to include thread name
                    try
                    {
                        Thread.Sleep(6000);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                    }
                    card.withdraw(a);
                    Console.WriteLine("thread " + thread.Name +  ", after withdrawing $" + a + ", Balace: $" + card.getBalance());
                }
            }
        }
    }
}
