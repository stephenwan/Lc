using System.Collections.Generic;
using System.Linq;
using Lc.BinaryTreeZigzagLevelOrderTraversal;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.BinaryTreeZigzagLevelOrderTraversalTest
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		


		[Test]
		public void Test1()
		{
			var tree = new TreeNode(3)
			{				
				left = new TreeNode(9),
				right = new TreeNode(20) { left = new TreeNode(15), right = new TreeNode(7) }
			};

			var result = _solution.ZigzagLevelOrder(tree).ToArray();
			result.Length.Should().Be.EqualTo(3);
			result[0].Should().Have.SameSequenceAs(new List<int> {3});
			result[1].Should().Have.SameSequenceAs(new List<int> {20, 9});
			result[2].Should().Have.SameSequenceAs(new List<int> {15, 7});
		}

		[Test]
		public void Test2()
		{
			var tree = new TreeNode(3);
			var result = _solution.ZigzagLevelOrder(tree).ToArray();
			result.Length.Should().Be.EqualTo(1);
			result[0].Should().Have.SameSequenceAs(new List<int> {3});

		}

	
	}
}
