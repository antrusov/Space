using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XnaGeometry;
using System.ComponentModel;
using System.Globalization;

namespace Space
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Kepler
    {

        //базовые параметры
        double a;  //большая полуось (м)
        double b;  //малая полуось (м)
        double m0; //масса притягивающего тела (кг)
        double c;  //фокусное расстояние (м)

        //вычисляемые параметры
        double e;  //эксцентриситет
        double u;  //гравитационный параметр (G*m0)
        double n;  //среднее движение
        double total; //время полного оборота

        public const double G = 0.0000000000667384; //гравитационная постоянная (от 2010 года)
        public const double EPS = 0.0000001; //точность вычисления ексцентрической аномалии численными методами

        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }
        public double Eccentricity { get { return e; } }
        public double M0 { get { return m0; } }
        public double Total { get { return total; } }

        public Kepler(double a, double b, double m0)
        {
            Trace.Assert(a > 0, "Большая полуось должна быть положительной");
            Trace.Assert(b > 0, "Малая полуось должна быть положительной");
            Trace.Assert(m0 > 0, "Масса притягивающего тела должна быть положительной");

            this.a = a;
            this.b = b;
            this.m0 = m0;
            this.c = Math.Sqrt(Math.Abs(a * a - b * b));

            this.e = Math.Sqrt(1 - (this.b * this.b) / (this.a * this.a));
            this.u = G * this.m0;
            this.n = Math.Sqrt(u / this.a * this.a * this.a);
            this.total = 2 * Math.PI / this.n;

        }

        //зная время, получить положение
        public Vector2 Time2Pos(double t)
        {
            Vector2 res = new Vector2(0, 0);

            //добиваемся, чтобы параметр времени был в интервале [0, total]
            t = t % this.total;
            if (t < 0) t += this.total;

            //средняя аномалия
            double M = t * this.n;

            //численное нахождение эксцентрической аномалии
            int i = 10000; //не более 10000 итераций
            double old = -1;
            double E = M;
            while (Math.Abs(E - old) > EPS && i-- > 0)
            {
                old = E;
                E = this.e * Math.Sin(E) + M;
            }

            //Console.WriteLine("t: {0}, i:{1}", t, 10001 - i);
            double sign = (t > total / 2) ? 1 : -1;

            //находим координаты
            res.X = Math.Cos(E) * this.a;
            res.Y = sign * Math.Sqrt((this.b * this.b) * (1 - res.X * res.X / (this.a * this.a)));

            //->
            //расстояние до притягивающего тела
            double r = this.a * (1 - this.e * Math.Cos(E));

            //скорость
            double speed = Math.Sqrt(this.u * (2 / r - 1 / this.a));

            //вектор скорости
            double tmp = this.n * this.a * this.a / r;
            Vector2 vel = new Vector2(
                tmp * (-Math.Sin(E)),
                tmp * (-Math.Sqrt(1 - this.e * this.e) * Math.Cos(E))
            );

            //double Vn = Math.Sqrt(this.u * this.c) / r; //касательная (поперечная) скорость (м/с)
            //double Vr = ; //радиальная скорость (м/с)
            //-<

            return res;
        }

    }
}
