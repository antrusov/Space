using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XnaGeometry;

namespace Space
{
    class Program
    {
        const double A = 227943820000;
        const double E = 0.0933941;        
        const double M = 1.9891E30;

        public static void Print(Vector2 pt)
        {
            Console.WriteLine("x:{0:0.0000000}, y:{1:0.0000000}", pt.X, pt.Y);
        }

        static void Main(string[] args)
        {
            double B = A * Math.Sqrt(1 - E * E);
            Kepler orbit = new Kepler(A, B, M);

            Console.WriteLine(orbit.Total / 60 / 60 / 24 / 365);

            for (int i = 0; i < orbit.Total; i+=100)
                Print(orbit.Time2Pos(i));

            Console.ReadKey(true);
        }
    }
}
