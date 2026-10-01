using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using TBH.DND.Android.Services;
using TBH.DND.Android.ViewModels;
using TBH.DND.Android.Views;

namespace TBH.DND.Android
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

            // Register app services and viewmodels
            builder.Services.AddSingleton<SpellDatabase>();
            builder.Services.AddSingleton<FeatDatabase>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<SpellAllViewModel>();
            builder.Services.AddTransient<SpellEditorViewModel>();

            // Pages can resolve viewmodels from DI when needed
            builder.Services.AddTransient<SpellEditorPage>();
            builder.Services.AddTransient<SpellAllPage>();
            builder.Services.AddSingleton<MainPage>();

            var app = builder.Build();

            // expose services for code-behind resolution
            App.Services = app.Services;

            return app;
        }
    }
}
