using System;

namespace SortingVisualisation
{
	public class InsertSort : ISortAlgorithm
	{
		int i,j;

		string ISortAlgorithm.SortName()
		{
			return "Insertion sort";
		}

		void ISortAlgorithm.Init()
		{
			i = 1;
			j = 1;
		}
		void ISortAlgorithm.Sort(IMarkable[] elements)
		{
			int max = elements.Length;
			for(int i = 1; i < max; i++)
			{
				int j = i;
				while(j > 0)
				{
					if (elements [j - 1].CompareTo (elements [j]) > 0) {
						var temp = elements [j - 1];
						elements [j - 1] = elements [j];
						elements [j] = temp;
						j--;
					}
					else
						break;
				}
			}
		}
		bool ISortAlgorithm.SortStep(IMarkable[] elements)
		{
			int max = elements.Length;
			foreach (var element in elements)
				element.Reset ();
			
			if (elements [j - 1].CompareTo (elements [j]) > 0) {
				var temp = elements [j - 1];
				elements [j - 1] = elements [j];
				elements [j] = temp;

				elements [i-1].MarkSortedRight ();
				elements [j].MarkSortedLeft ();
				j--;
			} else
				j = 0;

			if (j <= 0) {				
				i++;
				j = i;
				if (i >= max)
					return false;
			}
			return true;
		}
	}
}

