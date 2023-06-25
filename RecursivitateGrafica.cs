using System;
using System.Drawing;
using System.Windows.Forms;

public class FractalTreeForm : Form
{
    private const int Width = 800;
    private const int Height = 600;

    private Graphics graphics;
    private Pen pen;

    public FractalTreeForm()
    {
        InitializeComponent();
        graphics = CreateGraphics();
        pen = new Pen(Color.Black);
    }

    private void InitializeComponent()
    {
        Width = FractalTreeForm.Width;
        Height = FractalTreeForm.Height;
        Text = "Fractal Tree";
        BackColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        DrawFractalTree(Width / 2, Height - 50, -90, 100);
    }

    private void DrawFractalTree(int x, int y, double angle, double length)
    {
        if (length < 5) // Cazul de bază: dacă lungimea este suficient de mică, nu mai continuăm să desenăm
            return;

        int x2 = x + (int)(Math.Cos(angle * Math.PI / 180) * length);
        int y2 = y + (int)(Math.Sin(angle * Math.PI / 180) * length);

        graphics.DrawLine(pen, x, y, x2, y2);

        // Apeluri recursive pentru desenarea sub-arborilor
        DrawFractalTree(x2, y2, angle - 20, length * 0.7);
        DrawFractalTree(x2, y2, angle + 20, length * 0.7);
    }

    public static void Main()
    {
        Application.Run(new FractalTreeForm());
    }
}