using System;

namespace SortingVisualisation
{
	public class SortFactory
	{
		public static ISortAlgorithm Create (int sortAlgorithm)
		{
			sortAlgorithm = sortAlgorithm % 3;
			ISortAlgorithm sort = null;
			if (sortAlgorithm == 0)
				sort = new QuickSort ();
			else if (sortAlgorithm == 1)
				sort = new BubbleSort ();
			else if (sortAlgorithm == 2)
				sort = new InsertSort ();

			sort.Init ();
			return sort;
		}
	}
}

