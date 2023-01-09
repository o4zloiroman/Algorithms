namespace Algorithms.LeetCode;

/// <summary>
/// https://leetcode.com/problems/substring-with-concatenation-of-all-words/
/// </summary>
public class SubstringWithConcatenation
{
    public static IList<int> FindSubstring(string s, string[] words) {
        var result = new List<int>();

        var wordsCount = words.Length;
        var wordsLength = words.First().Length;
        var concLength = wordsCount * wordsLength;

        if(concLength > s.Length) return result;

        var i = 0;
        while(i <= s.Length - concLength) {
            var dict = s
                .Substring(i, concLength)
                .Chunk(wordsLength)
                .Select(x => new string(x))
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            foreach(var word in words) {
                if(dict.ContainsKey(word)) {
                    dict[word]--;
                }
                else {
                    break;
                }
            }

            if(dict.Values.All(x => x == 0)) result.Add(i);
            i++;
        }

        return result;
    }
    
    [Theory]
    [InlineData("barfoothefoobarman", new[] {"foo", "bar"}, 
        0,9)]
    [InlineData("wordgoodgoodgoodbestword", new[] {"word","good","best","word"})]
    [InlineData("barfoofoobarthefoobarman", new[] {"bar","foo", "the"}, 
        6,9,12)]
    [InlineData("wordgoodgoodgoodbestword", new[] {"word","good","best","good"}, 
        8)]
    public void Solution(string s, string[] words, params int[] expected)
    {
        var actual = FindSubstring(s, words);
        Assert.Equal(expected, actual);
    }
}