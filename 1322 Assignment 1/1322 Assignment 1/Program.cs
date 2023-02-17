using System;

namespace _1322_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            for (int i = 1; i <= 10; i++)
            {
                Circle myCircle = new Circle(i);
                Console.WriteLine("Area of a circle with radius " + i + " is " + myCircle.Area() + " circumferance is " + myCircle.Circumferance() + ".");
            }


            
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Rectangle myRectangle = new Rectangle(1, 1);
                    Console.WriteLine("Area of a rectangle " + i + " by " + j + " is " +myRectangle.Area() + " it's perimeter is " + myRectangle.Perimeter() + ".");
                }
            }

            Triangle myTriangle = new Triangle(18, 30, 24);
            //Console.WriteLine("Area of a triangle 18x30x24 is " + myTriangle.Area() + "it's perimeter is ")
            Console.WriteLine(myTriangle.ToString());

            Triangle newTriangle = new Triangle();
            Console.WriteLine(newTriangle.ToString());
        }
    }

    class Circle
    {
        private double radius;

        public Circle(double r) //constructor
        {
            radius = r;
        }
        public double Circumferance()
        {
            double cc = 2 * Math.PI * radius;
            return cc;
        }
        public double Area()
        {
            double cA = Math.PI * Math.Pow(radius, 2);
            return cA;
        }
    }

    class Triangle
    {
        private double side1;
        private double side2;
        private double side3;

        public Triangle(double s1, double s2, double s3)
        {
            side1 = s1;
            side2 = s2;
            side3 = s3;
        }
        public Triangle()
        {
            side1 = 3;
            side2 = 4;
            side3 = 5;
        }

        public double Perimeter()
        {
            double tP = side1 + side2 + side3;
            return tP;
        }
        public double Area()
        {
            double tP = (side1 + side2 + side3) / 2;
            double tA = Math.Sqrt(tP * (tP - side1) * (tP - side2) * (tP - side3));
            return tA;

        }
        public double Height()
        {
            //find smallest of 3 sides
            double smallSide = 0.0;
            if (side1 < side2 && side1 < side2)
            {
                smallSide = side1;
            }
            else if (side2 < side1 && side2 < side3)
            {
                smallSide = side2;
            }
            else if (side3 < side1 && side3 < side2)
            {
                smallSide = side3;
            }
            //multiply area of triangle by 2, then divide by smallest sides
            double tP = (side1 + side2 + side3) / 2;
            double tA = Math.Sqrt(tP * (tP - side1) * (tP - side2) * (tP - side3));
            double tH = (tA * 2) / smallSide;
            return tH;
        }

        
        public override string ToString() 
        {
            string a = "Traiangle has sides " + side1 + "," + side2 + "," + side3 + ". It has an area of " + Area() + " and a perimeter of " + Perimeter() + ". It also has a height of " + Height() + ".";
            return a;
            
        }

    }

    class Rectangle
    {
        private double height;
        private double width;

        public Rectangle(double a, double b)
        {
            height = a;
            width = b;
        }
        public double Perimeter()
        {
            double rP = 2 * height + 2 * width;
            return rP;
        }
        public double Area()
        {
            double rA = height * width;
            return rA;
        }
    }
}
