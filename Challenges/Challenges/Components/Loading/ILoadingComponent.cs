using System;
using Rg.Plugins.Popup.Pages;

namespace Challenges.Components.Loading
{
	public interface ILoadingComponent : IDisposable
	{
		void Hide();
		void Init(PopupPage loadingIndicatorPage = null);
		IDisposable Show();
	}
}