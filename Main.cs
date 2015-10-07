using UIKit;
using OpenTK.Platform;
using OpenGLES;

namespace SortingVisualisation
{
	public class Application
	{
		static void Main (string[] args)
		{
			using (var c = Utilities.CreateGraphicsContext(EAGLRenderingAPI.OpenGLES1)) {

				UIApplication.Main (args);

			}
		}
	}

}

