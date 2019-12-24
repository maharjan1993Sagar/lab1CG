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
            while (true)
            {
                Polygon polygon = new Polygon();
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
                {
                    Console.WriteLine("\n\n Given polygon is Convex.\n\n");


                    if (CheckPointInclusion(polygon, InclusionPoint))
                        Console.WriteLine("\n\nTest Inclusion Point is inside the polygon.\n\n");
                    else
                        Console.WriteLine("\n\nTest Inclusion Point is outside the polygon.\n\n");
                }
                else
                    Console.WriteLine("\n\nPolygon is not convex.\n\n");


                if (RayCasting(polygon, RayCastingPoint) % 2 == 1)
                    Console.WriteLine("\n\n Ray Casting:Point is inside the polygon\n\n");
                else
                    Console.WriteLine("\n\n Ray Casting:Point is outside the polygon\n\n");

                Console.ReadKey();
            }
        
}

        public static bool CheckConvex(Polygon p)
        {
            bool result = true;
            foreach (Point point in p.Vertex)
            {
                var nextPoint = p.Vertex.Find(point).Next;
                if (nextPoint !=null)
                {
                    if (point == p.Vertex.Find(p.Vertex.Last()).Previous.Value)
                    {
                        string turn = Lab2.turnTest(point, p.Vertex.Last(), p.Vertex.First());
                        if (turn != "left")
                        {
                            result = false;
                            break;
                        }
                    }
                    else
                    {
                        string turn = Lab2.turnTest(point, p.Vertex.Find(point).Next.Value, p.Vertex.Find(point).Next.Next.Value);
                        if (turn != "left")
                        {
                            result = false;
                            break;
                        }
                    }
                    
                }
                else
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
            Point maxPoint = new Point { x = 2000+point.x, y = 1000+point.y };
            Line line1 = new Line { Point1 = point, Point2 = maxPoint };
            Line line2 = new Line();
            string[] intersections = { "Proper", "Improper" };
            foreach (Point p in polygon.Vertex)
            {
                if (polygon.Vertex.Find(p).Next != null)
                {
                    line2.Point1 = p;
                    line2.Point2 = polygon.Vertex.Find(p).Next.Value;
                   
                }
                else
                {
                    line2.Point1 = p;
                    line2.Point2 = polygon.Vertex.First();
                  
                }
                if (!String.IsNullOrEmpty(Lab2.CheckIntersection(line1, line2))&&!String.IsNullOrEmpty(Lab2.CheckIntersection(line2,line1)))
                    count++;

            }

            return count;
        }



    }
}
