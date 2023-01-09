using System.Text;

namespace Algorithms.LeetCode;

/// <summary>
/// https://leetcode.com/problems/maximum-repeating-substring/description/
/// </summary>
public class MaximumRepeatingSubstring
{
    public int MaxRepeating(string sequence, string word)
    {
        var wordLength = word.Length;
        var sb = new StringBuilder(sequence);
        var max = 0;
        for (var i = 0; i <= sequence.Length - wordLength; i++)
        {
            if (sb.ToString(i, wordLength) == word)
            {
                var count = 1;
                var subLength = i+ wordLength;
                while (subLength + wordLength <= sequence.Length && sb.ToString(subLength, wordLength) == word)
                {
                    count++;
                    subLength += wordLength;
                }

                max = Math.Max(max, count);
            }
        }

        return max;
    }

    [Theory]
    [InlineData("ababc", "ab", 2)]
    [InlineData("ababc", "ba", 1)]
    [InlineData("ababc", "ac", 0)]
    [InlineData("aaabaaaabaaabaaaabaaaabaaaabaaaaba", "aaaba", 5)]
    [InlineData("a", "a", 1)]
    public void Solution(string sequence, string word, int expected)
    {
        var answer = MaxRepeating(sequence, word);
        Assert.Equal(expected, answer);
    }
}