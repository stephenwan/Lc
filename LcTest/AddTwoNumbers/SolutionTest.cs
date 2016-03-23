using Lc.AddTwoNumbers;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.AddTwoNumbers
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		


		[Test]
		public void Test1()
		{
			var l1 = new ListNode(2)
			{
			    next = new ListNode(4)
			    {
			        next = new ListNode(3)
			    }
			};

            var l2 = new ListNode(5)
            {
                next = new ListNode(6)
                {
                    next = new ListNode(4)
                }
            };

		    var result = _solution.AddTwoNumbers(l1, l2);

		    result.val.Should().Be.EqualTo(7);
            result.next.val.Should().Be.EqualTo(0);
            result.next.next.val.Should().Be.EqualTo(8);

        }





    }
}
