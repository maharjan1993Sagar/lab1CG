using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CG
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Point Point3 = new Point();
                Line Line1 = new Line();
                string P1 = "", P2 = "", P3 = "";
                getData();
                PointLineClassification(Line1.Point1, Line1.Point2, Point3);

                void getData()
                {

                    Console.WriteLine("Enter Starting point.");
                    P1 = Console.ReadLine();

                    Console.WriteLine("Enter Terminating point.");
                    P2 = Console.ReadLine();

                    Console.WriteLine("Enter Point to test.");
                    P3 = Console.ReadLine();

                    Line1.Point1.x = int.Parse(P1.Split(',')[0]);
                    Line1.Point1.y = int.Parse(P1.Split(',')[1]);

                    Line1.Point2.x = int.Parse(P2.Split(',')[0]);
                    Line1.Point2.y = int.Parse(P2.Split(',')[1]);


                    Point3.x = int.Parse(P3.Split(',')[0]);
                    Point3.y = int.Parse(P3.Split(',')[1]);
                }


                //Ex: (2,4) (4,6) (6,8)
                void PointLineClassification(Point p, Point q, Point s)
                {
                    if (q.x == s.x && q.y == s.y)
                        Console.WriteLine("Point is Ending Point");

                    else if (p.x == s.x && p.y == s.y)
                        Console.WriteLine("Point is Starting Point");

                    else if (((p.x < s.x && q.x > s.x) || (p.y < s.y && q.y > s.y)) && checkCollinear(p, q, s))                        
                        Console.WriteLine("Point is between.");

                    else if ((p.x > s.x && p.y > s.y) && checkCollinear(p, q, s))
                        Console.WriteLine("Point is behind.");

                    else if ((q.x < s.x && q.y < s.y) && checkCollinear(p, q, s))
                        Console.WriteLine("Point is beyond");

                    else
                        Console.WriteLine("Please Try again.");

                }

              bool checkCollinear(Point p, Point q, Point s)
                {
                    float slope1 =(float) (q.y-p.y) / (q.x-p.x);
                    float slope2 = (float)(q.y-s.y) / (q.x-s.x);

                    bool status = (Math.Abs(slope1) == Math.Abs(slope2));
                    return status;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }


        }
    }
}
