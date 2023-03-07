using CustomButton.ViewModels;

namespace CustomButton;

public partial class MainPage : ContentPage {
    int count = 0;
    private int magicButtonCount = 0;

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

    private void MagicButton_OnClicked(object sender, EventArgs e) {
        magicButtonCount++;

        if (magicButtonCount == 1)
            MagicButton.Text = $"Clicked {magicButtonCount} time";
        else
            MagicButton.Text = $"Clicked {magicButtonCount} times";
    }
}

