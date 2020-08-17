using BST;

using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BST<int>();

            bst.Insert(5);
            bst.Insert(7);
            bst.Insert(3);

            bst.Delete(3);

            ;
        }
    }
}
