using System;
using System.IO;
using System.Collections.Generic;

namespace _1322_Assignment_10
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = null;
            StreamWriter sr2 = null;
            StreamWriter sr3 = null;
            try
            {
                Console.WriteLine("Please enter name of input file: ");
                string FileName = Console.ReadLine();   

                sr = new StreamReader("RawGradesFile.txt");  
                sr2 = new StreamWriter("FinalGradesFile.txt");
                sr3 = new StreamWriter("ErrorGradesFile.txt"); //sr3.writeline
                List<string> ListOfLines = new List<string>();

                while (!sr.EndOfStream) //While we aren't at the end of the stream...
                {
                    ListOfLines.Add(sr.ReadLine()); //...read the line
                }
                //Evaluate each string on listoflines (for/foreach loop) for each string, split into an array of characters.
                for (int i = 0; i < ListOfLines.Count; i++)
                {
                    string[] studentArr = ListOfLines[i].Split(",");
                    //check if it has a name/student ID based on index
                    if(studentArr[1] == " ")
                    {
                        sr3.WriteLine(ListOfLines[i]);
                        continue;
                    }
                    //Remove the lowest quiz grade
                    double min = Double.Parse(studentArr[2]);
                    double sum = 0;
                    int indexOfMin = 2;
                    for (int j = 0; j < studentArr.Length; j++)
                    {
                        if (j > 1 && j < 12)
                        {
                            sum = sum + Double.Parse(studentArr[j]);
                            if (Double.Parse(studentArr[j]) < min)
                            {
                                indexOfMin = j;

                            }
                        }
                    }
                    double avg = (sum - Double.Parse(studentArr[indexOfMin])) / 9;  //average of quiz grades
                    
                    //Replace the lowest test/missed test with final exam grade

                    if(Double.Parse(studentArr[12]) < Double.Parse(studentArr[13]) && Double.Parse(studentArr[12]) < Double.Parse(studentArr[14]) || Double.Parse(studentArr[12]) == 0.0)
                    {
                        studentArr[12] = studentArr[14];
                    }
                    else if(Double.Parse(studentArr[13]) < Double.Parse(studentArr[12]) && Double.Parse(studentArr[13]) < Double.Parse(studentArr[14]) || Double.Parse(studentArr[13]) == 0.0)
                    {
                        studentArr[13] = studentArr[14];
                    }

                    //DON'T replace with final exam grade
                    if (studentArr[12].Contains("-1.00"))    //is .Contains correct?
                    {
                        
                        studentArr[12] = "0.0";
                        //sr3.WriteLine(i);
                    }
                    if (studentArr[13].Contains("-1.00"))
                    {
                        studentArr[13] = "0.0";
                    }
                    double testAvg = (Double.Parse(studentArr[12]) + Double.Parse(studentArr[13]) + Double.Parse(studentArr[14])) / 3;  //average test grade

                    double finalGrade = (Double.Parse(studentArr[12]) + Double.Parse(studentArr[13]) + Double.Parse(studentArr[14]) + avg) / 4; //Final grade

                    char finalLetterGrade = ' ';
                    if(finalGrade <= 59.4)
                    {
                        finalLetterGrade = 'F';
                    }
                    if(finalGrade >= 59.5 && finalGrade <= 69.5)
                    {
                        finalLetterGrade = 'D';
                    }
                    if(finalGrade >= 69.6 && finalGrade <= 79.5)
                    {
                        finalLetterGrade = 'C';
                    }
                    if(finalGrade >= 79.6 && finalGrade <= 89.5)
                    {
                        finalLetterGrade = 'B';
                    }
                    if(finalGrade >= 89.6)
                    {
                        finalLetterGrade = 'A';
                    }

                    sr2.WriteLine(studentArr[0] + " " + studentArr[1] + " " + finalGrade + " " + finalLetterGrade);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sr2 != null)
                {
                    sr2.Close();
                }
                if (sr3 != null)
                {
                    sr3.Close();
                }
            }
        }
    }
}