using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc.ContainsDuplicateIII
{
    public class Solution
    {
        private Item[] _window;
        private int[] _posarray;
        private int _curStart;
        

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums.Length < 2) return false;
            if (k < 2) return false;
            if (nums.Length < k) k = nums.Length;


            if (Initialzie(nums, k, t)) return true;

            for (var i = k; i < nums.Length; i ++)
            {
                if (ReplaceCurrent(nums[i], k, t)) return true;
            }

            return false;
        }


        private bool Initialzie(int[] nums, int k, int t)
        {
            _window = new Item[k];
            _posarray = new int[k];

            for (var i = 0; i < k; i++)
            {
                _window[i] = new Item(nums[i], i);
            }

            Array.Sort(_window);

            for (var i = 0; i < k; i++)
            {
                if (i < k - 1 && _window[i + 1].Value - _window[i].Value <= t) return true;
                _posarray[_window[i].Position] = i;
            }

            _curStart = 0;
            return false;
        }

        private bool ReplaceCurrent(int value, int k, int t)
        {
            _window[_posarray[_curStart]] = new Item(value, _curStart);
           
            if (_posarray[_curStart] > 0)
            {                               
                for (var j = _posarray[_curStart] - 1; j >= 0; j --)
                {
                    if (_window[j].Value > _window[j + 1].Value)
                    {
                        if (_window[j].Value <= _window[j + 1].Value) return true;
                        Swap(j, j + 1);                        
                    }
                    else
                    {
                        if (_window[j].Value >= _window[j + 1].Value - t) return true;
                        break;
                    }                        
                }                
            }

            if (_posarray[_curStart] >= k - 1) return false;

            for (var j = _posarray[_curStart]; j <= k - 2; j++)
            {
                if (_window[j].Value > _window[j + 1].Value)
                {
                    if (_window[j].Value <= _window[j + 1].Value) return true;
                    Swap(j, j + 1);
                }
                else
                {
                    if (_window[j].Value >= _window[j + 1].Value - t) return true;
                    break;
                }
            }

            if (_curStart == k - 1) _curStart = 0;
            else _curStart++;

            return false;
        }

        private void Swap(int i, int j)
        {
            _posarray[_window[i].Position] = j;
            _posarray[_window[j].Position] = i;

            var temp = _window[i];
            _window[i] = _window[j];
            _window[j] = temp;
        }
        

        class Item : IComparable<Item>
        {
            public readonly int Value;
            public readonly int Position;

            public Item(int value, int position)
            {
                Value = value;
                Position = position;
            }

            public int CompareTo(Item other)
            {
                return Value.CompareTo(other.Value);
            }
        }


    }
}
