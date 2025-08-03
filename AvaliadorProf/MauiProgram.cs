#if ANDROID
using Android.Content.Res;
#endif
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PanCardView;
using Microsoft.Maui.Handlers;
using AvaliadorProf.MVVM.ViewModels;
using Microsoft.Maui.Controls.Internals;
#if ANDROID
using AvaliadorProf.Platforms.Android;
using AvaliadorProf.Controls;
#endif

namespace AvaliadorProf
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
#if ANDROID
        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler(typeof(BlurView), typeof(BlurViewHandler));
        });
#endif
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseCardsView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<MVVM.Views.Login>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewService>();
            builder.Services.AddTransient<NavigationAux>();
            builder.Services.AddTransient<HttpClient>();
            builder.Services.AddSingleton<INavigation, NavigationProxy>();


#if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
            });
#endif
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {


#if ANDROID
            handler.PlatformView.BackgroundTintList =
Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif


            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
