using System;
using System.Collections.Generic;

namespace Lc.ContainsDuplicateIII
{
    public class Solution
    {
        private Dictionary<Tuple<int, int>, int> _cachedPathSum;
        private Dictionary<int, int> _valueSpread; 
        private int[] _nums;
        private int _pRange;
        private int _vRange;

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
                      
            if (nums.Length < 2) return false;           

            _pRange = k;
            _vRange = t;
            _nums = nums;
           
            if (t < k ) return SolveByValueSpread();
            return SolveByPathSum();
        }

        private bool SolveByPathSum()
        {
            _cachedPathSum = new Dictionary<Tuple<int, int>, int>();

            for (var i = 1; i <= _pRange; i++)
            {
                for (var j = 0; j + i < _nums.Length; j++)
                {
                    var pathSum = CalculatePathSum(j, j + i);
                    if (pathSum <= _vRange && pathSum >= -_vRange) return true;
                }
            }

            return false;
        }

        private int CalculatePathSum(int start, int end)
        {
            int pathSum;
            if (start == end - 1)
            {
                pathSum = _nums[start + 1] - _nums[start];
                _cachedPathSum[new Tuple<int, int>(start, end)] = pathSum;
                return pathSum;
            }

            pathSum = _cachedPathSum[new Tuple<int, int>(start, end - 1)] +
                      _cachedPathSum[new Tuple<int, int>(start + 1, end)];
            if (start + 1 < end - 1) pathSum -= _cachedPathSum[new Tuple<int, int>(start + 1, end - 1)];
            _cachedPathSum[new Tuple<int, int>(start, end)] = pathSum;
            return pathSum;
        }

        private bool SolveByValueSpread()
        {
            _valueSpread = new Dictionary<int, int>();
            for (var i = 0; i < _nums.Length; i ++)
            {
                if (UpdateValueSpread(i, _nums[i])) return true;
            }
            return false;
        }

        private bool UpdateValueSpread(int p, int v)
        {
            if (_valueSpread.ContainsKey(v) && p - _valueSpread[v] <= _pRange) return true;
            for (var i = v - _vRange; i <= v + _vRange; i++)
            {
                _valueSpread[i] = p;
            }
            return false;
        }
              



    }
}
