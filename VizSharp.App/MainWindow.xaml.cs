namespace VizSharp.App
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using VizSharp.Algorithms;
    using VizSharp.Utilities;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var selectedAlgorithm = new BubbleSortAlgorithm();
            algorithmsComboBox.Items.Add(selectedAlgorithm);
            algorithmsComboBox.Items.Add(new QuicksortAlgorithm());
            algorithmsComboBox.Items.Add(new InsertionSortAlgorithm());
            algorithmsComboBox.Items.Add(new SelectionSortAlgorithm());
            algorithmsComboBox.SelectedItem = selectedAlgorithm;
        }

        private async void goButton_Click(object sender, RoutedEventArgs e)
        {
            goButton.IsEnabled = false;
            algorithmsComboBox.IsEnabled = false;

            var values = CreateShuffledByteArray();
            var algorithm = (IInPlaceAlgorithm)algorithmsComboBox.SelectedItem;

            var stepCount = 0;
            algorithm.Perform((byte[])values.Clone(), _ => ++stepCount);

            var progress = (IProgress<byte[]>)new Progress<byte[]>(
                progressValues =>
                {
                    barGraph.SetValues(progressValues.AsImmutable());
                });

            var millisecondsTimeout = 5000 / stepCount;

            await Task.Run(() => algorithm.Perform(
                values,
                progressValues =>
                {
                    progress.Report(progressValues);
                    Thread.Sleep(millisecondsTimeout);
                }));

            goButton.IsEnabled = true;
            algorithmsComboBox.IsEnabled = true;
        }

        private static byte[] CreateShuffledByteArray()
        {
            var values = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();
            FisherYates.Shuffle(values);
            return values;
        }
    }
}
