namespace Lc.BestTimeToBuyAndSellStockII
{
	public class Solution
	{
		public int MaxProfit(int[] prices)
		{
			var profit = 0;
			int? buy = null;
			for (var i = 0; i < prices.Length - 1; i++)
			{
				if (prices[i] < prices[i + 1])
				{
					if (!buy.HasValue) buy = prices[i];
				}
				else if (prices[i] != prices[i+1] && buy.HasValue)
				{
					profit += prices[i] - buy.Value;
					buy = null;
				}
			}
			if (buy.HasValue) profit += prices[prices.Length - 1] - buy.Value;
			return profit;
		}
	}
}
