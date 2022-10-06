namespace MergeSort.Tests;

public class TestUtilities
{
    public static long[] RandomArray(int size)
    {
        var random = new Random();
        var values = new long[size];

        for (var i = 0; i < size; ++i)
            values[i] = random.NextInt64();

        return values;
    }
}