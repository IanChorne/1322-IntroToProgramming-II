using System;

namespace _1322_Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Item[] arrOfItems = new Item[5];

            Console.WriteLine("Please enter B for Book or P for Periodical");
            char bookType = Console.ReadLine()[0];

            if(bookType == 'B')
            {
                Console.WriteLine("Please ener the name of the Book: ");
                string title = Console.ReadLine();
                Console.WriteLine("Please enter the author of the Book: ");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the ISBN of the Book: ");
                int isbn = Int32.Parse(Console.ReadLine());

                //store input in array cell
            }
            else if(bookType == 'P')
            {

            }
        }
    }

    abstract class Item
    {
        private string title;

        public Item()
        {
            title = "";
        }

        public Item(string n)
        {
            title = n;
        }

        public abstract string getListing();
        

        public override string ToString()
        {
            return "Title: " + title;
        }
        //getter/setter for title
        public string getTitle()
        {
            return title;
        }
        public void setTitle(string n)
        {
            title = n;
        }
    }

    class Book : Item
    {
        private int isbn_number;
        private string author;

        public Book()
        {

        }
        public Book(int isbn, string n)
        {
            isbn_number = isbn;
            author = n;
            getTitle(); //right way to do it?
            //Book b : Item;
        }

        //getters/setters
        public int getISBN()
        {
            return isbn_number;
        }
        public void setISBN(int i)
        {
            isbn_number = i;
        }
        public string getAuthor()
        {
            return author;
        }
        public void setAuthor(string n)
        {
            author = n;
        }

        public override string getListing() //implementing abstract method from parent class
        {
            return "Book Name- " + getTitle() + "\nAuthor- " + author + "\nISBN # - " + isbn_number;
        }
    }

    class Periodical : Item
    {
        private int issueNum;

        public Periodical()
        {

        }
        public Periodical(int i)
        {
            issueNum = i;
            //other attributes go here
        }

        public override string getListing()
        {
            return "Periodical Title - " + getTitle() + "\nIssue # - " + issueNum;
        }

        //getter/setter for issueNum
        public int getIssueNum() { return issueNum; }
        public void setIssueNum(int a) { issueNum = a; }

    }
}
