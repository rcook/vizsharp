namespace VizSharp.Algorithms
{
    using System;

    public sealed class BubbleSortAlgorithm : IInPlaceAlgorithm
    {
        public BubbleSortAlgorithm() { }

        public string Name
        {
            get { return "Bubble sort"; }
        }

        public void Perform<T>(T[] values, Action<T[]> updateProgress) where T : IComparable<T>
        {
            updateProgress(values);

            for (var i = 1; i < values.Length; i++)
            {
                for (var j = 0; j < values.Length - i; j++)
                {
                    if (values[j].CompareTo(values[j + 1]) > 0)
                    {
                        var temp = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = temp;
                    }
                }

                updateProgress(values);
            }
        }
    }
}
