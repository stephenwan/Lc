using System;
using System.Linq;

namespace Lc.SuperUglyNumber
{
	public class Solution
	{
		public int NthSuperUglyNumber(int n, int[] primes)
		{
			var uglies = Enumerable.Repeat(int.MaxValue, n).ToArray();
			var indexes = new int[primes.Length];
			var nexts = new int[primes.Length];		

			uglies[0] = 1;
			primes.CopyTo(nexts, 0);

			for (var i = 1; i < n; i++)
			{
				var lastMinJ = -1;	
				for (var j = 0; j < primes.Length; j++)
				{
					if (uglies[i] > nexts[j])
					{						
						if (lastMinJ >= 0)
						{
							indexes[lastMinJ] -= 1;
							nexts[lastMinJ] = uglies[i];
						}
						uglies[i] = nexts[j];
						lastMinJ = j;
					}

					if (uglies[i] != nexts[j]) continue;
					indexes[j]++;
					nexts[j] = uglies[indexes[j]] * primes[j];
				}				
			}

			return uglies[n-1];
		}
	}
}
