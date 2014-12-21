namespace VizSharp.App
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public partial class BarGraph : UserControl
    {
        public BarGraph()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            canvas.Width = 100.0d;
            canvas.Height = 100.0d;
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var line = new Line();
            line.X1 = 0.0d;
            line.X2 = canvas.ActualWidth;
            line.Y1 = 0.0d;
            line.Y2 = canvas.ActualHeight;
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 1.0d;
            canvas.Children.Add(line);
        }
    }
}
