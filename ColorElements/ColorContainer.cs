using System;

namespace SortingVisualisation
{
	public class ColorContainer 
	{
		public IColorElement[] ColorElements;
		public ColorContainer(ElementTyp elementTyp, int count)
		{
			ColorElements = ElementFactory.CreateElementArray (elementTyp, count);
			for (byte i = 0; i < count; i++) {
				ColorElements [i] = ElementFactory.CreateElement(elementTyp, (float)(i + 1f) / (float)count);
			}
			Randomize(1000);
		}
		public byte[] ColorElement(int pos)
		{
			return ColorElements [pos % ColorElements.Length].GetSquareColors();
		}
		void Swap (int first, int last) {
			var save = ColorElements [first];
			ColorElements [first] = ColorElements [last];
			ColorElements [last] = save;
		}
		public void Randomize(int maxRound) {

			var r = new Random ();
			for (int round = 0; round < maxRound; round++) {
				Swap (r.Next () % ColorElements.Length, r.Next () % ColorElements.Length);
			}
		}
	}
}

