using System.Collections.Generic;

namespace Lc.PalindromePartitioning
{
	public class Solution
	{
		public IList<IList<string>> Partition(string s)
		{
			var result = new List<IList<string>>();

			for (var start = 0; start < s.Length; start++)
			{
				var isPalindrome = true;
				var i = start;
				var j = s.Length - 1;
				while (i < j)
				{
					if (s[i] != s[j])
					{
						isPalindrome = false;
						break;
					}
					i++;
					j--;
				}

				if (isPalindrome)
				{
					var palindrome = s.Substring(start, s.Length - start);
					if (start > 0)
					{
						var subresult = Partition(s.Substring(0, start));
						foreach (var l in subresult)
						{
							l.Add(palindrome);
						}
						result.AddRange(subresult);
					}
					else
					{
						result.Add(new List<string> {palindrome});
					}

				}

			}

			return result;
		}
	}

	
}
