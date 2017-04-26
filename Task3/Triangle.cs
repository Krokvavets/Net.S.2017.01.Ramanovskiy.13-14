using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Triangle : IFigure
    {
        private double ab;
        private double bc;
        private double ca;

         public Triangle(double ab, double bc, double ca)
        {
            AB = ab;
            BC = bc;
            CA = ca;
            if(!((AB + BC) > CA && (AB + CA)> BC && (BC + CA )>AB)) throw new ArgumentException();
        }
        public double AB
        {
            get => ab;
            private set
            {
                if (value <= 0) throw new ArgumentException();
                ab = value;
            }
        }
        public double BC
        {
            get => bc;
            private set
            {
                if (value <= 0) throw new ArgumentException();
                bc = value;
            }
        }
        public double CA
        {
            get => ca;
            private set
            {
                if (value <= 0) throw new ArgumentException();
                ca = value;
            }
        }
        public double CalculateArea()
        {
            double p = CalculatePerimeter() / 2;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
        }

        public double CalculatePerimeter()
        {
            return AB + BC + CA;
        }
    }
}
