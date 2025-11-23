namespace GeminiSpamDetector.Models;

public class EmailData
{
    public string Sender { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
