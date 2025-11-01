using System.Globalization;

namespace GeminiChatBot.Converters;

public class BoolToTextColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isUser)
        {
            // Texte blanc pour l'utilisateur, noir pour l'IA
            return isUser
                ? Colors.White
                : Color.FromArgb("#1A1A1A");
        }
        return Color.FromArgb("#1A1A1A");
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
