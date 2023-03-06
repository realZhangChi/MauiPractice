namespace CustomButton.Components;

public class MagicButtonDrawable : IDrawable {

    public Color StrokeColor { get; set; }

    public float StrokeThickness { get; set; }

    public Color BackgroundColor { get; set; }

    public int FontSize { get; set; }

    public Color FontColor { get; set; }

    public string Text { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect) {
        DrawStroke(canvas, dirtyRect);
        DrawBackground(canvas, dirtyRect);
        DrawText(canvas, dirtyRect);
    }

    public void DrawStroke(ICanvas canvas, RectF dirtyRect) {

        canvas.SaveState();

        canvas.SetFillPaint(new SolidPaint(StrokeColor), dirtyRect);

        canvas.FillRoundedRectangle(dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height, dirtyRect.Height / 2);

        canvas.RestoreState();
    }

    public void DrawBackground(ICanvas canvas, RectF dirtyRect) {

        canvas.SaveState();

        canvas.SetFillPaint(new SolidPaint(Brush.Blue.Color), dirtyRect);

        var x = dirtyRect.X + StrokeThickness;
        var y = dirtyRect.Y + StrokeThickness;
        var width = dirtyRect.Width - StrokeThickness * 2;
        var height = dirtyRect.Height - StrokeThickness * 2;

        canvas.FillRoundedRectangle(x, y, width, height, height / 2);

        canvas.RestoreState();
    }

    public void DrawText(ICanvas canvas, RectF dirtyRect) {
        canvas.SaveState();

        canvas.FontColor = FontColor;
        canvas.FontSize = FontSize;
        canvas.DrawString(Text, dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height,
            HorizontalAlignment.Center,
            VerticalAlignment.Center);

        canvas.RestoreState();
    }
}