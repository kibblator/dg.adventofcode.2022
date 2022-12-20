using System;
using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2022.Day7.Models;

namespace dg.adventofcode._2022.Day7;

public static class NoSpace
{
    public static long GetDirectorySizeSum(List<string> input)
    {
        var systemStructure = ParseSystemStructure(input);

        long initalSize = 0;
        var result = SumDirectoriesWithSizeLimit(systemStructure, 100000, ref initalSize);
        
        return result;
    }

    public static long GetMinimumDeletableDirSize(List<string> input)
    {
        const long hddSize = 70000000;
        const long requiredUpdateSize = 30000000;
        
        var systemStructure = ParseSystemStructure(input);
        var freeSpace = hddSize - systemStructure.GetDirectorySize();
        var requiredDeletionSize = requiredUpdateSize - freeSpace;

        var matchingDirectorySizes = new List<long>();
        GetDirectoryOfRequiredSize(systemStructure, requiredDeletionSize, matchingDirectorySizes);
        
        return matchingDirectorySizes.Min();
    }

    private static void GetDirectoryOfRequiredSize(SystemDirectory systemStructure, long requiredSize, ICollection<long> matchingDirectorySizes)
    {
        foreach (var directory in systemStructure.Directories)
        {
            var directorySize = directory.GetDirectorySize();
            if (directorySize > requiredSize)
            {
                matchingDirectorySizes.Add(directorySize);
            }
            GetDirectoryOfRequiredSize(directory, requiredSize, matchingDirectorySizes);
        }
    }

    private static long SumDirectoriesWithSizeLimit(SystemDirectory systemStructure, long maxSize, ref long sumSize)
    {
        foreach (var directory in systemStructure.Directories)
        {
            var directorySize = directory.GetDirectorySize();
            if (directorySize <= maxSize)
            {
                sumSize += directorySize;
            }
            SumDirectoriesWithSizeLimit(directory, maxSize, ref sumSize);
        }

        return sumSize;
    }

    private static SystemDirectory ParseSystemStructure(List<string> input)
    {
        var systemStructure = new SystemDirectory
        {
            Name = "/"
        };

        input = input.Skip(1).ToList();
        var activeDirectory = systemStructure;
        
        foreach (var line in input)
        {
            if (line.StartsWith("$"))
            {
                var command = GetCommand(line);
                switch (command)
                {
                    case Command.ChangeDirectory:
                    {
                        var directoryCommand = line.Split("$ cd ")[1].Trim();
                        activeDirectory = directoryCommand == ".."
                            ? activeDirectory.ParentDirectory
                            : SystemDirectory.FindDirectory(activeDirectory, directoryCommand);
                        break;
                    }
                    case Command.List:
                    default:
                        break;
                }
            }
            else
            {
                var fileParts = line.Split(' ');

                if (fileParts[0] == "dir")
                {
                    AddNewDirectory(fileParts, activeDirectory);
                }
                else
                {
                    AddNewFile(fileParts, activeDirectory);
                }
            }
        }

        return systemStructure;
    }

    private static void AddNewFile(string[] fileParts, SystemDirectory activeDirectory)
    {
        var newFile = new SystemFile
        {
            Name = fileParts[1],
            Size = Convert.ToInt64(fileParts[0])
        };
        activeDirectory.Files.Add(newFile);
    }

    private static void AddNewDirectory(string[] fileParts, SystemDirectory activeDirectory)
    {
        var newDirectory = new SystemDirectory
        {
            Name = fileParts[1],
            ParentDirectory = activeDirectory
        };
        activeDirectory.Directories.Add(newDirectory);
    }

    private static Command GetCommand(string line)
    {
        return line.StartsWith("$ cd") ? Command.ChangeDirectory : Command.List;
    }
}