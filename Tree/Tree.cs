using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Tree
    {
    }

    public class TreeNode<T>
    {
        public T Item { get; set; }
        public TreeNode<T> FristChild { get; set; }
        public TreeNode<T> NextSibling { get; set; }
    }
}
