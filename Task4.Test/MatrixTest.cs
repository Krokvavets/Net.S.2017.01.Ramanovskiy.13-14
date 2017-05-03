using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Test
{
    [TestFixture]
    public class MatrixTest
    {
        
        [Test]
        public void SymmetricalMatrix_Positive_Test()
        {
            SymmetricalMatrix<int> matrix = new SymmetricalMatrix<int>(3,  new int[] { 1, 2, 3, 2, 3, 4, 3, 4, 5 });
            Assert.AreEqual("{ 1, 2, 3 } { 2, 3, 4 } { 3, 4, 5 } ", matrix.ToString());
        }
        [Test]
        public void SymmetricalMatrix_ThrowsArgumentException()
        {            
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<int>(3, new int[] { 1, 2, 3, 2, 3, 4 }));
        }
        [Test]
        public void DiagonalMatrix_Positive_Test()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(3, new int[] { 1, 0, 0, 0, 3, 0, 0, 0, 3 });
            Assert.AreEqual("{ 1, 0, 0 } { 0, 3, 0 } { 0, 0, 3 } ", matrix.ToString());
        }
        [Test]
        public void DiagonalMatrix_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(2, new int[] { 1, 2, 3, 2, 3, 4, 3, 4, 5 }));
        }
    }
}
