using System;
using System.Collections.Generic;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day3;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day3;

public class RucksackTests
{
    [Test]
    public void TestData()
    {
        var input = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        const int expectedResult = 157;
        var result = Rucksack.GetPrioritySum(input);
        
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Part1()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\Rucksack.txt");
        
        var result = Rucksack.GetPrioritySum(input);
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2_Example()
    {
        var expectedResult = 70;
        var input = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };
        
        var result = Rucksack.GetPriorityGroupsSum(input);
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    public void Part2()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\Rucksack.txt");
        
        var result = Rucksack.GetPriorityGroupsSum(input);
        Console.WriteLine(result);
    }
}