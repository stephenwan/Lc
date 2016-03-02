using System.Collections.Generic;
using Lc.MaximumProductSubarray;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.MaximumProductSubarray
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();

		[Test]
		public void Test1()
		{
			var nums = new[] {3, 4, 5, 6, 2};
			_solution.MaxProduct(nums).Should().Be.EqualTo(720);
		}

		[Test]
		public void Test2()
		{
			var nums = new[] { 3, 4, 5, -6, 2 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(60);
		}

		[Test]
		public void Test3()
		{
			var nums = new[] { 3, 4,0,  5, -6, 2, 0, 3, 2, -1, 2, -1, -1, -3 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(36);
		}

		[Test]
		public void Test4()
		{
			var nums = new[] { -1, -2, -3 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(6);
		}

		[Test]
		public void Test5()
		{
			var nums = new[] {0, 0, 0 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(0);
		}

		[Test]
		public void Test6()
		{
			var nums = new[] { -1 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(-1);
		}

		[Test]
		public void Test7()
		{
			var nums = new[] { -1, 0 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(0);
		}

		[Test]
		public void Test8()
		{
			var nums = new[] { -4, -3 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(12);
		}

		[Test]
		public void Test9()
		{
			var nums = new[] { -2,0,-1 };
			_solution.MaxProduct(nums).Should().Be.EqualTo(0);
		}
	}
}
