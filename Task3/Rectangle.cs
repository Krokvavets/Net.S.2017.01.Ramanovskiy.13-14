using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Rectangle : IFigure
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double Width {
            get => width;
            private set {
                if (value <= 0) throw new ArgumentException();
                width = value;
            } }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0) throw new ArgumentException();
                height = value;
            }
        }
        public double CalculateArea()
        {
            return Height * Width;
        }

        public double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }
    }
}
