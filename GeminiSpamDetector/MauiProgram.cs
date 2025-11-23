using Microsoft.Extensions.Logging;
using GeminiSpamDetector.Services;
using GeminiSpamDetector.ViewModels;

namespace GeminiSpamDetector;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        // Register Services
        builder.Services.AddSingleton<GeminiAnalysisService>();

        // Register ViewModels
        builder.Services.AddTransient<SpamDetectorViewModel>();

        // Register Pages
        builder.Services.AddTransient<MainPage>();

		return builder.Build();
	}
}
