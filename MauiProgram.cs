using Microsoft.AspNetCore.Components.WebView.Maui;
using LoginFlowInMauiBlazorApp.Data;
using LoginFlowInMauiBlazorApp.Services;
using LoginFlowInMauiBlazorApp.Services.HTTPService;

namespace LoginFlowInMauiBlazorApp;

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
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddScoped<IAppService, AppService>();
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddScoped<IHttpService, HttpService>();

		return builder.Build();
	}
}
