﻿namespace VizSharp.Utilities
{
    using System.Collections.Immutable;

    public static class ImmutableExtensions
    {
        public static T[] CloneAsMutable<T>(this ImmutableArray<T> values)
        {
            var temp = new T[values.Length];
            values.CopyTo(temp);
            return temp;
        }
    }
}
