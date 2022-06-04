namespace Challenges.iOS.Dependency
{
    using System;
    using Challenges.Components.Loading;
    using Challenges.Views.Popups.Loading;
    using Rg.Plugins.Popup.Pages;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using XFPlatform = Xamarin.Forms.Platform.iOS.Platform;

    public class LoadingComponent : ILoadingComponent
    {
        private UIView nativeView;
        private bool isInitialized;

        public void Dispose()
        {
            Hide();
        }

        public void Hide()
        {
            nativeView.RemoveFromSuperview();
        }

        public void Init(PopupPage loadingIndicatorPage = null)
        {
            if (loadingIndicatorPage != null)
            {
                loadingIndicatorPage.Parent = Application.Current.MainPage;
                loadingIndicatorPage.Layout(new Rectangle(0, 0, Application.Current.MainPage.Width, Xamarin.Forms.Application.Current.MainPage.Height));
                var renderer = loadingIndicatorPage.GetOrCreateRenderer();
                nativeView = renderer.NativeView;
                isInitialized = true;
            }
        }

        public IDisposable Show()
        {
            if (!isInitialized)
                Init(new LoadingPopupPage());

            UIApplication.SharedApplication.KeyWindow.AddSubview(nativeView);

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
                renderer = XFPlatform.CreateRenderer(bindable);
                XFPlatform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}

