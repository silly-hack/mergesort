namespace Sort.Test;

public static class Scaffold
{
    public static void Main()
    {

        int[] arr = {-500, -1000, 25, 5000, 10, 100, -1, 50};

        Display("Initial unsorted array:", arr);

        arr.MergeSort();

        Display("Sorted array:", arr);
        Console.ReadKey();
    }

    private static void Display(string message, IEnumerable<int> array)
    {
        Console.WriteLine(message);

        foreach (var t in array)
            Console.Write(t + " ");

        Console.WriteLine("");
    }
}
