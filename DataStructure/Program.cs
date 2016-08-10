using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Link;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            //for (int i = 0; i < 100; i++)
            //{
            //    myLinkedList.Append(i);
            //}

            //foreach (var node in myLinkedList)
            //{
            //    Console.WriteLine(node);
            //}
            //Console.WriteLine(myLinkedList.Find(99).Item); 

            Expression expression1 = Expression.Constant(3);
            Console.WriteLine("NodeType:{0},Type:{1}",expression1.NodeType,expression1.Type);
            Expression expression2 = Expression.Constant(6);
            Console.WriteLine("NodeType:{0},Type:{1}",expression2.NodeType,expression2.Type);
            Expression expression3 = Expression.Add(expression1,expression2);
            Console.WriteLine("NodeType:{0},Type:{1}", expression3.NodeType, expression3.Type);
            Console.WriteLine("add:{0}", expression3);
            Console.ReadKey();
        }

    }
}
