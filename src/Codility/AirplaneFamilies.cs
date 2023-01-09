using System.Text.RegularExpressions;

namespace Algorithms.Codility;

/// <summary>
/// For CoverGo
/// You are processing plane seat reservations. ...
/// </summary>
public class AirplaneFamilies
{
    public int AirplaneTest(int rowsNumber, string reserved)
    {
        if (reserved == string.Empty) return rowsNumber * 2;

        const string ROW_LINE = "ABCDEFGHJK";

        var reservedSplit = reserved
            .Split(' ');

        var dict = new Dictionary<int, List<char>>();
        foreach (var res in reservedSplit)
        {
            var key = int.Parse(Regex.Match(res, @"\d+").Value);
            var val = res.Last();

            if (val is 'A' or 'K') continue;

            if (dict.ContainsKey(key))
            {
                dict[key].Add(val);
            }
            else
            {
                dict[key] = new List<char> { val };
            }
        }

        // Sure hope this isn't a hack, because this seems like a very intuitive solution 
        var possiblePositions = new List<string>
        {
            "BCDE",
            "DEFG",
            "FGHJ"
        };

        var count = 0;
        foreach (var n in Enumerable.Range(1, rowsNumber))
        {
            if (dict.TryGetValue(n, out var chars))
            {
                var line = chars.Aggregate(ROW_LINE, (current, ch) => current.Replace(ch, '*'));

                var rem = 0;
                foreach (var pos in possiblePositions)
                {
                    if (!line.Contains(pos)) rem++;
                }

                var fam = rem <= 2 ? 1 : 0;
                count += fam;
            }
            else
            {
                count += 2;
            }
        }

        return count;
    }

    [Theory]
    [InlineData(2, "1A 2F 1C", 2)]
    [InlineData(1, "", 2)]
    [InlineData(22, "1A 3C 2B 20G 5A", 41)]
    public void Solution(int rowsNumber, string reserved, int expected)
    {
        var answer = AirplaneTest(rowsNumber, reserved);
        Assert.Equal(expected, answer);
    }
}