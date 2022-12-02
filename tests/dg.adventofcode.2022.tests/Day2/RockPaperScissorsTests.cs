using System;
using System.Collections.Generic;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day2;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day2;

public class RockPaperScissorsTests
{
    private List<string> _input;
    
    [SetUp]
    public void Setup()
    {
        _input = new List<string>
        {
            "A Y",
            "B X",
            "C Z"
        };
    }

    [Test]
    public void RockPaperScissors_Part1Example()
    {
        const int expectedScore = 15;
        var result = RockPaperScissors.CalcStratScore(_input);

        Assert.AreEqual(expectedScore, result);
    }
    
    [Test]
    public void RockPaperScissors_Part2Example()
    {
        const int expectedScore = 12;
        var result = RockPaperScissors.CalcStratScorePart2(_input);

        Assert.AreEqual(expectedScore, result);
    }

    [Test]
    public void RockPaperScissors_Part1()
    {
        var textFileLoader = new TextFileLoader();
        var testData = textFileLoader.LoadStringListFromStrings("TestData\\RockPaperScissors.txt");
        
        var result = RockPaperScissors.CalcStratScore(testData);
        Console.WriteLine(result);
    }
    
    [Test]
    public void RockPaperScissors_Part2()
    {
        var textFileLoader = new TextFileLoader();
        var testData = textFileLoader.LoadStringListFromStrings("TestData\\RockPaperScissors.txt");
        
        var result = RockPaperScissors.CalcStratScorePart2(testData);
        Console.WriteLine(result);
    }
}