using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CG
{
    public static class Lab2
    {
        public static Point Point1 = new Point();
        public static Point Point2 = new Point();
        public static Point Point3 = new Point();

        public static void getData()
        {

            Console.WriteLine("Enter Origin point.");
            string P1 = Console.ReadLine();

            Console.WriteLine("Enter Reference point.");
            string P2 = Console.ReadLine();

            Console.WriteLine("Enter Point to test.");
            string P3 = Console.ReadLine();

            Point1.x = int.Parse(P1.Split(',')[0]);
            Point1.y = int.Parse(P1.Split(',')[1]);

            Point2.x = int.Parse(P2.Split(',')[0]);
            Point2.y = int.Parse(P2.Split(',')[1]);


            Point3.x = int.Parse(P3.Split(',')[0]);
            Point3.y = int.Parse(P3.Split(',')[1]);

            string turn = turnTest(Point1, Point2, Point3);
            Console.WriteLine("Test point is {0} turn", turn);


        }

        public static string turnTest(Point p, Point q, Point s)
        {
            double area = calculateTriangleArea(p, q, s);
            if (area > 0)
                return "left";

            else if (area < 0)
                return "right";

            else if (area == 0)
                return "collinear";

            else
                return "error";

        }
        //(x1.y2+x2.y3+x3.y1-x2.y1-x3.y2-x1.y3)
        public static double calculateTriangleArea(Point p1, Point p2, Point p3)
        {
            double area = .5 * (p1.x * p2.y
                + p2.x * p3.y + p3.x * p1.y - p2.x * p1.y - p3.x * p2.y - p1.x * p3.y);
            return area;
        }

        public static bool CheckIntersection(Line line1, Line line2)
        {
            bool result = false;
            string[] turn = { "left", "right" };
            string[] pointLineClassification = { "between", "start", "end" };
            string turn1 = turnTest(line1.Point1, line1.Point2, line2.Point1);
            string turn2 = turnTest(line1.Point1, line1.Point2, line2.Point2);

            if (turn1 != turn2 && turn.Contains(turn1) && turn.Contains(turn2))
                result = true;

            if (turn1 == "collinear")
            {
                if (pointLineClassification.Contains(Lab1.PointLineClassification(line1, line2.Point1)))
                    result = true;
            }

            if (turn2 == "collinear")
            {
                if (pointLineClassification.Contains(Lab1.PointLineClassification(line1, line2.Point1)))
                    result = true;
            }

            return result;

        }

    }
}
