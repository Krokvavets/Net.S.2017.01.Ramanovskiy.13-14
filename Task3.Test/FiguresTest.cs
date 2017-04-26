using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Test
{
    [TestFixture]
    public class FiguresTest
    {
        [TestCase(2,4, 8)]
        [TestCase(1,3, 3)]
        [TestCase(4,4, 16)]
        public void RectangleArea_Positive_Test(double value, double value1, double result)
        {
            IFigure figure = new Rectangle(value, value1);
            Assert.AreEqual(result, figure.CalculateArea());
        }

        [TestCase(2, 4, 12)]
        [TestCase(1, 3, 8)]
        [TestCase(4, 4, 16)]
        public void RectanglePerimeter_Positive_Test(double value, double value1, double result)
        {
            IFigure figure = new Rectangle(value, value1);
            Assert.AreEqual(result, figure.CalculatePerimeter());
        }

        [TestCase(2, 4)]
        [TestCase(1, 1)]
        [TestCase(4, 16)]
        public void SquareArea_Positive_Test(double value, double result)
        {
            IFigure figure = new Square(value);
            Assert.AreEqual(result, figure.CalculateArea());
        }

        [TestCase(2, 8)]
        [TestCase(1, 4)]
        [TestCase(4,16)]
        public void SquarePerimeter_Positive_Test(double value, double result)
        {
            IFigure figure = new Square(value);
            Assert.AreEqual(result, figure.CalculatePerimeter());
        }

        [TestCase(2, 12.566370614359173)]
        [TestCase(1, 3.1415926535897931)]
        [TestCase(4, 50.26548245743669)]
        public void СircleArea_Positive_Test(double value, double result)
        {
            IFigure figure = new Сircle(value);
            Assert.AreEqual(result, figure.CalculateArea());
        }

        [TestCase(2, 12.566370614359173)]
        [TestCase(1, 6.2831853071795862)]
        [TestCase(4, 25.132741228718345)]
        public void СirclePerimeter_Positive_Test(double value, double result)
        {
            IFigure figure = new Сircle(value);
            Assert.AreEqual(result, figure.CalculatePerimeter());
        }

        [TestCase(12, 10, 10, 48)]
        [TestCase(32, 21, 43, 321.99378875996973)]
        [TestCase(12, 12, 12, 62.353829072479584)]
        public void TriangleleArea_Positive_Test(double value, double value1, double value2, double result)
        {
            IFigure figure = new Triangle(value, value1, value2);
            Assert.AreEqual(result, figure.CalculateArea());
        }

        [TestCase(5, 4, 2, 11)]
        [TestCase(12, 10, 10, 32)]
        [TestCase(12, 12, 12, 36)]
        public void TrianglePerimeter_Positive_Test(double value, double value1, double value2, double result)
        {
            IFigure figure = new Triangle(value, value1, value2);
            Assert.AreEqual(result, figure.CalculatePerimeter());
        }
    }
}
