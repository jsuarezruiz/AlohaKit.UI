namespace AlohaKit.UI.Cupertino
{
    public class Switch : SwitchBase
    {
        const float ThumbOffPosition = 15f;
        const float ThumbOnPosition = 36f;

        const float BackgroundWidth = 51;

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
            canvas.SaveState();

            canvas.FillColor = TrackColor;

            var height = 30;
            var width = BackgroundWidth;

            canvas.FillRoundedRectangle(X, Y, width, height, 16f);

            canvas.RestoreState();
        }

        public void DrawThumb(ICanvas canvas, RectF bounds)
        {
            canvas.SaveState();

            canvas.FillColor = ThumbColor;

            var margin = 2;
            var radius = 13;

            var y = Y + margin + radius;

            canvas.SetShadow(new SizeF(0, 1), 2, CanvasDefaults.DefaultShadowColor);

            var cupertinoThumbPosition = X + (IsOn ? ThumbOnPosition : ThumbOffPosition);

            canvas.FillCircle(cupertinoThumbPosition, y, radius);

            canvas.RestoreState();
        }
    }
}