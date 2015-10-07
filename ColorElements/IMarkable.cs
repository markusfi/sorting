using System;

namespace SortingVisualisation
{
	public interface IMarkable : IComparable
	{
		void MarkSortedLeft();
		void MarkSortedRight();
		void Reset ();
	}
}

