using System.Collections.Generic;
using Lc.DifferentWaysToAddParentheses;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.DifferentWaysToAddParentheses
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();

	    [Test]
	    public void Test1()
	    {
	        var input = "2*3-4*5";
	        _solution.DiffWaysToCompute(input).Should().Have.SameSequenceAs(new List<int> { -34, -14, -10, -10, 10 });

        }

		
	}
}
