using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
namespace ShanePrototypeXamarin.MarkupExtensions
{
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourceId)) return null;
            return ImageSource.FromResource(ResourceId);
        }
    }
}
