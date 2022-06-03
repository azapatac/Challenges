using Android.Graphics.Drawables;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Challenges")]
[assembly: ExportEffect(typeof(Challenges.Droid.Effects.NoUnderlineEffect), nameof(Challenges.NoUnderlineEffect))]
namespace Challenges.Droid.Effects
{
    public class NoUnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                Control.SetBackgroundDrawable(gd);
                if (Control is EditText editText)
                {
                    editText.SetRawInputType(Android.Text.InputTypes.TextFlagNoSuggestions);
                }
            }
        }

        protected override void OnDetached() { }
    }
}

