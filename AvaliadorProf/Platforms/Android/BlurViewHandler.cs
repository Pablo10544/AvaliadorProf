using Android.Graphics;
using Android.Widget;
using AvaliadorProf.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Graph = Android.Graphics;
using View = Android.Views.View;

namespace AvaliadorProf.Platforms.Android
{
    public class BlurViewHandler : ViewHandler<BlurView, FrameLayout>
    {
        public BlurViewHandler() : base(BlurViewMapper.Mapper) { }

        protected override FrameLayout CreatePlatformView()
        {
            var layout = new FrameLayout(Context);

            if (OperatingSystem.IsAndroidVersionAtLeast(31))
            {
                var blur = Graph.RenderEffect.CreateBlurEffect(
                    VirtualView.Radius,
                    VirtualView.Radius,
                    Graph.Shader.TileMode.Clamp
                );
                layout.SetRenderEffect(blur);
            }

            // Fundo branco com transparência (opcional, mas dá o "vidro")
            layout.SetBackgroundColor(Graph.Color.Argb(128, 255, 255, 255));

            return layout;
        }

        protected override void ConnectHandler(FrameLayout platformView)
        {
            base.ConnectHandler(platformView);

            // Adiciona a subview convertida do conteúdo do ContentView
            var mauiContent = VirtualView.Content?.ToPlatform(MauiContext);
            if (mauiContent != null)
            {
                platformView.AddView(mauiContent);
            }
        }
    }
}
