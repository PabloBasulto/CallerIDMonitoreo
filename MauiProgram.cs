using Microsoft.Extensions.Logging;

namespace CIDVista;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        // Registro de servicios de datos
        builder.Services.AddSingleton<DBService>();
        builder.Services.AddSingleton<DetectLlamada>();
		builder.Services.AddSingleton<LlamadaService>();
        
        // Registro de la arquitectura MVVM
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
