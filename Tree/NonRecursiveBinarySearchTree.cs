using System.Collections.Generic;

namespace Tree
{
    public class NonRecursiveBinarySearchTree<T> : ITree<T>
    {
        private TreeNode<T> _root;
        public TreeNode<T> Root { get { return _root; } }
        private int _size;
        public int Size { get { return _size; } }
        private IComparer<T> _comparer;

        public NonRecursiveBinarySearchTree()
        {
            MakeEmpty();
            this._comparer = Comparer<T>.Default;
        }

        public void MakeEmpty()
        {
            _root = null;
            _size = 0;
        }

        public bool IsEmpty()
        {
            return _root == null;
        }

        public bool Contains(T item)
        {
            var node = this._root;
            while (true)
            {
                if (node == null) return false;
                var comparer = _comparer.Compare(item, node.Element);
                if (comparer > 0)
                {
                    node = node.Right;
                }
                else if (comparer < 0)
                {
                    node = node.Left;
                }
                else
                {
                    return true;
                }
            }
        }

        public T FindMin()
        {
            var node = this._root;
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.Element;
        }

        public T FindMax()
        {
            var node = this._root;
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node.Element;
        }

        public void Insert(T item)
        {
            if (this._root == null)
            {
                this._root = new TreeNode<T>(item);
            }
            var node = this._root;

            while (true)
            {
                var comparer = _comparer.Compare(item, node.Element);
                if (comparer < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T>(item);
                        return;
                    }
                    node = node.Left;
                }
                else if (comparer > 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode<T>(item);
                        return;
                    }
                    node = node.Right;
                }
                else
                {
                    return;
                }
            }
        }

        public void Remove(T item)
        {
            if (IsEmpty()) return;
            var node = this._root;
            var fatherNode = this._root;
            while (true)
            {
                var comparer = _comparer.Compare(item, node.Element);
                if (comparer > 0)
                {
                    fatherNode = node;
                    node = node.Right;
                }
                else if (comparer < 0)
                {
                    fatherNode = node;
                    node = node.Left;
                }
                else
                {
                    if (node.Left == null && node.Right == null)
                    {
                        if (fatherNode.Left != null)
                        {
                            fatherNode.Left = null;
                            break;

                        }
                        if (fatherNode.Right != null)
                        {
                            fatherNode.Right = null; break;
                        }
                    }
                    else if (node.Left == null || node.Right == null)
                    {
                        var tmp = node.Left ?? node.Right;
                        if (fatherNode.Left == node)
                        {
                            fatherNode.Left = tmp; break;
                        }
                        else
                        {
                            fatherNode.Right = tmp; break;
                        }
                    }
                    else
                    {
                        var tmp = node;
                        while (tmp.Left != null)
                        {
                            tmp = tmp.Left;
                        }
                        node.Element = tmp.Element;

                    }
                }
            }
        }

        public void PrintTree()
        {
            throw new System.NotImplementedException();
        }
    }
}