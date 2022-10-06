using Sort.Test;

namespace MergeSort.Tests;

public class MergeSortTests
{
    [Theory]
    [InlineData(100)]
    [InlineData(5000)]
    [InlineData(7500)]
    public void random_generated_array_should_sort(int size)
    {
        //ASSIGN
        var source = TestUtilities.RandomArray(size);

        //ACT
        source.MergeSort(boundCheck: 10000);
        
        //ASSERT
        for (var i = 0; i < source.Length - 1; i++)
            Assert.True(source[i] <= source[i + 1]);
    }

    [Fact]
    public void array_larger_than_bound_check_should_not_sort()
    {
        //ASSIGN
        var source = TestUtilities.RandomArray(5001);
        var clone = new long[5001];
        source.CopyTo(clone, 0);

        //ACT
        source.MergeSort();

        //ASSERT
        Assert.True(source.SequenceEqual(clone));
    }
    
    [Fact]
    public void Unsorted_int_array_should_sort()
    {
        //ASSIGN
        int[] arr = {-500, -1000, 25, 5000, 10, 100, -1, 50};

        //ACT
        arr.MergeSort();
        
        //ASSERT
        Assert.Collection(arr,
            item => Assert.Equal(-1000, item),
            item => Assert.Equal(-500, item),
            item => Assert.Equal(-1, item),
            item => Assert.Equal(10, item),
            item => Assert.Equal(25, item),
            item => Assert.Equal(50, item),
            item => Assert.Equal(100, item),
            item => Assert.Equal(5000, item)
        );
    }

    [Fact]
    public void Unsorted_string_array_should_sort()
    {
        //ASSIGN
        string[] states =
        {
            "Georgia", "Texas", "North Dakota", "Washington", "Pennsylvania", "Maryland", "California", "Minnesota",
            "New Hampshire", "Louisiana", "Delaware", "Missouri", "Wisconsin", "Nebraska", "Indiana", "Arizona",
            "Mississippi", "Utah", "Florida", "Kansas", "Vermont", "South Carolina", "Oklahoma", "Connecticut",
            "Massachusetts", "New Jersey", "Ohio", "South Dakota", "Kentucky", "Colorado", "New York", "Rhode Island",
            "Michigan", "Alabama", "Illinois", "North Carolina", "Wyoming", "Oregon", "Maine", "Tennessee", "Hawaii",
            "West Virginia", "Iowa", "New Mexico", "Arkansas", "Idaho", "Virginia", "Montana", "Nevada", "Alaska"
        };

        //ACT
        states.MergeSort();
        
        //ASSERT
        Assert.Collection(states,
            state => Assert.Equal("Alabama", state),
            state => Assert.Equal("Alaska", state),
            state => Assert.Equal("Arizona", state),
            state => Assert.Equal("Arkansas", state),
            state => Assert.Equal("California", state),
            state => Assert.Equal("Colorado", state),
            state => Assert.Equal("Connecticut", state),
            state => Assert.Equal("Delaware", state),
            state => Assert.Equal("Florida", state),
            state => Assert.Equal("Georgia", state),
            state => Assert.Equal("Hawaii", state),
            state => Assert.Equal("Idaho", state),
            state => Assert.Equal("Illinois", state),
            state => Assert.Equal("Indiana", state),
            state => Assert.Equal("Iowa", state),
            state => Assert.Equal("Kansas", state),
            state => Assert.Equal("Kentucky", state),
            state => Assert.Equal("Louisiana", state),
            state => Assert.Equal("Maine", state),
            state => Assert.Equal("Maryland", state),
            state => Assert.Equal("Massachusetts", state),
            state => Assert.Equal("Michigan", state),
            state => Assert.Equal("Minnesota", state),
            state => Assert.Equal("Mississippi", state),
            state => Assert.Equal("Missouri", state),
            state => Assert.Equal("Montana", state),
            state => Assert.Equal("Nebraska", state),
            state => Assert.Equal("Nevada", state),
            state => Assert.Equal("New Hampshire", state),
            state => Assert.Equal("New Jersey", state),
            state => Assert.Equal("New Mexico", state),
            state => Assert.Equal("New York", state),
            state => Assert.Equal("North Carolina", state),
            state => Assert.Equal("North Dakota", state),
            state => Assert.Equal("Ohio", state),
            state => Assert.Equal("Oklahoma", state),
            state => Assert.Equal("Oregon", state),
            state => Assert.Equal("Pennsylvania", state),
            state => Assert.Equal("Rhode Island", state),
            state => Assert.Equal("South Carolina", state),
            state => Assert.Equal("South Dakota", state),
            state => Assert.Equal("Tennessee", state),
            state => Assert.Equal("Texas", state),
            state => Assert.Equal("Utah", state),
            state => Assert.Equal("Vermont", state),
            state => Assert.Equal("Virginia", state),
            state => Assert.Equal("Washington", state),
            state => Assert.Equal("West Virginia", state),
            state => Assert.Equal("Wisconsin", state),
            state => Assert.Equal("Wyoming", state)
        );
    }
}