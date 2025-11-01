using System.Globalization;

namespace GeminiChatBot.Converters;

public class BoolToMarginConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isUser)
        {
            // Messages de l'utilisateur alignés à droite, de l'IA à gauche
            return isUser
                ? new Thickness(60, 0, 0, 0)  // Marge à gauche pour pousser à droite
                : new Thickness(0, 0, 60, 0);  // Marge à droite pour garder à gauche
        }
        return new Thickness(0, 0, 60, 0);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
