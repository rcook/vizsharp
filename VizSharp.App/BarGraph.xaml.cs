namespace VizSharp.App
{
    using System.Collections.Immutable;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public partial class BarGraph : UserControl
    {
        private const double CanvasHeight = 256.0d;
        private const double LineThickness = 3.0d;
        private const double LineOffset = 1.0d;
        private Line[] m_lines;

        public BarGraph()
        {
            InitializeComponent();
        }

        public void SetValues(ImmutableArray<byte> values)
        {
            if (m_lines == null || m_lines.Length != values.Length)
            {
                CreateLines(values);
            }

            for (var i = 0; i < m_lines.Length; ++i)
            {
                m_lines[i].Y2 = CanvasHeight - values[i];
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            canvas.Height = CanvasHeight;
        }

        private void CreateLines(ImmutableArray<byte> values)
        {
            canvas.Width = LineThickness * values.Length;
            canvas.Children.Clear();
            m_lines = new Line[values.Length];
            for (var i = 0; i < m_lines.Length; ++i)
            {
                var line = new Line();
                line.Y1 = CanvasHeight;
                line.X1 = line.X2 = LineThickness * i + LineOffset;
                line.Stroke = Brushes.Red;
                line.StrokeThickness = LineThickness;

                m_lines[i] = line;
                canvas.Children.Add(line);
            }
        }
    }
}
