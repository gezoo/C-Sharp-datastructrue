using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Link
{
    public class MyArrayList<T> : ICollection<T>
    {
        public T this[int index]
        {
            get
            {
                if (index < Count)
                    return this.TheItems[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index > Count) throw new IndexOutOfRangeException();
                TheItems[index] = value;
            }
        }

        private T[] TheItems
        {
            get;
            set;
        }

        private int _count;
        private const int DEFUTL_CAPACITY = 5;

        public MyArrayList()
        {
            Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++) {
                yield return TheItems[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            Add(Count, item);
        }

        public void Add(int location, T item)
        {
            if (TheItems.Length == Count) {
                EnsureCapacity(Count * 2 + 1);
            }
            for (int i = Count; i < location; i--) {
                TheItems[i] = TheItems[i - 1];
            }
            TheItems[location] = item;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
            EnsureCapacity(DEFUTL_CAPACITY);
        }

        public bool Contains(T item)
        {
            var iterator = GetEnumerator();
            while (iterator.MoveNext()) {
                if (iterator.Current.Equals(item)) {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            var iterator = GetEnumerator();
            var index = 0;
            while (iterator.MoveNext()) {
                if (iterator.Current.Equals(item)) {
                    for (int i = index; i < Count; i++) {
                        TheItems[i] = TheItems[i + 1];
                    }
                    _count--;
                    return true;
                }
                index++;
            }
            return false;
        }

        public int Count
        {
            get { return _count; }
            private set { _count = value; }
        }
        public bool IsReadOnly { get; private set; }


        public void EnsureCapacity(int newCapacity)
        {
            if (newCapacity < Count) { return; }
            var old = TheItems;
            TheItems = new T[newCapacity];

            for (int i = 0; i < Count; i++) {
                TheItems[i] = old[i];
            }
        }
    }
}