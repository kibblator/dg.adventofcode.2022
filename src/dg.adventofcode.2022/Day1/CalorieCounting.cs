using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day1;

public class CalorieCounting
{
    public static IEnumerable<int> CountCalories(List<string> input)
    {
        var currentCalories = 0;
        var caloriesList = new List<int>();
        
        foreach (var item in input)
        {
            if (!string.IsNullOrEmpty(item))
            {
                currentCalories += int.Parse(item);
            }
            else
            {
                caloriesList.Add(currentCalories);
                currentCalories = 0;
            }
        }
        
        return caloriesList.OrderByDescending(c => c);
    }
}