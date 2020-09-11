using BST;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
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

            int[] integers = { 1, 42, 52, 72, 99, 101 };
        }

        class SimpleTree
        {
            public int Value { get; set; }
            public SimpleTree Left { get; set; }
            public SimpleTree Right { get; set; }


            public static SimpleTree MakeTree(int[] numbers) //binary search 
            {
                //Since its Sorted, Inorder traversal

                int low = 0;
                int high = numbers.Length - 1;

                int mid = (low + high) / 2;

                SimpleTree root = new SimpleTree() { Value = numbers[mid] };

                // recursively add to left and right

                root.Left = HelperMakeTree(root.Left, numbers[mid], numbers[high]);// recursive;
                root.Right = HelperMakeTree(root.Right, numbers[low], numbers[mid]);// recursive

                return root;

                int HelperBinarySearch(int[] numbers, int head, int tail, int index)
                {
                    if (tail >= 1)
                    {
                        int mid = 1 + (tail - 1) / 2;
                        if (numbers[mid] == tail)
                        {
                            return mid;
                        }
                        if (numbers[mid] > index)
                        {
                            return HelperBinarySearch(numbers, tail, mid - 1, index);
                        }
                        else
                        {
                            return HelperBinarySearch(numbers, mid + 1, tail, index);
                        }
                    }
                    return -1;
                }

                SimpleTree HelperMakeTree(SimpleTree root, int low, int high)
                {
                   //base case:
                   if(low <= high)
                    {
                        return root;
                    }

                    if (root.Value < numbers[mid]) //if # > mid
                    {
                         return HelperMakeTree(root, numbers[mid],numbers[high]);
                    }
                    else //if #<mid
                    {
                        return HelperMakeTree(root, numbers[low], numbers[mid]);
                    }
                    

                }

            }
        }


    }
}
