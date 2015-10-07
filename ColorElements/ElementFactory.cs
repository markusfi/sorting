using System;

namespace SortingVisualisation
{
	public enum ElementTyp { BlackAndWhite, Color }

	public class ElementFactory
	{
		public static IColorElement CreateElement (ElementTyp elementTyp, float color)
		{
			if (elementTyp == ElementTyp.BlackAndWhite)
				return new BlackAndWhiteElement (color);
			else 
				return new ColorElement (color);
		}
		public static IColorElement[] CreateElementArray(ElementTyp elementTyp, int length)
		{
			if (elementTyp == ElementTyp.BlackAndWhite)
				return new BlackAndWhiteElement[length];
			else 
				return new ColorElement[length];
		}
	}
}

