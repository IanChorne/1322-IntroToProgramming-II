using System;
using System.Collections.Generic;

namespace _1322_Assignment_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            List<Bank_Account> BankAccounts = new List<Bank_Account>();
            do
            {
                Console.WriteLine("1 – Create An Account\n2 – Delete An Account\n3 – Make An Account Deposit\n4 – Make An Account Withdrawal\n5 – Check An Account Balance\n6 – Exit");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter the customer's name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter User ID: ");
                        string ID = Console.ReadLine();
                        Console.WriteLine("Please enter password: ");
                        string pass = Console.ReadLine();
                        //put exception handling here for password
                        try
                        {
                            //right spot for try block? Should the prompt asking for the user password be included with it?
                            Console.WriteLine("Processing...");
                            if (pass.Length < 8)
                            {
                                throw new InvalidPasswordFormatException("Invalid Password");
                             
                            }
                            if(!pass.Contains('*'))//Need to loop through array of chars
                            {
                               

                                throw new InvalidPasswordFormatException("Invalid Password Format");
                            }
                            
                        }
                        catch(InvalidPasswordFormatException e)
                        {
                            Console.WriteLine(e);
                        }
                        Bank_Account acc1 = new Checking_Account(name, ID, pass);   //Polymorphism! (necessary?)
                        BankAccounts.Add(acc1);
                        break;
                    case 2:
                        Console.WriteLine("Please enter User ID: ");
                        string id = Console.ReadLine();
                        Console.WriteLine("Please enter User Password: ");
                        string passwd = Console.ReadLine();

                        try
                        {
                            bool found = false;
                            foreach (Bank_Account b in BankAccounts)
                            {
                                if (b.getUserID() == id)
                                {
                                    if (b.getPassword() == passwd)
                                    {
                                        found = true;
                                        BankAccounts.Remove(b);
                                    }
                                }
                            }
                            if (!found)
                            {
                                throw new CustomerAccountNotFoundException("Error: Customer not found");
                            }
                        }
                        catch(CustomerAccountNotFoundException e)
                        {
                            Console.WriteLine(e);
                        }
                        
                        break;
                    case 3:
                        Console.WriteLine("Please enter User ID: ");
                        string uID = Console.ReadLine();
                        Console.WriteLine("Please enter password: ");
                        string password = Console.ReadLine();
                        Console.WriteLine("Please enter amount: ");
                        float amount = float.Parse(Console.ReadLine());

                        try
                        {
                            bool isFound = false;
                            foreach(Bank_Account ba in BankAccounts)
                            {
                                if(ba.getUserID() == uID)
                                {
                                    if(ba.getPassword() == password)
                                    {
                                        isFound = true;
                                        if(amount > 0)
                                        {
                                            ba.setAccBal(amount + ba.getAccBal());
                                        }
                                        else
                                        {
                                            throw new NegativeDollarAmountException("Error: Invalid Dollar Amount");
                                        }
                                    }
                                }
                            }
                            if (!isFound)
                            {
                                throw new CustomerAccountNotFoundException("Error: Customer not found");
                            }
                        }
                        catch(NegativeDollarAmountException e)
                        {
                            Console.WriteLine(e);
                        }
                        catch(CustomerAccountNotFoundException e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter user ID: ");
                        string accID = Console.ReadLine();
                        Console.WriteLine("Please enter password: ");
                        string passWord = Console.ReadLine();
                        Console.WriteLine("Please enter amount: ");
                        float wAmount = float.Parse(Console.ReadLine());

                        try
                        {
                            bool found = false;
                            foreach (Bank_Account ba in BankAccounts)
                            {
                                if (ba.getUserID() == accID)
                                {
                                    if (ba.getPassword() == passWord)
                                    {
                                        found = true;
                                        if (wAmount > 0)
                                        {
                                            if(wAmount < ba.getAccBal())
                                            {
                                                ba.setAccBal(ba.getAccBal() - wAmount);
                                            }
                                            
                                        }
                                        else
                                        {
                                            throw new InsufficientFundsException("Error: Invalid Dollar Amount");
                                        }
                                    }
                                }
                            }
                            if (!found)
                            {
                                throw new CustomerAccountNotFoundException("Error: Customer not found");
                            }
                        }
                        catch (InsufficientFundsException e)
                        {
                            Console.WriteLine(e);
                        }
                        catch (CustomerAccountNotFoundException e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Please enter user ID: ");
                        string iD = Console.ReadLine();
                        Console.WriteLine("Please enter password: ");
                        string p = Console.ReadLine();

                        try
                        {
                            bool found = false;
                            /*foreach (Bank_Account b in BankAccounts)
                            {
                                
                                
                            }*/
                            Console.WriteLine(BankAccounts.Count);
                            for(int i = 0; i < BankAccounts.Count; i++)
                            {
                                Console.WriteLine(BankAccounts[i].getUserID());
                                if (BankAccounts[i].getUserID() == iD)
                                {
                                    if (BankAccounts[i].getPassword() == p)
                                    {
                                        found = true;
                                        Console.WriteLine("Customer Name: " + BankAccounts[i].getName() + "\nAccount Number: " + BankAccounts[i].getUserID() + "\nAccount Balance: " + BankAccounts[i].getAccBal());
                                    }
                                }
                            }
                            if (found == false)
                            {
                                Console.WriteLine("Hello World!");
                                throw new CustomerAccountNotFoundException("Error: Customer's Account not found");
                            }
                        }
                        catch (CustomerAccountNotFoundException e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 6:
                        break;
                }

                if(choice > 6 || choice < 1)
                {
                    Console.WriteLine("Error: Please enter a valid choice (1 thru 6) ");
                }

            } while (choice != 6);
        }
    }

    //method that searches
    //Write something one time, then put it int a method and call that method multiple times

    class Bank_Account
    {
        private string name;
        private int accID;
        private static int numOfAccs = 0;
        private string userID;
        private string password;
        private double accBal;

        public Bank_Account(string a, string b, string c)
        {
            name = a;
            userID = b;
            password = c;
            numOfAccs++;
            accID = numOfAccs;
        }

        public static int numOfAccounts()   //Why do we need this method if we have a getter?
        {
            return numOfAccs;
        }

        public static void removeAccount()
        {
            //Should I use recursion here?
            numOfAccs = numOfAccs - 1;
        }

        //getters
        public string getName() { return name; }
        public string getUserID() { return userID; }
        public string getPassword() { return password; }
        public int getAccID() { return accID; }
        public double getAccBal() { return accBal; }
        public int getNUmOfAccs() { return numOfAccs; }
        //setters
        public void setName(string s) { name = s; }
        public void setUserID(string s) { userID = s; }
        public void setPassword(string s) { password = s; }
        public void setAccBal(double a) { accBal = a; }
    }

    class Checking_Account : Bank_Account
    {
        private double withdrawLimit;

        public Checking_Account(string n, string id, string p) : base(n, id, p)
        {
            withdrawLimit = 300.00;
        }

        //getter/setter
        public double getWithdrawlLimit() { return withdrawLimit; }
        public void setWithdrawlLimit(double a) { withdrawLimit = a; }
    }

    class InvalidPasswordFormatException : Exception
    {
        public InvalidPasswordFormatException() { }
        public InvalidPasswordFormatException(string message) : base(message)
        {
           
        }
    }

    class NegativeDollarAmountException : Exception
    {
        public NegativeDollarAmountException() { }
        public NegativeDollarAmountException(string message) : base(message)
        {

        }
    }

    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() { }
        public InsufficientFundsException(string message) : base(message) 
        {
            
        }

    }

    class CustomerAccountNotFoundException : Exception
    {
        public CustomerAccountNotFoundException() { }
        public CustomerAccountNotFoundException(string message) : base(message)
        {
            
        }
    }
}
