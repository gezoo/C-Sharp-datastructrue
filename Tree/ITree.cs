using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public interface ITree<T>
    {
        void MakeEmpty();
        bool IsEmpty();
        bool Contains(T item);
        T FindMin();
        T FindMax();
        void Insert(T item);
        void Remove(T item);

        void PrintTree();

        TreeNode<T> Root { get;}
    }
}
