using Lc.BestTimeToBuyAndSellStockII;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.BestTimeToBuyAndSellStockIITest
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		


		[Test]
		public void Test1()
		{
			var prices = new[] {1, 2, 3, 4, 5};
			var profit = _solution.MaxProfit(prices);
			profit.Should().Be.EqualTo(4);
		}

		[Test]
		public void Test2()
		{
			var prices = new[] {5, 4, 3, 2, 1};
			var profit = _solution.MaxProfit(prices);
			profit.Should().Be.EqualTo(0);
		}

		[Test]
		public void Test3()
		{
			var prices = new[] {1, 3, 2, 4, 5};
			var profit = _solution.MaxProfit(prices);
			profit.Should().Be.EqualTo(5);
		}
		

	
	}
}
