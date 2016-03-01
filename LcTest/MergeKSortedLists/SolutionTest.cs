using System.Collections.Generic;
using Lc.MergeKSortedLists;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.MergeKSortedLists
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		

		[Test]
		public void Test1()
		{
			var listNode1 = new ListNode(5)
			{
				next = new ListNode(9)
			};
			var listNode2 = new ListNode(7)
			{
				next = new ListNode(8)
			};
			var listNode3 = new ListNode(10);

			var result =_solution.MergeKLists(new [] {listNode1, listNode2, listNode3});

			result.val.Should().Be.EqualTo(5);
		}

		[Test]
		public void Test2()
		{
			var listNode1 = new ListNode(5)
			{
				next = new ListNode(9)
			};
			

			var result = _solution.MergeKLists(new[] { listNode1 });

			result.val.Should().Be.EqualTo(5);
		}


		[Test]
		public void TestGetHeapSize()
		{
			var lists = new [] { new ListNode(1), new ListNode(2), new ListNode(3), new ListNode(4)   };
			_solution.GetHeapSize(lists).Should().Be.EqualTo(7);
		}
	
	}

    [TestFixture]
    public class FixedSizeMinHeapTest
    {
        [Test]
        public void Test1()
        {
            var heap = new FixedSizeMinHeap<int>(7);

            var elements = new int[] {5, 7, 4, 2, 8, 9, 1};
            heap.Build(elements);

            heap.GetRepresentation().Should().Have.SameSequenceAs(new List<int> {1, 2, 4, 7, 8, 9, 5});
        }
    }
}
