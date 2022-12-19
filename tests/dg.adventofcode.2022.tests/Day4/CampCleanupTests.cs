using System;
using System.Collections.Generic;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day4;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day4;

public class CampCleanupTests
{
    [Test]
    public void Part_Example()
    {
        var input = new List<string>
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };

        const int expectedResult = 2;
        var result = CampCleanup.GetContainingRanges(input);
        
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Part1()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\CampCleanup.txt");
        
        var result = CampCleanup.GetContainingRanges(input);
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2_Example()
    {
        var expectedResult = 4;
        var input = new List<string>
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };
        
        var result = CampCleanup.GetOverlappingRanges(input);
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    public void Part2()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\CampCleanup.txt");
        
        var result = CampCleanup.GetOverlappingRanges(input);
        Console.WriteLine(result);
    }
}