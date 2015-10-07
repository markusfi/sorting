using System;

namespace SortingVisualisation
{
	public interface IColorElement : IMarkable
	{
		byte[] GetSquareColors();
		void SetSquareColors(byte[] array);
	}
}

