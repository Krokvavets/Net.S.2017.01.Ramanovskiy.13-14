using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Set<T> : ISet<T>, IEnumerable<T>, IEnumerable
        where T : class
    {
        private readonly List<T> items = new List<T>();
        IEqualityComparer<T> comparer;
        #region constructors;
        public Set()
        {
            comparer = EqualityComparer<T>.Default;
        }
        public Set(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null)) throw new ArgumentNullException();
            comparer = EqualityComparer<T>.Default;
            foreach (var item in collection)
                this.Add(item);
            Count = collection.Count();
        }
        public Set(IEqualityComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException();
            this.comparer = comparer;
        }
        public Set(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (ReferenceEquals(collection, null) || ReferenceEquals(comparer, null)) throw new ArgumentNullException();
            this.comparer = comparer;
            foreach (var item in collection)
                this.Add(item);
            Count = collection.Count();
        }
        #endregion;

        public int Count { get; private set; } = 0;
        public bool IsReadOnly { get => false; }
        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>true if the element is added to the Set<T> object; false if the element is already present.</returns>
        public bool Add(T item)
        {
            if (!this.Contains(item))
            {
                Count++;
                items.Add(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes all elements from a Set<T> object.
        /// </summary>
        public void Clear()
        {
            items.Clear();
            Count = 0;
        }
        /// <summary>
        /// Determines whether a Set<T> object contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate in the Set<T> object.</param>
        /// <returns>true if the Set<T> object contains the specified element; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return items.Contains(item, comparer);
        }

        /// <summary>
        /// Copies the elements of a Set<T> object to an array.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from the Set<T> object. The array must have zero-based indexing.</param>
        public void CopyTo(T[] array)
        {
            CopyTo(array, 0, this.Count);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(array, arrayIndex, this.Count);
        }
        public void CopyTo(T[] array, int arrayIndex, int count)
        {
            items.CopyTo(0, array, arrayIndex, count);
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current Set<T> object.
        /// </summary>
        /// <param name="other">The collection of items to remove from the Set<T> object.</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            ReferenceEquals(other, null);

            foreach (var item in other)
                this.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain only elements that are present in that object and in the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            if (other.Count() == 0) return;
            Set<T> set = new Set<T>(this);
            foreach (var item in set)
            {
                if (!other.Contains(item))
                    this.Remove(item);
            }
        }

        /// <summary>
        /// Determines whether a Set<T> object is a proper subset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        /// <returns>true if the Set<T> object is a proper subset of other; otherwise, false.</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            if (other.Count() > Count)
                return IsProperSubsetOrSupersetOf(this, other);
            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a proper superset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        /// <returns>true if the Set<T> object is a proper superset of other; otherwise, false.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            if (other.Count() < Count)
                return IsProperSubsetOrSupersetOf(other, this);
            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a subset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current HashSet<T> object.</param>
        /// <returns>true if the Set<T> object is a subset of other; otherwise, false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            if (other.Count() >= Count)
                return IsProperSubsetOrSupersetOf(this, other);
            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a superset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        /// <returns>true if the Set<T> object is a superset of other; otherwise, false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            if (Count >= other.Count())
                return IsProperSubsetOrSupersetOf(other, this);
            return false;
        }

        private static bool IsProperSubsetOrSupersetOf(IEnumerable<T> set, IEnumerable<T> otherSet)
        {
            foreach (var item in set)
                if (!otherSet.Contains(item))
                    return false;
            return true;
        }
        /// <summary>
        /// Determines whether the current Set<T> object and a specified collection share common elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        /// <returns>true if the Set<T> object and other share at least one common element; otherwise, false.</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            if (Count != 0 && other.Count() != 0)
                foreach (var item in other)
                    if (this.Contains(item))
                        return true;
            return false;
        }

        /// <summary>
        /// Removes the specified element from a Set<T> object.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>true if the element is successfully found and removed; otherwise, false. This method returns false if item is not found in the Set<T> object.</returns>
        public bool Remove(T item)
        {
            Count--;
            return items.Remove(item);
        }

        /// <summary>
        /// Determines whether a Set<T> object and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        /// <returns>true if the Set<T> object is equal to other; otherwise, false.</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentException("other");
            if (Count == other.Count())
                return IsProperSubsetOrSupersetOf(other, this);
            return false;
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain only elements that are present either in that object or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            Set<T> otherSet = new Set<T>(other);
            Set<T> ownSet = OwnItems(other);
            this.ExceptWith(ownSet);
            otherSet.ExceptWith(ownSet);
            this.UnionWith(otherSet);
        }
        private Set<T> OwnItems(IEnumerable<T> other)
        {
            Set<T> set = new Set<T>();
            foreach (var item in other)
                if (this.Contains(item))
                    set.Add(item);
            return set;
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain all elements that are present in itself, the specified collection, or both.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object.</param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null)) throw new ArgumentNullException("other");
            foreach (var item in other)
                this.Add(item);
        }
        /// <summary>
        /// Adds an item to an ICollection<T> object.
        /// </summary>
        /// <param name="item">The object to add to the ICollection<T> object.</param>
        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}