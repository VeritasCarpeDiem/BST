using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    public class Node<T>
    {
        public T Value;

        public int NodeCount;

        public Node<T> Parent;

        public Node<T> Left;

        public Node<T> Right;


        public Node(T value, Node<T> parent) //? default parameter
        {
            Value = value;
            Parent = parent;
            NodeCount = 1;

        }

        public Node(T value) //? default parameter
        {
            Value = value;
            Parent = null;
            NodeCount = 1;

        }
    }


    public class BST<T> where T : IComparable<T>
    {
        public Node<T> Root;

        public T RootValue => Root.Value;
        public BST()
        {
            Count = 0;
            Root = null;
        }

        public int Count { get; private set; }

        private Node<T> Maximum(Node<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node;
        }

        public void Insert(T Value)
        {
            Count++;

            if (Root == null)
            {
                Root = new Node<T>(Value);
                return; //???
            }

            Node<T> Current = Root;
            while (Current != null)
            {
                //3 cases:
                if (Value.CompareTo(Current.Value) < 0) //less than
                {
                    if (Current.Left == null)
                    {
                        Current.Left = new Node<T>(Value, Current);
                        break;
                        
                    }
                    Current = Current.Left;
                }
                else if (Value.CompareTo(Current.Value) > 0)//greater than
                {
                    if (Current.Right == null)
                    {
                        Current.Right = new Node<T>(Value, Current);
                        break;
                    }
                    Current = Current.Right;
                }
                else //values are equal
                {
                    Current.NodeCount++;
                    break;
                    //2 approaches:
                    //1. traverse right until you reach leaf, 
                    //2. increment the nodecount for that specific value

                    //1.
                    //if (Current.Right == null)
                    //{
                    //    Current.Right = new Node<T>(Value, Current);

                    //    Current.Parent = Current.Left;//set  parent of the new node to current

                    //    if (Current.Right.Value.CompareTo(Current.Value) < 0) 
                    //        //if right child < left child of parent node, move right child to left
                    //    {
                    //        Current.Right = Current.Left;
                    //    }
                    //}
                    //Current = Current.Right;


                    ////2.
                    
                    //if (Current.Right == null)
                    //{
                    //    Current.NodeCount++;
                    //}
                    //Current = Current.Right;



                }
            }

        }
        public bool Delete(T Value)
        {
            Node<T> NodeToDelete = Find(Value);
            //2 cases: 1. Node to delete does not exist 2. Node got deleted
            if(NodeToDelete==null)
            {
                return false;
            }
            Delete(NodeToDelete);
            Count--;

            return true;
        }

        private Node<T> Delete(Node<T> node)
        {
            //4 cases: Parent has 1. 0 child 2. 1 child 3. 2 child 
            //4. If node you want to delete is has NodeCount>1

        }
        public Node<T> Find(T value)
        {
            Node<T> current = Root;

            int CurrentValue = value.CompareTo(Root.Value);

            while (current != null)
            {
                if (CurrentValue < 0)
                {
                    current = current.Left;
                }
                else if (CurrentValue > 0)
                {
                    current = current.Right;
                }
                else //if value= value 
                {
                    break;
                }
                //this means you did NOT find the value
                //return throw new Exception("Node not Found!");
            }

            return current;

        }

        public bool Contains(T value)
        {
            Node<T> node = Find(value);

            //if(node.value=null)//if=null return false
            //{
            //    return false;
            //}
            //else //return true
            //{
            //    return true;
            //}

            return Find(value) != null;
        }


    }

}
