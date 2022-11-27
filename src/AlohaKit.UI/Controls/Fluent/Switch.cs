namespace AlohaKit.UI.Fluent
{
    public class Switch : SwitchBase
    {
        const float ThumbOffPosition = 10f;
        const float ThumbOnPosition = 30f;

        const float BackgroundWidth = 40;

        public override void Draw(ICanvas canvas, RectF bounds)
        {
            canvas.SaveState();

            base.Draw(canvas, bounds);

            DrawBackground(canvas, bounds);
            DrawThumb(canvas, bounds);

            canvas.RestoreState();
        }

        public void DrawBackground(ICanvas canvas, RectF bounds)
        {
            var strokeWidth = 1;

            canvas.SaveState();

            canvas.FillColor = canvas.StrokeColor = TrackColor;

            var height = 20;
            var width = BackgroundWidth;

            canvas.StrokeSize = strokeWidth;

            canvas.DrawRoundedRectangle(X, Y, width, height, 10);
            canvas.FillRoundedRectangle(X, Y, width, height, 10);

            canvas.RestoreState();
        }

        public void DrawThumb(ICanvas canvas, RectF bounds)
        {
            canvas.SaveState();

            canvas.FillColor = ThumbColor;

            var margin = 4;
            var radius = 6;

            var y = Y + margin + radius;

            var thumbPosition = X + (IsOn ? ThumbOnPosition : ThumbOffPosition);
            canvas.FillCircle(thumbPosition, y, radius);

            canvas.RestoreState();
        }
    }
}