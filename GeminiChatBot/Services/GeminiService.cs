using GenerativeAI;

namespace GeminiChatBot.Services;

public class GeminiService
{
    private readonly GenerativeModel _model;

    public GeminiService()
    {
        var apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("GEMINI_API_KEY environment variable is not set");
        }

        var googleAI = new GoogleAi(apiKey);
        _model = googleAI.CreateGenerativeModel("models/gemini-2.5-flash");
    }

    public async Task<string> SendMessageAsync(string message)
    {
        try
        {
            var response = await _model.GenerateContentAsync(message);
            return response.Text() ?? "No response received";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}
