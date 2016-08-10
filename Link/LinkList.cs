using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Link
{
    public class LinkList<T> : ILink<T>
    {
        internal Node<T> head;
        private Node<T> tail;

        public LinkList()
        {
            head = null;
            tail = head;
        }

        public LinkList(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection) {
                Append(item);
            }
        }

        private void InternalInsertNodeToEmptyLink(Node<T> newNode)
        {
            newNode.next = newNode;
            head = newNode;
            tail = head;
        }

        private void InternalInsertNodeToLink(Node<T> newNode)
        {
            tail.next = newNode;
            tail = newNode;
        }

        private bool IsEmpty()
        {
            return head == null;
        }

        public int GetLength()
        {
            var index = 1;
            var p = head;
            while (p.Next != null) {
                p = p.Next;
                index++;
            }

            return index;
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public T Delete(int location)
        {
            if (IsEmpty()) throw new NoNullAllowedException();
            if (location < 1 || location > GetLength()) {
                throw new IndexOutOfRangeException();
            }
            var current = head;
            if (location == 1) {
                head = head.next;
                current = head;
                return current.data;
            }

            var pre = head;
            var index = 1;
            while (current.next != null && index < location) {
                pre = current;
                current = current.next;
                index++;
            }

            if (index == location) {
                pre.next = current.next;
                return current.data;
            }
            return default(T);

        }

        public void Insert(T item, int location)
        {
            if (IsEmpty()) throw new NoNullAllowedException();
            if (location > GetLength() || location < 1) throw new IndexOutOfRangeException();
            var node = new Node<T>(this, item);
            if (location == 1) {
                node.next = head;
                head = node;
                return;
            }

            var pre = Find(location - 1);
            var p = pre.next;
            pre.next = node;
            node.next = p;
        }

        public void Append(T item)
        {
            var node = new Node<T>(this, item);
            if (head == null) {
                InternalInsertNodeToEmptyLink(node);
            }
            else {
                InternalInsertNodeToLink(node);
            }
        }

        public int Find(T t)
        {
            if (IsEmpty()) return -1;
            var p = head;
            var index = 1;
            while (p.next != null) {
                if (t.Equals(p.Data)) break;
                index++;
                p = p.next;
            }
            if (p.next == null) return -1;
            return index;
        }

        private Node<T> Find(int location)
        {
            if (IsEmpty()) throw new NoNullAllowedException();
            var p = head;
            var index = 1;

            while (p.next != null && index < location) {
                p = p.next;
                index++;
            }
            return p;
        }

        public void ShowLink()
        {
            var p = head;
            while (p.next != null) {
                Console.WriteLine(p.data);
                p = p.next;
            }
            Console.WriteLine(p.data);
        }

        public void CreateClosedLoop(IEnumerable<T> collection)
        {
            var last = head;
            foreach (var item in collection)
            {
                var node = new Node<T>(this, item);
                if (head == null)
                {
                    head = node;
                    head.next = node;
                    last = node;
                    last.next = head;
                }
                else
                {
                    last.next = node;
                    node.next = head;
                    last = node;
                }
            }
        }

        public T Getk(int k)
        {
            var current = head;
            var pre = head;
            while (current.next!=current)
            {
                for (int i = 1; i < k ; i++)
                {
                    pre = current;
                    current = current.next;
                }
                pre.next = current.next;
                Console.WriteLine(current.data);
                current = current.next;
            }
            return current.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Node<T>
    {
        private LinkList<T> list;
        internal Node<T> next;
        internal T data;
        public Node()
        {
            data = default(T);
        }

        public Node(LinkList<T> list, T date)
        {
            this.list = list;
            this.data = date;
        }

        public T Data { get { return data; } }

        public Node<T> Next { get { return next == null || list.head == null ? null : next; } }
    }
}
