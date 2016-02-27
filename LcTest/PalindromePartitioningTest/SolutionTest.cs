using Lc.PalindromePartitioning;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.PalindromePartitioningTest
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		

		[Test]
		public void Test1()
		{
			var result = _solution.Partition("abba");
			result.Count.Should().Be.EqualTo(3);
		}

		[Test]
		public void Test2()
		{
			var result = _solution.Partition("aaa");
			result.Count.Should().Be.EqualTo(4);
		}

		[Test]
		public void Test3()
		{
			var result = _solution.Partition("aab");
			result.Count.Should().Be.EqualTo(2);
		}

	}
}
