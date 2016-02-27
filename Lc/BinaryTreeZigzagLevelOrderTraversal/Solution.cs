using System.Collections.Generic;

namespace Lc.BinaryTreeZigzagLevelOrderTraversal
{

	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;

		public TreeNode(int x)
		{
			val = x;
		}
	}

	public class Solution
	{
		public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
		{

			var result = new List<IList<int>>();

			var nodeStack = new Stack<TreeNode>();
			var reverse = false;		
			if (root != null) nodeStack.Push(root);

			while (true)
			{
				if (nodeStack.Count == 0) break;

				var childNodes = new Stack<TreeNode>();
				var curLayer = new List<int>();

				while (nodeStack.Count > 0)
				{
					var node = nodeStack.Pop();
					curLayer.Add(node.val);
					if (reverse)
					{
						if (node.right != null) childNodes.Push(node.right);
						if (node.left != null) childNodes.Push(node.left);
					}
					else
					{
						if (node.left != null) childNodes.Push(node.left);
						if (node.right != null) childNodes.Push(node.right);						
					}

				}
				
				result.Add(curLayer);
				nodeStack = childNodes;
				reverse = !reverse;
			}

			return result;
		}
	
	}



}
