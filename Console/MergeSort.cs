namespace Sort.Test;

public static class SortExtensions
{
    /// Merge array slices bottom up.
    /// Starting with array slice size[1] up to array slice size[originalSize/2]
    public static void MergeSort<T>(this T[] source, int boundCheck = 5000) where T : IComparable
    {
        var lastIndex = source.Length - 1;

        if (lastIndex + 1 > boundCheck) return;

        for (var windowSize = 1; windowSize <= lastIndex; windowSize *= 2)
        {
            // Pick starting point of different sub-arrays of current size
            for (var leftStart = 0; leftStart < lastIndex; leftStart += (2 * windowSize))
            {
                // Find ending point of left  subarray. mid+1 is starting point of right
                var mid = Math.Min(leftStart + windowSize - 1, lastIndex);

                var rightStop = Math.Min(leftStart + 2 * windowSize - 1, lastIndex);

                SliceAndMerge(source, leftStart, mid, rightStop);
            }
        }
    }

    private static void SliceAndMerge<T>(T[] array, int startPos, int midPoint, int endPos) where T : IComparable
    {
        var masterIndex = startPos;

        var leftBlock = new Slice<T>(array, startPos, midPoint - startPos + 1);
        var rightBlock = new Slice<T>(array, midPoint + 1, endPos - midPoint);
        
        while (leftBlock.HasValues() && rightBlock.HasValues())
        {
            masterIndex = leftBlock.CompareTo(rightBlock) <= 0 
                ? leftBlock.AssignTo(ref array, masterIndex) 
                : rightBlock.AssignTo(ref array, masterIndex);
        }

        masterIndex = leftBlock.CopyTo(ref array, masterIndex);
        rightBlock.CopyTo(ref array, masterIndex);
    }

    internal class Slice<T>: IComparable<Slice<T>> where T : IComparable
    {
        internal readonly T[] Buffer;
        private int _index;

        public Slice(T[] source, int start, int size)
        {
            if (source.Length < start + size)
                Buffer = new T[] { };
            else
            {
                Buffer = new T[size];
                Array.Copy(source, start, Buffer, 0, size);
            }
        }
        
        public int AssignTo(ref T[] dest, int destIndex)
        {
            if (destIndex >= dest.Length) return destIndex;
            dest[destIndex] = Value;
            _index += 1;
            return destIndex + 1;
        }

        public int CopyTo(ref T[] dest, int destIndex)
        {
            while (HasValues())
                destIndex = AssignTo(ref dest, destIndex);

            return destIndex;
        }

        public bool HasValues() => Buffer.Any() && _index < Buffer.Length;

        private T Value => Buffer[_index];

        // IComparable implementation
        public int CompareTo(Slice<T>? other) => other == null ? 1 : Value.CompareTo(other.Value);
    }

}