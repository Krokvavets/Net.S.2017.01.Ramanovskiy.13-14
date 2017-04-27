using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5;

namespace Task5.Test
{
    [TestFixture]
    public class TreeTest
    {
        [Test]
        public void IntTreeStn_Positive_Test()
        {
            BinarySearchTree<int> bin = new BinarySearchTree<int>(new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 });
            bin.Remove(14);
            string str = String.Empty;
            foreach (var i in bin)
                str += i + ", ";
            Assert.AreEqual("8, 3, 1, 6, 4, 7, 10, 13, ", str);
        }
        [Test]
        public void IntTreeCust_Positive_Test()
        {

            BinarySearchTree<int> bin = new BinarySearchTree<int>(new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 }, new CustmComp());
            bin.Remove(14);
            string str = String.Empty;
            foreach (var i in bin)
                str += i + ", ";
            Assert.AreEqual("8, 10, 13, 3, 6, 7, 4, 1, ", str);
        }
        private class CustmComp : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x > y)
                    return -1;
                if (x < y)
                    return 1;
                return 0;
            }
        }
        [Test]
        public void StringTreeStn_Positive_Test()
        {
            BinarySearchTree<string> bin = new BinarySearchTree<string>(new string[] { "a", "b", "c", "d", "e", "x", "d", "z", "c" });
            bin.Remove("14");
            string str = String.Empty;
            foreach (var i in bin)
                str += i ;
            Assert.AreEqual("abcdexz", str);
        }
        [Test]
        public void StrTreeCust_Positive_Test()
        {

            BinarySearchTree<string> bin = new BinarySearchTree<string>(new string[] { "8", "3", "10", "1", "6", "4", "7", "14", "13" }, new CustmSTRComp());
            bin.Remove("14");
            string str = String.Empty;
            foreach (var i in bin)
                str += i + ", ";
            Assert.AreEqual("8, 10, 13, 3, 6, 7, 4, 1, ", str);
        }
        private class CustmSTRComp : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x == null && y == null)
                    return 0;
                if (x == null)
                    return 1;
                if (y == null)
                    return -1;
                CustmComp cs = new CustmComp();
                return cs.Compare(int.Parse(x), int.Parse(y));                
            }
        }

        [Test]
        public void BookTreeStn_Positive_Test()
        {
            BinarySearchTree<Book> bin = new BinarySearchTree<Book>(new Book());
            bin.Insert(new Book("a", 8));
            bin.Insert(new Book("b", 3));
            bin.Insert(new Book("c", 10));
            bin.Insert(new Book("d", 1));
            bin.Insert(new Book("e", 6));
            bin.Insert(new Book("x", 4));
            bin.Insert(new Book("g", 7));
            bin.Insert(new Book("z", 14));
            bin.Insert(new Book("s", 13));
            string str = String.Empty;
            foreach (var i in bin)
                str += i.Cost + ", ";
            Assert.AreEqual("8, 3, 1, 6, 4, 7, 10, 14, 13, ", str);
        }
        [Test]
        public void BookTreeCust_Positive_Test()
        {

            BinarySearchTree<Book> bin = new BinarySearchTree<Book>(new BookCustmComp());
            bin.Insert(new Book("a", 8));
            bin.Insert(new Book("b", 3));
            bin.Insert(new Book("c", 10));
            bin.Insert(new Book("d", 1));
            bin.Insert(new Book("e", 6));
            bin.Insert(new Book("x", 4));
            bin.Insert(new Book("g", 7));
            bin.Insert(new Book("z", 14));
            bin.Insert(new Book("s", 13));
            string str = String.Empty;
            foreach (var i in bin)
                str += i.Cost + ", ";
            Assert.AreEqual("8, 10, 14, 13, 3, 6, 7, 4, 1, ", str);
        }
        private class Book : IComparer<Book>
        {
            public string Name { get; set; }
            public int Cost { get; set; }
            public Book() { }
            public Book(string name, int cost)
            {
                Name = name;
                Cost = cost;
            }

            public int Compare(Book x, Book y)
            {
                if (x == null && y == null)
                    return 0;
                if (x == null || x.Cost < y.Cost)
                    return -1;
                if (y == null || x.Cost > y.Cost)
                    return 1;
                return 0;
            }
        }
        private class BookCustmComp : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                if (x == null && y == null)
                    return 0;
                if (x == null )
                    return 1;
                if (y == null)
                    return -1;
                CustmComp cs = new CustmComp();
                return cs.Compare(x.Cost, y.Cost);
            }
        }
        [Test]
        public void PointTreeCust_Positive_Test()
        {

            BinarySearchTree<Point> bin = new BinarySearchTree<Point>(new PointCustmComp());
            bin.Insert(new Point(1, 8));
            bin.Insert(new Point(1, 3));
            bin.Insert(new Point(1, 10));
            bin.Insert(new Point(1, 1));
            bin.Insert(new Point(1, 6));
            bin.Insert(new Point(1, 4));
            bin.Insert(new Point(1, 7));
            bin.Insert(new Point(1, 14));
            bin.Insert(new Point(1, 13));
            string str = String.Empty;
            foreach (var i in bin)
                str += i.Y + ", ";
            Assert.AreEqual("8, 10, 14, 13, 3, 6, 7, 4, 1, ", str);
        }
        private struct Point 
        {
            public int X;
            public int Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        private class PointCustmComp : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                if (x.X == 0 && x.Y == 0 && y.X == 0 && y.Y == 0)
                    return 0;
                if (x.X == 0 && x.Y == 0)
                    return 1;
                if (y.X == 0 && y.Y == 0)
                    return -1;
                CustmComp cs = new CustmComp();
                return cs.Compare(x.Y, y.Y);
            }
        }
    }
}
