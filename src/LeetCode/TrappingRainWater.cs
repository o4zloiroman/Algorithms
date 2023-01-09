namespace Algorithms.LeetCode;

/// <summary>
/// https://leetcode.com/problems/trapping-rain-water/
/// </summary>
public class TrappingRainWater
{
    public int Trap(int[] height)
    {
        if (height.Length < 3 || height.ToHashSet().Count == 1) return 0;

        var length = height.Length;
        
        var leftMax = new int[length];
        leftMax[0] = height[0];
        for (var i = 1; i < length; i++)
        {
            leftMax[i] = Math.Max(height[i], leftMax[i - 1]);
        }

        var rightMax = new int[length];
        rightMax[^1] = height[^1];
        for (var i = length - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(height[i], rightMax[i + 1]);
        }

        var water = 0;
        for (var i = 0; i < length; i++)
        {
            water += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }
        
        return water;
    }

    [Theory]
    [InlineData(new []{0,1,0,2,1,0,1,3,2,1,2,1}, 6)]
    [InlineData(new []{4,2,0,3,2,5}, 9)]
    public void Solution(int[] height, int expected)
    {
        var answer = Trap(height);
        Assert.Equal(expected, answer);
    }
}