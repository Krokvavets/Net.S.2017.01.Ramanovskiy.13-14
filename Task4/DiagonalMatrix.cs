using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public new event EventHandler<NewMatrixEventArgs> Eevent = delegate { };
        private T[] diagonal;
        public DiagonalMatrix(int n) : base(n)
        {
            diagonal = new T[Rows];
        }
        public DiagonalMatrix(int n, T[] array) : base(n, array)
        {
            int j = 0;
            diagonal = new T[Rows];
            for (int i = 0; i < n; i++)
            {
                diagonal[i] = array[j];
                j += n + 1;
            }


        }
        public DiagonalMatrix(T[,] array) : base(array)
        {
            diagonal = new T[Rows];
            for (int i = 0; i < Rows; i++)
                diagonal[i] = array[i, i];
        }
        public override T this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index2 < 0) throw new ArgumentOutOfRangeException();
                if (index1 != index2) return default(T);
                return diagonal[index1];
            }
            set
            {
                if (index1 < 0 || index2 < 0) throw new ArgumentOutOfRangeException();
                if (index1 != index2) throw new ArgumentException("You can't change value not owned the main diagonal");
                diagonal[index1] = value;
                OnNewEvent(new NewMatrixEventArgs(index1, index2));
            }

        }

        public override string ToString()
        {
            StringBuilder matrix = new StringBuilder();
            for (int i = 0; i < Cols; i++)
            {
                matrix.Append("{ ");
                for (int j = 0; j < Rows; j++)
                {
                    if (i == j)
                        matrix.Append(diagonal[i] + ", ");
                    else
                        matrix.Append(default(T) + ", ");
                }

                matrix.Append(" } ");
            }
            matrix.Replace("{  } ", "");
            matrix.Replace(",  } ", " } ");
            return matrix.ToString();
        }
    }
}
