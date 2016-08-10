using System;

namespace Tree
{
    public class BinarySearchTree<T> : IComparable<T>
    {
        private BinaryNode<T> Root;

        public BinarySearchTree()
        {
            MakeEmpty();
        }

        public void MakeEmpty()
        {
            this.Root = null;
        }
        public bool IsEmpty()
        {
            return this.Root == null;
        }
        public bool Contains(T item) { throw new NotImplementedException(); }

        public T FindMin()
        {
            if (IsEmpty()) throw new Exception("Root is null");
            return FindMin(this.Root);
        }
        private T FindMin(BinaryNode<T> node)
        {
            if (node == null) return default(T);
            if (node.Left == null) return node.Element;
            return FindMin(node.Left);
        }
        public T FindMax()
        {
            if (IsEmpty()) throw new Exception("Root is null");
            return FindMax(this.Root);
        }

        private T FindMax(BinaryNode<T> node)
        {
            //递归写法
            if (node == null) return default(T);
            if (node.Right == null) return node.Element;
            return FindMax(node.Right);

            //非递归写法
            /*
            if (node != null)
                while (node.Right != null)
                    node = node.Right;
            return node.Element;
             */
        }
        public void Insert(T item) { throw new NotImplementedException(); }
        public void Remove(T item) { throw new NotImplementedException(); }
        public void PrintTree() { throw new NotImplementedException(); }

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }

    internal class BinaryNode<T>
    {
        public BinaryNode(T item) : this(item, null, null) { }

        public BinaryNode(T item, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.Element = item;
            this.Left = left;
            this.Right = right;
        }

        public T Element { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }
    }
}