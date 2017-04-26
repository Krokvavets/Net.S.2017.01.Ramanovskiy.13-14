using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Сircle : IFigure
    {
        private double radius;

        public Сircle(double radius)
        {
            Radius = radius;
        }
        public double Radius
        {
            get => radius;
            private set
            {
                if (value <= 0) throw new ArgumentException();
                radius = value;
            }
        }
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double CalculatePerimeter()
        {
            return Math.PI * 2* Radius;
        }
    }
}
