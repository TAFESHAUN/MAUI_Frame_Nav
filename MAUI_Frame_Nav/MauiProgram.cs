using MAUI_Frame_Nav.Components;
using MAUI_Frame_Nav.ViewModels;
using Microsoft.Extensions.Logging;

namespace MAUI_Frame_Nav
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

            //builder.Services.AddTransient<ProductDetailsView>();
            //builder.Services.AddTransient<ProductDetailsViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}