using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private IComparer<T> comparer;
        public T Data { get; private set; }
        public BinarySearchTree<T> Left { get; set; }
        public BinarySearchTree<T> Right { get; set; }
        public BinarySearchTree<T> Parent { get; set; }
        #region ctor
        public BinarySearchTree()
        {
            this.comparer = Comparer<T>.Default;
        }
        public BinarySearchTree(IEnumerable<T> collection)
        {
            this.comparer = Comparer<T>.Default;
            foreach (var item in collection)
                Insert(item);
        }
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            this.comparer = comparer;
            foreach (var item in collection)
                Insert(item);
        }
        #endregion
        #region public methods
        /// <summary>
        ///  The method inserts value into tree
        /// </summary>
        /// <param name="data"> value</param>
        public void Insert(T data)
        {
            if (ReferenceEquals(null, data)) throw new ArgumentException("data");
            int compareResult = comparer.Compare(Data, data);
            if (compareResult == 0 || Equals(Data, default(T)))
            {
                Data = data;
                return;
            }
            if (compareResult > 0)
            {
                if (Left == null) Left = new BinarySearchTree<T>();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinarySearchTree<T>();
                Insert(data, Right, this);
            }
        }

        /// <summary>
        /// The method finds value in tree
        /// </summary>
        /// <param name="data">input value</param>
        /// <returns>Seeking value</returns>
        public BinarySearchTree<T> Find(T data)
        {
            if (ReferenceEquals(null, data)) throw new ArgumentException("data");
            int compareResult = comparer.Compare(Data, data);
            if (compareResult == 0) return this;
            if (compareResult > 0)
            {
                return Find(data, Left);
            }
            return Find(data, Right);
        }
        public BinarySearchTree<T> Find(T data, BinarySearchTree<T> node)
        {
            if (ReferenceEquals(null, node)) return null;
            int compareResult = comparer.Compare(node.Data, data);
            if (compareResult == 0) return node;
            if (compareResult > 0)
            {
                return Find(data, node.Left);
            }
            return Find(data, node.Right);
        }

        /// <summary>
        /// The method removes value from tree
        /// </summary>
        /// <param name="data">input value</param>
        public void Remove(T data)
        {
            var removeNode = Find(data);
            if (removeNode != null)
            {
                Remove(removeNode);
            }
        }
        public void Remove(BinarySearchTree<T> node)
        {
            if (node == null) return;
            if (node.Left == null && node.Right == null)
            {
                if (node.Parent.Left == node) node.Parent.Left = null;
                else node.Parent.Right = null;
                return;
            }
            if (node.Left == null && !ReferenceEquals(null, node.Parent))
            {
                if (node.Parent.Left == node) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
                node.Right.Parent = node.Parent;
                return;
            }
            if (node.Right == null)
            {
                if (node.Parent.Left == node) node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;
                node.Left.Parent = node.Parent;
                return;
            }

            if (node.Parent == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                if (!ReferenceEquals(null, bufLeft))
                    Insert(bufLeft, node, node);
                return;
            }

            if (node == node.Parent.Left)
            {
                node.Parent.Left = node.Right;
            }
            if (node == node.Parent.Right)
            {
                node.Parent.Right = node.Right;
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left, node.Right, node.Right);
            }
        }

        public IEnumerable<T> Preorder()
        {
            BinarySearchTree<T> node = this;
            yield return this.Data;
            while (true)
            {
                if (!ReferenceEquals(null, node.Left))
                {
                    node = node.Left;
                    yield return node.Data;
                }
                else if (!ReferenceEquals(null, node.Right))
                {
                    node = node.Right;
                    yield return node.Data;
                }
                else
                {
                    if (node.Parent == null) yield break;
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        node.Left = null;
                    }
                    else
                    {
                        node = node.Parent;
                        node.Right = null;
                    }
                }

            }

        }

        public IEnumerable<T> Inorder()
        {
            BinarySearchTree<T> lastNode = null;
            BinarySearchTree<T> node = this;
            while (node != null)
            {
                if (lastNode == node.Parent)
                {
                    if (node.Left != null)
                    {
                        lastNode = node;
                        node = node.Left;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if (lastNode == node.Left)
                {
                    yield return node.Data;

                    if (node.Right != null)
                    {
                        lastNode = node;
                        node = node.Right;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if (lastNode == node.Right)
                {
                    lastNode = node;
                    node = node.Parent;
                }
            }
        }

        public IEnumerable<T> Postorder()
        {
            BinarySearchTree<T> node = this;
            while (true)
            {
                if (!ReferenceEquals(null, node.Left))
                {
                    node = node.Left;
                }
                else if (!ReferenceEquals(null, node.Right))
                {
                    node = node.Right;
                }
                else
                {
                    yield return node.Data;
                    if (node.Parent == null) yield break;
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        node.Left = null;
                    }
                    else
                    {
                        node = node.Parent;
                        node.Right = null;
                    }
                }

            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }
        #endregion
        #region prvate methods
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Insert(T data, BinarySearchTree<T> node, BinarySearchTree<T> parent)
        {
            int compareResult = comparer.Compare(node.Data, data);
            if (compareResult == 0 || Equals(node.Data, default(T)))
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }

            if (compareResult > 0)
            {
                if (node.Left == null) node.Left = new BinarySearchTree<T>();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinarySearchTree<T>();
                Insert(data, node.Right, node);
            }

        }
        /// <summary>
        ///  The method inserts node into tree
        /// </summary>
        /// <param name="data">node</param>
        private void Insert(BinarySearchTree<T> data, BinarySearchTree<T> node, BinarySearchTree<T> parent)
        {
            int compareResult = comparer.Compare(node.Data, data.Data);
            if (node.Data.Equals(default(T)) || compareResult == 0)
            {
                node.Data = data.Data;
                node.Left = data.Left;
                node.Right = data.Right;
                node.Parent = parent;
                return;
            }
            if (compareResult > 0)
            {
                if (node.Left == null) node.Left = new BinarySearchTree<T>();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinarySearchTree<T>();
                Insert(data, node.Right, node);
            }
        }
        #endregion
    }
}