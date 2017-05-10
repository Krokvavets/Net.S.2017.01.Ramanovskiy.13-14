using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class AddOperation<T> : IOperation<T>
    {
        private Func<T, T, T> add;

        AddOperation(Func<T,T,T> add)
        {
            this.add = add;
        }
        
        public Matrix<T> Calculate(Matrix<T> lhs, Matrix<T> rhs)
        {
            if (ReferenceEquals(null, lhs) || ReferenceEquals(null, rhs)) throw new ArgumentNullException();
            if (lhs.Rows != rhs.Rows) throw new ArgumentException();
            SquareMatrix < T > newMatrix = new SquareMatrix<T>(lhs.Rows);
            for (int i = 0; i < lhs.Rows; i++)
                for (int j = 0; j < lhs.Cols; j++)
                    newMatrix[i, j] = add(lhs[i, j], rhs[i, j]);
            return newMatrix;            
        }
    }
}
