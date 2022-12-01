namespace AlohaKit.UI.Extensions
{
    public static class ButtonExtensions
    {
        public static T Text<T>(this T button, string text) where T : Button
        {
            button.Text = text;

            return button;
        }

        public static T TextColor<T>(this T button, Color textColor) where T : Button
        {
            button.TextColor = textColor;

            return button;
        }

        public static T FontSize<T>(this T button, double fontSize) where T : Button
        {
            button.FontSize = fontSize;

            return button;
        }
    }
}