namespace AlohaKit.UI
{
    public abstract class SwitchBase : View
	{
        public static readonly BindableProperty IsOnProperty =
            BindableProperty.Create(nameof(IsOn), typeof(bool), typeof(SwitchBase), false,
                propertyChanged: InvalidatePropertyChanged);

        public static readonly BindableProperty TrackColorProperty =
            BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(SwitchBase), Colors.Black,
                propertyChanged: InvalidatePropertyChanged);

        public static readonly BindableProperty ThumbColorProperty =
           BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(SwitchBase), Colors.White,
               propertyChanged: InvalidatePropertyChanged);

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

        public override void StartInteraction(PointF[] points)
        {
            base.StartInteraction(points);

            IsOn = !IsOn;
        }
    }
        
	public class Switch :
#if ANDROID
        Material.Switch
#elif IOS || MACCATALYST
		Cupertino.Switch
#elif WINDOWS
		Fluent.Switch
#else
		Material.Switch
#endif
	{

	}
}