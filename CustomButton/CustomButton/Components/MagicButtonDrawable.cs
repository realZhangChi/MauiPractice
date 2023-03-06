namespace CustomButton.Components;

public class MagicButtonDrawable : IDrawable {

    public void Draw(ICanvas canvas, RectF dirtyRect) {
        DrawStroke(canvas, dirtyRect);
        DrawBackground(canvas, dirtyRect);
        DrawText(canvas, dirtyRect);
    }

    public void DrawStroke(ICanvas canvas, RectF dirtyRect) {

        canvas.SaveState();

        canvas.SetFillPaint(new SolidPaint(Brush.LightBlue.Color), dirtyRect);

        canvas.FillRoundedRectangle(dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height, dirtyRect.Height / 2);

        canvas.RestoreState();
    }

    public void DrawBackground(ICanvas canvas, RectF dirtyRect) {

        canvas.SaveState();

        canvas.SetFillPaint(new SolidPaint(Brush.Blue.Color), dirtyRect);

        var strokeThickness = 3;
        var x = dirtyRect.X + strokeThickness;
        var y = dirtyRect.Y + strokeThickness;
        var width = dirtyRect.Width - strokeThickness;
        var height = dirtyRect.Height - strokeThickness;

        canvas.FillRoundedRectangle(x, y, width, height, height / 2);

        canvas.RestoreState();
    }

    public void DrawText(ICanvas canvas, RectF dirtyRect) {
        canvas.SaveState();

        canvas.FontColor = Brush.White.Color;
        canvas.FontSize = 16;
        canvas.DrawString("Magic Button", dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height,
            HorizontalAlignment.Center,
            VerticalAlignment.Center);

        canvas.RestoreState();
    }
}