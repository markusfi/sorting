using System;

namespace SortingVisualisation
{
	public class SortFactory
	{
		public static ISortAlgorithm Create (int sortAlgorithm)
		{
			sortAlgorithm = sortAlgorithm % 4;
			ISortAlgorithm sort = null;
			if (sortAlgorithm == 0)
				sort = new QuickSort ();
			else if (sortAlgorithm == 1)
				sort = new BubbleSort ();
			else if (sortAlgorithm == 2)
				sort = new InsertSort ();
			else if (sortAlgorithm == 3)
				sort = new MergeSort ();

			sort.Init ();
			return sort;
		}
	}
}

