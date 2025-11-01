using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GeminiChatBot.Models;
using GeminiChatBot.Services;

namespace GeminiChatBot.ViewModels;

public partial class ChatViewModel : ObservableObject
{
    private readonly GeminiService _geminiService;

    [ObservableProperty]
    private string _userMessage = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

    public ObservableCollection<ChatMessage> Messages { get; } = new();

    public ChatViewModel(GeminiService geminiService)
    {
        _geminiService = geminiService;

        // Message de bienvenue
        Messages.Add(new ChatMessage
        {
            Text = "Bonjour! Je suis votre assistant IA alimenté par Gemini. Comment puis-je vous aider aujourd'hui?",
            IsUser = false,
            Timestamp = DateTime.Now
        });
    }

    [RelayCommand]
    private async Task SendMessageAsync()
    {
        if (string.IsNullOrWhiteSpace(UserMessage) || IsBusy)
            return;

        var messageText = UserMessage;
        UserMessage = string.Empty;

        // Ajouter le message de l'utilisateur
        Messages.Add(new ChatMessage
        {
            Text = messageText,
            IsUser = true,
            Timestamp = DateTime.Now
        });

        IsBusy = true;

        try
        {
            // Obtenir la réponse de Gemini
            var response = await _geminiService.SendMessageAsync(messageText);

            // Ajouter la réponse de l'IA
            Messages.Add(new ChatMessage
            {
                Text = response,
                IsUser = false,
                Timestamp = DateTime.Now
            });
        }
        catch (Exception ex)
        {
            Messages.Add(new ChatMessage
            {
                Text = $"Erreur: {ex.Message}",
                IsUser = false,
                Timestamp = DateTime.Now
            });
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void ClearChat()
    {
        Messages.Clear();
        Messages.Add(new ChatMessage
        {
            Text = "Bonjour! Je suis votre assistant IA alimenté par Gemini. Comment puis-je vous aider aujourd'hui?",
            IsUser = false,
            Timestamp = DateTime.Now
        });
    }
}
