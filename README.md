# Binary Search Tree
![Image of BST](/Capture.png)
## TO DO:
- [x] Finished Iterative and Recursive DepthFirst and BreadthFirst Traversals
- [ ] Delete unnecessary comments
- [ ] Need to include ```public static SimpleTree MakeTreeRecursively(int[] numbers, int low, int high)```
### DS-10:
I have a sorted array of integers, like 1, 42, 54, 72, 99, 101; I'd like a function that produces a binary tree (like a BST) from this list. However, it's very important that the tree remains as close to balanced as possible; but I don't want to use AVL or Red/Black trees, due to extra costs of insertion. In fact, here's the structure I want to place my result in:

```csharpclass SimpleTree
{
   public int Value { get; set; } 
   public SimpleTree Left { get; set; } 
   public SimpleTree Right { get; set; }
} 
```
So, the function I want takes in an array and returns a tree:
```csharp
SimpleTree MakeTree(int[] numbers)
{
   // your code here
}
```
