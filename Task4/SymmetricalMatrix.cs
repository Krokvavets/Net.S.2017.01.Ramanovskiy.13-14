using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricalMatrix<T> : Matrix<T>
    {
        public SymmetricalMatrix(int rows, int cols) : base(rows, cols)
        {
            if (!this.Equals(Transpose(this)) || rows != cols) throw new ArgumentException();
        }
        public SymmetricalMatrix(int rows, int cols, T[] array) : base(rows, cols, array)
        {
            if (!this.Equals(Transpose(this)) || rows != cols) throw new ArgumentException();
        }

        public SymmetricalMatrix(T[,] array) : base(array)
        {
            if (!this.Equals(Transpose(this)) || this.Rows != this.Cols) throw new ArgumentException();
        }

        private Matrix<T> Transpose(Matrix<T> matrix)
        {
            Matrix<T> tMatrix = new Matrix<T>(matrix.Rows, matrix.Cols);
            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Cols; j++)
                    tMatrix[j, i] = this[i, j];
            return tMatrix;
        }

    }
}
