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


    public MagicButton() {
        Drawable = new MagicButtonDrawable();
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
}