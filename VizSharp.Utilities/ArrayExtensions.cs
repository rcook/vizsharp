namespace VizSharp.Utilities
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] values, int index0, int index1)
        {
            var temp = values[index0];
            values[index0] = values[index1];
            values[index1] = temp;
        }
    }
}
