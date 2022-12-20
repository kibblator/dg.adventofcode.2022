using System;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day6;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day6;

public class TuningTroubleTests
{
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1_Example(string input, int expectedResult)
    {
        var result = TuningTrouble.GetFirstMarker(input);
        
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Part1()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadString("TestData\\TuningTrouble.txt");
        
        var result = TuningTrouble.GetFirstMarker(input);
        Console.WriteLine(result);
    }
    
    // [Test]
    // public void Part2_Example()
    // {
    //     const string expectedResult = "MCD";
    //     var input = new List<string>
    //     {
    //         "    [D]",   
    //         "[N] [C]",  
    //         "[Z] [M] [P]",
    //         "1   2   3", 
    //         "",
    //         "move 1 from 2 to 1",
    //         "move 3 from 1 to 3",
    //         "move 2 from 2 to 1",
    //         "move 1 from 1 to 2"
    //     };
    //     
    //     var result = SupplyStacks.GetTopCrates(input, true);
    //     Assert.AreEqual(expectedResult, result);
    // }
    //
    // [Test]
    // public void Part2()
    // {
    //     var textFileLoader = new TextFileLoader();
    //     var input = textFileLoader.LoadStringListFromStrings("TestData\\SupplyStacks.txt");
    //     
    //     var result = SupplyStacks.GetTopCrates(input, true);
    //     Console.WriteLine(result);
    // }
}