using Microsoft.Extensions.Logging;
using TesseractOcrMaui;

namespace MauiApp2
{
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
            builder.Services.AddTesseractOcr(
            files =>
            {
                // must have matching files in Resources/Raw folder
                files.AddFile("eng.traineddata");
            });

            // Inject main page, so services are injected to its constructor
            builder.Services.AddSingleton<Pages.MainPage>();

            return builder.Build();
        }
    }
}
