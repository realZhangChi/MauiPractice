using CustomButton.ViewModels;

namespace CustomButton;

public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
        InitializeComponent();

        BindingContext = new MainViewModel();
    }

    private void OnCounterClicked(object sender, EventArgs e) {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private int _magicButtonCount = 0;
    private void MagicButton_OnClicked(object sender, EventArgs e)
    {
        _magicButtonCount++;

        MagicButton.Text = _magicButtonCount == 1 ?
            $"Clicked {_magicButtonCount} time" :
            $"Clicked {_magicButtonCount} times";
    }
}

