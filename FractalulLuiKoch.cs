using System;
using System.Drawing;
using System.Windows.Forms;

public class KochFractal : Form
{
    private const int Width = 800;
    private const int Height = 600;
    private const int Depth = 5;

    public KochFractal()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        ClientSize = new Size(Width, Height);
        Text = "Fractalul lui Koch";
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Paint += KochFractal_Paint;
    }

    private void KochFractal_Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        Pen pen = new Pen(Color.Black);

        // Calculează coordonatele punctelor de pornire și direcția inițială
        Point startPoint = new Point(Width / 4, Height / 2);
        Point endPoint = new Point(Width * 3 / 4, Height / 2);

        // Desenează fractalul lui Koch recursiv
        DrawKochCurve(graphics, pen, Depth, startPoint, endPoint);
    }

    private void DrawKochCurve(Graphics graphics, Pen pen, int depth, Point start, Point end)
    {
        if (depth == 0)
        {
            // Desenează segmentul de bază
            graphics.DrawLine(pen, start, end);
        }
        else
        {
            // Calculează punctele intermediare
            Point p1 = new Point(start.X + (end.X - start.X) / 3, start.Y + (end.Y - start.Y) / 3);
            Point p2 = new Point(start.X + (end.X - start.X) * 2 / 3, start.Y + (end.Y - start.Y) * 2 / 3);
            Point tip = CalculateKochTip(start, end);

            // Desenează cele 4 segmente recursiv
            DrawKochCurve(graphics, pen, depth - 1, start, p1);
            DrawKochCurve(graphics, pen, depth - 1, p1, tip);
            DrawKochCurve(graphics, pen, depth - 1, tip, p2);
            DrawKochCurve(graphics, pen, depth - 1, p2, end);
        }
    }
    private Point CalculateKochTip(Point start, Point end)
    {
        // Calculează coordonatele punctului vârf al triunghiului Koch
        int deltaX = end.X - start.X;
        int deltaY = end.Y - start.Y;

        int tipX = (int)(start.X + deltaX / 2.0 - deltaY * Math.Sqrt(3) / 6.0);
        int tipY = (int)(start.Y + deltaY / 2.0 + deltaX * Math.Sqrt(3) / 6.0);

        return new Point(tipX, tipY);
    }

    public static void Main()
    {
        Application.Run(new KochFractal());
    }
}