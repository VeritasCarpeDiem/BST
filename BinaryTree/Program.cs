using BST;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Transactions;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //var newbst = new BST<char>();

            //newbst.Insert('A');

            //var temp = newbst.InOrder();



            var bst = new BST<int>();

            bst.Insert(100); //F
            bst.Insert(50); //B
            bst.Insert(30); //A
            bst.Insert(60); //D
            bst.Insert(55); //C
            bst.Insert(70); //E
            bst.Insert(200); //G
            bst.Insert(250); // I
            bst.Insert(230); // H

            Dictionary<int, string> map = new Dictionary<int, string>()
            {
                [100] = "F",
                [50] = "B",
                [30] = "A",
                [60] = "D",
                [55] = "C",
                [70] = "E",
                [200] = "G",
                [250] = "I",
                [230] = "H"
            };

            // var returnPath = bst.BreadthFirst();

            //while (returnPath.Count > 0)
            //{
            //    Console.Write($"{map[returnPath.Dequeue().Value]}->");
            //}
            //foreach (var item in returnPath)
            //{
            //    Console.Write($"{item}->");
            //}

            var returnPath = bst.PostOrderRecursive();



            foreach (var item in returnPath)
            {
                Console.Write($"{item}->");
            }
        }
    }
}
