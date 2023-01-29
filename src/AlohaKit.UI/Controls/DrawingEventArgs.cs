namespace AlohaKit.UI
{
    public class DrawingEventArgs : EventArgs
    {
        public DrawingEventArgs(ICanvas canvas, RectF bounds)
        {
            Canvas = canvas;
            Bounds = bounds;
        }

        public ICanvas Canvas { get; set; }
        public RectF Bounds { get; set; }
    }
}