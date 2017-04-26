using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Test
{
    [TestFixture]
    public class SetTest
    {
        [TestCase("1, 2, 3, 5, 8, 4, ", "0", "1", "1", "2", "3","5", "8")]
        [TestCase("1, 12, 4, 55, 33, 53, 8, 5, ", "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [Test]
        public void SetAdd_Positive_Test(string result, params string [] array )
        {
            Set<string> set = new Set<string>(array);
            set.Add("4");
            set.Add("5");
            set.Remove("0");
            string str = String.Empty;
            foreach (var item in set)
                str += item +", ";
            Assert.AreEqual(result, str);
        }

        [TestCase("2, 3, 5, ", "0", "1", "1", "2", "3", "5", "8", "53")]
        [TestCase("", "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [Test]
        public void ExceptWith_Positive_Test(string result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8" };
            set.ExceptWith(ar);
            string str = String.Empty;
            foreach (var item in set)
                str += item + ", ";
            Assert.AreEqual(result, str);
        }

        [TestCase("0, 1, 8, 53, ", "0", "1", "1", "2", "3", "5", "8", "53")]
        [TestCase("0, 1, 12, 4, 55, 33, 53, 8, ", "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [Test]
        public void IntersectWith_Positive_Test(string result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8" };
            set.IntersectWith(ar);
            string str = String.Empty;
            foreach (var item in set)
                str += item + ", ";
            Assert.AreEqual(result, str);
        }

        [TestCase(false, "2", "3", "5", "8", "53")]
        [TestCase(false, "0", "1", "12", "4", "55", "12", "33", "53", "8", "9")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [Test]
        public void IsProperSubsetOf_Positive_Test(bool result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8", "9" };
            Assert.AreEqual(result, set.IsProperSubsetOf(ar));
        }

        [TestCase(false, "2", "3", "5", "8", "53")]
        [TestCase(false, "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8", "9")]
        [Test]
        public void IsProperSupersetOf_Positive_Test(bool result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8" };
            Assert.AreEqual(result, set.IsProperSupersetOf(ar));
        }

        [TestCase(false, "2", "3", "5", "8", "53")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [Test]
        public void IsSubsetOf_Positive_Test(bool result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8", "222", "32" };
            Assert.AreEqual(result, set.IsSubsetOf(ar));
        }

        [TestCase(false, "2", "3", "5", "8", "53")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8", "222", "32")]
        [Test]
        public void IsSupersetOf_Positive_Test(bool result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8"};
            Assert.AreEqual(result, set.IsSupersetOf(ar));
        }

        [TestCase(false, "22222", "31231", "123125", "82312", "532131")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8", "222", "32")]
        [Test]
        public void Overlaps_Positive_Test(bool result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8" };
            Assert.AreEqual(result, set.Overlaps(ar));
        }
        [TestCase(false, "22222", "31231", "123125", "82312", "532131")]
        [TestCase(true, "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [TestCase(false, "0", "1", "12", "4", "55", "12", "33", "53", "8", "222", "32")]
        [Test]
        public void SetEquals_Positive_Test(bool result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8" };
            Assert.AreEqual(result, set.SetEquals(ar));
        }

        [TestCase("2, 3, 5, 12, 4, 55, 33, ", "0", "1", "1", "2", "3", "5", "8", "53")]
        [TestCase("", "0", "1", "12", "4", "55", "12", "33", "53", "8")]
        [Test]
        public void SymmetricExceptWith_Positive_Test(string result, params string[] array)
        {
            Set<string> set = new Set<string>(array);
            string[] ar = { "0", "1", "12", "4", "55", "12", "33", "53", "8" };
            set.SymmetricExceptWith(ar);
            string str = String.Empty;
            foreach (var item in set)
                str += item + ", ";
            Assert.AreEqual(result, str);
        }

    }
}
