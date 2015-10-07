using System;

namespace SortingVisualisation
{
	public class BlackAndWhiteElement: IComparable, IMarkable, IColorElement
	{
		byte[] squareColors;
		byte[] IColorElement.GetSquareColors() {
			return this.squareColors;
		}
		void IColorElement.SetSquareColors(byte[] sq)
		{
			this.squareColors = sq;
		}
		public BlackAndWhiteElement(float color)
		{
			color = color * 255f;
			squareColors = new byte[16];
			for (int j=0;j<4;j++) {					
				squareColors [j * 4 + 0] = (byte)(color % 255);
				squareColors [j * 4 + 1] = (byte)(color % 255);
				squareColors [j * 4 + 2] = (byte)(color % 255);
				squareColors [j * 4 + 3] = 0;
			}
		}
		int IComparable.CompareTo (object obj)
		{
			var objElement = obj as IColorElement;
			return this.squareColors [0].CompareTo (objElement.GetSquareColors() [0]);
		}
		void IMarkable.MarkSortedLeft() {
			// squareColors [1] = squareColors [1+4] = 0;
		}
		void IMarkable.MarkSortedRight() {
			// squareColors [2] = squareColors [2+4] = 0;
		}
		void IMarkable.Reset() {
			// squareColors [1] = squareColors [2] = squareColors [1+4] = squareColors [2+4] =squareColors [0];
		}
	}
}

