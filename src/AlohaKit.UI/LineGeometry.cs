namespace AlohaKit.UI
{
    public class LineGeometry : Geometry
    {
        public LineGeometry()
        {

        }

        public LineGeometry(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public static readonly BindableProperty StartPointProperty =
            BindableProperty.Create(nameof(StartPoint), typeof(Point), typeof(LineGeometry), new Point());

        public static readonly BindableProperty EndPointProperty =
            BindableProperty.Create(nameof(EndPoint), typeof(Point), typeof(LineGeometry), new Point());

        public Point StartPoint
        {
            set { SetValue(StartPointProperty, value); }
            get { return (Point)GetValue(StartPointProperty); }
        }

        public Point EndPoint
        {
            set { SetValue(EndPointProperty, value); }
            get { return (Point)GetValue(EndPointProperty); }
        }

        public override void AppendPath(PathF path, Rect viewBounds)
        {
            float startPointX = (float)(viewBounds.X + StartPoint.X);
            float startPointY = (float)(viewBounds.Y + StartPoint.Y);

            float endPointX = (float)(viewBounds.X + EndPoint.X);
            float endPointY = (float)(viewBounds.Y + EndPoint.Y);

            path.Move(startPointX, startPointY);
            path.LineTo(endPointX, endPointY);
        }
    }
}