using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloMethod
{

    struct Point
    {
        public double xPoint;
        public double yPoint;

        public Point(Random rand)
        {
            this.xPoint = rand.NextDouble();
            this.yPoint = rand.NextDouble();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPoints=0;
            Random rand = new Random();
            do
            {
                double count = 0.0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the number of points you would like to check, or enter 0 to quit");
                    try
                    {
                        numberOfPoints = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("You did not enter a valid number");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("You entered a number too large");
                    }
                } while (numberOfPoints < 0);
                if(numberOfPoints!=0)
                {
                    Point[] points = new Point[numberOfPoints];
                    for(int i=0;i<points.Length;i++)
                    {
                        points[i] = new Point(rand);
                    }
                    for(int i=0;i<points.Length;i++)
                    {
                        if(GetHypotenuse(points[i])<=1)
                        {
                            count++;
                        }
                    }
                    double overlappingPoints = count / points.Length;
                    overlappingPoints *= 4;
                    Console.WriteLine($"{overlappingPoints}\n{Math.PI}\nDifference:{Math.Abs(overlappingPoints-Math.PI)}");
                }
                Console.ReadLine();
            } while (numberOfPoints != 0);
           
            
        }
        public static double GetHypotenuse(Point point)
        {
            double hypotenuse = Math.Sqrt((Math.Pow(point.xPoint, 2) + Math.Pow(point.yPoint, 2)));
            return hypotenuse;
        }
    }
}
