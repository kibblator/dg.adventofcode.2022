using System;
using System.Collections.Generic;
using dg.adventofcode._2022.crosscutting;
using dg.adventofcode._2022.Day7;
using NUnit.Framework;

namespace dg.adventofcode._2022.tests.Day7;

public class NoSpaceTests
{
    [Test]
    public void Part1_Example()
    {
        const long expectedResult = 95437;
        var input = new List<string>
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };
        var result = NoSpace.GetDirectorySizeSum(input);
        
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Part1()
    {
        var textFileLoader = new TextFileLoader();
        var input = textFileLoader.LoadStringListFromStrings("TestData\\NoSpace.txt");
        
        var result = NoSpace.GetDirectorySizeSum(input);
        Console.WriteLine(result);
    }
    
    // [Test]
    // public void Part2_Example()
    // {
    //     const long expectedResult = 95437;
    //     var input = new List<string>
    //     {
    //         "$ cd /",
    //         "$ ls",
    //         "dir a",
    //         "14848514 b.txt",
    //         "8504156 c.dat",
    //         "dir d",
    //         "$ cd a",
    //         "$ ls",
    //         "dir e",
    //         "29116 f",
    //         "2557 g",
    //         "62596 h.lst",
    //         "$ cd e",
    //         "$ ls",
    //         "584 i",
    //         "$ cd ..",
    //         "$ cd ..",
    //         "$ cd d",
    //         "$ ls",
    //         "4060174 j",
    //         "8033020 d.log",
    //         "5626152 d.ext",
    //         "7214296 k"
    //     };
    //     var result = NoSpace.GetDirectorySizeSum(input);
    //     
    //     Assert.AreEqual(expectedResult, result);
    // }
    //
    // [Test]
    // public void Part2()
    // {
    //     var textFileLoader = new TextFileLoader();
    //     var input = textFileLoader.LoadStringListFromStrings("TestData\\NoSpace.txt");
    //     
    //     var result = NoSpace.GetDirectorySizeSum(input);
    //     Console.WriteLine(result);
    // }
}