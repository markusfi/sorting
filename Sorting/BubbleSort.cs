using System;

namespace SortingVisualisation
{
	public class BubbleSort : ISortAlgorithm
	{
		int i;
		int j;

		string ISortAlgorithm.SortName()
		{
			return "BubbleSort";
		}		
		void ISortAlgorithm.Sort(IMarkable[] elements)
		{
			var max = elements.Length;

			for(int i = 1; i < max; i++)
			{
				for(int j = 0; j < max - i; j++)
				{
					if(elements[j].CompareTo(elements[j + 1]) > 0)
					{
						var temp = elements[j];
						elements[j] = elements[j + 1];
						elements[j + 1] = temp;
					}
				}
			
			}
		}  

		void ISortAlgorithm.Init()
		{
			i = 1;
			j = 0;
		}
		bool ISortAlgorithm.SortStep(IMarkable[] elements)
		{
			foreach (var element in elements)
				element.Reset ();
			
			var max = elements.Length;
			if (i < max && j < max - i) {
				if (elements [j].CompareTo(elements [j + 1]) > 0) {
					var temp = elements [j];
					elements [j] = elements [j + 1];
					elements [j + 1] = temp;
					elements[j].MarkSortedLeft();
					elements[j+1].MarkSortedRight();
				}
			}
			j++;
			if (j >= max - i) {
				j = 0; 
				i++;
				if (i >= max)
					return false;
			}
			return true;
		}  

	}
}

