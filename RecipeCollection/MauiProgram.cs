using Microsoft.Extensions.Logging;
using RecipeCollection.Views;
using RecipeCollection.ViewModels;

namespace RecipeCollection
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<CategoryPage>();
            builder.Services.AddTransient<CategoryPageViewModel>();
            builder.Services.AddTransient<RecipePage>();
            builder.Services.AddTransient<RecipePageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
