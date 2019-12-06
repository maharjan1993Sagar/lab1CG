using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CG
{
   public static class Lab3
    {
       
        

        public static void getData()
        {
            Polygon polygon=new Polygon();
            Console.WriteLine("Enter no of vertices in polygon.");
            int N = int.Parse(Console.ReadLine());

            //Point[] points = new Point[N];

            for (int i = 0; i < N; i++)
            {
                Point p = new Point();

                Console.WriteLine("Enter Point of Polygon.");
                string point = Console.ReadLine();

                p.x = int.Parse(point.Split(',')[0]);
                p.y = int.Parse(point.Split(',')[1]);

               
                //if (i == 0)
                //{
                //    Polygon.Vertex.AddFirst(p); 
                //}
                //else
                //{
                    polygon.Vertex.AddLast(p);
               // }
            }



            Console.WriteLine("Enter Point for Inclusion Test.");
            string IncPoint = Console.ReadLine();

            Console.WriteLine("Enter Point for Ray Casting.");
            string RayPoint = Console.ReadLine();

            Point InclusionPoint = new Point();
            Point RayCastingPoint = new Point();

            InclusionPoint.x = int.Parse(IncPoint.Split(',')[0]);
            InclusionPoint.y = int.Parse(IncPoint.Split(',')[1]);

            RayCastingPoint.x = int.Parse(RayPoint.Split(',')[0]);
            RayCastingPoint.y = int.Parse(RayPoint.Split(',')[1]);


            if (CheckConvex(polygon))
                if (CheckPointInclusion(polygon, InclusionPoint))
                    Console.WriteLine("Test Inclusion Point is inside the polygon.");
                else
                    Console.WriteLine("Test Inclusion Point is outside the polygon.");

            if (RayCasting(polygon, RayCastingPoint) % 2 == 1)
                Console.WriteLine("Ray Casting:Point is inside the polygon");
            else
                Console.WriteLine("Ray Casting:Point is outside the polygon");
        }

        public static bool CheckConvex(Polygon p)
        {
            bool result = true;
            foreach (Point point in p.Vertex)
            {
                if (p.Vertex.Find(point).Next.Next.Value != p.Vertex.Last())
                {
                    string turn = Lab2.turnTest(point, p.Vertex.Find(point).Next.Value, p.Vertex.Find(point).Next.Next.Value);
                    if (turn != "left")
                    {
                        result = false;
                        break;
                    }
                }
                else if (point != p.Vertex.Last())
                {
                    string turn = Lab2.turnTest(point, p.Vertex.Find(point).Next.Value, p.Vertex.First());
                    if (turn != "left")
                    {
                        result = false;
                        break;
                    }
                }
                else if(point==p.Vertex.Last())
                {
                    string turn = Lab2.turnTest(p.Vertex.Last(), p.Vertex.First(),p.Vertex.Find(p.Vertex.First()).Next.Value);
                    if (turn != "left")
                    {
                        result = false;
                    }
                    break;

                }

            }

            return result;
        }

        public static bool CheckPointInclusion(Polygon polygon, Point point)
        {
            bool result = true;

            foreach (Point p in polygon.Vertex)
            {
                if (p != polygon.Vertex.Last())
                {
                    string turn = Lab2.turnTest(point, p, polygon.Vertex.Find(p).Next.Value);
                    if (turn != "left")
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    string turn = Lab2.turnTest(point, p, polygon.Vertex.First());
                    if (turn != "left")
                    {
                        result = false;
                    }
                }
               
            }

            return result;
        }

        public static int RayCasting(Polygon polygon, Point point)
        {
            int count = 0;
            Point maxPoint = new Point { x = 600, y = 800 };
            Line line1 = new Line { Point1 = point, Point2 = maxPoint };
            Line line2 = new Line();

            foreach (Point p in polygon.Vertex)
            {
                if (polygon.Vertex.Find(p).Next.Value != null)
                {
                    line2.Point1 = p;
                    line2.Point2 = polygon.Vertex.Find(p).Next.Value;
                   
                }
                else
                {
                    line2.Point1 = p;
                    line2.Point2 = polygon.Vertex.First();
                  
                }
                if (Lab2.CheckIntersection(line1, line2))
                    count++;

            }

            return count;
        }



    }
}
