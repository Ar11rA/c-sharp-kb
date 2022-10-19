using System.Collections.Generic;
using QuoteFetcher.DTO;
using QuoteFetcher.Services.Tree;
using Xunit;

namespace Tests;

public class TreeTests
{
    [Fact]
    public void HasPathSum_Success()
    {
        BinaryTree bt = new()
        {
            Value = 1,
            Left = null,
            Right = new BinaryTree
            {
                Value = 2,
                Left = null,
                Right = null
            }
        };
        bool result1 = PathSum.HasPathSum(bt, 4);
        bool result2 = PathSum.HasPathSum(bt, 3);
        Assert.False(result1);
        Assert.True(result2);
    }
    
    [Fact]
    public void PathSum_Success_1()
    {
        BinaryTree bt = new()
        {
            Value = 1,
            Left =  new BinaryTree
            {
                Value = 2,
                Left = null,
                Right = null
            },
            Right = new BinaryTree
            {
                Value = 2,
                Left = null,
                Right = null
            }
        };
        IList<IList<int>> result = PathSum.GetOptionsRecursive(bt, 3);
        Assert.Equal(2, result.Count);
    }
    
    [Fact]
    public void PathSum_Success_2()
    {
        BinaryTree bt = new()
        {
            Value = 1,
            Left =  new BinaryTree
            {
                Value = 2,
                Left = null,
                Right = null
            },
            Right = new BinaryTree
            {
                Value = 2,
                Left = null,
                Right = null
            }
        };
        IList<IList<int>> result = PathSum.GetOptionsDFS(bt, 3);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void TreeTraversal_Success()
    {
        BinaryTree grandchildLeft = new()
        {
            Value = 15
        };
        BinaryTree grandchildRight = new()
        {
            Value = 18
        };
        BinaryTree firstChild = new()
        {
            Value = 10,
            Left = grandchildLeft,
            Right = grandchildRight
        };

        BinaryTree secondChild = new()
        {
            Value = 20
        };
        BinaryTree parent = new()
        {
            Value = 30,
            Left = firstChild,
            Right = secondChild
        };
        TreeTraversal.DfsRecursive(parent);
        TreeTraversal.DfsIterative(parent);
        TreeTraversal.BfsIterative(parent);
    }

    [Fact]
    public void FloodFill_Success()
    {
        int[][] filledImage = FloodFill.Run(new[]
        {
            new[] {1, 1, 1},
            new[] {1, 1, 0},
            new[] {1, 0, 1}
        }, 1, 1, 2);
        Assert.Equal(2, filledImage[0][0]);
    }

    [Fact]
    public void RottingOranges_Success()
    {
        int filledImage = RottingOranges.Run(new[]
        {
            new[] {2, 1, 1},
            new[] {1, 1, 0},
            new[] {0, 1, 1}
        });
        Assert.Equal(4, filledImage);
    }

    [Fact]
    public void IslandPerimeter_Success_1()
    {
        int perimeter = IslandPerimeter.Run(new[]
        {
            new[] {0, 1, 0, 0},
            new[] {1, 1, 1, 0},
            new[] {0, 1, 0, 0},
            new[] {1, 1, 0, 0}
        });
        Assert.Equal(16, perimeter);
    }

    [Fact]
    public void IslandPerimeter_Success_2()
    {
        int perimeter = IslandPerimeter.Run(new[]
        {
            new[] {1, 1},
            new[] {1, 1}
        });
        Assert.Equal(8, perimeter);
    }

    [Fact]
    public void CourseSchedule_Success()
    {
        bool res = CourseSchedule.CanFinish(3, new[]
        {
            new[] {0, 1},
            new[] {1, 2}
        });
        Assert.True(res);
        res = CourseSchedule.CanFinish(2, new[]
        {
            new[] {0, 1},
            new[] {1, 0}
        });
        Assert.False(res);
    }

    [Fact]
    public void CourseSchedule_Success_2()
    {
        bool res = CourseSchedule.CanFinish(2, new[]
        {
            new[] {1, 0}
        });
        Assert.True(res);
    }

    [Fact]
    public void RoomVisitor_Success_1()
    {
        List<IList<int>> rooms = new()
        {
            new List<int> {1},
            new List<int> {2},
            new List<int> {3},
            new List<int> {0}
        };
        bool res = RoomVisitor.Check(rooms);
        Assert.True(res);
    }

    [Fact]
    public void RoomVisitor_Success_2()
    {
        List<IList<int>> rooms = new()
        {
            new List<int> {1, 3},
            new List<int> {3, 0, 1},
            new List<int> {2},
            new List<int> {0}
        };
        bool res = RoomVisitor.Check(rooms);
        Assert.False(res);
    }

    [Fact]
    public void InfectionSequences_Success()
    {
        int count = InfectionSequences.GetCount(6, new[] {3, 5});
        Assert.Equal(6, count);
    }

    [Fact]
    public void FlightDependencies_Success()
    {
        List<int> count = FlightDependencies.CountDelayedFlights(4,
            new List<int> {4, 3},
            new List<int> {1, 2},
            new List<int> {1, 3});
        Assert.Equal(new List<int> {1, 3, 4}, count);
    }
}
