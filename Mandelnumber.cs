using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    // Calculate the Mandelnumber for each point (with formula from tutorial)
    public class Mandelnumber
    {
        public double a;
        public double b;

        public Mandelnumber(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        //Square AB
        public void Square()
        {
            double temp = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = temp;
        }

        public double Distance()
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        public void Add(Mandelnumber c)
        {
            a += c.a;
            b += c.b;
        }

    }
}
