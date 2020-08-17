using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        public int ChildCount
        {
            get
            {
                int Count = 0;
                if (Left != null || Right != null)
                {
                    Count++;
                }
                return Count;
            }

            set => ChildCount = value;
        }

        public bool IsChildLeft => Parent == null ? false : Parent.Left == this; //why not just put true?
        //A:need to account for case where you traverse the right node

        public bool IsChildRight => Parent == null ? false : Parent.Right == this;
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
            Node<T> NodeToDelete = Find(Value); //returns current node of this value
            //2 cases: 1. If Node to Delete Does not exist 2. Node got deleted
            if (NodeToDelete == null)
            {
                return false;
            }
            Delete(NodeToDelete);
            Count--;

            return true;
        }

        private void Delete(Node<T> Node)
        {
            //4 cases: Parent has 1. 0 child 2. 1 child 3. 2 child 4. If node you want to delete is has NodeCount>1
            if (Node.ChildCount == 2)
            {
                //go left once, then keep on traversing right--similar concept to binary search from guessing game
                Node<T> Replacement = Maximum(Node.Left); //takes log(N) time to traverse this way rather than nlog(N) if I used a list of the ordered tree 
                                          
                Node.Value = Replacement.Value;
                Node = Replacement;
            }

            
            if (Node.ChildCount == 1) //set child equal to Parent
            {
                //child node depends whether it is the right or left node of a parent
                Node<T> Child = Node.Left == null ? Node.Right : Node.Left; 

                // 3 cases:
                if (Node == Root)
                {
                    Root = Child;
                }
                else if (Node.IsChildLeft)
                {
                    Node.Parent.Left = Child;
                }
                else//Node.ChildIsRight
                {
                    Node.Parent.Right =Child ;
                }

                Child.Parent = Node.Parent; //set the Node's Parent to the Child's Parent
            }
            else if (Node.ChildCount == 0)
            {
                //3 cases:
                if (Node == Root)
                {
                    Root = null;
                }
                else if (Node.IsChildLeft)
                {
                    Node.Parent.Left = null;
                }
                else//Node.ChildIsRight
                {
                    Node.Parent.Right = null;
                }
            }
            else //if Node to delete has NodeCount>1
            {
                Node.NodeCount--;
            }

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
