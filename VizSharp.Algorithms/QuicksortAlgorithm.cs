namespace VizSharp.Algorithms
{
    using System;
    using System.Collections.Generic;
    using VizSharp.Utilities;

    public sealed class QuicksortAlgorithm : IInPlaceAlgorithm
    {
        public QuicksortAlgorithm() { }

        public string Name
        {
            get { return "Quicksort"; }
        }

        public void Perform<T>(T[] values, Action<T[]> updateProgress) where T : IComparable<T>
        {
            updateProgress(values);
            Quicksort(values, 0, values.Length - 1, updateProgress);
        }

        private static void Quicksort<T>(T[] values, int startIndex, int endIndex, Action<T[]> updateProgress) where T : IComparable<T>
        {
            if (values.Length <= 0 || startIndex >= endIndex)
            {
                return;
            }

            var stack = new Stack<Range>();
            stack.Push(new Range { StartIndex = startIndex, EndIndex = endIndex });
            while (stack.Count > 0)
            {
                updateProgress(values);

                var top = stack.Pop();
                if (top.StartIndex >= top.EndIndex)
                {
                    continue;
                }

                var partitionIndex = Partition(values, top.StartIndex, top.EndIndex);
                stack.Push(new Range { StartIndex = partitionIndex + 1, EndIndex = top.EndIndex });
                stack.Push(new Range { StartIndex = top.StartIndex, EndIndex = partitionIndex - 1 });
            }
        }

        private static int Partition<T>(T[] values, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            var leftIndex = startIndex;
            var rightIndex = endIndex - 1;
            var pivot = values[endIndex];

            for (; ; )
            {
                while (leftIndex < endIndex && values[leftIndex].CompareTo(pivot) <= 0)
                {
                    ++leftIndex;
                }

                while (rightIndex > startIndex && values[rightIndex].CompareTo(pivot) >= 0)
                {
                    --rightIndex;
                }

                if (leftIndex >= rightIndex)
                {
                    break;
                }

                values.Swap(leftIndex, rightIndex);
            }

            values.Swap(leftIndex, endIndex);
            return leftIndex;
        }

        private struct Range
        {
            public int StartIndex;
            public int EndIndex;
        }
    }
}
