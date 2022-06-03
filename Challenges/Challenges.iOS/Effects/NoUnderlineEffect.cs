using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Challenges")]
[assembly: ExportEffect(typeof(Challenges.iOS.Effects.NoUnderlineEffect), nameof(Challenges.NoUnderlineEffect))]
namespace Challenges.iOS.Effects
{
    public class NoUnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null & Control is UITextField)
            {
                var entry = (UITextField)Control;
                entry.BorderStyle = UITextBorderStyle.None;
                return;
            };
        }

        protected override void OnDetached() { }

    }
}