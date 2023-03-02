using Com.Kongzue.Dialogx.Dialogs;
using Com.Kongzue.Dialogx.Interfaces;

using Java.Lang;

using Object = Java.Lang.Object;
using View = Android.Views.View;

namespace DialogXMaui;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e) {

        BottomMenu.Show("菜单", new[] { "菜单1", "菜单2", "菜单3" })?
            .SetOnMenuItemClickListener(new MenuItemClickListener() {
                OnMenuItemClick = (menu, menuName, menuIndex) => {
                    PopTip.Show($"{menuName} has been clicked! index: {menuIndex}");
                    return false;
                }
            });
    }
}

public class MenuItemClickListener : Object, IOnMenuItemClickListener {
    public Func<BottomMenu, string, int, bool> OnMenuItemClick;

    public bool OnClick(Object p0, ICharSequence p1, int p2) {
        if (p0 is BottomMenu bm) {
            return OnMenuItemClick?.Invoke(bm, p1.ToString(), p2) ?? false;
        }

        return false;
    }
}

public class InputOkClickListener : Java.Lang.Object, IOnInputDialogButtonClickListener {

    public Func<InputDialog, View, string, bool> OnOkButtonClicked;

    public bool OnClick(Object p0, View p1, string p2) {
        if (p0 is InputDialog id) {
            return OnOkButtonClicked(id, p1, p2);
        }

        return false;
    }
}

public class OkClickListener : Java.Lang.Object, IOnDialogButtonClickListener {
    public Func<MessageDialog, View, bool> OnOkButtonClicked;

    public bool OnClick(Object p0, View p1) {
        if (p0 is MessageDialog md) {
            return OnOkButtonClicked?.Invoke(md, p1) ?? false;
        }

        return false;
    }
}

//private void OnCounterClicked(object sender, EventArgs e) {

//    var input = new InputDialog("Hi", null, "确定");
//    input.Show();

//    input.SetOkButtonClickListener(new InputOkClickListener() {
//        OnOkButtonClicked = (dialog, view, arg3) => {
//            PopTip.Show(arg3);
//            return false;
//        }
//    });

//    //MessageDialog.Show("Hi", "Maui", "确定")
//    //    .SetOkButton(new OkClickListener() {
//    //        OnOkButtonClicked = (dialog, view) => {
//    //            PopTip.Show("Hello! Ok Button has been clicked!");
//    //            return false;
//    //        }
//    //    });
//}