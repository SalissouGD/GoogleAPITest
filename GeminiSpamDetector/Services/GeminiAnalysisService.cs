using GenerativeAI;

namespace GeminiSpamDetector.Services;

public class GeminiAnalysisService
{
    private readonly GenerativeModel _model;

    public GeminiAnalysisService()
    {
        var apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY"); 
        // Note: En production mobile, utilisez SecureStorage pour la clé API
        
        if (string.IsNullOrEmpty(apiKey))
        {
             // Fallback or error handling if needed, but for now we assume it's set as per instructions
             // You might want to hardcode it for testing if env var isn't picked up in the emulator easily
        }

        var googleAI = new GoogleAi(apiKey);
        
        // On utilise Flash pour la rapidité d'analyse
        _model = googleAI.CreateGenerativeModel("models/gemini-2.5-flash");
    }

    public async Task<string> AnalyzeEmailAsync(string sender, string subject, string body)
    {
        // Construction du prompt spécifique pour la détection
        string prompt = $@"
        Tu es un système anti-spam avancé. Analyse les informations suivantes :
        
        EXPÉDITEUR: {sender}
        OBJET: {subject}
        CORPS DU MESSAGE: {body}
        
        Ta mission : Déterminer si c'est un Spam/Phishing ou un mail Légitime.
        
        Format de réponse obligatoire :
        STATUT: [SPAM] ou [SAFE]
        ANALYSE: [Explication concise en 2 phrases max sur les indices trouvés]
        ";

        try
        {
            var response = await _model.GenerateContentAsync(prompt);
            return response.Text() ?? "Analyse impossible.";
        }
        catch (Exception ex)
        {
            return $"Erreur lors de l'analyse : {ex.Message}";
        }
    }
}
