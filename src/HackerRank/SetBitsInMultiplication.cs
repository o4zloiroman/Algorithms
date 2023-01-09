namespace Algorithms.HackerRank;

/// <summary>
/// For Sonar
/// </summary>
public class SetBitsInMultiplication
{
    public int NumberOfSetBits(int[] values)
    {
        long a = values[0];
        long b = values[1];

        var mult = a * b;
        var bitString = Convert.ToString(mult, 2);
        var result = bitString.Count(x => x == '1');
        
        return result;
    }

    [Theory]
    [InlineData(new [] {100000000, 100000000}, 20)]
    public void Solution(int[] values, int expected)
    {
        var answer = NumberOfSetBits(values);
        Assert.Equal(expected, answer);
    }
}