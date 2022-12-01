using System;
using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day1;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day1;

public class CalorieCountingTests
{
    private List<string> _input;
    
    [SetUp]
    public void Setup()
    {
        _input = new List<string>
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };
    }

    [Test]
    public void CountCalories_CalculatesHighestElf()
    {
        const int expectedMostCalories = 24000;
        var result = CalorieCounting.CountCalories(_input);

        Assert.AreEqual(expectedMostCalories, result.First());
    }

    [Test]
    public void CountCalories_Part1()
    {
        var textFileLoader = new TextFileLoader();
        var testData = textFileLoader.LoadStringListFromStrings("TestData\\CalorieCounting.txt");
        
        var result = CalorieCounting.CountCalories(testData);
        Console.WriteLine(result.First());
    }
    
    [Test]
    public void CountCalories_Part2()
    {
        var textFileLoader = new TextFileLoader();
        var testData = textFileLoader.LoadStringListFromStrings("TestData\\CalorieCounting.txt");
        
        var result = CalorieCounting.CountCalories(testData);
        Console.WriteLine(result.Take(3).Sum());
    }
}