using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(int rows, int cols) : base(rows, cols)
        {
            MatrixChecker();
        }
        public DiagonalMatrix(int rows, int cols, T[] array) : base(rows, cols, array)
        {
            MatrixChecker();
        }
        public DiagonalMatrix(T[,] array) : base(array)
        {
            MatrixChecker();
        }

        private void MatrixChecker()
        {
            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Cols; j++)
                    if (j != i && !this[i, j].Equals(default(T))) throw new ArgumentException();
        }
    }
}
