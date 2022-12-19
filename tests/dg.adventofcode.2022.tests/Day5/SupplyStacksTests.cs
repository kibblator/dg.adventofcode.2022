using System;
using System.Collections.Generic;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day5;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day5;

public class SupplyStacksTests
{
    [Test]
    public void Part1_Example()
    {
        var input = new List<string>
        {
            "    [D]",   
            "[N] [C]",  
            "[Z] [M] [P]",
            "1   2   3", 
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };

        const string expectedResult = "CMZ";
        var result = SupplyStacks.GetTopCrates(input);
        
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Part1()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\SupplyStacks.txt");
        
        var result = SupplyStacks.GetTopCrates(input);
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2_Example()
    {
        const string expectedResult = "MCD";
        var input = new List<string>
        {
            "    [D]",   
            "[N] [C]",  
            "[Z] [M] [P]",
            "1   2   3", 
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };
        
        var result = SupplyStacks.GetTopCrates(input, true);
        Assert.AreEqual(expectedResult, result);
    }
    
    [Test]
    public void Part2()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\SupplyStacks.txt");
        
        var result = SupplyStacks.GetTopCrates(input, true);
        Console.WriteLine(result);
    }
}