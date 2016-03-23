using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc.AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }


    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            ListNode tail = null;

            var op1 = l1;
            var op2 = l2;
            bool carry = false;

            while (op1 != null || op2 != null)
            {
                var value = carry? 1: 0;

                if (op1 != null)
                {
                    value += op1.val;
                    op1 = op1.next;
                }

                if (op2 != null)
                {
                    value += op2.val;
                    op2 = op2.next;
                }

                if (value > 9)
                {
                    value -= 10;
                    carry = true;
                }
                else
                {
                    carry = false;
                }

                var node = new ListNode(value);
                if (result == null)
                {
                    result = node;
                    tail = node;
                }
                else
                {
                    tail.next = node;
                    tail = node;
                }                
            }

            if (carry) tail.next = new ListNode(1);

            return result;
        }
    }
}
