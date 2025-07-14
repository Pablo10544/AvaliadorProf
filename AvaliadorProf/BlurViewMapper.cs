using Microsoft.Maui.Handlers;
using AvaliadorProf.Controls;
#if ANDROID

using AvaliadorProf.Platforms.Android;
#endif
namespace AvaliadorProf
{
    public static class BlurViewMapper
    {
#if ANDROID
        public static IPropertyMapper<BlurView, BlurViewHandler> Mapper =
            new PropertyMapper<BlurView, BlurViewHandler>(ViewHandler.ViewMapper)
            {
                [nameof(BlurView.Radius)] = (handler, view) =>
                {
                    if (OperatingSystem.IsAndroidVersionAtLeast(31))
                    {
                        var blur = Android.Graphics.RenderEffect.CreateBlurEffect(
                            view.Radius,
                            view.Radius,
                            Android.Graphics.Shader.TileMode.Clamp
                        );
                        handler.PlatformView?.SetRenderEffect(blur);
                    }
                }
            };
#endif
    }
}
