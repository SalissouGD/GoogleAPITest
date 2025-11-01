using GeminiChatBot.ViewModels;

namespace GeminiChatBot;

public partial class MainPage : ContentPage
{
	public MainPage(ChatViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

