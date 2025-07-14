using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorProf.Controls
{
    public class BlurView: ContentView
    {
        public static readonly BindableProperty RadiusProperty =
    BindableProperty.Create(nameof(Radius), typeof(float), typeof(BlurView), 10f);

        public float Radius
        {
            get => (float)GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }
    }
}
