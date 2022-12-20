using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day6;

public static class TuningTrouble
{
    public static int GetFirstMarker(string input)
    {
        for (var i = 0; i < input.Length; i++)
        {
            var charList = new List<char>
            {
                input[i],
                input[i + 1],
                input[i+2],
                input[i+3]
            };
            if (charList.Distinct().Count() == 4)
                return i+4;
        }
        return 0;
    }
    
    public static int GetMessageMarker(string input)
    {
        for (var i = 0; i < input.Length; i++)
        {
            var charList = new List<char>
            {
                input[i],
                input[i + 1],
                input[i+2],
                input[i+3],
                input[i+4],
                input[i+5],
                input[i+6],
                input[i+7],
                input[i+8],
                input[i+9],
                input[i+10],
                input[i+11],
                input[i+12],
                input[i+13]
            };
            if (charList.Distinct().Count() == 14)
                return i+14;
        }
        return 0;
    }
}