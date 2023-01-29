using AlohaKit.UI.Extensions;

namespace AlohaKit.UI
{
    class CanvasViewDrawable : IDrawable
    {
        readonly CanvasView _owner;

        public CanvasViewDrawable(CanvasView owner)
        {
            _owner = owner;
        }

        public void Draw(ICanvas canvas, RectF bounds)
        {
            canvas.SaveState();

            _owner.DrawCore(canvas, bounds);

            canvas.RestoreState();
        }
    }

    public interface ICanvasView : IElement
    {

	}

    [ContentProperty(nameof(Children))]
    public class CanvasView : GraphicsView, ICanvasView, IDisposable
    {
        public CanvasView()
        {
            Children = new ElementsCollection(this);

            Drawable = new CanvasViewDrawable(this);

            StartInteraction += OnCanvasViewStartInteraction;
            EndInteraction += OnCanvasViewEndInteraction;
            CancelInteraction += OnCanvasViewCancelInteraction;
		}

		public ElementsCollection Children { get; internal set; }

        public event EventHandler<DrawingEventArgs> Drawing;

        #region IElement Implementation

        float IVisualElement.X { get => (float)X; set => throw new NotImplementedException(); }
        float IVisualElement.Y { get => (float)Y; set => throw new NotImplementedException(); }
        float IVisualElement.WidthRequest { get => (float)WidthRequest; set => WidthRequest = value; }
        float IVisualElement.HeightRequest { get => (float)HeightRequest; set => HeightRequest = value; }
        Shadow IVisualElement.Shadow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        float IVisualElement.TranslationX { get => (float)TranslationX; set => TranslationX = value; }
        float IVisualElement.TranslationY { get => (float)TranslationY; set => TranslationY = value; }
        float IVisualElement.ScaleX { get => (float)ScaleX; set => ScaleX = value; }
        float IVisualElement.ScaleY { get => (float)ScaleY; set => ScaleY = value; }
        IElement IElement.Parent { get => null; set => throw new NotImplementedException(); }

        public void AttachParent(IElement parent)
        {

        }

        #endregion

        internal void DrawCore(ICanvas canvas, RectF bounds)
        {
            Draw(canvas, bounds);
        }

        public virtual void Draw(ICanvas canvas, RectF bounds)
        {
            foreach (var child in Children)
            {
                if (child.IsVisible)
                {
                    child.Draw(canvas, bounds);
                }
            }

            Drawing?.Invoke(this, new DrawingEventArgs(canvas, bounds));
        }

		void IDisposable.Dispose()
		{
			StartInteraction -= OnCanvasViewStartInteraction;
			EndInteraction -= OnCanvasViewEndInteraction;
			CancelInteraction -= OnCanvasViewCancelInteraction;
		}

        void OnCanvasViewStartInteraction(object sender, TouchEventArgs e)
        {
            var touchPoint = e.Touches[0];

            foreach (var child in Children)
            {
                if (child.IsVisible && child is View view && view.IsInsideBounds(touchPoint))
                {
                    view.StartInteraction(e.Touches);

                    foreach (var gesture in view.GestureRecognizers)
                    {
                        if (gesture is TapGestureRecognizer tapGestureRecognizer)
                            tapGestureRecognizer.SendTapped(view);
                    }
                }
            }
        }

        void OnCanvasViewEndInteraction(object sender, TouchEventArgs e)
		{
			var touchPoint = e.Touches[0];

			foreach (var child in Children)
            {
                if (child.IsVisible && child is View view && view.IsInsideBounds(touchPoint))
                {
                    view.EndInteraction(e.Touches, e.IsInsideBounds);
                }
            }
		}

        void OnCanvasViewCancelInteraction(object sender, EventArgs e)
		{
			foreach (var child in Children)
			{
				if (child.IsVisible && child is View view)
				{
					view.CancelInteraction();
				}
			}
		}
    }
}