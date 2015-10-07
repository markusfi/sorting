using System;
using System.Collections;
using UIKit;
using CoreAnimation;
using OpenTK.Platform.iPhoneOS;
using Foundation;
using OpenTK.Graphics;
using OpenGLES;
using OpenTK.Graphics.ES11;
using ObjCRuntime;

namespace SortingVisualisation
{
	public partial class EAGLView : UIView
	{
		public SortingVisualisationAppDelegate appDelegate; 

		int BackingWidth;
		int BackingHeight;
		iPhoneOSGraphicsContext Context;
		uint ViewRenderBuffer, ViewFrameBuffer;
		uint DepthRenderBuffer;
		NSTimer AnimationTimer;
		internal double AnimationInterval;

		const bool UseDepthBuffer = false;

		[Export ("layerClass")]
		public static Class LayerClass ()
		{
			return new Class (typeof (CAEAGLLayer));
		}

		[Export ("initWithCoder:")]
		public EAGLView (NSCoder coder) : base (coder)
		{
			CAEAGLLayer eaglLayer = (CAEAGLLayer) Layer;
			eaglLayer.Opaque = true;
			eaglLayer.DrawableProperties = new NSDictionary (
				EAGLDrawableProperty.RetainedBacking, false,
				EAGLDrawableProperty.ColorFormat, EAGLColorFormat.RGBA8
			);
			Context = (iPhoneOSGraphicsContext) ((IGraphicsContextInternal) GraphicsContext.CurrentContext).Implementation;

			Context.MakeCurrent(null);
			AnimationInterval = 1.0 / 60.0;		
		}
			
		ColorContainer _myColorContainer = null;
		public ColorContainer MyColorContainer {
			get {
				if (_myColorContainer == null) {
					bool color = appDelegate.ColorSwitch.On;
					anzahlElemente = Math.Max (3, Math.Min (255, (int)(appDelegate.Slider.Value * 255f)));
					_myColorContainer = new ColorContainer (color ? ElementTyp.Color : ElementTyp.BlackAndWhite, anzahlElemente);
				}
				return _myColorContainer;
			}
		}

		public void Reset() 
		{
			finish = false;
			sort = null;
			sortstep = 0;
			anzahlIterationen = 0;
			_myColorContainer = null;
			sortAlgorithm = Math.Max(0,Math.Min(2,(int)appDelegate.SegmentedControl.SelectedSegment));
		}

		ISortAlgorithm sort = null;
		bool finish = false;
		int sortstep = 0;
		int sortAlgorithm = 0;
		int anzahlIterationen = 0;
		int anzahlElemente = 0;

		void DrawView ()
		{
			Context.MakeCurrent(null);
			GL.Oes.BindFramebuffer (All.FramebufferOes, ViewFrameBuffer);
			GL.Viewport (0, 0, BackingWidth, BackingHeight);

			GL.MatrixMode (All.Projection);
			GL.LoadIdentity ();
			// GL.Ortho (-0.55f, 0.55f, -1.5f, 1.5f, -1.0f, 1.0f);
			GL.Ortho (-0.5f, 0.5f, -0.5f, 0.5f, -1.0f, 1.0f);
			GL.MatrixMode (All.Modelview);
			//if (finish)
			//	GL.Rotate (3.0f, 0.0f, 0.0f, 1.0f);

			GL.ClearColor (1f, 1f, 1f, 1.0f);
			GL.Clear (ClearBufferMask.ColorBufferBit);

			float[] squareVerticesD = new float[8];
			float countX = MyColorContainer.ColorElements.Length;
			float countY = 1f;
			int i = 0;
			for (float x = 0; x < countX; x+=1f) {
				for (float y = 0; y < countY; y+=1f) {
					var dx = x / countX;
					var dy = y / countY;
					float sizeX = 1 / (countX * 1f);
					float sizeY = 1 / (countY * 1f);
					squareVerticesD [0] = -0.5f + dx;
					squareVerticesD [1] = -0.5f + dy;
					squareVerticesD [2] = -0.5f + sizeX + dx;
					squareVerticesD [3] = -0.5f + dy;
					squareVerticesD [4] = -0.5f + dx;
					squareVerticesD [5] = -0.5f + sizeY + dy;
					squareVerticesD [6] = -0.5f + sizeX + dx;
					squareVerticesD [7] = -0.5f + sizeY + dy;
					GL.VertexPointer (2, All.Float, 0, squareVerticesD);
					GL.EnableClientState (All.VertexArray);
					GL.ColorPointer (4, All.UnsignedByte, 0, MyColorContainer.ColorElement(i));
					i = (i + 1) % 255;
					GL.EnableClientState (All.ColorArray);
					GL.DrawArrays (All.TriangleStrip, 0, 4);
				}
			}
			if (!finish) {
				if (sort == null) {
					sort = SortFactory.Create (sortAlgorithm);
					appDelegate.SetSortName (sort.SortName ());
					appDelegate.SegmentedControl.SelectedSegment = sortAlgorithm % 3;
				}
				sortstep++;
				if (AnimationInterval != 0 &&
				    sortstep % (int)((1 / AnimationInterval) / 30) == 0) {
					finish = !sort.SortStep (MyColorContainer.ColorElements);
					appDelegate.AnzahlIterationenLabel.Text = string.Format ("Iterationen {0} bei {1} Elementen", ++this.anzahlIterationen, anzahlElemente);
				}
			} else {
				if (sort != null) {
					sortAlgorithm++;
					sort = null;
					sortstep = 0;
					anzahlIterationen = 0;
				}
				sortstep++;
				if (AnimationInterval != 0 &&
					sortstep % (int)((1 / AnimationInterval) * 5) == 0) {
					finish = false;
					MyColorContainer.Randomize (1000);
				}
			}

			// MyColorContainer.Sort ();

			GL.Oes.BindRenderbuffer (All.RenderbufferOes, ViewRenderBuffer);
			Context.EAGLContext.PresentRenderBuffer ((uint) All.RenderbufferOes);
		}

		public override void LayoutSubviews ()
		{
			Context.MakeCurrent(null);
			DestroyFrameBuffer ();
			CreateFrameBuffer ();
			DrawView ();
		}

		bool CreateFrameBuffer ()
		{
			GL.Oes.GenFramebuffers (1, out ViewFrameBuffer);
			GL.Oes.GenRenderbuffers (1, out ViewRenderBuffer);

			GL.Oes.BindFramebuffer (All.FramebufferOes, ViewFrameBuffer);
			GL.Oes.BindRenderbuffer (All.RenderbufferOes, ViewRenderBuffer);
			Context.EAGLContext.RenderBufferStorage ((uint) All.RenderbufferOes, (CAEAGLLayer) Layer);
			GL.Oes.FramebufferRenderbuffer (All.FramebufferOes,
				All.ColorAttachment0Oes,
				All.RenderbufferOes,
				ViewRenderBuffer);

			GL.Oes.GetRenderbufferParameter (All.RenderbufferOes, All.RenderbufferWidthOes, out BackingWidth);
			GL.Oes.GetRenderbufferParameter (All.RenderbufferOes, All.RenderbufferHeightOes, out BackingHeight);

			if (GL.Oes.CheckFramebufferStatus (All.FramebufferOes) != All.FramebufferCompleteOes) {
				Console.Error.WriteLine("failed to make complete framebuffer object {0}",
					GL.Oes.CheckFramebufferStatus (All.FramebufferOes));
			}
			return true;
		}

		void DestroyFrameBuffer ()
		{
			GL.Oes.DeleteFramebuffers (1, ref ViewFrameBuffer);
			ViewFrameBuffer = 0;
			GL.Oes.DeleteRenderbuffers (1, ref ViewRenderBuffer);
			ViewRenderBuffer = 0;

			if (DepthRenderBuffer != 0) {
				GL.Oes.DeleteRenderbuffers (1, ref DepthRenderBuffer);
				DepthRenderBuffer = 0;
			}
		}

		public void StartAnimation ()
		{
			AnimationTimer = NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromSeconds (1/60.0), (d) => DrawView ());
		}

		public void StopAnimation ()
		{
			AnimationTimer = null;
		}

		public void SetAnimationTimer (NSTimer timer)
		{
			AnimationTimer.Invalidate ();
			AnimationTimer = timer;
		}

		public void SetAnimationInterval (double interval)
		{
			AnimationInterval = interval;
			if (AnimationTimer != null) {
				StopAnimation ();
				StartAnimation ();
			}
		}
	}
}

