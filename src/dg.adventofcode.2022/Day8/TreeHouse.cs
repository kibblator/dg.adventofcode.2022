using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

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
        var width = input.First().Length;
        var length = input.Count;

        var matrix = new int[width, length];
        PopulateMatrix(matrix, input);

        var scenicScoreList = new List<ScenicScore>();
        
        for (var i = 1; i < width - 1; i++)
        {
            for (var j = 1; j < length - 1; j++)
            {
                var treeValue = matrix[j, i];
                var scenicScore = new ScenicScore
                {
                    DownScore = GatherScenicScore(treeValue, matrix, width, length, i, j, CheckDir.Down),
                    LeftScore = GatherScenicScore(treeValue, matrix, width, length, i, j, CheckDir.Left),
                    UpScore = GatherScenicScore(treeValue, matrix, width, length, i, j, CheckDir.Up),
                    RightScore = GatherScenicScore(treeValue, matrix, width, length, i, j, CheckDir.Right)
                };
                scenicScoreList.Add(scenicScore);
            }
        }
        
        return scenicScoreList.Max(s => s.TotalScore());
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
    
    private static double GatherScenicScore(int treeValue, int[,] matrix, int width, int length, int i, int j, CheckDir checkDir)
    {
        var counter = 0;
        switch (checkDir)
        {
            case CheckDir.Up:
                j--;
                while (j >= 0)
                {
                    if (treeValue <= matrix[j, i])
                    {
                        counter++;
                        return counter;
                    }

                    counter++;
                    j--;
                }

                return counter;
            case CheckDir.Down:
                j++;
                while (j < length)
                {
                    if (treeValue <= matrix[j, i])
                    {
                        counter++;
                        return counter;
                    }
                    counter++;
                    j++;
                }
                return counter;
            case CheckDir.Left:
                i--;
                while (i >= 0)
                {
                    if (treeValue <= matrix[j, i])
                    {
                        counter++;
                        return counter;
                    }
                    counter++;
                    i--;
                }
                return counter;
            case CheckDir.Right:
                i++;
                while (i < width)
                {
                    if (treeValue <= matrix[j, i])
                    {
                        counter++;
                        return counter;
                    }
                    counter++;
                    i++;
                }
                return counter;
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

internal class ScenicScore
{
    public double UpScore { get; set; }
    public double DownScore { get; set; }
    public double LeftScore { get; set; }
    public double RightScore { get; set; }

    public double TotalScore()
    {
        return UpScore * LeftScore * RightScore * DownScore;
    }
}