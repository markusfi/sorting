using System;

namespace SortingVisualisation
{
	public interface ISortAlgorithm
	{
		void Init();
		void Sort(IMarkable[] elements);
		bool SortStep(IMarkable[] elements);

		string SortName();
	}
}

