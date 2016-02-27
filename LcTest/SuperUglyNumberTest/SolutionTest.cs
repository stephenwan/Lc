using Lc.SuperUglyNumber;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.SuperUglyNumberTest
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		

		[Test]
		public void Test1()
		{
			_solution.NthSuperUglyNumber(5, new[] {5}).Should().Be.EqualTo(625);
		}


		[Test]
		public void Test2()
		{			
			_solution.NthSuperUglyNumber(5, new[] {2, 3, 5}).Should().Be.EqualTo(5);
		}

		[Test]
		public void Test3()
		{
			_solution.NthSuperUglyNumber(12, new[] {2, 7, 13, 19}).Should().Be.EqualTo(32);
		}
	}
}
