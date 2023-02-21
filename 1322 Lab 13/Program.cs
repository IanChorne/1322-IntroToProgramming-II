using System;

namespace _1322_Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            BlueRayCollection films = new BlueRayCollection();
            do
            {
                Console.WriteLine("0. Quit\n1.Add BlueRay to collection\n2.See collection");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("What is the title? ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Who is the director? ");
                        string director = Console.ReadLine();
                        Console.WriteLine("When did the film release? ");
                        int release = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("What is the cost? ");
                        double cost = Double.Parse(Console.ReadLine());

                        films.add(title, director, release, cost);
                        break;
                    case 2:
                        films.show_all();
                        break;
                }

                if (choice < 0 || choice > 2)
                {
                    Console.WriteLine("Invalid selection. Please try again");
                }

            } while (choice != 0);
        }
    }

    class BlueRayDisk
    {
        public string title;
        public string director;
        public int yrOfRelease;
        public double cost;

        public BlueRayDisk() { }
        public BlueRayDisk(string t, string d, int y, double c)
        {
            title = t;
            director = d;
            yrOfRelease = y;
            cost = c;
        }

        public override string ToString()
        {
            return "$ " + cost + " " + yrOfRelease + " " + title + ", " + director;
        }

    }

    class Node
    {
        public BlueRayDisk disk;
        public BlueRayDisk data;
        public Node next;

        public Node()
        {

        }
        public Node(string t, string d, int y, double c)
        {
            disk = new BlueRayDisk(t, d, y, c);
        }
        //data field
    }

    class BlueRayCollection
    {
        private Node head = null;
       
        public void add(string t, string d, int y, double c)
        {
            Node newNode = new Node(t, d, y, c);
            
            newNode.next = head;    //head.next.next?
            //Node newNode = new Node(t, d, y, c);
            if (head == null)
            {
                head = newNode;
                    //new Node(t, d, y, c);
                //head.data = data;
                newNode.next = null;
            }
            else
            {
                if(head.next == null)
                {
                    head.next = newNode;
                    
                    newNode.next = null;
                    while (newNode.next != null)
                    {
                        newNode = newNode.next;
                    }
                    /*if (newNode.next == null)
                    {
                        newNode.next = newNode;
                        newNode.next = null;
                    //why won't it work?????
                    }*/

                }
                

                //newNode.data = data;
                //newNode.next = head;
            }
        }

        public void show_all()
        {
            for(Node cursor = head; cursor != null; cursor = cursor.next)
            {
                Console.WriteLine(cursor.disk);
            }
        }
    }
}
/*public void push_back(string t, string d, int y, double c)
       {
           Node newNode = new Node(t, d, y, c);
           newNode.data = new BlueRayDisk(t, d, y, c);
           newNode.next = null;

           if(head == null)
           {
               head = newNode;
           }
           else
           {
               Node temp = new Node();
               temp = head;
               while(temp.next != null)
               {
                   temp = temp.next;
                   //temp.next = newNode;
               }
           }
       }*/

/*newNode.data = new BlueRayDisk(t, d, y, c);
            
            if (head == null)
            {
                head = newNode;
            }
            else if (head.next == null)
            {
                head.next = newNode;
                newNode.next = null;
            }
            else if (newNode.next == null)
            {
                newNode.next = newNode;
            }
            newNode.next = null;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = new Node(t, d, y, c);
                temp = head;
                while(temp.next != null)
                {
                    temp = temp.next;
                    temp.next = newNode;
                }
            }*/
//temp.next = head;
//head = temp;
//Help me please 