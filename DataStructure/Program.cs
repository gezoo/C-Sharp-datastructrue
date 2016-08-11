using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Link;
using Tree;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            ITree<int> tree = new BinarySearchTree<int>();
            Random rd = new Random(1);
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                while (true)
                {
                    var num = rd.Next(0, 20);
                    if (list.Contains(num) == false)
                    {
                        list.Add(num);
                        break;
                    }
                }
            }
            foreach (var i in list)
            {
                Console.WriteLine(i);
                tree.Insert(i);
            }
             tree.Remove(12);
            
            Console.ReadKey();
        }

    }
}
