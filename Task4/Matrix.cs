using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public abstract class Matrix<T>
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
    }
    #endregion
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


