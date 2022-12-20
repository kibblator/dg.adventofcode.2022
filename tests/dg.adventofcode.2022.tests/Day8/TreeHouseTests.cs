using System;
using System.Collections.Generic;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day8;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day8;

public class TreeHouseTests
{
    [Test]
    public void Part1_Example()
    {
        const int expectedResult = 21;
        var input = new List<string>
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };
        
        var result = TreeHouse.GetVisibleTrees(input);
        
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Part1()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\TreeHouse.txt");
        
        var result = TreeHouse.GetVisibleTrees(input);
        Console.WriteLine(result);
    }
    
    // [Test]
    // public void Part2_Example()
    // {
    //     const int expectedResult = 21;
    //     var input = new List<string>
    //     {
    //         "30373",
    //         "25512",
    //         "65332",
    //         "33549",
    //         "35390"
    //     };
    //     var result = TreeHouse.GetVisibleTrees(input);
    //     
    //     Assert.AreEqual(expectedResult, result);
    // }
    //
    // [Test]
    // public void Part2()
    // {
    //     var textFileLoader = new TextFileLoader();
    //     var input = textFileLoader.LoadStringListFromStrings("TestData\\TreeHouse.txt");
    //     
    //     var result = TreeHouse.GetVisibleTrees(input);
    //     Console.WriteLine(result);
    // }
}