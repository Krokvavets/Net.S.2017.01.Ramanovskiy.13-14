using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public abstract class Matrix<T> :IEnumerable<T>, IEnumerable
    {
        public int Rows { get; protected set; }
        public int Cols { get; protected set; }

        #region ctor
        public Matrix(int n)
        {
            if (n < 0) throw new ArgumentException(nameof(n));
            Rows = Cols = n;
        }
        public Matrix(T[,] array)
        {
            if (ReferenceEquals(null, array)) throw new ArgumentNullException("array");
        }
        public Matrix(int n, T[] array)
        {
            if (n < 0) throw new ArgumentException();
            Rows = Cols = n;
            if (array.Length / Cols != Rows) throw new ArgumentException("array");
        }
        public abstract T this[int index1, int index2] { get; set; }
        #endregion

        public Matrix<T> Operation(Matrix<T> rhs, IOperation<T> operation)
        {
            if (ReferenceEquals(null, operation) || ReferenceEquals(null, rhs)) throw new ArgumentNullException();
            Matrix<T> result = operation.Calculate(this, rhs);
            result = ToSymmetrical(result);
            result = ToDiagonal(result);
            return result;
        }
        /// <summary>
        /// Convert matrix to Diagonal matrix
        /// </summary>
        /// <param name="matrix">input matrix</param>
        /// <returns> Diagonal or input matrix</returns>
        private Matrix<T> ToDiagonal(Matrix<T> matrix)
        {
            DiagonalMatrix<T> diogM = new DiagonalMatrix<T>(matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    if(i != j)
                        if ( matrix[i, j].Equals(default(T)))
                            diogM[i, j] = matrix[i, j];
                        else
                            return matrix;
            return diogM;
        }
        /// <summary>
        /// Convert matrex to Symmetrical matrix
        /// </summary>
        /// <param name="matrix">input matrix</param>
        /// <returns>Symmetrical or input matrix</returns>
        private Matrix<T> ToSymmetrical(Matrix<T> matrix)
        {
            SymmetricalMatrix<T> SymM = new SymmetricalMatrix<T>(matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    if (matrix[i,j].Equals(matrix[j,i]))
                        SymM[i, j] = matrix[i, j];
                    else
                        return matrix;
            return SymM;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    yield return this[i, j];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }    


    public sealed class NewMatrixEventArgs : EventArgs
    {
        private readonly int i;
        private readonly int j;

        public NewMatrixEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
        public int I => i;
        public int J => j;

    }

}


