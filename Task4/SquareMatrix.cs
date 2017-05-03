using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public event EventHandler<NewMatrixEventArgs> Eevent = delegate { };
        private T[,] array;
        #region ctor
        public SquareMatrix(int n) : base(n)
        {
            array = new T[Rows, Cols];
        }
        public SquareMatrix(T[,] array) : base(array)
        {
            ;
            this.array = array;
        }
        public SquareMatrix(int n, T[] array) : base(n, array)
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
        protected virtual void OnNewEvent(NewMatrixEventArgs e)
        {
            EventHandler<NewMatrixEventArgs> temp = Eevent;
        }

        public override int GetHashCode()
        {
            return Cols ^ Rows;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj is SquareMatrix<T>) return Equals((SquareMatrix<T>)obj);
            return false;
        }
        public bool Equals(SquareMatrix<T> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(obj, this)) return true;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (!obj[i, j].Equals(this[i, j]))
                        return false;
            return true;
        }
    }
}
