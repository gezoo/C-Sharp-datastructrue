using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TreeNode<T> : IComparable<T>
    {
        public T Element { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T item) : this(item, null, null) { }

        public TreeNode(T item, TreeNode<T> left, TreeNode<T> right)
        {
            this.Element = item;
            this.Left = left;
            this.Right = right;
        }

        public int CompareTo(T other)
        {
            var comparer = new Comparer(CultureInfo.CurrentCulture);
            return comparer.Compare(other, Element);
        }
    }
}
