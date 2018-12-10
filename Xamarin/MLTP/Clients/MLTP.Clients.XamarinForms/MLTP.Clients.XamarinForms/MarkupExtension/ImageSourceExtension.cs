using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MLTP.Clients.XamarinForms.MarkupExtension
{
    [ContentProperty(nameof(Source))]
    public class ImageSourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Source == null ? null : ImageSource.FromResource(Source);
        }
    }
}