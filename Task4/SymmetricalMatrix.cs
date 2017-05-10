using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        private T[][] triangle;
        #region ctor
        public SymmetricalMatrix(int n) : base(n)
        {
            triangle = new T[Rows][];
        }
        public SymmetricalMatrix(T[,] array) : base(array)
        {
            triangle = new T[Rows][];
            T[] temp = new T[Rows];
            int n;
            for (int i = 0; i < Rows; i++)
            {
                n = 0;
                for (int j = i; i < Rows; j++)
                {
                    temp = new T[Rows - i];
                    temp[n] = array[i, j];
                    n++;
                }
                triangle[i] = new T[temp.Length];
                Array.Copy(temp, triangle[i], temp.Length);
            }
                
        }
        public SymmetricalMatrix(int n, T[] array) : base(n, array)
        {
            T [,] inarray = new T[Rows, Cols];
            int cols = 0, rows = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (rows == Cols)
                {
                    rows = 0;
                    cols++;
                }
                inarray[cols, rows] = array[i];
                rows++;
            }
            triangle = new T[Rows][];
            T[] temp = new T[Rows];
            int k;
            for (int i = 0; i < Rows; i++)
            {
                k = 0;
                for (int j = i; i < Rows; j++)
                {
                    temp = new T[Rows - i];
                    temp[k] = inarray[i, j];
                    k++;
                }
                triangle[i] = new T[temp.Length];
                Array.Copy(temp, triangle[i], temp.Length);
            }

            if (!Equals(Transpose(this))) throw new ArgumentException();
        }
        #endregion
        public override T this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index2 < 0 || index1 > Rows || index2 > Rows) throw new ArgumentOutOfRangeException();
                if (triangle[index1].Length < index2)
                    return triangle[index2][index1];
                return triangle[index2][index1];
            }
            set
            {
                if (index1 < 0 || index2 < 0 || index1 > Rows || index2 > Rows) throw new ArgumentOutOfRangeException();
                if (triangle[index1].Length < index2)
                    triangle[index2][index1] = value;
                triangle[index1][index2] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder matrix = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                matrix.Append("{ ");
                for (int j = 0; j < Cols; j++)
                    matrix.Append(this[i, j] + ", ");
                matrix.Append(" } ");
            }
            matrix.Replace("{  } ", "");
            matrix.Replace(",  } ", " } ");
            return matrix.ToString();
        }


        /// <summary>
        /// / The method Transposes the matrix
        /// </summary>
        /// <param name="matrix">input matrix</param>
        /// <returns>Transpose matrix</returns>
        private SquareMatrix<T> Transpose(Matrix<T> matrix)
        {
            SquareMatrix<T> tMatrix = new SquareMatrix<T>(matrix.Rows);
            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Cols; j++)
                    tMatrix[j, i] = this[i, j];
            return tMatrix;
        }

    }
}
