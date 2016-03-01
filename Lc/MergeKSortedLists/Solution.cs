using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc.MergeKSortedLists
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


    public class FixedSizeMinHeap<T> where T : IComparable<T>
    {
        private readonly T[] _container;

        public FixedSizeMinHeap(int size)
        {
            _container = new T[size];
        }

        public void Build(T[] elements)
        {
            for (var i = 0; i < elements.Length; i++)
            {
                _container[i] = elements[i];
            }

            var processLength = (elements.Length - 1) / 2;            
            while (processLength > 0)
            {
                var bottomStartIdx = (processLength - 1)/2;
                var bottomEndIdx = processLength - 1;
                
                for (var i = bottomStartIdx; i <= bottomEndIdx; i++)
                {
                    sink(i);
                }
                processLength = (processLength - 1)/2;
            }
        }

	    public T GetMin()
	    {
		    return _container[0];
	    }

	    public void ReplaceMin(T element)
	    {		   
		    _container[0] = element;
			sink(0);		  
	    }

        public T[] GetRepresentation()
        {
            return _container;
        }

        private void swap(int i, int j)
        {
            var temp = _container[i];           
            _container[i] = _container[j];
            _container[j] = temp;
        }

        private void sink(int idx)
        {           
            while (true)
            {
                var left = idx * 2 + 1;
                var right = idx * 2 + 2;

                if (right > _container.Length - 1) break;

                if (_container[left].CompareTo(_container[right]) > 0)
                {
                    if (_container[idx].CompareTo(_container[right]) > 0)
                    {
                        swap(idx, right);
                        idx = right;
                    }
                    else break;

                }
                else
                {
                    if (_container[idx].CompareTo(_container[left]) > 0)
                    {
                        swap(idx, left);
                        idx = left;
                    }
                    else break;
                }
            }               
        }        
    }

	class TrackElement : IComparable<TrackElement>
	{
		public int ListIdx { get; set; }
		public int Value { get; set; }

		public TrackElement(int listIdx, int value)
		{
			ListIdx = listIdx;
			Value = value;
		}
		
		public int CompareTo(TrackElement other)
		{
			return Value.CompareTo(other.Value);
		}
	}

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {			
	        var trackLists = new ListNode[lists.Length];				
			
	        ListNode result = null;
	        ListNode resultTail = null;

	        var heapSize = GetHeapSize(lists);
	        if (heapSize <= 0) return null;

			var heapInitializer = new TrackElement[heapSize];
			var heap = new FixedSizeMinHeap<TrackElement>(heapSize);

	        for (var i = 0; i < heapSize; i++)
	        {
		        if (i < lists.Length && lists[i] != null)
		        {
			        heapInitializer[i] = new TrackElement(i, lists[i].val);
			        trackLists[i] = lists[i].next;
		        }
				else heapInitializer[i] = new TrackElement(-1, Int32.MaxValue);
	        }

			heap.Build(heapInitializer);

	        while (true)
	        {
		        var element = heap.GetMin();
		        if (element.ListIdx >= 0)
		        {
			        if (trackLists[element.ListIdx] != null)
			        {
				        heap.ReplaceMin(new TrackElement(element.ListIdx, trackLists[element.ListIdx].val));
				        trackLists[element.ListIdx] = trackLists[element.ListIdx].next;
			        }
			        else
			        {
				        heap.ReplaceMin(new TrackElement(-1, Int32.MaxValue));
			        }

			        if (result == null)
			        {
				        result = new ListNode(element.Value);
				        resultTail = result;
			        }
			        else
			        {
						resultTail.next = new ListNode(element.Value);
				        resultTail = resultTail.next;
			        }
		        }
		        else break;
	        }

            return result;
        }

	    public int GetHeapSize(ListNode[] lists)
	    {
			return (int)Math.Pow(2, Math.Ceiling(Math.Log(lists.Length + 1, 2))) - 1; 
	    }
    }
}
