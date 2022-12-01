namespace AlohaKit.UI.Extensions
{
    public static class SwitchExtensions
    {
        public static T IsOn<T>(this T sw, bool isOn) where T : Switch
        {
            sw.IsOn = isOn;

            return sw;
        }

        public static T TrackColor<T>(this T sw, Color trackColor) where T : Switch
        {
            sw.TrackColor = trackColor;

            return sw;
        }

        public static T ThumbColor<T>(this T sw, Color thumbColor) where T : Switch
        {
            sw.ThumbColor = thumbColor;

            return sw;
        }
    }
}
