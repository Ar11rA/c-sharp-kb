using System;
using System.Collections.Generic;
using QuoteFetcher.Services.DPRecursion;
using QuoteFetcher.Services.Tree;
using Xunit;

namespace Tests;

public class DpRecursionTests
{
    [Fact]
    public void JumpGame_Success()
    {
        bool canJump = JumpGame.CanJump(new List<int> {2, 3, 1, 1, 4});
        int jumps = JumpGame.CountMinJumps(new List<int> {2, 3, 1, 1, 4});
        Assert.True(canJump);
        Assert.Equal(2, jumps);
    }

    [Fact]
    public void JumpGame_Failure()
    {
        bool canJump = JumpGame.CanJump(new List<int> {3, 2, 1, 0, 4});
        int jumps = JumpGame.CountMinJumps(new List<int> {3, 2, 1, 0, 4});
        Assert.False(canJump);
        Assert.Equal(-1, jumps);
    }

    [Fact]
    public void Climb_Success()
    {
        int jumps = Stairs.Climb(3);
        Assert.Equal(3, jumps);
    }

    [Fact]
    public void Tribonacci_Success()
    {
        int result = Stairs.Tribonacci(3);
        Assert.Equal(2, result);
    }

    [Fact]
    public void MinCost_Success()
    {
        int result = Stairs.MinCost(new List<int> {10, 15, 20});
        Assert.Equal(15, result);
    }

    [Fact]
    public void LetterCombinationsPhone_Success()
    {
        List<string> result = LetterCombinationsPhone.FindCombinations("23");
        Assert.Equal(new List<string>
        {
            "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
        }, result);
    }

    [Fact]
    public void LetterCombinationsPhoneLinq_Success()
    {
        List<string> result = LetterCombinationsPhone.FindCombinationsLinq("23");
        Assert.Equal(new List<string>
        {
            "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
        }, result);
    }

    [Fact]
    public void UniquePaths_Success_1()
    {
        int result = UniquePaths.CalculateWithoutObstacle(7, 3);
        Assert.Equal(28, result);
    }

    [Fact]
    public void UniquePaths_Success_2()
    {
        int result = UniquePaths.CalculateWithObstacles(new int[][]
        {
            new[] {0, 0, 0},
            new[] {0, 1, 0},
            new[] {0, 0, 0}
        });
        Assert.Equal(2, result);

        result = UniquePaths.CalculateWithObstacles(new int[][]
        {
            new[] {1, 0},
        });
        Assert.Equal(0, result);
    }


    [Fact]
    public void MaximalSquare_Success()
    {
        int result = MaximalSquare.Calculate(new[]
        {
            new[] {'1', '0', '1', '0', '1'},
            new[] {'1', '0', '1', '1', '1'},
            new[] {'1', '1', '1', '1', '1'},
            new[] {'1', '0', '0', '1', '0'},
        });
        Assert.Equal(4, result);
        result = MaximalSquare.Calculate(new[]
        {
            new[] {'0', '1'}
        });
        Assert.Equal(1, result);
    }

    [Fact]
    public void AllPaths_Success_1()
    {
        IList<IList<int>> result = AllPaths.Run(new[]
        {
            new[] {1, 2},
            new[] {3},
            new[] {3},
            Array.Empty<int>()
        });
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void AllPaths_Success_2()
    {
        IList<IList<int>> result = AllPaths.Run(new[]
        {
            new[] {2},
            Array.Empty<int>(),
            new[] {1}
        });
        Assert.Equal(1, result.Count);
    }

    [Fact]
    public void MinimumPathSum_Success_1()
    {
        int result = MinimumPathSum.Run(new[]
        {
            new[] {1, 3, 1},
            new[] {1, 5, 1},
            new[] {4, 2, 1}
        });
        Assert.Equal(7, result);
    }

    [Fact]
    public void MinimumPathSum_Success_2()
    {
        int result = MinimumPathSum.Run(new[]
        {
            new[] {1, 2},
            new[] {5, 6},
            new[] {1, 1}
        });
        Assert.Equal(8, result);
    }

    [Fact]
    public void DecodeWays_Success()
    {
        int result = DecodeWays.RunRecursive("126");
        Assert.Equal(3, result);
        result = DecodeWays.RunDP("126");
        Assert.Equal(3, result);
        result = DecodeWays.RunRecursive("1221");
        Assert.Equal(5, result);
        result = DecodeWays.RunDP("1221");
        Assert.Equal(5, result);
    }

    [Fact]
    public void HouseRobber_Success_1()
    {
        int result = HouseRobber.RobRecursive(new[] {1, 2, 3, 1});
        Assert.Equal(4, result);
        result = HouseRobber.RobRecursive(new[] {2, 7, 9, 3, 1});
        Assert.Equal(12, result);
    }

    [Fact]
    public void HouseRobber_Success_2()
    {
        int result = HouseRobber.RobDP(new[] {1, 2, 3, 1});
        Assert.Equal(4, result);
        result = HouseRobber.RobDP(new[] {2, 7, 9, 3, 1});
        Assert.Equal(12, result);
    }

    [Fact]
    public void HouseRobber_Success_3()
    {
        int result = HouseRobber.RobDPCircle(new[] {2, 3, 2});
        Assert.Equal(3, result);
        result = HouseRobber.RobDPCircle(new[] {2, 7, 9, 3, 1});
        Assert.Equal(11, result);
        result = HouseRobber.RobDPCircle(new[] {1, 2, 1, 1});
        Assert.Equal(3, result);
        result = HouseRobber.RobDPCircle(new[] {2, 1, 1, 2});
        Assert.Equal(3, result);
    }

    [Fact]
    public void CoinGame_Success()
    {
        int result = CoinGame.Calculate(new[] {1, 2, 5}, 11);
        Assert.Equal(3, result);
        result = CoinGame.Calculate(new[] {2}, 3);
        Assert.Equal(-1, result);
        result = CoinGame.Calculate(new[] {1}, 0);
        Assert.Equal(0, result);
        result = CoinGame.Calculate(new[] {2, 5, 10, 1}, 27);
        Assert.Equal(4, result);
        // failing case
        result = CoinGame.Calculate(new[] {186, 419, 83, 408}, 6249);
        Assert.Equal(-1, result);
    }
    
    [Fact]
    public void CoinGame_SuccessDP()
    {
        int result = CoinGame.CalculateDP(new[] {1, 2, 5}, 11);
        Assert.Equal(3, result);
        result = CoinGame.CalculateDP(new[] {2}, 3);
        Assert.Equal(-1, result);
        result = CoinGame.CalculateDP(new[] {1}, 0);
        Assert.Equal(0, result);
        result = CoinGame.CalculateDP(new[] {2, 5, 10, 1}, 27);
        Assert.Equal(4, result);
        result = CoinGame.CalculateDP(new[] {186, 419, 83, 408}, 6249);
        Assert.Equal(20, result);
    }

    [Fact]
    public void Triangle_Success_1()
    {
        List<IList<int>> triangle = new()
        {
            new List<int> {2},
            new List<int> {3, 4},
            new List<int> {6, 5, 7},
            new List<int> {4, 1, 8, 3}
        };
        int result = Triangle.MinimumTotal(triangle);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Triangle_Success_2()
    {
        List<IList<int>> triangle = new()
        {
            new List<int> {-1},
            new List<int> {2, 3},
            new List<int> {1, -1, -3}
        };
        int result = Triangle.MinimumTotal(triangle);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Triangle_Success_3()
    {
        List<IList<int>> triangle = new()
        {
            new List<int> {2},
            new List<int> {3, 4},
            new List<int> {6, 5, 7},
            new List<int> {4, 1, 8, 3}
        };
        int result = Triangle.MinimumTotalRecursive(triangle);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Triangle_Success_4()
    {
        List<IList<int>> triangle = new()
        {
            new List<int> {-1},
            new List<int> {2, 3},
            new List<int> {1, -1, -3}
        };
        int result = Triangle.MinimumTotalRecursive(triangle);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void MaxPathSum_Success_1()
    {
        List<List<int>> board = new()
        {
            new List<int> {1, 2, 3, 4},
            new List<int> {5, 6, 7, 8},
            new List<int> {9, 10, 15, 12}
        };
        int result = MaxPathSum.Run(board, 2, 2);
        Assert.Equal(27, result);
    }

    [Fact]
    public void MaxPathSum_Success_2()
    {
        List<List<int>> board = new()
        {
            new List<int> {9, 4, 7},
            new List<int> {2, 1, 3},
            new List<int> {1, 4, 2}
        };
        int result = MaxPathSum.Run(board, 2, 1);
        Assert.Equal(15, result);
    }
}
