using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GeminiSpamDetector.Services;

namespace GeminiSpamDetector.ViewModels;

public partial class SpamDetectorViewModel : ObservableObject
{
    private readonly GeminiAnalysisService _geminiService;

    [ObservableProperty]
    private string _senderInput;

    [ObservableProperty]
    private string _subjectInput;

    [ObservableProperty]
    private string _bodyInput;

    [ObservableProperty]
    private string _analysisResult;

    [ObservableProperty]
    private Color _resultColor = Colors.Gray;

    [ObservableProperty]
    private bool _isBusy;

    public SpamDetectorViewModel(GeminiAnalysisService service)
    {
        _geminiService = service;
    }

    [RelayCommand]
    private async Task AnalyzeSpamAsync()
    {
        if (IsBusy) return;

        if (string.IsNullOrWhiteSpace(SenderInput) || string.IsNullOrWhiteSpace(BodyInput))
        {
            AnalysisResult = "Veuillez remplir au moins l'expéditeur et le contenu.";
            return;
        }

        IsBusy = true;
        AnalysisResult = "Analyse en cours par Gemini...";
        ResultColor = Colors.Gray;

        try
        {
            var result = await _geminiService.AnalyzeEmailAsync(SenderInput, SubjectInput, BodyInput);
            AnalysisResult = result;

            // Coloration simple selon le résultat
            if (result.Contains("STATUT: [SPAM]"))
                ResultColor = Colors.Red;
            else if (result.Contains("STATUT: [SAFE]"))
                ResultColor = Colors.Green;
            else
                ResultColor = Colors.Orange; // Incertain ou erreur
        }
        finally
        {
            IsBusy = false;
        }
    }
}
