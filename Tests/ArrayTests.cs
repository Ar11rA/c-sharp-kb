using System.Collections.Generic;
using QuoteFetcher.Services.Array;
using Xunit;

namespace Tests;

public class ArrayTests
{
    [Fact]
    public void ReplaceDuplicatesCount_Success()
    {
        int result = InplaceOperations.ReplaceDuplicatesCount(new[] {1, 1, 2, 2, 2, 3, 4, 5});
        Assert.Equal(5, result);
    }

    [Fact]
    public void RemoveElement_Success()
    {
        int result = InplaceOperations.RemoveElement(new[] {1, 2, 3, 2, 1, 2}, 2);
        Assert.Equal(3, result);
    }

    [Fact]
    public void SpiralMatrix_Success()
    {
        List<int> spiral = SpiralMatrix.Traverse(new List<List<int>>
        {
            new() {1, 2, 3},
            new() {4, 5, 6},
            new() {7, 8, 9}
        });
        Assert.Equal(1, spiral[0]);
        Assert.Equal(4, spiral[^2]);
        Assert.Equal(5, spiral[^1]);
    }

    [Fact]
    public void PascalTriangle_Success()
    {
        List<List<int>> triangle = PascalTriangle.Generate(6);
        Assert.Equal(1, triangle[5][0]);
        Assert.Equal(5, triangle[5][1]);
        Assert.Equal(10, triangle[5][2]);
        Assert.Equal(10, triangle[5][3]);
        Assert.Equal(5, triangle[5][4]);
        Assert.Equal(1, triangle[5][5]);
    }

    [Fact]
    public void Median_Success()
    {
        double res = Median.CalculateTwoSortedArrays(
            new[] {1, 2},
            new[] {3}
        );
        Assert.Equal(2.0d, res);
        res = Median.CalculateTwoSortedArrays(
            new[] {1, 2},
            new[] {3, 4}
        );
        Assert.Equal(2.5d, res);
    }


    [Fact]
    public void MaximumSubarray_Success()
    {
        int res = MaximumSubarray.Calculate(
            new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}
        );
        Assert.Equal(6, res);
    }


    [Fact]
    public void Backtracking_Subsets_Success()
    {
        IList<IList<int>> res = Backtracking.Subsets(
            new[] {1, 2, 3}
        );
        Assert.Equal(8, res.Count);
    }

    [Fact]
    public void Backtracking_Permute_Success()
    {
        IList<IList<int>> res = Backtracking.Permute(
            new[] {1, 2, 3}
        );
        Assert.Equal(6, res.Count);
    }

    [Fact]
    public void Backtracking_CombinationSum_Success()
    {
        IList<IList<int>> res = Backtracking.CombinationSum(
            new[] {2, 3, 6, 7}, 7
        );
        Assert.Equal(2, res.Count);
    }

    [Fact]
    public void RotateMatrix_Success()
    {
        int[][] m =
        {
            new[] {1, 2, 3},
            new[] {4, 5, 6},
            new[] {7, 8, 9}
        };

        RotateMatrix.Perform90(m);
        Assert.Equal(7, m[0][0]);
    }
}
