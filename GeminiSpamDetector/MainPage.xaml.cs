using GeminiSpamDetector.ViewModels;

namespace GeminiSpamDetector;

public partial class MainPage : ContentPage
{
	public MainPage(SpamDetectorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
