using System;
using System.Collections;
using System.Collections.Generic;

namespace _1322_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();
            int choice;
            do
            {
                Console.Write("1. Add a question to the quiz\n2.Remove a question from the quiz\n3.Modify a question in the quiz\n4.Take the quiz\n5.Quit\n");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        quiz.add_question();
                        break;
                    case 2:
                        quiz.remove_question();
                        break;
                    case 3:
                        quiz.modify_question();
                        break;
                    case 4:
                        quiz.give_quiz();
                        break;
                    case 5:
                        break;
                }
            } while (choice != 5);
            
        }
    }

    class Question
    {
        private string question;
        private string answer;
        private int difficulty; //do I use a static variable to get a range of 1-3? Or an array

        public Question() //is a default constructor redundant?
        {
            question = "";
            answer = "";
            difficulty = 1; //would I start it at 1?
        }
        public Question(string q, string a, int d)
        {
            question = q;
            answer = a;
            difficulty = d;
        }

        public void set_question(string q)
        {
            question = q;
            
        }

        public void set_answer(string a)
        {
            answer = a;
            
        }

        public void set_difficulty(int d)
        {
            difficulty = d;
            /*if (d >= 4 || d <= 0)
            {
                Console.WriteLine("Invalid difficulty level");
            }*/
            //if user selects a certain number, allow certain questions from list(?)
            
        }
        public string get_question()
        {
            return question;
        }
        public string get_answer()
        {
            return answer;
        }
        public int get_difficulty()
        {
            return difficulty;
        }
    }

    class Quiz
    {
        List<Question> qList = new List<Question>();
        
        public void add_question()
        {
            string q = "";
            Console.WriteLine("What is the question text? ");
            q = Console.ReadLine();
            string a = "";
            Console.WriteLine("What is the answer? ");
            a = Console.ReadLine();
            int d;
            Console.WriteLine("How Difficult (1-3)? ");
            d = Int32.Parse(Console.ReadLine());

            Question Q = new Question(q, a, d);
            qList.Add(Q);
        }

        public void remove_question()
        {
            int choice;
            Console.Write("Choose a question to remove: ");
            for (int i = 0; i < qList.Count; i++)
            {
                Console.WriteLine(i + ". " + qList[i].get_question());
            }
            choice = Int32.Parse(Console.ReadLine());
            qList.RemoveAt(choice);
            //How to present questions as a choice? For loops?
        }

        public void modify_question()
        {
            int choice;
            Console.WriteLine("Choose a question to modify: ");
            for (int i = 0; i < qList.Count; i++)
            {
                Console.WriteLine(i + ". " + qList[i].get_question());
            }
            choice = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("What is the question text? ");
            string q = Console.ReadLine();
            
            Console.Write("What is the answer? ");
            string a = Console.ReadLine();

            Console.WriteLine("What is the question difficulty? ");
            int d = Int32.Parse(Console.ReadLine());

            Question nQuestion = new Question(q, a, d);

            qList[choice] = nQuestion;
        }

        public void give_quiz()
        {
            int score = 0;
            string a = "";
            for(int i = 0; i < qList.Count; i++)
            {
                Console.WriteLine(i + ". " + qList[i].get_question());
                a = Console.ReadLine();
                if (a.Equals(qList[i].get_answer()))
                {
                    Console.WriteLine("Correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
            }
            Console.WriteLine("You got " + score + " out of " + qList.Count);
        }
    }
}
