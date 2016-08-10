using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private int _size;
        public int Size { get { return _size; } }

        internal LinkedLinkNode<T> _head;
        internal LinkedLinkNode<T> _tail;

        public MyLinkedList()
        {
            Clear();
        }

        public int GetLength()
        {
            return Size;
        }

        public void Clear()
        {
            _size = 0;
            _head = new LinkedLinkNode<T>(default(T), null, null);
            _tail = new LinkedLinkNode<T>(default(T), _head, null);
            _head.Next = _tail;
        }

        public T Remove(int index)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item, int i)
        {
            var node = Find(i);
            AddAfter(node, item);
        }

        public void Append(T item)
        {
            AddBefore(_tail, item);
        }

        public void AddBefore(LinkedLinkNode<T> node, T item)
        {
            var newNode = new LinkedLinkNode<T>(item, node.Pre, node);
            newNode.Pre.Next = newNode;
            node.Pre = newNode;
            _size++;
        }

        public void AddAfter(LinkedLinkNode<T> node, T item)
        {
            var newNode = new LinkedLinkNode<T>(item, node, node.Next);
            newNode.Pre.Next = newNode;
            node.Next = newNode;
            node.Next.Pre = node;
            _size++;
        }

        public int Find(T t)
        {
            throw new NotImplementedException();
        }

        public LinkedLinkNode<T> Find(int index)
        {
            if (index > _size || index < 0) {
                throw new IndexOutOfRangeException();
            }

            LinkedLinkNode<T> node;
            if (index < _size / 2) {
                node = _head.Next;
                for (int i = 0; i < index; i++) {
                    node = node.Next;
                }
            }
            else {
                node = _tail.Pre;
                for (int i = _size; i > index; i--) {
                    node = node.Pre;
                }
            }
            return node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LinkedLinkNode<T>
    {
        private T _item;
        public T Item { get { return _item; } }
        public LinkedLinkNode<T> Next { get; set; }
        public LinkedLinkNode<T> Pre { get; set; }

        public LinkedLinkNode()
        {
            _item = default(T);
        }

        public LinkedLinkNode(T item, LinkedLinkNode<T> pre, LinkedLinkNode<T> next)
        {
            this._item = item;
            this.Next = next;
            this.Pre = pre;
        }
    }

    internal class Enumerator<T> : IEnumerator<T>
    {
        private LinkedLinkNode<T> _node;
        private MyLinkedList<T> _list;
        private T _current;
        public Enumerator(MyLinkedList<T> list)
        {
            this._list = list;
            this._node = _list._head.Next;
            this._current = default(T);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return _node != _list._tail;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public T Current
        {
            get
            {
                var tmpNode = _node;
                _node = _node.Next;
                _current = tmpNode.Item;
                return _current;
            }
            private set
            {
                _current = value;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
