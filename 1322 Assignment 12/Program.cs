using System;

namespace _1322_Assignment_12
{
    class Program
    {
        static void Main(string[] args)
        {
            JobLeadsList ListOfLeads = new JobLeadsList();
            int choice = 0;
            do
            {

                Console.WriteLine("1 – Add lead to head of list\n2 – Add lead to tail of list\n3 – Delete a lead\n4 – Print list from head to tail\n5 – Print list from tail to head\n6 – Exit");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please Enter Company Name: ");
                        string a = Console.ReadLine();
                        Console.WriteLine("Please Enter Contact Name: ");
                        string b = Console.ReadLine();
                        Console.WriteLine("Please Enter the Contact's Phone Number: ");
                        string c = Console.ReadLine();
                        Console.WriteLine("Please Enter Job Title: ");
                        string d = Console.ReadLine();
                        Console.WriteLine("Please Enter Job Description: ");
                        string e = Console.ReadLine();

                        //JobLead lead1 = new JobLead(a, b, c, d, e);
                        ListOfLeads.add_to_front(a, b, c, d, e);
                        break;
                    case 2:
                        Console.WriteLine("Please Enter Company Name: ");
                        string f = Console.ReadLine();
                        Console.WriteLine("Please Enter Contact Name: ");
                        string g = Console.ReadLine();
                        Console.WriteLine("Please Enter the Contact's Phone Number: ");
                        string h = Console.ReadLine();
                        Console.WriteLine("Please Enter Job Title: ");
                        string i = Console.ReadLine();
                        Console.WriteLine("Please Enter Job Description: ");
                        string j = Console.ReadLine();

                        //JobLead lead1 = new JobLead(a, b, c, d, e);
                        ListOfLeads.add_to_tail(f, g, h, i, j);
                        break;
                    case 3:
                        Console.WriteLine("Please Enter Company Name: ");
                        string k = Console.ReadLine();
                        Console.WriteLine("Please Enter Job Title: ");
                        string l = Console.ReadLine();

                        ListOfLeads.remove_lead(k, l);
                        break;
                    case 4:
                        ListOfLeads.print_head_to_tail();
                        break;
                    case 5:
                        ListOfLeads.print_tail_to_head();
                        break;
                    case 6:
                        break;
                }
            } while (choice != 6);
        }
    }

    class JobLead
    {
        private string companyName;
        private string contactName;
        private string contactPhone;
        private string jobTitle;
        private string jobDescription;

        public JobLead(string c, string n, string p, string j, string d)
        {
            companyName = c;
            contactName = n;
            contactPhone = p;
            jobTitle = j;
            jobDescription = d;
        }

        public override string ToString()
        {
            return "Company: " + companyName + ", Contact: " + contactName + ", Phone: " + contactPhone + ", Title: " + jobTitle + ", Description: " + jobDescription;
        }

        //setters
        public void setCompanyName(string s) { companyName = s; }
        public void setContactName(string s) { contactName = s; }
        public void setContactPhone(string s) { contactPhone = s; }
        public void setJobTitle(string s) { jobTitle = s; }
        public void setJobDescription(string s) { jobDescription = s; }

        //getters
        public string getCompanyName() { return companyName; }
        public string getContactName() { return contactName; }
        public string getCOntactPhone() { return contactPhone; }
        public string getJobTitle() { return jobTitle; }
        public string getJobDescription() { return jobDescription; }
    }

    class Node
    {
        public JobLead lead;
        public Node prev;   //Node pointer that points to previous node in list
        public Node next;   //Node pointer that points to next node in list
        public Node(string a, string b, string c, string d, string e)
        {
            lead = new JobLead(a, b, c, d, e);
        }
    }

    class JobLeadsList
    {
        private Node head = null;  //pointer that always points to first node in the list
        private Node tail = null;  //pointer that always points to the last node in the list

        public JobLeadsList() { head = null; tail = null; }

        public void add_to_front(string a, string b, string c, string d, string e)
        {
            Node newNode = new Node(a, b, c, d, e);
            //updates Node object and adds it to the front of the list
            //updates head/tail if necessary (if the lead replaced the current head or tail of the list of leads, right?)
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                newNode.next = null;
                newNode.prev = null;
            }
            else
            {
                head.prev = newNode;
                newNode.next = head;
                newNode.prev = null;
                head = newNode;
            }
            //print: Addition succesful
            Console.WriteLine("Addition Succesful");
        }

        public void add_to_tail(string a, string b, string c, string d, string e)
        {
            //JobLead newLead = new JobLead(a, b, c, d, e);
            Node newNode = new Node(a, b, c, d, e);
            //updates Node and adds it to the tail of the list
            //updates head/tail if necessary
            if (tail == null)
            {
                tail = newNode;
                head = newNode;
                newNode.next = null;
                newNode.prev = null;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                newNode.next = null;
                tail = newNode;
            }
            //print: Addition succesful
            Console.WriteLine("Addition Succesful");
        }

        public void remove_lead(string companyName, string jobTitle)
        {
            //if(list = empty)  then(print: Error, list empty)
            if (head == null)
            {
                Console.WriteLine("Error, List is empty");
            }
            /*else if(head.next == null || tail.prev == null)
            {
                head = null;
                tail = null;
                Console.WriteLine("List now empty");
            }*/
            else
            {
                for (Node cursor = head; cursor != null; cursor = cursor.next)
                {
                    if (cursor.lead.getCompanyName() == companyName && cursor.lead.getJobTitle() == jobTitle)
                    {
                        if (cursor == head)
                        {
                            head = head.next;
                            head.prev.next = null;
                            head.prev = null;
                        }
                        else if (cursor == tail)
                        {
                            tail = tail.prev;
                            tail.next.prev = null;
                            tail.next = null;
                        }
                        else
                        {
                            cursor.prev.next = cursor.next;
                            cursor.next.prev = cursor.prev;
                            cursor.next = null;
                            cursor.prev = null;
                        }

                    }

                }
            }
            //searches list using for loop?
            //if(node not found)    then(print: Error, Node not found)
            //if(node found)    remove node
            //updates tail/head

        }

        public void print_head_to_tail()
        {
            for (Node cursor = head; cursor != null; cursor = cursor.next)
            {
                Console.WriteLine(cursor.lead);
            }
            //if(list = empty)  then(print: Error, list empty)

            //else
            //use for loop to traverse list?
            //print each object in list
        }

        public void print_tail_to_head()
        {
            //does same function as previous method but in reverse
            for (Node cursor = tail; cursor != null; cursor = cursor.prev)
            {
                Console.WriteLine(cursor.lead);
            }
        }
    }
}