namespace AlohaKit.UI.Material
{
    public class Switch : SwitchBase
    {
        const float ThumbOffPosition = 12f;
        const float ThumbOnPosition = 34f;

        const float BackgroundWidth = 34;
        const float BackgroundMargin = 5;

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

            var margin = BackgroundMargin;

            var x = X + margin;
            var y = Y + margin;

            var height = 14;
            var width = BackgroundWidth;

            canvas.FillRoundedRectangle(x, y, width, height, 8);

            canvas.RestoreState();
        }

        public void DrawThumb(ICanvas canvas, RectF bounds)
        {
            canvas.SaveState();

            canvas.FillColor = ThumbColor;
           
            var margin = 2;
            var radius = 10;

            var y = Y + margin + radius;

            canvas.SetShadow(new SizeF(0, 1), 2, CanvasDefaults.DefaultShadowColor);

            var thumbPosition = X + (IsOn ? ThumbOnPosition : ThumbOffPosition);

            canvas.FillCircle(thumbPosition, y, radius);

            canvas.RestoreState();
        }
    }
}