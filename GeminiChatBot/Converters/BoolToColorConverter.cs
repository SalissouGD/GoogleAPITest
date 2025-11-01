using System.Globalization;

namespace GeminiChatBot.Converters;

public class BoolToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isUser)
        {
            // Couleur pour l'utilisateur: bleu, pour l'IA: gris
            return isUser
                ? Color.FromArgb("#4285F4")  // Bleu pour l'utilisateur
                : Color.FromArgb("#E8EAED");  // Gris clair pour l'IA
        }
        return Color.FromArgb("#E8EAED");
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
