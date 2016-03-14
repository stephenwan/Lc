using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static System.Int16;
using static System.Int64;

namespace Lc.AdditiveNumber
{
    public class Solution
    {
        public bool IsAdditiveNumber(string num)
        {            
            if (num.Length == 0) return false;

            var digits = new int[num.Length];
            for (var i = 0; i < num.Length; i++)
            {
                digits[i] = num[i] - '0';
            }

            for (var i = 1; i < num.Length/2 + 1; i ++)
            {                                
                for (var j = 1; j <= i; j++)
                {
                    var pend = num.Length;
                    var pmid = pend - i;
                    var pstart = pmid - j;

                    var toContinue = true;

                    while (toContinue)
                    {
                        var next = getNextPoint(digits, pstart, pmid, pend);

                        if (next == 0) return true;
                        if (next < 0) toContinue = false;
                        
                        pend = pmid;
                        pmid = pstart;
                        pstart = next;
                    }                  
                }
            }
            return false;
        }

        private int getNextPoint(int[] s, int pstart, int pmid, int pend)
        {
            if (pstart == 0) return -1;
            if (s[pmid] == 0 && pmid < pend - 1) return -1;
            if (s[pstart] == 0 && pstart < pmid - 1) return -1;

            Int64 sum = 0;
            Int64 rpart = 0;

            for (var i = pmid; i < pend; i++)
            {
                sum = sum*10 + s[i];
            }

            for (var i = pstart; i < pmid; i++)
            {
                rpart = rpart*10 + s[i];
            }
           
            var lpart = sum - rpart;
            if (lpart < 0) return -1;
            if (lpart == 0) return (s[pstart - 1] == 0) ? pstart - 1 : -1;

            var strLpart = lpart.ToString();
            if (strLpart.Length > pstart) return -1;

            Int64 target = 0;
            for (var i = pstart - strLpart.Length; i < pstart; i++)
            {
                target = target*10 + s[i];
            }

            return target == lpart ? pstart - strLpart.Length : -1;
        }
       
    }
}
