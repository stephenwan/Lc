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
                        var next = getNextPoint(num, pstart, pmid, pend);

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

        private int getNextPoint(string s, int pstart, int pmid, int pend)
        {
            if (pstart == 0) return -1;
            if (s[pmid] == '0' && pmid < pend - 1) return -1;
            if (s[pstart] == '0' && pstart < pmid - 1) return -1;
             
            var sum = Int64.Parse(s.Substring(pmid, pend - pmid));
            var rpart = Int64.Parse(s.Substring(pstart, pmid - pstart));
         
            var lpart = sum - rpart;
            if (lpart < 0) return -1;
            if (lpart == 0) return (s[pstart - 1] == '0') ? pstart - 1 : -1;


            var strLpart = lpart.ToString();
            if (strLpart.Length > pstart) return -1;

            return s.Substring(pstart - strLpart.Length, strLpart.Length) == strLpart
                ? pstart - strLpart.Length
                : -1;
        }
       
    }
}
