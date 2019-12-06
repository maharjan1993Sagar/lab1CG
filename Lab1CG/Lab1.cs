﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CG
{
    public static class Lab1
    {
        public static Line Line1 = new Line();
        public static Point Point3 = new Point();

        public static void getData()
        {
            Line Line1 = new Line();
            Point Point3 = new Point();

            Console.WriteLine("Enter Starting point.");
            string P1 = Console.ReadLine();

            Console.WriteLine("Enter Terminating point.");
            string P2 = Console.ReadLine();

            Console.WriteLine("Enter Point to test.");
            string P3 = Console.ReadLine();

            Line1.Point1.x = int.Parse(P1.Split(',')[0]);
            Line1.Point1.y = int.Parse(P1.Split(',')[1]);

            Line1.Point2.x = int.Parse(P2.Split(',')[0]);
            Line1.Point2.y = int.Parse(P2.Split(',')[1]);


            Point3.x = int.Parse(P3.Split(',')[0]);
            Point3.y = int.Parse(P3.Split(',')[1]);


            string PLC = PointLineClassification(Line1, Point3);
            Console.WriteLine("{0} of Line",PLC);
        }

        public static string PointLineClassification(Line Line1, Point Point3)
        {
            if (Line1.Point2.x == Point3.x && Line1.Point2.y == Point3.y)
                return "end";

            else if (Line1.Point1.x == Point3.x && Line1.Point1.y == Point3.y)
                return "start";

            else if (((Line1.Point1.x < Point3.x && Line1.Point2.x > Point3.x) || (Line1.Point1.y < Point3.y && Line1.Point2.y > Point3.y)))
                return "between";

            else if (Line1.Point1.x > Point3.x && Line1.Point2.y > Point3.y)
                return "behind";

            else if (Line1.Point2.x < Point3.x && Line1.Point2.y < Point3.y)
                return "beyond";

            else
                return "error";
            }
        }
}

