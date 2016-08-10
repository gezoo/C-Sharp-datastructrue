using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    public class BinarySearchTree<T>
    {
        private BinaryNode<T> _root;
        private IComparer<T> _comparer;
        public BinarySearchTree()
        {
            MakeEmpty();
            this._comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            MakeEmpty();
            this._comparer = _comparer == null ? Comparer<T>.Default : comparer;
        }

        public void MakeEmpty()
        {
            this._root = null;
        }

        public bool IsEmpty()
        {
            return this._root == null;
        }

        public bool Contains(T item)
        {
            return Contains(item, this._root);
        }

        private bool Contains(T item, BinaryNode<T> node)
        {
            var compareResult = _comparer.Compare(node.Element, item);
            if (compareResult > 0)
                return Contains(item, node.Right);
            if (compareResult < 0)
                return Contains(item, node.Left);

            return true;
        }

        public T FindMin()
        {
            if (IsEmpty()) throw new Exception("Root is null");
            return FindMin(this._root);
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
            return FindMax(this._root);
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