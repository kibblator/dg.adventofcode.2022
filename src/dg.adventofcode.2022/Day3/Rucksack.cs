using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day3;

public static class Rucksack
{
    private const int LowercaseCharOffset = 96;
    private const int UpperCaseCharOffset = 38;
    
    public static int GetPrioritySum(List<string> input)
    {
        var sumOfAll = 0;
        foreach (var rucksack in input)
        {
            var halfLength = rucksack.Length / 2;
            var half1 = rucksack.Substring(0, halfLength);
            var half2 = rucksack.Substring(halfLength, halfLength);

            var sharedValues = half1.Intersect(half2).ToList();

            foreach (var sharedValue in sharedValues)
            {
                if (sharedValue.ToString() == sharedValue.ToString().ToLower())
                    sumOfAll += sharedValue - LowercaseCharOffset;
                else
                {
                    sumOfAll += sharedValue - UpperCaseCharOffset;
                }
            }
        }
        
        return sumOfAll;
    }

    public static int GetPriorityGroupsSum(List<string> input)
    {
        var sumOfAll = 0;
        
        for (var i = 0; i <  input.Count; i+=3)
        {
            var group1 = input[i];
            var group2 = input[i + 1];
            var group3 = input[i + 2];

            var sharedValues = group1.Intersect(group2).Intersect(group3).ToList();

            foreach (var sharedValue in sharedValues)
            {
                if (sharedValue.ToString() == sharedValue.ToString().ToLower())
                    sumOfAll += sharedValue - LowercaseCharOffset;
                else
                {
                    sumOfAll += sharedValue - UpperCaseCharOffset;
                }
            }
        }

        return sumOfAll;
    }
}