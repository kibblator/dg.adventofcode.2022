using System;
using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day4;

public static class CampCleanup
{
    public static int GetContainingRanges(List<string> input)
    {
        var groupsOfNote = 0;
        foreach (var line in input)
        {
            var rangeParts = line.Split(',');
            var firstRange = ExtractRangeFromString(rangeParts[0]);
            var secondRange = ExtractRangeFromString(rangeParts[1]);
            var firstGroup = Enumerable.Range(firstRange.startIndex, firstRange.length).ToList();
            var secondGroup = Enumerable.Range(secondRange.startIndex, secondRange.length).ToList();

            if (!firstGroup.Except(secondGroup).Any() || !secondGroup.Except(firstGroup).Any())
                groupsOfNote++;
        }
        
        return groupsOfNote;
    }
    
    public static int GetOverlappingRanges(List<string> input)
    {
        var groupsOfNote = 0;
        foreach (var line in input)
        {
            var rangeParts = line.Split(',');
            var firstRange = ExtractRangeFromString(rangeParts[0]);
            var secondRange = ExtractRangeFromString(rangeParts[1]);
            var firstGroup = Enumerable.Range(firstRange.startIndex, firstRange.length).ToList();
            var secondGroup = Enumerable.Range(secondRange.startIndex, secondRange.length).ToList();

            if (firstGroup.Any(fg => secondGroup.Contains(fg)))
                groupsOfNote++;
        }
        
        return groupsOfNote;
    }

    private static (int startIndex, int length) ExtractRangeFromString(string rangeString)
    {
        var startIndex = Convert.ToInt32(rangeString.Split('-')[0]);
        var length = Convert.ToInt32(rangeString.Split('-')[1]) - startIndex + 1;
        return (startIndex, length);
    }
}