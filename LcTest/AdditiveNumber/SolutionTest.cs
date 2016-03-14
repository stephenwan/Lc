using Lc.AdditiveNumber;
using NUnit.Framework;
using SharpTestsEx;

namespace LcTest.AdditiveNumber
{
	[TestFixture]
	public class SolutionTest
	{
		private readonly Solution _solution = new Solution();		

		[Test]
		public void Test1()
		{
			_solution.IsAdditiveNumber("112358").Should().Be.True();
		}

        [Test]
        public void Test2()
        {
            _solution.IsAdditiveNumber("1203").Should().Be.False();
        }

        [Test]
        public void Test3()
        {
            _solution.IsAdditiveNumber("0123").Should().Be.False();
        }

	    [Test]
	    public void Test4()
	    {
	        _solution.IsAdditiveNumber("11235813213455890144").Should().Be.False();
	    }

        [Test]
        public void Test5()
        {
            _solution.IsAdditiveNumber("8917").Should().Be.True();
        }

    }
}
