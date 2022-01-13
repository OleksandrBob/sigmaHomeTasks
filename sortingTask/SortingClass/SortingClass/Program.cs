using System;

namespace SortingClass
{
    class Point2D
    {
        public int X { get; set; }
        public double Y { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = new Point2D[5];

            inputArray[0] = new Point2D() { X = 2, Y = 7 };
            inputArray[1] = new Point2D() { X = 1, Y = 4 };
            inputArray[2] = new Point2D() { X = 5, Y = 8 };
            inputArray[3] = new Point2D() { X = 3, Y = 3 };
            inputArray[4] = new Point2D() { X = 0, Y = 22 };

            UniversalSort.Sort<Point2D>(inputArray, "Y", 0, inputArray.Length - 1, false);            
        }
    }
}
