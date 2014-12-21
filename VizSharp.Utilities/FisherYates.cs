namespace VizSharp.Utilities
{
    using System;
    using System.Collections.Immutable;

    public static class FisherYates
    {
        private static readonly Random s_random = new Random();

        public static T[] Shuffle<T>(ImmutableArray<T> values)
        {
            var temp = values.CloneAsMutable();
            Shuffle(temp);
            return temp;
        }

        public static void Shuffle<T>(T[] values)
        {
            for (var i = 0; i < values.Length; ++i)
            {
                var r = i + (int)(s_random.NextDouble() * (values.Length - i));
                var temp = values[r];
                values[r] = values[i];
                values[i] = temp;
            }
        }
    }
}
