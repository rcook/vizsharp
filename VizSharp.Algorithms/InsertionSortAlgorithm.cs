namespace VizSharp.Algorithms
{
    using System;
    using System.Collections.Immutable;
    using VizSharp.Utilities;

    public sealed class InsertionSortAlgorithm : IInPlaceAlgorithm
    {
        public InsertionSortAlgorithm() { }

        public string Name
        {
            get { return "Insertion sort"; }
        }

        public void Perform<T>(T[] values, Action<T[]> updateProgress) where T : IComparable<T>
        {
            updateProgress(values);

            for (var i = 1; i < values.Length; i++)
            {
                var j = i;
                while (j > 0)
                {
                    if (values[j - 1].CompareTo(values[j]) > 0)
                    {
                        var temp = values[j - 1];
                        values[j - 1] = values[j];
                        values[j] = temp;
                        --j;
                    }
                    else
                    {
                        break;
                    }
                }

                updateProgress(values);
            }
        }
    }
}
