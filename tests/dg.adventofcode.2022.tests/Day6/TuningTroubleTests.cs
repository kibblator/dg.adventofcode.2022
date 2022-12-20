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
    
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Part2_Example(string input, int expectedResult)
    {
        var result = TuningTrouble.GetMessageMarker(input);
        
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    public void Part2()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadString("TestData\\TuningTrouble.txt");
        
        var result = TuningTrouble.GetMessageMarker(input);
        Console.WriteLine(result);
    }
}