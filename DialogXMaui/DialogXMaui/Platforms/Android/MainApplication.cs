using Android.App;
using Android.Runtime;

namespace DialogXMaui;

[Application]
public class MainApplication : MauiApplication {
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership) {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override void OnCreate() {
        base.OnCreate();

        Com.Kongzue.Dialogx.DialogX.Init(this);
    }
}
