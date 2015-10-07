using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SortingVisualisation
{
	public class QuickSort : ISortAlgorithm
	{
		List<QuickPosInfo> gList;
		QuickPosInfo gInfo;
		bool repeatPartition = false;

		string ISortAlgorithm.SortName()
		{
			return "QuickSort";
		}
		void ISortAlgorithm.Init ()
		{
			gList = null;
			repeatPartition = false;
		}
		static public int Partition(IMarkable[]  numbers, int left, int right)
		{
			var pivot = numbers[left];
			while (true)
			{
				while (numbers[left].CompareTo(pivot) < 0)
					left++;

				while (numbers[right].CompareTo(pivot) > 0)
					right--;

				if (left < right)
				{
					var temp = numbers[right];
					numbers[right] = numbers[left];
					numbers[left] = temp;
					numbers [right].MarkSortedRight ();
					numbers [left].MarkSortedLeft ();
					return -1;
				}
				else
				{
					return right;
				}
			}
		}

		struct QuickPosInfo
		{
			public int left;
			public int right;
		};

		void ISortAlgorithm.Sort(IMarkable[] numbers)
		{
			ISortAlgorithm qs = new QuickSort ();
			while (qs.SortStep (numbers))
				;
		}

		bool ISortAlgorithm.SortStep(IMarkable[] numbers)
		{
			if (gList == null) {
				gList = new List<QuickPosInfo> ();

				gInfo.left = 0;
				gInfo.right = numbers.Length - 1;
				gList.Insert (gList.Count, gInfo);
			}
			foreach (IMarkable n in numbers)
				n.Reset ();
			while (true) {
				if (gList.Count == 0)
					return false;

				int left = gList [0].left;
				int right = gList [0].right;

				int pivot = Partition (numbers, left, right);   
				repeatPartition = pivot == -1;
				if (repeatPartition)
					return true;
			
				gList.RemoveAt (0);

				if (pivot > 1 &&
				   left < (pivot - 1)) {
					gInfo.left = left;
					gInfo.right = pivot - 1;
					gList.Insert (gList.Count, gInfo);
				}

				if (pivot + 1 < right) {
					gInfo.left = pivot + 1;
					gInfo.right = right;
					gList.Insert (gList.Count, gInfo);
				}

			}
		}
	}
}

