using Sort.Test;

namespace MergeSort.Tests;

public class SliceTests
{
    #region New Slice
    
    [Fact]
    public void new_slice_should_contain_valid_array_segment()
    {
        //ASSIGN
        var masterArray = TestUtilities.RandomArray(10);
        
        //ACT
        var slice = new SortExtensions.Slice<long>(masterArray, 2, 5);

        //ASSERT
        Assert.True(slice.HasValues());
        for (var i = 0; i < 5; i++)
        {
            var originalIndex = i + 2;
            Assert.Equal(masterArray[originalIndex], slice.Buffer[i]);
        }
    }

    [Fact]
    public void new_slice_with_invalid_index_should_return_empty()
    {
        //ASSIGN
        var masterArray = TestUtilities.RandomArray(10);
        
        //ACT
        var slice = new SortExtensions.Slice<long>(masterArray, 8, 5);

        //ASSERT
        Assert.NotNull(slice);
    }

    #endregion

    #region AssignTo

    [Fact]
    public void assign_to_should_assign_values_to_destination()
    {
        //ASSIGN
        var masterArray = TestUtilities.RandomArray(10);
        var slice = new SortExtensions.Slice<long>(masterArray, 4, 2);
        var dest = new long[2];
        
        //ACT
        slice.AssignTo(ref dest, 0);
        slice.AssignTo(ref dest, 1);

        //ASSERT
        Assert.Equal(masterArray[4], dest[0]);
        Assert.Equal(masterArray[5], dest[1]);
        Assert.False(slice.HasValues());
    }

    [Fact]
    public void assign_to_should_not_assign_past_destination()
    {
        //ASSIGN
        var masterArray = TestUtilities.RandomArray(10);
        var slice = new SortExtensions.Slice<long>(masterArray, 0, 3);
        var dest = new long[2];
        
        //ACT
        slice.AssignTo(ref dest, 0);
        slice.AssignTo(ref dest, 1);
        var index = slice.AssignTo(ref dest, 2);
        
        //ASSERT
        Assert.Equal(2, index);
        Assert.True(slice.HasValues()); // not fully consumed
        
        Assert.Equal(masterArray[0], dest[0]);
        Assert.Equal(masterArray[1], dest[1]);
    }
    
    #endregion
    
    #region HasValues
    
    [Fact]
    public void has_values_should_return_false_when_empty()
    {
        //ASSIGN
        var masterArray = TestUtilities.RandomArray(10);
        
        //ACT
        var slice = new SortExtensions.Slice<long>(masterArray, 8, 5);

        //ASSERT
        Assert.False(slice.HasValues());
    }

    [Fact]
    public void has_values_should_return_valid_state()
    {
        //ASSIGN
        var masterArray = TestUtilities.RandomArray(10);
        var slice = new SortExtensions.Slice<long>(masterArray, 2, 3);
        var results = new List<bool>();

        //ACT
        for (var i = 0; i < 3; i++)
        {
            slice.AssignTo(ref masterArray, 2 + i);
            results.Add(slice.HasValues());
        }

        //ASSERT
        Assert.True(results[0]);
        Assert.True(results[1]);
        Assert.False(results[2]);
    }
    
    #endregion
}