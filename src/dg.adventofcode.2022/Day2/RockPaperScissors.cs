using System;
using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day2;

public static class RockPaperScissors
{
    private static readonly List<RpsValue> RpsValues = new()
    {
        new RpsValue
        {
            Key = "Rock",
            Values = new List<string>
            {
                "A",
                "X"
            },
            Score = 1
        },
        new RpsValue
        {
            Key = "Paper",
            Values = new List<string>
            {
                "B",
                "Y"
            },
            Score = 2
        },
        new RpsValue
        {
            Key = "Scissors",
            Values = new List<string>
            {
                "C",
                "Z"
            },
            Score = 3
        },
    };

    private const int LosePoints = 0;
    private const int DrawPoints = 3;
    private const int WinPoints = 6;

    public static int CalcStratScore(List<string> input)
    {
        var combinedScore = 0;
        foreach (var play in input)
        {
            var players = play.Split(' ');
            var opponentPlayed = RpsValues.First(rp => rp.Values.Contains(players[0]));
            var playerPlayed = RpsValues.First(rp => rp.Values.Contains(players[1]));
            
            var result = GameResult(opponentPlayed.Key, playerPlayed.Key);
            combinedScore += CalcScore(result, playerPlayed);
        }
        return combinedScore;
    }

    private static string GameResult(string opponent, string player)
    {
        if (opponent == player)
            return "Draw";

        return opponent switch
        {
            "Rock" when player == "Paper" => "Win",
            "Rock" => "Lose",
            "Paper" when player == "Scissors" => "Win",
            "Paper" => "Lose",
            _ => player == "Rock" ? "Win" : "Lose"
        };
    }

    private static int CalcScore(string result, RpsValue playerInput)
    {
        return result switch
        {
            "Win" => WinPoints + playerInput.Score,
            "Draw" => DrawPoints + playerInput.Score,
            "Lose" => LosePoints + playerInput.Score,
            _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
        };
    }
}

public class RpsValue
{
    public string Key { get; set; }
    public List<string> Values { get; set; }
    public int Score { get; set; }
}