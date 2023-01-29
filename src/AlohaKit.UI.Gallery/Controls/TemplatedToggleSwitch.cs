namespace AlohaKit.UI.Gallery.Controls
{
    public class TemplatedToggleSwitch : TemplatedView
    {
        const string ElementCanvasView = "Part_Canvas";
        const string ElementThumbBorder = "Part_ThumbBorder";
        const string ElementThumb = "Part_Thumb";

        CanvasView _canvasView;
        Path _thumbBorder;
        Path _thumb;

        public static readonly BindableProperty IsOnProperty =
            BindableProperty.Create(nameof(IsOn), typeof(bool), typeof(TemplatedToggleSwitch), true,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    if (newValue != null && bindableObject is TemplatedToggleSwitch toggleSwitch)
                    {
                        toggleSwitch.UpdateIsOn();
                    }
                }); 
        
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(
            nameof(TrackColor),
            typeof(Color),
            typeof(Switch),
            null);

        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(
            nameof(ThumbColor),
            typeof(Color),
            typeof(Switch),
            null);

        public bool IsOn
        {
            get => (bool)GetValue(IsOnProperty);
            set => SetValue(IsOnProperty, value);
        }

        public Color TrackColor
        {
            get => (Color)GetValue(TrackColorProperty);
            set => SetValue(TrackColorProperty, value);
        }

        public Color ThumbColor
        {
            get => (Color)GetValue(ThumbColorProperty);
            set => SetValue(ThumbColorProperty, value);
        }

        public event EventHandler<ToggledEventArgs> Toggled;

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvasView = GetTemplateChild(ElementCanvasView) as CanvasView;
            _thumbBorder = GetTemplateChild(ElementThumbBorder) as Path;
            _thumb = GetTemplateChild(ElementThumb) as Path;

            if (_canvasView != null)
            {
                _canvasView.Drawing += OnCanvasViewDrawing;
                _canvasView.StartInteraction += OnToggleSwitchStartInteraction;
            }

            UpdateIsOn();
        }

        void UpdateIsOn()
        {
            if (IsOn)
            {
                _thumbBorder.X = 43.2f;
                _thumb.X = 43.6f;
            }
            else
            {
                _thumbBorder.X = 3.2f;
               _thumb.X = 3.6f;
            }

            Toggled?.Invoke(this, new ToggledEventArgs(IsOn));

            _canvasView.Invalidate();
        }

        void OnCanvasViewDrawing(object sender, DrawingEventArgs e)
        {
#if DEBUG
            var canvas = e.Canvas;
            var bounds = e.Bounds;
            
            canvas.SaveState();

            canvas.FontSize = 6;

            canvas.DrawString("Drawing from code", 0, 0, bounds.Width, bounds.Height, HorizontalAlignment.Left, VerticalAlignment.Top);

            canvas.RestoreState();
#endif
        }

        void OnToggleSwitchStartInteraction(object sender, TouchEventArgs e)
        {
            IsOn = !IsOn;
        }
    }
}