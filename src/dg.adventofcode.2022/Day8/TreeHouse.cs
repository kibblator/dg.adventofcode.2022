using System;
using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day8;

public static class TreeHouse
{
    public static int GetVisibleTrees(List<string> input)
    {
        var width = input.First().Length;
        var length = input.Count;
        var outsideTrees = width * 2 + length * 2 - 4;

        var matrix = new int[width, length];
        PopulateMatrix(matrix, input);
        
        var visibleTrees = outsideTrees;
        
        for (var i = 1; i < width - 1; i++)
        {
            for (var j = 1; j < length - 1; j++)
            {
                var treeValue = matrix[j, i];
                if (CheckVisibility(treeValue, matrix, width, length, i, j, CheckDir.Up) 
                    || CheckVisibility(treeValue, matrix, width, length, i, j, CheckDir.Down) 
                    || CheckVisibility(treeValue, matrix, width, length, i, j, CheckDir.Left) 
                    || CheckVisibility(treeValue, matrix, width, length, i, j, CheckDir.Right))
                {
                    visibleTrees++;
                }
            }
        }
        
        return visibleTrees;
    }

    public static double GetBestScenicScore(List<string> input)
    {
        return 0;
    }

    private static void PopulateMatrix(int[,] matrix, List<string> input)
    {
        for (var i = 0; i < input.First().Length; i++)
        {
            for (var j = 0; j < input.Count; j++)
            {
                matrix[j, i] = Convert.ToInt32(input[j][i].ToString());
            }
        }
    }

    private static bool CheckVisibility(int treeValue, int[,] matrix, int width, int length, int i, int j, CheckDir checkDir)
    {
        switch (checkDir)
        {
            case CheckDir.Up:
                j--;
                while (j >= 0)
                {
                    if (treeValue <= matrix[j, i])
                        return false;
                    j--;
                }
                return true;
            case CheckDir.Down:
                j++;
                while (j < length)
                {
                    if (treeValue <= matrix[j, i])
                        return false;
                    j++;
                }
                return true;
            case CheckDir.Left:
                i--;
                while (i >= 0)
                {
                    if (treeValue <= matrix[j, i])
                        return false;
                    i--;
                }
                return true;
            case CheckDir.Right:
                i++;
                while (i < width)
                {
                    if (treeValue <= matrix[j, i])
                        return false;
                    i++;
                }
                return true;
            default:
                throw new ArgumentOutOfRangeException(nameof(checkDir), checkDir, null);
        }
    }
}

internal enum CheckDir
{
    Up = 1,
    Down = 2,
    Left = 3,
    Right = 4
}