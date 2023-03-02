using Com.Lzf.Easyfloat;

using Microsoft.Maui.Platform;

namespace EasyFloatInMaui;

public partial class MainPage : ContentPage {

    public MainPage() {
        InitializeComponent();
    }

    private bool _isFloatViewShow = false;
    private const string FloatViewTag = "FloatView";
    private void OnCounterClicked(object sender, EventArgs e) {
#if ANDROID
        if (!_isFloatViewShow &&
            Microsoft.Maui.ApplicationModel.Platform.CurrentActivity != null &&
            Application.Current?.Handler?.MauiContext != null) {
            EasyFloat
                .With(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity)
                .SetTag(FloatViewTag)
                .SetLayout(new FloatView().ToPlatform(Application.Current.Handler.MauiContext))
                .SetLocation(250, 1000)
                .SetDragEnable(true)
                .Show();
            _isFloatViewShow = true;
        }
        else {
            EasyFloat.Dismiss(FloatViewTag);
            _isFloatViewShow = false;
        }
#endif
    }
}

