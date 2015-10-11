using System;
using System.Collections.Generic;

namespace SortingVisualisation
{
	public class MergeSort : ISortAlgorithm
	{
		string ISortAlgorithm.SortName()
		{
			return "Merge sort";
		}

		void ISortAlgorithm.Init()
		{
		}
		/*
		void ISortAlgorithm.Sort(IMarkable[] elements)
		{
			while (((ISortAlgorithm)this).SortStep (elements)) {
				
			}
		}
		*/
		private void Merge(IMarkable[] array, int start, int middle, int end)
		{
			IMarkable[] merge = new IMarkable[end-start];
			int l = 0, r = 0, i = 0;
			while (l < middle - start && r < end - middle)
			{
				if (i < merge.Length &&
				    middle + r < array.Length &&
					start + l < array.Length) {
					merge [i++] = array [start + l].CompareTo (array [middle + r]) < 0
					? array [start + l++]
					: array [middle + r++];
				} else
					break;
			}

			while (r < end - middle && 
				i < merge.Length &&
				middle + r < array.Length) merge[i++] = array[middle + r++];

			while (l < middle - start &&
				i < merge.Length &&
				start + l < array.Length) merge[i++] = array[start + l++];

			Array.Copy(merge, 0, array, start, Math.Min(merge.Length,array.Length-start));
		}

		int stepWidth = 1;
		int stepJ = 1;

		bool ISortAlgorithm.SortStep(IMarkable[] elements)
		{			
			if (stepWidth <= elements.Length / 2 + 1) {				
				if (stepJ < elements.Length) {
					Merge (elements, stepJ - stepWidth, stepJ, stepJ + stepWidth);
					stepJ += 2 * stepWidth;
					return true;
				} else {
					stepWidth *= 2;
					stepJ = stepWidth;
					return true;
				}
			} else {
				for (int i=0;i<elements.Length-1;i++) {
					if (elements[i].CompareTo(elements[i+1]) > 0) {							
						Merge(elements, 0, i+1, elements.Length);
						break;
					}
				}
				return false;
			}
		}

		void ISortAlgorithm.Sort(IMarkable[] elements)
		{
			for (int width = 1; width <= elements.Length / 2 + 1; width *= 2)
			{
				for (int j = width; j < elements.Length; j += 2 * width)
				{
					Merge (elements, j - width, j, j + width);
				}
			}
			for (int i=0;i<elements.Length-1;i++) {
				if (elements[i].CompareTo(elements[i+1]) > 0) {							
					Merge(elements, 0, i+1, elements.Length);
					break;
				}
			}
		}
	}
}

