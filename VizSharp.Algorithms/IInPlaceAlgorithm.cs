namespace VizSharp.Algorithms
{
    using System;

    public interface IInPlaceAlgorithm
    {
        string Name { get; }
        void Perform<T>(T[] values, Action<T[]> updateProgress) where T : IComparable<T>;
    }
}
