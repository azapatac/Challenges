using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Challenges.Components.Loading;
using Challenges.Views.Popups.Loading;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFPlatform = Xamarin.Forms.Platform.Android.Platform;

namespace Challenges.Droid.Dependency
{   
    public class LoadingComponent : ILoadingComponent
    {
        private Android.Views.View nativeView;
        private Dialog dialog;
        private bool isInitialized;

        public void Dispose()
        {
            Hide();
        }

        public void Hide()
        {
            dialog.Hide();
        }

        public void Init(PopupPage loadingIndicatorPage = null)
        {
            if (loadingIndicatorPage != null)
            {
                loadingIndicatorPage.Parent = Xamarin.Forms.Application.Current.MainPage;

                loadingIndicatorPage.Layout(new Rectangle(0, 0,
                    Xamarin.Forms.Application.Current.MainPage.Width,
                    Xamarin.Forms.Application.Current.MainPage.Height));

                var renderer = loadingIndicatorPage.GetOrCreateRenderer();

                nativeView = renderer.View;

                dialog = new Dialog(Xamarin.Essentials.Platform.CurrentActivity);
                dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                dialog.SetCancelable(false);
                dialog.SetContentView(nativeView);
                Window window = dialog.Window;
                window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                window.ClearFlags(WindowManagerFlags.DimBehind);
                window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));

                isInitialized = true;
            }
        }

        public IDisposable Show()
        {
            if (!isInitialized)
                Init(new LoadingPopupPage());

            dialog.Show();

            return this;
        }
    }

    internal static class PlatformExtension
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
        {
            var renderer = XFPlatform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = XFPlatform.CreateRendererWithContext(bindable, Xamarin.Essentials.Platform.CurrentActivity);
                XFPlatform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}