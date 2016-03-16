using Lc.ContainsDuplicateIII;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.ContainsDuplicateIII
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		

		[Test]
		public void Test1()
		{
		    _solution.ContainsNearbyAlmostDuplicate(new[] {500, 10, 300, 2, 100}, 3, 10).Should().Be.True();

		}

        [Test]
        public void Test2()
        {
            _solution.ContainsNearbyAlmostDuplicate(new[] { 0 }, 0, 0).Should().Be.False();

        }

        [Test]
        public void Test3()
        {
            _solution.ContainsNearbyAlmostDuplicate(new[] { 2, 2 }, 3, 0).Should().Be.True();

        }


	   


    }
}
