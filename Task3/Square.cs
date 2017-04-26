using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Square : IFigure
    {
        private double side;
        public Square(double side)
        {
            Side = side;
        }
        public double Side
        {
            get => side;
            private set
            {
                if (value <= 0) throw new ArgumentException();
                side = value;
            }
        }
        public double CalculateArea()
        {
            return Side * Side;
        }

        public double CalculatePerimeter()
        {
            return 4 * Side;
        }
    }
}
