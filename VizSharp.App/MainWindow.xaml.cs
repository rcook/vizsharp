namespace VizSharp.App
{
    using System.Collections.Immutable;
    using System.Linq;
    using System.Windows;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            barGraph.SetValues(ImmutableArray.Create<byte>(
                Enumerable
                .Range(0, 256)
                .Select(i => (byte)i)
                .ToArray()));
        }
    }
}
