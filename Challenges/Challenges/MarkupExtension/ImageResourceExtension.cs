using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenges.MarkupExtension
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            var imageSource = ImageSource.FromResource($"Challenges.Resources.Images.{Source}" , typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}