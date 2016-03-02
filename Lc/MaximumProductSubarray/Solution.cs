using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc.MaximumProductSubarray
{
	public class Solution
	{


		public int MaxProduct(int[] nums)
		{
			var idx = 0;
			var curStart = 0;
			var curMaxProduct = Int32.MinValue;
			;

			while (idx < nums.Length)
			{
				if (nums[idx] < 0)
				{
					if (neg3 >= 0)
					{
						sp2 = sp2*nums[neg2]*sp3*nums[neg3]*sp4;
						sp3 = 1;
						sp4 = 0;
						neg2 = idx;
						neg3 = -1;
					}
					else if (neg2 >= 0)
					{
						neg3 = idx;
						sp4 = 1;
					}
					else if (neg1 >= 0)
					{
						neg2 = idx;
						sp3 = 1;
					}
					else
					{
						neg1 = idx;
						sp2 = 1;
						if (sp1 == 0) sp1 = 1;
					}
				}
				else if (nums[idx] > 0)
				{
					if (neg3 >= 0)
					{
						sp4 *= nums[idx];
					}
					else if (neg2 >= 0)
					{
						sp3 *= nums[idx];
					}
					else if (neg1 >= 0)
					{
						sp2 *= nums[idx];
					}
					else
					{
						sp1 = sp1 == 0 ? nums[idx] : sp1*nums[idx];
					}
				}
				else
				{
					curMaxProduct = Math.Max(curMaxProduct, calculateSubpAndReset(nums, curStart + 1 == idx));
					if (curMaxProduct < 0) curMaxProduct = 0;
					curStart = idx + 1;
				}

				idx++;
			}

			if (curStart <= nums.Length)
			{
				curMaxProduct = Math.Max(curMaxProduct, calculateSubpAndReset(nums, curStart + 1 == nums.Length));
			}

			return curMaxProduct;
		}

		private int calculateSubpAndReset(int[] nums, bool onlyOne)
		{
			int subp;
			if (neg3 >= 0)
			{
				var common = sp2*nums[neg2]*sp3;
				subp = Math.Max(sp1*nums[neg1]*common, common*nums[neg3]*sp4);
				sp1 = 0;
				sp2 = 0;
				sp3 = 0;
				sp4 = 0;
				neg1 = -1;
				neg2 = -1;
				neg3 = -1;
			}
			else if (neg2 >= 0)
			{
				subp = sp1*nums[neg1]*sp2*nums[neg2]*sp3;
				sp1 = 0;
				sp2 = 0;
				sp3 = 0;
				neg1 = -1;
				neg2 = -1;
			}
			else if (neg1 >= 0)
			{
				subp = onlyOne ? nums[neg1] : Math.Max(sp1, sp2);
				sp1 = 0;
				sp2 = 0;
				neg1 = -1;
			}
			else
			{
				subp = sp1;
				sp1 = 0;
			}
			return subp;
		}

		private int sp1 = 0;
		private int sp2 = 0;
		private int sp3 = 0;
		private int sp4 = 0;
		private int neg1 = -1;
		private int neg2 = -1;
		private int neg3 = -1;
	}
}
