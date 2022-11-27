namespace AlohaKit.UI
{
    public class RectangleGeometry : Geometry
    {
        public RectangleGeometry()
        {

        }

        public RectangleGeometry(Rect rect)
        {
            Rect = rect;
        }

        public static readonly BindableProperty RectProperty =
            BindableProperty.Create(nameof(Rect), typeof(Rect), typeof(RectangleGeometry), new Rect());

        public Rect Rect
        {
            set { SetValue(RectProperty, value); }
            get { return (Rect)GetValue(RectProperty); }
        }

        public override void AppendPath(PathF path, Rect viewBounds)
        {
            float x = (float)(viewBounds.X + Rect.X);
            float y = (float)(viewBounds.Y + Rect.Y);
            float w = (float)Rect.Width;
            float h = (float)Rect.Height;

            path.AppendRectangle(x, y, w, h);
        }
    }
}
