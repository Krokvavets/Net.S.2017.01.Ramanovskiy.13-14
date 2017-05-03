﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        private T[,] array;
        #region ctor
        public SymmetricalMatrix(int n) : base(n)
        {
            array = new T[Rows, Cols];
        }
        public SymmetricalMatrix(T[,] array) : base(array)
        {
            this.array = array;
            if (!Equals(Transpose(this))) throw new ArgumentException();
        }
        public SymmetricalMatrix(int n, T[] array) : base(n, array)
        {
            this.array = new T[Rows, Cols];
            int cols = 0, rows = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (rows == Cols)
                {
                    rows = 0;
                    cols++;
                }
                this.array[cols, rows] = array[i];
                rows++;
            }
            if (!Equals(Transpose(this))) throw new ArgumentException();
        }
        #endregion
        public override T this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index2 < 0) throw new ArgumentOutOfRangeException();
                return array[index1, index2];
            }
            set
            {
                if (index1 < 0 || index2 < 0) throw new ArgumentOutOfRangeException();
                array[index1, index2] = value;
                if (!Equals(Transpose(this))) throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            StringBuilder matrix = new StringBuilder();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                matrix.Append("{ ");
                for (int j = 0; j < array.GetLength(1); j++)
                    matrix.Append(array[i, j] + ", ");
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
