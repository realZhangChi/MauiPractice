using System.Windows.Input;

using Microsoft.Maui.Animations;

namespace CustomButton.Components;

public class MagicButton : GraphicsView {

    public static BindableProperty StrokeColorProperty = BindableProperty.Create(
        nameof(StrokeColor),
        typeof(Color),
        typeof(MagicButton),
        null,
        propertyChanged: (bindable, value, newValue) => {
            if (bindable is MagicButton magicButton) {
                magicButton.UpdateStrokeColor();
            }
        });

    public Color StrokeColor {
        get => (Color)GetValue(FontColorProperty);
        set => SetValue(FontColorProperty, value);
    }

    public new static BindableProperty BackgroundColorProperty = BindableProperty.Create(
        nameof(BackgroundColor),
        typeof(Color),
        typeof(MagicButton),
        null,
        propertyChanged: (bindable, value, newValue) => {
            if (bindable is MagicButton magicButton) {
                magicButton.UpdateBackgroundColor();
            }
        });

    public new Color BackgroundColor {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public static BindableProperty StrokeThicknessProperty = BindableProperty.Create(
        nameof(StrokeThickness),
        typeof(float),
        typeof(MagicButton),
        0f,
        propertyChanged: (bindable, value, newValue) => {

            if (bindable is MagicButton magicButton) {
                magicButton.UpdateStrokeThickness();
            }
        });

    public float StrokeThickness {
        get => (float)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public static BindableProperty FontSizeProperty = BindableProperty.Create(
        nameof(FontSize),
        typeof(int),
        typeof(MagicButton),
        16,
        propertyChanged: (bindable, value, newValue) => {

            if (bindable is MagicButton magicButton) {
                magicButton.UpdateFontSize();
            }
        });

    public int FontSize {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static BindableProperty FontColorProperty = BindableProperty.Create(
        nameof(FontColor),
        typeof(Color),
        typeof(MagicButton),
        null,
        propertyChanged: (bindable, value, newValue) => {
            if (bindable is MagicButton magicButton) {
                magicButton.UpdateFontColor();
            }
        });

    public Color FontColor {
        get => (Color)GetValue(FontColorProperty);
        set => SetValue(FontColorProperty, value);
    }


    public static BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(MagicButton),
        string.Empty,
        propertyChanged: (bindable, value, newValue) => {
            if (bindable is MagicButton magicButton) {
                magicButton.UpdateText();
            }
        });

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(MagicButton));

    public ICommand Command {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(MagicButton));

    public object CommandParameter {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public event EventHandler Clicked;

    private readonly IAnimationManager _animationManager;

    public MagicButton() {
        Drawable = new MagicButtonDrawable();

        StartInteraction += OnStartInteraction;
        EndInteraction += OnEndInteraction;

#if __ANDROID__
        _animationManager = new AnimationManager(new PlatformTicker(new Microsoft.Maui.Platform.EnergySaverListenerManager()));
#else
        _animationManager = new AnimationManager(new PlatformTicker());
#endif
    }

    private void OnStartInteraction(object sender, TouchEventArgs e) {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        if (IsEnabled) {
            VisualStateManager.GoToState(this, "Clicked");
        }

        drawable.TouchPoint = e.Touches[0];
        AnimateRippleEffect();
    }

    private void OnEndInteraction(object sender, TouchEventArgs e) {

        if (IsEnabled) {
            VisualStateManager.GoToState(this, "Normal");
        }

        Clicked?.Invoke(sender, e);
        Command?.Execute(CommandParameter);
    }

    protected override void OnPropertyChanged(string propertyName = null) {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(BackgroundColor)) {
            UpdateBackgroundColor();
        }
    }

    protected override void OnParentChanged() {
        base.OnParentChanged();

        UpdateStrokeColor();
        UpdateStrokeThickness();
        UpdateBackgroundColor();
        UpdateFontColor();
        UpdateFontSize();

        Invalidate();
    }

    public void UpdateEnableStatus() {
        VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled");
    }

    public void UpdateStrokeColor() {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        if (StrokeColor is null) {
            return;
        }

        drawable.StrokeColor = StrokeColor;

        Invalidate();
    }

    public void UpdateStrokeThickness() {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        drawable.StrokeThickness = StrokeThickness;

        Invalidate();
    }

    public void UpdateBackgroundColor() {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        drawable.BackgroundColor = BackgroundColor;

        Invalidate();
    }

    public void UpdateFontColor() {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        if (FontColor is null) {
            return;
        }

        drawable.FontColor = FontColor;

        Invalidate();
    }

    public void UpdateFontSize() {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        drawable.FontSize = FontSize;

        Invalidate();
    }

    public void UpdateText() {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        drawable.Text = Text;

        Invalidate();
    }

    public void AnimateRippleEffect() {
        if (Drawable is not MagicButtonDrawable drawable) {
            return;
        }

        var start = 0f;
        var end = 1f;

        _animationManager.Add(new Microsoft.Maui.Animations.Animation(
            (progress) => {
                drawable.AnimationPercent = start.Lerp(end, progress);
                Invalidate();
            },
            duration: 0.5f,
            easing: Easing.SinInOut,
            finished: () => {
                drawable.AnimationPercent = 0;
            }));
    }
}