using System;

namespace _1322_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StockItem Milk = new StockItem("1 Gallon of Milk", 3.60f, 15);
            StockItem Bread = new StockItem("1 Loaf of Bread", 1.98f, 30);
            int choice = 0;
            do
            {
                Console.WriteLine("1.Sold One Milk " + "\n2.Sold One Bread " + "\n3.Change price of Milk " + "\n4.Change price of Bread " + "\n5.Add Milk to Inventory " + "\n6.Add Bread to Inventory " + "\n7.See Inventory" + "\n8.Quit");
                choice = Int32.Parse(Console.ReadLine());
            
                switch (choice)
                {
                    case 1:
                        int lq = 1;
                        Milk.SetLowQuantity(lq);
                        break;
                    case 2:
                        int lQ = 1;
                        Bread.SetLowQuantity(lQ);
                        break;
                    case 3:
                        float np;
                        Console.WriteLine("Enter new price of Milk: ");
                        np = float.Parse(Console.ReadLine());
                        Milk.SetPrice(np);
                        break;
                    case 4:
                        float nP;
                        Console.WriteLine("Enter new price of Bread: ");
                        nP = float.Parse(Console.ReadLine());
                        Bread.SetPrice(nP);
                        break;
                    case 5:
                        int rq;
                        Console.WriteLine("How much Milk did we get? ");
                        rq = Int32.Parse(Console.ReadLine());
                        Milk.SetHighQuantity(rq);
                        break;
                    case 6:
                        int rQ;
                        Console.WriteLine("How much Bread did we get? ");
                        rQ = Int32.Parse(Console.ReadLine());
                        Bread.SetHighQuantity(rQ);
                        Console.WriteLine(Bread.GetQuantity());
                        break;
                    case 7:
                        //Milk.ToString();
                        //Bread.ToString();
                        Console.WriteLine("Milk: " + Milk.ToString());
                        Console.WriteLine("Bread: " + Bread.ToString());
                        break;
                    case 8:

                        break;
                }
            } while (choice != 8);
        }
    }

    class StockItem
    {
        private string description;
        private int id;
        private static int ID=0;
        private float price;
        private int quantity;

        public StockItem() //default constructor
        {
            description = "";
         
            price = 0.0f;
            quantity = 0;

        }
        public StockItem(string a, float c, int d) //overloaded constructor
        {
            description = a;
            id = ID++;
            price = c;
            quantity = d;
        }

        public override string ToString() //prints out for option 7
        {
            string a = "Item number: " + GetID() + " is " + description + " has price " + GetPrice() + " we currently have " + GetQuantity() + " in stock.";
            return a;
        }
        //setters
        public float SetPrice(float a)
        {
            price = a;
            if (price < 0)
            {
                Console.WriteLine("Error, please try again: ");
            } 
            return price;
        }

        public int SetLowQuantity(int a)
        {
            quantity = quantity - a;
            if (quantity < 0)
            {
                Console.WriteLine("Error, quantity cannot be less than zero, please try again: ");
            } 
            return quantity;
        }

        public int SetHighQuantity(int a)
        {
            quantity = quantity + a;
            return quantity;
        }
        //getters
        public string GetDescription()
        {
            return description;
        }
        public int GetID()
        {
            return id;
        }
        public float GetPrice()
        {
            return price;
        }
        public int GetQuantity()
        {
            return quantity;
        }

    }
}