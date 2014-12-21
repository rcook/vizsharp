namespace VizSharp.Algorithms
{
    using System;
    using VizSharp.Utilities;

    public sealed class SelectionSortAlgorithm : IInPlaceAlgorithm
    {
        public string Name
        {
            get { return "Selection sort"; }
        }

        public void Perform<T>(T[] values, Action<T[]> updateProgress) where T : IComparable<T>
        {
            updateProgress(values);

            for (var i = 0; i < values.Length - 1; ++i)
            {
                updateProgress(values);
                var k = FindMinimum(values, i);
                if (i != k)
                {
                    values.Swap(i, k);
                }
            }
        }

        private static int FindMinimum<T>(T[] values, int startIndex) where T : IComparable<T>
        {
            var minimumIndex = startIndex;
            for (var index = startIndex + 1; index < values.Length; ++index)
            {
                if (values[index].CompareTo(values[minimumIndex]) < 0)
                {
                    minimumIndex = index;
                }
            }
            return minimumIndex;
        }
    }
}
