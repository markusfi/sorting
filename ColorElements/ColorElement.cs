using System;
using System.Collections;

namespace SortingVisualisation
{
	
	public class ColorElement : IComparable, IMarkable, IColorElement
	{
		byte[] squareColors;
		int lamda;

		byte[] IColorElement.GetSquareColors() {
			return this.squareColors;
		}
		void IColorElement.SetSquareColors(byte[] sq)
		{
			this.squareColors = sq;
		}
		public ColorElement(float color)
		{
			// color is 0..1 
			float lamdaBorderLow = 50;
			float lamdaBorderHigh = 100;
			this.lamda = (int) (color * (Const.SpektrumLambdaMax - lamdaBorderHigh - (Const.SpektrumLambdaMin + lamdaBorderLow)) + Const.SpektrumLambdaMin + lamdaBorderLow);
			// lamda is Min..Max
			var rgb = Farbmetrik.LambdaToRGB (this.lamda);

			squareColors = new byte[16];
			for (int j=0;j<4;j++) {					
				squareColors [j * 4 + 0] = rgb.R;
				squareColors [j * 4 + 1] = rgb.G;
				squareColors [j * 4 + 2] = rgb.B;
				squareColors [j * 4 + 3] = 255;
			}
		}
		int IComparable.CompareTo (object obj)
		{
			var objElement = obj as ColorElement;
			return this.lamda.CompareTo (objElement.lamda);
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

