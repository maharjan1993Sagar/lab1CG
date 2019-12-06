using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CG
{
    //https://www.c-sharpcorner.com/article/linked-list-implementation-in-c-sharp/
    public class Vertex
    {
        public Point Point;
        public Point Next;
        public Point Prev;

        public Vertex(Point p)
        {
            Point = p;
            Next = null;
            Prev = null;
        }
    }
}
