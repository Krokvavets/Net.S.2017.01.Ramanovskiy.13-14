using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Matrix<T>
    {
        private T[,] array;
        public event EventHandler<NewMatrixEventArgs> Eevent = delegate { };
        public int Rows { get; protected set; }
        public int Cols { get; protected set; }
        #region ctor
        public Matrix(int rows, int cols)
        {
            if (!Validation(rows, cols)) throw new ArgumentException();
            Rows = rows;
            Cols = cols;
            array = new T[Rows, Cols];
        }
        public Matrix(T[,] array)
        {
            if (ReferenceEquals(null, array)) throw new ArgumentNullException("array");
            this.array = array;
        }
        public Matrix(int rows, int cols, T[] array)
        {
            if (!Validation(rows, cols)) throw new ArgumentException();
            Rows = rows;
            Cols = cols;
            if (array.Length / Cols != Rows) throw new ArgumentException("array");
            this.array = new T[Rows, Cols];
            int n = 0, m = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (m == Cols)
                {
                    m = 0;
                    n++;
                }
                this.array[n, m] = array[i];
                m++;
            }
        }
        #endregion
        public T this[int index1, int index2]
        {
            get => array[index1, index2];
            set
            {
                OnNewEvent(new NewMatrixEventArgs(index1, index2));
                array[index1, index2] = value;
            }
        }
        private bool Validation(int rows, int cols) => rows == cols && cols >= 0;
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
        public override int GetHashCode()
        {
            return Cols ^ Rows;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj is Matrix<T>) return Equals((Matrix<T>)obj);
            return false;
        }
        public bool Equals(Matrix<T> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(obj, this)) return true;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (!obj[i, j].Equals(this[i, j]))
                        return false;
            return true;
        }
        protected virtual void OnNewEvent(NewMatrixEventArgs e)
        {
            EventHandler<NewMatrixEventArgs> temp = Eevent;
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
}
