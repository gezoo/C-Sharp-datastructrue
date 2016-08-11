using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    public class BinarySearchTree<T> : ITree<T>
    {
        private TreeNode<T> _root;
        public TreeNode<T> Root { get { return _root; } }
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

        private bool Contains(T item, TreeNode<T> node)
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

        private T FindMin(TreeNode<T> node)
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

        private T FindMax(TreeNode<T> node)
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

        public void Insert(T item)
        {
            Insert(item, this._root);
        }

        private TreeNode<T> Insert(T item, TreeNode<T> node)
        {
            if (node == null)
            {
                var n = new TreeNode<T>(item);
                if (this._root == null) this._root = n;
                return n;
            }
            var comparerResult = _comparer.Compare(item, node.Element);
            if (comparerResult > 0) node.Right = Insert(item, node.Right);
            else if (comparerResult < 0) node.Left = Insert(item, node.Left);
            else { }
            return node;
        }

        public void Remove(T item)
        {
            Remove(item, this._root);
        }

        private TreeNode<T> Remove(T item, TreeNode<T> node)
        {
            if (node == null) return node;
            var comparerResult = _comparer.Compare(item, node.Element);
            if (comparerResult < 0)
            {
                node.Left = Remove(item, node.Left);
            }
            else if (comparerResult > 0)
            {
                node.Right = Remove(item, node.Right);
            }
            else
            {
                if (node.Left != null && node.Right != null)
                {
                    node.Element = FindMin(node.Right);
                    node.Right = Remove(node.Element, node.Right);
                }
                else
                {
                    node = node.Left ?? node.Right;
                }
            }
            return node;
        }

        public void PrintTree()
        {
            if (IsEmpty()) throw new ArgumentNullException("Root");
            PrintTree(this._root);
        }

        private void PrintTree(TreeNode<T> node)
        {
            if (node != null)
            {
                PrintTree(node.Left);
                Console.WriteLine(node.Element);
                PrintTree(node.Right);
            }
        }

    }


}