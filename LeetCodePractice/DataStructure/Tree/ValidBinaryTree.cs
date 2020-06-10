using System.Linq;
/*
1361. Validate Binary Tree Nodes

You have n binary tree nodes numbered from 0 to n - 1 where node i has two children leftChild[i] and rightChild[i], return true if and only if all the given nodes form exactly one valid binary tree.

If node i has no left child then leftChild[i] will equal -1, similarly for the right child.

Note that the nodes have no values and that we only use the node numbers in this problem.

Example 1:

Input: n = 4, leftChild = [1,-1,3,-1], rightChild = [2,-1,-1,-1]
Output: true
Example 2:

Input: n = 4, leftChild = [1,-1,3,-1], rightChild = [2,3,-1,-1]
Output: false
Example 3:

Input: n = 2, leftChild = [1,0], rightChild = [-1,-1]
Output: false
Example 4:

Input: n = 6, leftChild = [1,-1,-1,4,-1,-1], rightChild = [2,-1,-1,5,-1,-1]
Output: false
 
Constraints:

1 <= n <= 10^4
leftChild.length == rightChild.length == n
-1 <= leftChild[i], rightChild[i] <= n - 1

Sol
Time O(n)
Space O(n)
A valid tree satisfy that all node except root have exactly one parent, and root have no parent.
Also check that there is only one connected graph.
 */
namespace LeetCodePractice.DataStructure.Tree
{
    class ValidBinaryTree
    {
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            if (n == 1) return true;
            bool[] haveParent = new bool[n], connected = new bool[n];
            int temp = n;
            for(int i = 0; i < n; ++i)
            {
                if (leftChild[i] != -1)
                {
                    if(haveParent[leftChild[i]]) return false;
                    else
                    {
                        connected[i] = true;
                        connected[leftChild[i]] = true;
                        haveParent[leftChild[i]] = true;                        
                        --temp;
                    }
                }
                if (rightChild[i] != -1)
                {
                    if (haveParent[rightChild[i]]) return false;
                    else
                    {
                        connected[i] = true;
                        connected[rightChild[i]] = true;
                        haveParent[rightChild[i]] = true;
                        --temp;
                    }
                }

            }
            return temp == 1 && connected.All(x => x);
        }

    }
}
