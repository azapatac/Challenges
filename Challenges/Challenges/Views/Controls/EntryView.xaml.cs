using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Challenges.Views.Controls
{
    public partial class EntryView : ContentView
	{
        private bool _isClosed = true;

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(EntryView), string.Empty, BindingMode.TwoWay);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(EntryView), string.Empty, BindingMode.TwoWay);
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(EntryView), false, BindingMode.TwoWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public EntryView ()
		{
			InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(IsPassword):
                    btn_eye.IsVisible = IsPassword;
                    entry.IsPassword = IsPassword;
                    break;

                case nameof(Title):
                    lbl_title.Text = Title;
                    break;
                    
                default:
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }

        void btn_eye_Clicked(object sender, System.EventArgs e)
        {
            var source = _isClosed ? "eye_b.png" : "eye_none_b.png";

            btn_eye.Source = ImageSource.FromResource($"Challenges.Resources.Images.{source}", typeof(EntryView).GetTypeInfo().Assembly);
            _isClosed = !_isClosed;
            entry.IsPassword = _isClosed;
        }       
    }
}